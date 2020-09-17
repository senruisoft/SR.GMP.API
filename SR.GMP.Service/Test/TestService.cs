using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SR.GMP.Common.Model;
using SR.GMP.DataEntity.Alarm;
using SR.GMP.DataEntity.System;
using SR.GMP.DataEntity.ViewModel;
using SR.GMP.EFCore;
using SR.GMP.Infrastructure.Repositories;
using SR.GMP.Infrastructure.Repositories.Alarm;
using SR.GMP.Infrastructure.UnitOfWork;
using SR.GMP.Service.Contracts.Test;
using SR.GMP.Service.Contracts.Test.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace SR.GMP.Service.Test
{
    public class TestService : ITestService
    {
        IMapper _mapper;
        GMPContext context;

        IUnitOfWork unitOfWork;

        IRepository<GMP_ALARM_ITEM, Guid> repository;

        IRepository<SYS_INST, Guid> repository_sys;

        public TestService(IMapper mapper, GMPContext context, IUnitOfWork unitOfWork,
            IRepository<GMP_ALARM_ITEM, Guid> repository, IRepository<SYS_INST, Guid> repository_sys)
        {
            _mapper = mapper;
            this.context = context;
            this.unitOfWork = unitOfWork;
            this.repository = repository;
            this.repository_sys = repository_sys;
        }

        public string test() 
        {


            var result = unitOfWork.Commit();
            return "OK";
        }


        public string text()
        {
            string cent_code = "0010";
            DateTime date = new DateTime(2020, 6, 15);
            List<GMP_ALARM_RECORD> alarmRecordList = new List<GMP_ALARM_RECORD>();

            // 报警配置读取
            var config = context.GMP_ALARM_ITEM.Where(x => x.CENTER.CODE == cent_code && x.STATE == DataEntity.DictEnum.StateEnum.启用)
                .Include(x => x.ALARM_ITEM_RULE_LIST).ThenInclude(x => x.ALARM_RULE_CONFIG_LIST).ToList();

            // 报警配置的监测数据项目
            List<string> monitorItemList = new List<string>();
            config.ForEach(x => monitorItemList.AddRange(x.ALARM_ITEM_RULE_LIST.Where(x => !string.IsNullOrEmpty(x.MONITOR_ITEM_CODE)).Select(x => x.MONITOR_ITEM_CODE)));
            monitorItemList = monitorItemList.Distinct().ToList();

            List<MonitorRecordData> RecordDataList = new List<MonitorRecordData>();
            if (monitorItemList.Count > 0) 
            {
                var MonitorDataList = context.Set<MonitorViewData>().Where(x => x.CENT_ID == cent_code && x.CREATE_AT >= date).ToList();
                MonitorDataList.GroupBy(x => x.PATIENT_ID).ToList().ForEach(item =>
                {
                    int count = item.Count();
                    DateTime? end = item.Max(x => x.RECORD_TIME);
                    DateTime? begin = end.HasValue ? end.Value.Date : end;
                    var orgData = item.OrderByDescending(x => x.RECORD_TIME).ToList();
                    var lastData = context.Set<MonitorViewData>().Where(x => x.CENT_ID == cent_code && x.PATIENT_ID == item.Key && x.RECORD_TIME < end && x.RECORD_TIME >= begin).OrderByDescending(x => x.RECORD_TIME).Take(count).ToList();

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
                                dict[monitorItem + "_diff"] = lastValue == null ? default(decimal?) : (decimal)lastValue - dict[monitorItem];
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
                            MonitorItems = dict
                        });
                    }
                });
            }

            // 报警配置的临床事件项目
            List<string> eventItemList = new List<string>();
            config.ForEach(x => eventItemList.AddRange(x.ALARM_ITEM_RULE_LIST.Where(x => !string.IsNullOrEmpty(x.EVENT_ITEM_CODE)).Select(x => x.EVENT_ITEM_CODE)));
            List<EventViewData> EventDataList = new List<EventViewData>();
            if (eventItemList.Count > 0) 
            {
                EventDataList = context.Set<EventViewData>().Where(x => x.CENT_ID == cent_code).ToList();
            }

            foreach (var item in config)
            {
                List<MonitorRecordData> recordDataList = new List<MonitorRecordData>();
                #region 监测数据报警检查
                if (RecordDataList.Count > 0)
                {
                    var monitorRule = item.ALARM_ITEM_RULE_LIST.Where(x => x.RULE_TYPE == DataEntity.DictEnum.AlarmRuleEnum.监测数据).OrderBy(x => x.SORT_NUM).ToList();
                    Func<MonitorRecordData, bool> condition = x => true;
                    monitorRule.ForEach(rule =>
                    {
                        var tempFun = condition;
                        Func<MonitorRecordData, bool> role_condition = x => false;
                        rule.ALARM_RULE_CONFIG_LIST.ToList().ForEach(config =>
                        {
                            var tempCondition = role_condition;
                        // 是否比对前后数据差值
                        if (!config.IS_DIFFVALUE)
                            {
                                role_condition = x => tempCondition(x) || x.MonitorItems[rule.MONITOR_ITEM_CODE] != null &&
                                (!config.MIN_VALUE.HasValue || x.MonitorItems[rule.MONITOR_ITEM_CODE] > config.MIN_VALUE || config.IS_CONTAINMIN && x.MonitorItems[rule.MONITOR_ITEM_CODE] == config.MIN_VALUE) &&
                                (!config.MAX_VALUE.HasValue || x.MonitorItems[rule.MONITOR_ITEM_CODE] < config.MAX_VALUE || config.IS_CONTAINMAX && x.MonitorItems[rule.MONITOR_ITEM_CODE] == config.MAX_VALUE);
                            }
                            else
                            {
                                var item_code = rule.MONITOR_ITEM_CODE + "_diff";
                                role_condition = x => tempCondition(x) || x.MonitorItems[item_code] != null &&
                                (!config.MIN_VALUE.HasValue || Math.Abs(x.MonitorItems[item_code].Value) > config.MIN_VALUE || config.IS_CONTAINMIN && Math.Abs(x.MonitorItems[item_code].Value) == config.MIN_VALUE) &&
                                (!config.MAX_VALUE.HasValue || Math.Abs(x.MonitorItems[item_code].Value) < config.MAX_VALUE || config.IS_CONTAINMAX && Math.Abs(x.MonitorItems[item_code].Value) == config.MAX_VALUE);
                            }
                        });

                        switch (rule.LOGIC_TYPE)
                        {
                            case DataEntity.DictEnum.AlarmLogicEnum.and:
                                condition = x => tempFun(x) && role_condition(x);
                                break;
                            case DataEntity.DictEnum.AlarmLogicEnum.or:
                                condition = x => tempFun(x) || role_condition(x);
                                break;
                        }
                    });
                    recordDataList = RecordDataList.Where(x => condition(x)).ToList();
                }
                #endregion

                #region 临床事件报警检查
                var eventRule = item.ALARM_ITEM_RULE_LIST.Where(x => x.RULE_TYPE == DataEntity.DictEnum.AlarmRuleEnum.临床事件).OrderBy(x => x.SORT_NUM).ToList();
                if (eventRule.Count > 0)
                {
                    var eventData = EventDataList.Where(x => eventRule.Select(x => x.EVENT_ITEM_CODE).Contains(x.EVENT_CODE)).ToList();
                    if (eventData.Count > 0) 
                    {
                        List<GMP_ALARM_RECORD> alarmRecord = new List<GMP_ALARM_RECORD>();
                        switch (eventRule[0].LOGIC_TYPE)
                        {
                            case DataEntity.DictEnum.AlarmLogicEnum.and:
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
                                                     CENT_CODE = cent_code,
                                                     DATA_RECORD_TIME = monitordata.Select(x => x.RECORD_TIME).Min(),
                                                     CREATE_AT = DateTime.Now
                                                 }).ToList();
                                break;
                            case DataEntity.DictEnum.AlarmLogicEnum.or:
                                alarmRecord = (from eventdata in eventData.GroupBy(x => x.PATIENT_ID)
                                              join monitordata in recordDataList.GroupBy(x => x.PATIENT_ID)
                                              on eventdata.Key equals monitordata.Key into gv
                                              from gvdata in gv.DefaultIfEmpty()
                                              where gvdata.Count() == 0
                                              let data = eventdata.First()
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
                                                  CENT_CODE = cent_code,
                                                  DATA_RECORD_TIME = eventdata.Select(x => x.RECORD_TIME).Min(),
                                                  CREATE_AT = DateTime.Now
                                              }).ToList();
                                break;
                        }
                        alarmRecordList.AddRange(alarmRecord);
                    }
                }
                #endregion

                if (eventRule.Count == 0 || eventRule[0].LOGIC_TYPE == DataEntity.DictEnum.AlarmLogicEnum.or)
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
                        CENT_CODE = cent_code,
                        DATA_RECORD_TIME = x.Select(x => x.RECORD_TIME).Min(),
                        CREATE_AT = DateTime.Now
                    }));
                }
            }


            if (alarmRecordList.Count > 0)
            {
                // 过滤重复未处理的报警
                DateTime nowDate = DateTime.Now.Date;
                var recordList = context.GMP_ALARM_RECORD.Where(x => x.CREATE_AT >= nowDate && x.STATE != DataEntity.DictEnum.AlarmStateEnum.已处理).ToList();
                var InsertRecord = from alarm in alarmRecordList
                                   join record in recordList
                                   on new { alarm.ALARM_ITEM_ID, alarm.PATIENT_EXT_ID } equals new { record.ALARM_ITEM_ID, record.PATIENT_EXT_ID } into list
                                   from data in list.DefaultIfEmpty()
                                   where data == null
                                   select alarm;
                context.GMP_ALARM_RECORD.AddRange(InsertRecord);
                context.SaveChanges();
            }

            return "ok";
        }

    }
}
