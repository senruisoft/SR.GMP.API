using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SR.GMP.Common.Extensions;
using SR.GMP.DataEntity.Alarm;
using SR.GMP.DataEntity.DictEnum;
using SR.GMP.DataEntity.Dictionary;
using SR.GMP.EFCore;
using SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Infrastructure.Repositories.Alarm
{
    public class AlarmRepository : Repository<GMP_ALARM_ITEM, Guid>, IAlarmRepository
    {
        IMapper _mapper;
        IRepository<GMP_EVENT_ITEM, int> eventItemRepository;
        IRepository<GMP_MONITOR_ITEM, int> monitorItemRepository;

        public AlarmRepository(GMPContext context, IRepository<GMP_EVENT_ITEM, int> eventItemRepository, 
            IRepository<GMP_MONITOR_ITEM, int> monitorItemRepository, IMapper _mapper) : base(context)
        {
            this.eventItemRepository = eventItemRepository;
            this.monitorItemRepository = monitorItemRepository;
            this._mapper = _mapper;
        }

        /// <summary>
        /// 查询监测项字典
        /// </summary>
        /// <returns></returns>
        public AlarmMonitorDic GetMonitorItemDic()
        {
            var monitorDic = monitorItemRepository.GetQueryable(x => x.STATE == StateEnum.启用).OrderBy(x => x.SORT_CODE)
                .Select(x => new MonitorItemDto(x.ITEM_NAME, x.ITEM_CODE)).ToList();

            var eventDic = eventItemRepository.GetQueryable(x => x.STATE == StateEnum.启用).OrderBy(x => x.SORT_CODE)
                .Select(x => new MonitorItemDto(x.ITEM_NAME, x.ITEM_CODE)).ToList();

            return new AlarmMonitorDic { monitorDic = monitorDic, eventDic = eventDic };
        }

        /// <summary>
        /// 获取报警规则信息
        /// </summary>
        /// <param name="cent_id"></param>
        /// <param name="idList"></param>
        /// <param name="containRule"></param>
        /// <returns></returns>
        public List<AlarmItemDto> GetAlarmItemsInfo(Guid cent_id, List<Guid> idList = null, bool containRule = false) 
        {
            List<AlarmItemDto> AlarmRules = new List<AlarmItemDto>();
            // 监测数据项字典
            var monitor_items = new Dictionary<string, string>();
            monitorItemRepository.GetQueryable().ToList().ForEach(item =>
            {
                monitor_items.Add(item.ITEM_CODE, item.ITEM_NAME);
            });
            var event_items = new Dictionary<string, string>();
            eventItemRepository.GetQueryable().ToList().ForEach(item =>
            {
                event_items.Add(item.ITEM_CODE, item.ITEM_NAME);
            });
            Dictionary<Guid, string> itemRules = new Dictionary<Guid, string>();
            var alarms = GetQueryable(x => x.CENT_ID == cent_id && x.STATE != StateEnum.删除).WhereIf(idList != null, x => idList.Contains(x.ID)).Include(x => x.ALARM_ITEM_RULE_LIST).ThenInclude(x => x.ALARM_RULE_CONFIG_LIST).ToList();
            alarms.ForEach(item =>
            {
                string monitorRule = "";
                string eventRule = "";
                var ruleList = item.ALARM_ITEM_RULE_LIST.ToList();
                ruleList.Where(x => x.RULE_TYPE == AlarmRuleEnum.监测数据).OrderBy(x => x.SORT_NUM).ToList().ForEach(r =>
                {
                    var item_name = monitor_items.ContainsKey(r.MONITOR_ITEM_CODE) ? monitor_items[r.MONITOR_ITEM_CODE] : "";
                    var configs = r.ALARM_RULE_CONFIG_LIST.ToList();
                    List<string> item_rules = new List<string>();
                    r.ALARM_RULE_CONFIG_LIST.ToList().ForEach(c =>
                    {
                        string upper = c.MAX_VALUE.HasValue ? (c.IS_CONTAINMAX ? "≤" : "＜") + c.MAX_VALUE : "";
                        string lower = c.MIN_VALUE.HasValue ? c.MIN_VALUE + (c.IS_CONTAINMIN ? "≤" : "＜") : "";
                        string rule = string.Format("{0}{1}{2}", lower, c.IS_DIFFVALUE ? item_name + "前后差值" :  item_name, upper);
                        item_rules.Add(rule);
                    });
                    if (item_rules.Count > 0)
                    {
                        monitorRule += monitorRule == "" ? "【监测数据】" : " " + r.LOGIC_TYPE.ToString() + " ";
                        monitorRule += "（" + string.Join(" or ", item_rules) + "）";
                    }
                });
                //monitorRule += monitorRule != "" ? "）" : "";
                ruleList.Where(x => x.RULE_TYPE == AlarmRuleEnum.临床事件).OrderBy(x => x.SORT_NUM).ToList().ForEach(r =>
                {
                    var item_name = event_items.ContainsKey(r.EVENT_ITEM_CODE) ? event_items[r.EVENT_ITEM_CODE] : "";
                    eventRule += (eventRule == "" ? " " + (monitorRule == "" ? "" : r.LOGIC_TYPE.ToString()) + " 【透析事件】" : " " + r.LOGIC_TYPE.ToString() + " ") + item_name;
                });
                //eventRule += eventRule != "" ? "）" : "";
                itemRules[item.ID] = monitorRule + eventRule;
            });
            if (!containRule) 
            {
                alarms.ForEach(x => x.ALARM_ITEM_RULE_LIST = null);
            }
            AlarmRules = _mapper.Map<List<GMP_ALARM_ITEM>, List<AlarmItemDto>>(alarms).OrderByDescending(x => x.PRIORITY).ToList();
            AlarmRules.ForEach(x => x.RULE = itemRules[x.ID]);
            return AlarmRules;
        }

        /// <summary>
        /// 删除报警规则
        /// </summary>
        /// <param name="item_id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteAlarmItem(Guid item_id) 
        {
            var entity = await FindAsync(item_id);
            if (entity != null) 
            {
                entity.STATE = StateEnum.删除;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 更新报警规则
        /// </summary>
        /// <param name="item_id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GMP_ALARM_ITEM> UpdateAlarmItem(Guid item_id, AlarmItemCreatInput input) 
        {
            var entity = await GetQueryable(x => x.ID == item_id).Include(x => x.ALARM_ITEM_RULE_LIST).ThenInclude(x => x.ALARM_RULE_CONFIG_LIST).FirstOrDefaultAsync();
            if (entity == null) 
            {
                return null;
            }
            var result = Update(entity, input);
            result.ALARM_ITEM_RULE_LIST = _mapper.Map<List<ItemRuleCreatInput>, List<GMP_ALARM_ITEM_RULE>>(input.RuleList);
            return result;
        }


    }

}
