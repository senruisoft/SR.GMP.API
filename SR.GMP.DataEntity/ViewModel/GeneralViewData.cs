using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.DataEntity.ViewModel
{
    /// <summary>
    /// 患者基本信息
    /// </summary>
    public class PatientGeneralView
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID { get; set; }

        /// <summary>
        /// 中心ID
        /// </summary>
        public string CENT_ID { get; set; }

        /// <summary>
        /// 透析号
        /// </summary>
        public string DIALYSIS_ID { get; set; }

        /// <summary>
        /// 班次
        /// </summary>
        public string CLASS_NAME { get; set; }

        /// <summary>
        /// 患者姓名
        /// </summary>
        public string PATIENT_NAME { get; set; }

        /// <summary>
        /// 患者性别
        /// </summary>
        public string PATIENT_SEX { get; set; }

        /// <summary>
        /// 患者年龄
        /// </summary>
        public int PATIENT_AGE { get; set; }

        /// <summary>
        /// 患者类型
        /// </summary>
        public string PATIENT_TYPE { get; set; }

        /// <summary>
        /// 医保类型
        /// </summary>
        public string MEDICAL_TYPE { get; set; }

        /// <summary>
        /// 床位号
        /// </summary>
        public string BED_LABEL { get; set; }

        /// <summary>
        /// 医生名称
        /// </summary>
        public string DOCTOR_NAME { get; set; }

        /// <summary>
        /// 护士名称
        /// </summary>
        public string NURSE_NAME { get; set; }

        /// <summary>
        /// 治疗日期
        /// </summary>
        public DateTime TRAETMENT_DATE { get; set; }

        /// <summary>
        /// 首透日期
        /// </summary>
        public DateTime? TREATMENT_START_DATE { get; set; }
    }
}
