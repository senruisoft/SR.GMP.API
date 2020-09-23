using SR.GMP.Service.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.System.Dto.Center
{
    public class CenterDto : EntityDto<Guid>
    {
        /// <summary>
        /// 机构ID
        /// </summary>
        public Guid INST_ID { get; set; }

        /// <summary>
        /// 中心CODE
        /// </summary>
        public string CODE { get; set; }

        /// <summary>
        /// 中心名称
        /// </summary>
        public string NAME { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public string SORT_CODE { get; set; }

        /// <summary>
        /// 外部ID
        /// </summary>
        public string EXT_ID { get; set; }
    }
}
