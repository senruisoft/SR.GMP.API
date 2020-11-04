using AutoMapper;
using Microsoft.EntityFrameworkCore;
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
        /// 获取报警规则信息
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public List<AlarmItemDto> GetAlarmItemsInfo(List<Guid> idList) 
        {
            List<AlarmItemDto> AlarmRules = new List<AlarmItemDto>();
            if (idList.Count == 0) 
            {
                return AlarmRules;
            }
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
            var alarms = GetQueryable(x => idList.Contains(x.ID)).Include(x => x.ALARM_ITEM_RULE_LIST).ThenInclude(x => x.ALARM_RULE_CONFIG_LIST).ToList();
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
                        string lower = c.MIN_VALUE.HasValue ? c.MIN_VALUE + (c.IS_CONTAINMIN ? "≥" : "＞") : "";
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
                    eventRule += (eventRule == "" ? " " + r.LOGIC_TYPE.ToString() + " 【透析事件】" : " " + r.LOGIC_TYPE.ToString() + " ") + item_name;
                });
                //eventRule += eventRule != "" ? "）" : "";
                itemRules[item.ID] = monitorRule + eventRule;
            });
            AlarmRules = _mapper.Map<List<GMP_ALARM_ITEM>, List<AlarmItemDto>>(alarms);
            AlarmRules.ForEach(x => x.RULE = itemRules[x.ID]);
            return AlarmRules;
        }
    }

}
