using SR.GMP.DataEntity.DictEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SR.GMP.Service.Contracts.System.Dto.Center
{
    public class CenterInput
    {
        /// <summary>
        /// 机构ID
        /// </summary>
        public Guid INST_ID { get; set; }

        /// <summary>
        /// 中心CODE
        /// </summary>
        [Required]
        [StringLength(128)]
        public string CODE { get; set; }

        /// <summary>
        /// 中心名称
        /// </summary>
        [Required]
        [StringLength(128)]
        public string NAME { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        [StringLength(128)]
        public string SORT_CODE { get; set; }

        /// <summary>
        /// 描述备注
        /// </summary>
        [StringLength(256)]
        public string CENT_DESC { get; set; }

        /// <summary>
        /// 类型编码
        /// </summary>
        public CenterTypeEnum TYPE_CODE { get; set; }

        /// <summary>
        /// 外部ID
        /// </summary>
        [StringLength(128)]
        public string EXT_ID { get; set; }
    }
}
