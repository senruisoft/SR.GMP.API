using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.DataEntity.BaseEntity
{
    /// <summary>
    /// 修改信息接口
    /// </summary>
    public interface IHasModificationInfo
    {
        /// <summary>
        /// 修改时间
        /// </summary>
        DateTime? MODIFY_AT { get; set; }

        /// <summary>
        /// 修改人ID
        /// </summary>
        Guid? MODIFIER_ID { get; set; }
    }
}
