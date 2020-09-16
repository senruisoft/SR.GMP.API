using SR.GMP.DataEntity.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SR.GMP.DataEntity.BaseEntity
{
    /// <summary>
    /// 中心信息接口
    /// </summary>
    public interface IHasCenterInfo<T>
    {
        /// <summary>
        /// 中心ID
        /// </summary>
        T CENT_ID { get; set; }
    }
}
