using SR.GMP.DataEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SR.GMP.DataEntity.Alarm
{
    /// <summary>
    /// 报警项目规则配置
    /// </summary>
    public class GMP_ALARM_RULE_CONFIG : GuidEntityHasCreationModify
    {
        /// <summary>
        /// 报警项目ID
        /// </summary>
        public Guid RULE_ID { get; set; }
        [ForeignKey("RULE_ID")]
        public virtual GMP_ALARM_ITEM_RULE ALARM_ITEM_RULE { get; set; }

        /// <summary>
        /// 最大值
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? MAX_VALUE { get; set; }

        /// <summary>
        /// 是否包含最大值
        /// </summary>
        public bool IS_CONTAINMAX { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? MIN_VALUE { get; set; }

        /// <summary>
        /// 是否包含最小值
        /// </summary>
        public bool IS_CONTAINMIN { get; set; }

        /// <summary>
        /// 是否前后数据差值
        /// </summary>
        public bool IS_DIFFVALUE { get; set; }
    }
}
