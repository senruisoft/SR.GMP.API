﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SR.GMP.DataEntity.Alarm;
using SR.GMP.DataEntity.DictEnum;
using SR.GMP.DataEntity.System;
using SR.GMP.DataEntity.ViewModel;
using SR.GMP.EFCore;
using SR.GMP.Infrastructure.Repositories;
using SR.GMP.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SR.GMP.WorkerService.WorkerJob
{
    public class AlarmCheckJob : IJob
    {
        private readonly ILogger<AlarmCheckJob> _logger;
        IServiceScopeFactory _serviceScopeFactory;

        public AlarmCheckJob(IServiceScopeFactory _serviceScopeFactory, ILogger<AlarmCheckJob> _logger) 
        {
            this._serviceScopeFactory = _serviceScopeFactory;
            this._logger = _logger;
        }


        public List<Task> init(DateTime lastCheckTime, CancellationToken stoppingToken)
        {
            List<SYS_INST_CENTER> centerList = new List<SYS_INST_CENTER>();
            using var scope = _serviceScopeFactory.CreateScope();
            using (var dbContext = scope.ServiceProvider.GetRequiredService<GMPContext>())
            {
                centerList = dbContext.SYS_INST_CENTER.Where(x => x.STATE == StateEnum.启用).ToList();
            }
            List<Task> tasks = new List<Task>();
            centerList.ForEach(center =>
            {
                tasks.Add(Task.Run(() => 
                {
                    try
                    {
                        Check(center, lastCheckTime);
                    }
                    catch(Exception ex) { _logger.LogError(ex, "Error！"); }
                }, stoppingToken));
            });
            return tasks;
        }

        public void Check(SYS_INST_CENTER center, DateTime LastCheckTime)
        {
            //LastCheckTime = new DateTime(2020,11, 3);
            using var scope = _serviceScopeFactory.CreateScope();
            using (var dbcontext = scope.ServiceProvider.GetRequiredService<GMPContext>())
            {
                // 监测数据项字典
                var monitor_items = new Dictionary<string, string>();
                dbcontext.GMP_MONITOR_ITEM.ToList().ForEach(item =>
                {
                    monitor_items.Add(item.ITEM_CODE, item.ITEM_NAME);
                    monitor_items.Add(item.ITEM_CODE + "_diff", item.ITEM_NAME + "前后差值");
                });
                var event_items = new Dictionary<string, string>();
                dbcontext.GMP_EVENT_ITEM.ToList().ForEach(item =>
                {
                    event_items.Add(item.ITEM_CODE, item.ITEM_NAME);
                });
                List<GMP_ALARM_RECORD> alarmRecordList = new List<GMP_ALARM_RECORD>();
                // 报警配置读取
                var AlarmItems = dbcontext.GMP_ALARM_ITEM.Where(x => x.CENT_ID == center.ID && x.STATE == StateEnum.启用)
                    .Include(x => x.ALARM_ITEM_RULE_LIST).ThenInclude(x => x.ALARM_RULE_CONFIG_LIST).ToList();

                // 获取报警配置的监测数据项目
                List<string> monitorItemList = new List<string>();
                AlarmItems.ForEach(x => monitorItemList.AddRange(x.ALARM_ITEM_RULE_LIST.Where(x => !string.IsNullOrEmpty(x.MONITOR_ITEM_CODE)).Select(x => x.MONITOR_ITEM_CODE)));
                monitorItemList = monitorItemList.Distinct().ToList();

                List<MonitorRecordData> RecordDataList = new List<MonitorRecordData>();
                if (monitorItemList.Count > 0)
                {
                    #region 构造报警配置项目的监测数据集合
                    // 查询监测实时数据
                    var MonitorDataList = dbcontext.Set<MonitorViewData>().Where(x => x.CENT_ID == center.EXT_ID && x.CREATE_AT >= LastCheckTime).ToList();
                    MonitorDataList.GroupBy(x => x.PATIENT_ID).ToList().ForEach(item =>
                    {
                        int count = item.Count();
                        DateTime? end = item.Max(x => x.RECORD_TIME);
                        DateTime? begin = end.HasValue ? end.Value.Date : end;
                        var orgData = item.OrderByDescending(x => x.RECORD_TIME).ToList();
                        // 查询用于计算前后数据差的监测数据
                        var lastData = dbcontext.Set<MonitorViewData>().Where(x => x.CENT_ID == center.EXT_ID && x.PATIENT_ID == item.Key
                                && x.RECORD_TIME < end && x.RECORD_TIME >= begin).OrderByDescending(x => x.RECORD_TIME).Take(count).ToList();
                        for (int i = 0; i < orgData.Count; i++)
                        {
                            Dictionary<string, decimal?> dict = new Dictionary<string, decimal?>();
                            foreach (var monitorItem in monitorItemList)
                            {
                                var orgValue = orgData[i].GetType().GetProperty(monitorItem).GetValue(orgData[i]);
                                dict[monitorItem] = orgValue == null ? default(decimal?) : (decimal)orgValue;
                                // 计算前后差值
                                if (lastData.Count - 1 >= i)
                                {
                                    var lastValue = lastData[i].GetType().GetProperty(monitorItem).GetValue(lastData[i]);
                                    dict[monitorItem + "_diff"] = lastValue == null ? default(decimal?) : dict[monitorItem] - (decimal)lastValue;
                                }
                                else
                                {
                                    dict[monitorItem + "_diff"] = null;
                                }
                            }
                            RecordDataList.Add(new MonitorRecordData
                            {
                                PATIENT_ID = orgData[i].PATIENT_ID,
                                PATIENT_NAME = orgData[i].PATIENT_NAME,
                                PATIENT_SEX = orgData[i].PATIENT_SEX,
                                PATIENT_AGE = orgData[i].PATIENT_AGE,
                                BED_LABEL = orgData[i].BED_LABEL,
                                DOCTOR_NAME = orgData[i].DOCTOR_NAME,
                                NURSE_NAME = orgData[i].NURSE_NAME,
                                RECORD_TIME = orgData[i].RECORD_TIME,
                                CLASS_ID = orgData[i].CLASS_ID,
                                CLASS_NAME = orgData[i].CLASS_NAME,
                                MonitorItems = dict
                            });
                        }
                    });
                    #endregion
                }

                // 是否存在临床事件项目报警配置
                bool hasEventAlarm = AlarmItems.Any(x => x.ALARM_ITEM_RULE_LIST.Where(c => !string.IsNullOrEmpty(c.EVENT_ITEM_CODE)).Count() > 0);
                // 查询临床事件记录
                DateTime nowDate = LastCheckTime.Date;
                DateTime endDate = LastCheckTime.Date.AddDays(1);
                List<EventViewData> EventDataList = !hasEventAlarm ? new List<EventViewData>() :
                    dbcontext.Set<EventViewData>().Where(x => x.CENT_ID == center.EXT_ID && x.CREATE_AT >= nowDate && x.CREATE_AT < endDate).ToList();

                // 遍历报警配置项目
                foreach (var item in AlarmItems)
                {
                    
                    List<MonitorRecordData> recordDataList = new List<MonitorRecordData>();
                    #region 监测数据报警检查
                    if (RecordDataList.Count > 0)
                    {
                        var monitorRule = item.ALARM_ITEM_RULE_LIST.Where(x => x.RULE_TYPE == AlarmRuleEnum.监测数据).OrderBy(x => x.SORT_NUM).ToList();
                        Func<MonitorRecordData, bool> condition = x => true;
                        // 构造报警条件委托
                        monitorRule.ForEach(rule =>
                        {
                            var tempFun = condition;
                            Func<MonitorRecordData, bool> role_condition = x => false;
                            // 遍历项目报警条件
                            rule.ALARM_RULE_CONFIG_LIST.ToList().ForEach(config =>
                            {
                                var tempCondition = role_condition;
                                // 是否比对前后数据差值
                                if (!config.IS_DIFFVALUE)
                                {
                                    role_condition = x =>
                                    {
                                        var logic_result = x.MonitorItems[rule.MONITOR_ITEM_CODE] != null &&
                                         (!config.MIN_VALUE.HasValue || x.MonitorItems[rule.MONITOR_ITEM_CODE] > config.MIN_VALUE
                                         || config.IS_CONTAINMIN && x.MonitorItems[rule.MONITOR_ITEM_CODE] == config.MIN_VALUE) &&
                                         (!config.MAX_VALUE.HasValue || x.MonitorItems[rule.MONITOR_ITEM_CODE] < config.MAX_VALUE
                                         || config.IS_CONTAINMAX && x.MonitorItems[rule.MONITOR_ITEM_CODE] == config.MAX_VALUE);
                                        // 记录报警项
                                        if (logic_result && !x.AlarmItems.Contains(rule.MONITOR_ITEM_CODE))
                                        {
                                            x.AlarmItems.Add(rule.MONITOR_ITEM_CODE);
                                        }
                                        // 记录监控数据项
                                        x.AlarmConfigItems[rule.MONITOR_ITEM_CODE] = x.MonitorItems[rule.MONITOR_ITEM_CODE];
                                        return tempCondition(x) || logic_result;
                                    };
                                }
                                else
                                {
                                    var item_code = rule.MONITOR_ITEM_CODE + "_diff";
                                    role_condition = x =>
                                    {
                                        var logic_result = x.MonitorItems[item_code] != null &&
                                         (!config.MIN_VALUE.HasValue || Math.Abs(x.MonitorItems[item_code].Value) > config.MIN_VALUE
                                         || config.IS_CONTAINMIN && Math.Abs(x.MonitorItems[item_code].Value) == config.MIN_VALUE) &&
                                         (!config.MAX_VALUE.HasValue || Math.Abs(x.MonitorItems[item_code].Value) < config.MAX_VALUE
                                         || config.IS_CONTAINMAX && Math.Abs(x.MonitorItems[item_code].Value) == config.MAX_VALUE);
                                        // 记录报警项
                                        if (logic_result && !x.AlarmItems.Contains(item_code))
                                        {
                                            x.AlarmItems.Add(item_code);
                                        }
                                        // 记录监控数据项
                                        x.AlarmConfigItems[item_code] = x.MonitorItems[item_code];
                                        x.AlarmConfigItems[rule.MONITOR_ITEM_CODE] = x.MonitorItems[rule.MONITOR_ITEM_CODE];
                                        return tempCondition(x) || logic_result;
                                    };
                                }
                            });
                            // 组合逻辑
                            switch (rule.LOGIC_TYPE)
                            {
                                case DataEntity.DictEnum.AlarmLogicEnum.and:
                                    condition = x => tempFun(x) && role_condition(x);
                                    break;
                                case DataEntity.DictEnum.AlarmLogicEnum.or:
                                    condition = x => 
                                    {
                                        var logic_result = role_condition(x);
                                        return tempFun(x) || logic_result;
                                    };
                                    break;
                            }
                        });
                        recordDataList = RecordDataList.Where(x => condition(x)).ToList();
                    }
                    #endregion

                    #region 临床事件报警检查
                    var eventRule = item.ALARM_ITEM_RULE_LIST.Where(x => x.RULE_TYPE == AlarmRuleEnum.临床事件).OrderBy(x => x.SORT_NUM).ToList();
                    if (eventRule.Count > 0)
                    {
                        // 筛选报警的临床事件记录
                        var eventData = EventDataList.Where(x => eventRule.Select(x => x.EVENT_ITEM_CODE).Contains(x.EVENT_CODE)).ToList();
                        if (eventData.Count > 0)
                        {
                            List<GMP_ALARM_RECORD> alarmRecord = new List<GMP_ALARM_RECORD>();
                            // 处理临床事件的报警条件逻辑
                            switch (eventRule[0].LOGIC_TYPE)
                            {
                                case AlarmLogicEnum.and:
                                    #region 与逻辑
                                    alarmRecord = (from monitordata in recordDataList.GroupBy(x => x.PATIENT_ID)
                                                   join eventdata in eventData.GroupBy(x => x.PATIENT_ID)
                                                   on monitordata.Key equals eventdata.Key
                                                   let data = monitordata.First()
                                                   select new GMP_ALARM_RECORD
                                                   {
                                                       ALARM_ITEM_ID = item.ID,
                                                       PATIENT_EXT_ID = monitordata.Key,
                                                       PATIENT_NAME = data.PATIENT_NAME,
                                                       PATIENT_AGE = data.PATIENT_AGE,
                                                       PATIENT_SEX = data.PATIENT_SEX,
                                                       BED_LABEL = data.BED_LABEL,
                                                       DOCTOR_NAME = data.DOCTOR_NAME,
                                                       NURSE_NAME = data.NURSE_NAME,
                                                       ALARM_ITEM_NAME = item.ITEM_NAME,
                                                       PRIORITY = item.PRIORITY,
                                                       CENT_ID = center.ID,
                                                       CLASS_ID = data.CLASS_ID,
                                                       CLASS_NAME = data.CLASS_NAME,
                                                       DATA_RECORD_TIME = monitordata.Select(x => x.RECORD_TIME).Min(),
                                                       ALARM_RECORD_DATA_LIST = data.AlarmConfigItems.Select(x => new GMP_ALARM_RECORD_DATA 
                                                       {
                                                           MONITOR_ITEM_CODE = x.Key,
                                                           MONITOR_ITEM_VALUE = x.Value.ToString(),
                                                           IS_ALARM = data.AlarmItems.Contains(x.Key),
                                                           RULE_TYPE = AlarmRuleEnum.监测数据,
                                                           MONITOR_ITEM_NAME = monitor_items.ContainsKey(x.Key) ? monitor_items[x.Key] : null,
                                                       }).Concat(eventData.Select(x => new GMP_ALARM_RECORD_DATA 
                                                       {
                                                           MONITOR_ITEM_CODE = x.EVENT_CODE,
                                                           IS_ALARM = true,
                                                           RULE_TYPE = AlarmRuleEnum.临床事件,
                                                           MONITOR_ITEM_NAME = event_items.ContainsKey(x.EVENT_CODE) ? event_items[x.EVENT_CODE] : null,
                                                       })).ToArray()
                                                   }).ToList();
                                    #endregion
                                    break;

                                case AlarmLogicEnum.or:
                                    #region 或逻辑
                                    alarmRecord = (from eventdata in eventData.GroupBy(x => x.PATIENT_ID)
                                                   join monitordata in recordDataList.GroupBy(x => x.PATIENT_ID)
                                                   on eventdata.Key equals monitordata.Key into gv
                                                   from gvdata in gv.DefaultIfEmpty()
                                                   where gvdata == null || gvdata.Count() == 0
                                                   let data = eventdata.First()
                                                   let monitor_data = RecordDataList.Where(x => x.PATIENT_ID == eventdata.Key).OrderByDescending(x => x.RECORD_TIME).FirstOrDefault()
                                                   select new GMP_ALARM_RECORD
                                                   {
                                                       ALARM_ITEM_ID = item.ID,
                                                       PATIENT_EXT_ID = eventdata.Key,
                                                       PATIENT_NAME = data.PATIENT_NAME,
                                                       PATIENT_AGE = data.PATIENT_AGE,
                                                       PATIENT_SEX = data.PATIENT_SEX,
                                                       BED_LABEL = data.BED_LABEL,
                                                       DOCTOR_NAME = data.DOCTOR_NAME,
                                                       NURSE_NAME = data.NURSE_NAME,
                                                       ALARM_ITEM_NAME = item.ITEM_NAME,
                                                       PRIORITY = item.PRIORITY,
                                                       CENT_ID = center.ID,
                                                       CLASS_ID = data.CLASS_ID,
                                                       CLASS_NAME = data.CLASS_NAME,
                                                       DATA_RECORD_TIME = eventdata.Select(x => x.RECORD_TIME).Min(),
                                                       ALARM_RECORD_DATA_LIST = eventData.Select(x => new GMP_ALARM_RECORD_DATA
                                                       {
                                                           MONITOR_ITEM_CODE = x.EVENT_CODE,
                                                           IS_ALARM = true,
                                                           RULE_TYPE = AlarmRuleEnum.临床事件,
                                                           MONITOR_ITEM_NAME = event_items.ContainsKey(x.EVENT_CODE) ? event_items[x.EVENT_CODE] : null,
                                                       }).Concat(monitor_data == null ? new GMP_ALARM_RECORD_DATA[0] : monitor_data.AlarmConfigItems.Select(x => new GMP_ALARM_RECORD_DATA 
                                                       {
                                                           MONITOR_ITEM_CODE = x.Key,
                                                           MONITOR_ITEM_VALUE = x.Value.ToString(),
                                                           RULE_TYPE = AlarmRuleEnum.监测数据,
                                                           MONITOR_ITEM_NAME = monitor_items.ContainsKey(x.Key) ? monitor_items[x.Key] : null,
                                                       })).ToArray()
                                                   }).ToList();
                                    #endregion
                                    break;
                            }
                            alarmRecordList.AddRange(alarmRecord);
                        }
                    }
                    #endregion

                    // 临床事件为空或者是次要条件的情况
                    if (eventRule.Count == 0 || eventRule[0].LOGIC_TYPE == AlarmLogicEnum.or)
                    {
                        alarmRecordList.AddRange(recordDataList.GroupBy(x => x.PATIENT_ID).Select(x => new GMP_ALARM_RECORD
                        {
                            ALARM_ITEM_ID = item.ID,
                            PATIENT_EXT_ID = x.Key,
                            PATIENT_NAME = x.First().PATIENT_NAME,
                            PATIENT_AGE = x.First().PATIENT_AGE,
                            PATIENT_SEX = x.First().PATIENT_SEX,
                            BED_LABEL = x.First().BED_LABEL,
                            DOCTOR_NAME = x.First().DOCTOR_NAME,
                            NURSE_NAME = x.First().NURSE_NAME,
                            ALARM_ITEM_NAME = item.ITEM_NAME,
                            PRIORITY = item.PRIORITY,
                            CENT_ID = center.ID,
                            CLASS_ID = x.First().CLASS_ID,
                            CLASS_NAME = x.First().CLASS_NAME,
                            DATA_RECORD_TIME = x.Select(x => x.RECORD_TIME).Min(),
                            ALARM_RECORD_DATA_LIST = x.First().AlarmConfigItems.Select(c => new GMP_ALARM_RECORD_DATA
                            {
                                MONITOR_ITEM_CODE = c.Key,
                                MONITOR_ITEM_VALUE = c.Value.ToString(),
                                IS_ALARM = x.First().AlarmItems.Contains(c.Key),
                                RULE_TYPE = AlarmRuleEnum.监测数据,
                                MONITOR_ITEM_NAME = monitor_items.ContainsKey(c.Key) ? monitor_items[c.Key] : null,
                            }).ToArray()
                        }));
                    }
                }

                if (alarmRecordList.Count > 0)
                {
                    // 过滤重复未处理的报警
                    //DateTime nowDate = LastCheckTime.Date;
                    var recordList = dbcontext.GMP_ALARM_RECORD.Where(x => x.CENT_ID == center.ID && x.CREATE_AT >= nowDate && x.STATE != AlarmStateEnum.已处理).ToList();
                    var InsertRecord = from alarm in alarmRecordList
                                       join record in recordList
                                       on new { alarm.ALARM_ITEM_ID, alarm.PATIENT_EXT_ID } equals new { record.ALARM_ITEM_ID, record.PATIENT_EXT_ID } into list
                                       from data in list.DefaultIfEmpty()
                                       where data == null
                                       select alarm;
                    dbcontext.GMP_ALARM_RECORD.AddRange(InsertRecord);
                    dbcontext.SaveChanges();
                }
            }

            _logger.LogInformation("{name}：check completed", center.NAME);
        }
    }
}
