using SR.GMP.DataEntity.BaseEntity;
using SR.GMP.DataEntity.DictEnum;
using SR.GMP.DataEntity.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SR.GMP.DataEntity.Alarm
{
    /// <summary>
    /// 报警项目表
    /// </summary>
    public partial class GMP_ALARM_ITEM : GuidEntityHasCreationModify, IHasCenterInfo<Guid>
    {
        public GMP_ALARM_ITEM() 
        {
            STATE = StateEnum.启用;
        }

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
        [ForeignKey("CENT_ID")]
        public virtual SYS_INST_CENTER CENTER { get; set; }

        /// <summary>
        /// 报警项目规则列表
        /// </summary>
        public ICollection<GMP_ALARM_ITEM_RULE> ALARM_ITEM_RULE_LIST { get; set; }

    }
}
