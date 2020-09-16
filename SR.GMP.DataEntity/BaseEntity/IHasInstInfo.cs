using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.DataEntity.BaseEntity
{
    /// <summary>
    /// 机构信息接口
    /// </summary>
    public interface IHasInstInfo<T>
    {
        /// <summary>
        /// 机构ID
        /// </summary>
        T INST_ID { get; set; }
    }
}
