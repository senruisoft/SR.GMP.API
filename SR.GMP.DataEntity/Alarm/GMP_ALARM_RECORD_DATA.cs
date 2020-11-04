using SR.GMP.DataEntity.DictEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SR.GMP.DataEntity.Alarm
{
    /// <summary>
    /// 报警记录监测数据项表
    /// </summary>
    public class GMP_ALARM_RECORD_DATA
    {
        /// <summary>
        /// 报警记录ID
        /// </summary>
        [Required]
        public Guid ALARM_RECORD_ID { get; set; }

        [ForeignKey("ALARM_RECORD_ID")]
        public virtual GMP_ALARM_RECORD ALARM_RECORD { get; set; }

        /// <summary>
        /// 监控项CODE
        /// </summary>
        [StringLength(64)]
        [Required]
        public string MONITOR_ITEM_CODE { get; set; }

        /// <summary>
        /// 监控项名称
        /// </summary>
        [StringLength(64)]
        public string MONITOR_ITEM_NAME { get; set; }

        /// <summary>
        /// 监控项数值
        /// </summary>
        [StringLength(64)]
        public string MONITOR_ITEM_VALUE { get; set; }

        /// <summary>
        /// 是否为报警项
        /// </summary>
        public bool IS_ALARM { get; set; }

        /// <summary>
        /// 数据项类型
        /// </summary>
        public AlarmRuleEnum RULE_TYPE { get; set; }
    }
}
