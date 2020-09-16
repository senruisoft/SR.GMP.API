using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SR.GMP.DataEntity.ViewModel
{
    public class RecordDataBase
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID { get; set; }

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
        /// 床位
        /// </summary>
        public string BED_LABEL { get; set; }

        /// <summary>
        /// 医生
        /// </summary>
        public string DOCTOR_NAME { get; set; }

        /// <summary>
        /// 护士
        /// </summary>
        public string NURSE_NAME { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime RECORD_TIME { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CREATE_AT { get; set; }
    }

    /// <summary>
    /// 监控数据视图模型
    /// </summary>
    public class MonitorViewData : RecordDataBase
    {
        /// <summary>
        /// 静脉压
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? VENOUS_PRESSURE { get; set; }

        /// <summary>
        /// 动脉压
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? ARTERIAL_PRESSURE { get; set; }

        /// <summary>
        /// 跨膜压
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? TRANS_PRESSURE { get; set; }

        /// <summary>
        /// 血流量
        /// </summary>
       [Column(TypeName = "decimal(8, 2)")]
        public decimal? BLOOD_FLOW { get; set; }

        /// <summary>
        /// 置换液流量
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? RP_FLUID_FLOW { get; set; }

        /// <summary>
        /// 超滤率
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? UF_RATE { get; set; }

        /// <summary>
        /// 超滤量
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? UF { get; set; }

        /// <summary>
        /// 呼吸
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? BREATHE { get; set; }

        /// <summary>
        /// 透析液温度
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? DIALYSATE_TEMPERATURE { get; set; }

        /// <summary>
        /// 体温
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? BODY_TEMPERATURE { get; set; }

        /// <summary>
        /// 收缩压
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? SYSTOLIC_BLOOD_PRESSURE { get; set; }

        /// <summary>
        /// 舒张压
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? STRETCH_PRESSURE { get; set; }

        /// <summary>
        /// 心率
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? HEART_RATE { get; set; }

        /// <summary>
        /// 电导率
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? ELECTRICAL_CONDUCTIVITY { get; set; }

        /// <summary>
        /// 透析液流量
        /// </summary>
        //public decimal? DIALYSATE_FLOW { get; set; }

        /// <summary>
        /// 肝素追加
        /// </summary>
        //public decimal? ATICOAGULANT_ADD { get; set; }

        /// <summary>
        /// KTV
        /// </summary>
        [Column(TypeName = "decimal(8, 2)")]
        public decimal? KTV { get; set; }

        /// <summary>
        /// 中心ID
        /// </summary>
        public string CENT_ID { get; set; }

    }

    /// <summary>
    /// 监控数据模型
    /// </summary>
    public class MonitorRecordData : RecordDataBase
    {
        /// <summary>
        /// 监测数据项
        /// </summary>
        public Dictionary<string, decimal?> MonitorItems { get; set; }
    }

    /// <summary>
    /// 透析事件视图模型
    /// </summary>
    public class EventViewData : RecordDataBase
    {
        /// <summary>
        /// 事件名称
        /// </summary>
        public string EVENT_NAME { get; set; }

        /// <summary>
        /// 事件CODE
        /// </summary>
        public string EVENT_CODE { get; set; }

        /// <summary>
        /// 中心ID
        /// </summary>
        public string CENT_ID { get; set; }
    }
}
