using SR.GMP.DataEntity.DictEnum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig
{
    public class AlarmItemRuleDto
    {
        /// <summary>
        /// 规则类型
        /// </summary>
        public AlarmRuleEnum RULE_TYPE { get; set; }

        /// <summary>
        /// 监测项目
        /// </summary>
        public string MONITOR_ITEM_CODE { get; set; }

        /// <summary>
        /// 临床事件
        /// </summary>
        public string EVENT_ITEM_CODE { get; set; }

        /// <summary>
        /// 逻辑值
        /// </summary>
        public AlarmLogicEnum LOGIC_TYPE { get; set; }

        /// <summary>
        /// 顺序值
        /// </summary>
        public int SORT_NUM { get; set; }
    }


}
