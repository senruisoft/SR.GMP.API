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
    /// 报警记录表
    /// </summary>
    public class GMP_ALARM_RECORD : Entity<Guid>, IHasCenterInfo<Guid>
    {
        public GMP_ALARM_RECORD() 
        {
            STATE = AlarmStateEnum.未处理;
            CREATE_AT = DateTime.Now;
        }

        /// <summary>
        /// 报警项目ID
        /// </summary>
        [Required]
        public Guid ALARM_ITEM_ID { get; set; }

        /// <summary>
        /// 患者ID
        /// </summary>
        [Required]
        [StringLength(64)]
        public string PATIENT_EXT_ID { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        [StringLength(64)]
        public string PATIENT_NAME { get; set; }

        /// <summary>
        /// 患者性别
        /// </summary>
        [StringLength(64)]
        public string PATIENT_SEX { get; set; }

        /// <summary>
        /// 患者年龄
        /// </summary>
        public int PATIENT_AGE { get; set; }

        /// <summary>
        /// 床位
        /// </summary>
        [StringLength(64)]
        public string BED_LABEL { get; set; }

        /// <summary>
        /// 医生
        /// </summary>
        [StringLength(64)]
        public string DOCTOR_NAME { get; set; }

        /// <summary>
        /// 护士
        /// </summary>
        [StringLength(64)]
        public string NURSE_NAME { get; set; }

        /// <summary>
        /// 项目名称
        /// </summary>
        [Required]
        [StringLength(128)]
        public string ALARM_ITEM_NAME { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public PriorityEnum PRIORITY { get; set; }

        /// <summary>
        /// 报警信息
        /// </summary>
        [StringLength(128)]
        public string ALARM_INFO { get; set; }

        /// <summary>
        /// 数据记录时间
        /// </summary>
        public DateTime DATA_RECORD_TIME { get; set; }

        /// <summary>
        /// 报警状态
        /// </summary>
        public AlarmStateEnum STATE { get; set; }

        /// <summary>
        /// 处理时间
        /// </summary>
        public DateTime? HANDLE_TIME { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CREATE_AT { get; set; }

        /// <summary>
        /// 中心ID
        /// </summary>
        public Guid CENT_ID { get; set; }

        /// <summary>
        /// 班次ID
        /// </summary>
        public string CLASS_ID { get; set; }

        /// <summary>
        /// 班次名称
        /// </summary>
        public string CLASS_NAME { get; set; }
    }
}
