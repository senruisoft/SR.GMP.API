using SR.GMP.DataEntity.DictEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig
{
    public class AlarmItemCreatInput
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]
        [StringLength(128)]
        public string ITEM_NAME { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public PriorityEnum PRIORITY { get; set; }

        /// <summary>
        /// 处理措施
        /// </summary>
        public string TREAT_MEASURE { get; set; }

        /// <summary>
        /// 处理流程
        /// </summary>
        public string TREAT_PROCESS { get; set; }

        /// <summary>
        /// 中心ID
        /// </summary>
        public Guid CENT_ID { get; set; }

        public List<ItemRuleCreatInput> RuleList { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public StateEnum STATE { get; set; }
    }

    public class ItemRuleCreatInput
    {
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

        public List<RuleConfigCreatInput> ConfigList { get; set; }
    }

    public class RuleConfigCreatInput
    {
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
