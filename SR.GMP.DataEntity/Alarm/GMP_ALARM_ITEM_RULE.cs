using SR.GMP.DataEntity.BaseEntity;
using SR.GMP.DataEntity.DictEnum;
using SR.GMP.DataEntity.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SR.GMP.DataEntity.Alarm
{
    /// <summary>
    /// 报警项目规则表
    /// </summary>
    public class GMP_ALARM_ITEM_RULE : GuidEntityHasCreationModify
    {
        /// <summary>
        /// 报警项目ID
        /// </summary>
        public Guid ITEM_ID { get; set; }
        [ForeignKey("ITEM_ID")]
        public virtual GMP_ALARM_ITEM ALARM_ITEM { get; set; }

        /// <summary>
        /// 规则类型
        /// </summary>
        public AlarmRuleEnum RULE_TYPE { get; set; }

        /// <summary>
        /// 监测项目
        /// </summary>
        [StringLength(64)]
        public string MONITOR_ITEM_CODE { get; set; }

        /// <summary>
        /// 临床事件
        /// </summary>
        [StringLength(64)]
        public string EVENT_ITEM_CODE { get; set; }

        /// <summary>
        /// 逻辑值
        /// </summary>
        public AlarmLogicEnum LOGIC_TYPE { get; set; }

        /// <summary>
        /// 顺序值
        /// </summary>
        public int SORT_NUM { get; set; }

        /// <summary>
        /// 报警项目规则配置列表
        /// </summary>
        public ICollection<GMP_ALARM_RULE_CONFIG> ALARM_RULE_CONFIG_LIST { get; set; }
    }
}
