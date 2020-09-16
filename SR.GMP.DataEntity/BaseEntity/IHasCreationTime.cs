using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.DataEntity.BaseEntity
{
    /// <summary>
    /// 创建信息接口
    /// </summary>
    public interface IHasCreationInfo
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        DateTime? CREATE_AT { get; set; }

        /// <summary>
        /// 创建人ID
        /// </summary>
        Guid? CREATOR_ID { get; set; }
    }
}
