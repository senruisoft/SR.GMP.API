using SR.GMP.DataEntity.BaseEntity;
using SR.GMP.DataEntity.DictEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SR.GMP.DataEntity.System
{
    public class SYS_USER : GuidEntityHasCreationModify
    {
        /// <summary>
        /// 账号
        /// </summary>
        [Required]
        [StringLength(128)]
        public string ACCOUNT { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(128)]
        public string PWD { get; set; }

        /// <summary>
        /// 工号
        /// </summary>
        [StringLength(32)]
        public string JOB_NO { get; set; }

        /// <summary>
        /// 姓名
        /// </summary>
        [Required]
        [StringLength(128)]
        public string NAME { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public GenderEnum GENDER { get; set; }

    }
}
