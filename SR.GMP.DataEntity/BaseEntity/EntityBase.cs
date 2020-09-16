using SR.GMP.DataEntity.DictEnum;
using SR.GMP.DataEntity.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SR.GMP.DataEntity.BaseEntity
{
    /// <summary>
    /// 带创建信息的GUID主键类
    /// </summary>
    public class GuidEntityHasCreation : Entity<Guid>, IHasCreationInfo
    {
        public GuidEntityHasCreation() 
        {
            STATE = StateEnum.启用;
        }

        /// <summary>
        /// 状态
        /// </summary>
        public StateEnum STATE { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATE_AT { get; set; }

        /// <summary>
        /// 创建人
        /// </summary>
        public Guid? CREATOR_ID { get; set; }
        [ForeignKey("CREATOR_ID")]
        public virtual SYS_USER CREATE_USER { get; set; }
    }

    /// <summary>
    /// 带创建和修改信息的GUID主键类
    /// </summary>
    public class GuidEntityHasCreationModify : GuidEntityHasCreation, IHasModificationInfo
    {
        /// <summary>
        /// 修改时间
        /// </summary>
        public DateTime? MODIFY_AT { get; set; }

        /// <summary>
        /// 修改人
        /// </summary>
        public Guid? MODIFIER_ID { get; set; }
        [ForeignKey("MODIFIER_ID")]
        public virtual SYS_USER MODIFY_USER { get; set; }
    }

}
