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

    /// <summary>
    /// 患者基本治疗情况
    /// </summary>
    public class PatientBasicTreatView
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID { get; set; }

        /// <summary>
        /// 治疗ID
        /// </summary>
        public string TREATMENT_ID { get; set; }

        /// <summary>
        /// 中心ID
        /// </summary>
        public string CENT_ID { get; set; }
        
        /// <summary>
        /// 治疗日期
        /// </summary>
        public DateTime TRAETMENT_DATE { get; set; }

        /// <summary>
        /// 治疗方式
        /// </summary>
        public string TREATMENT_MODE { get; set; }

        /// <summary>
        /// 透析器
        /// </summary>
        public string DIALYZER_NAME { get; set; }

        /// <summary>
        /// 抗凝剂
        /// </summary>
        public string ATICOAGULANT_NAME { get; set; }

        /// <summary>
        /// 首剂
        /// </summary>
        public decimal? FIRST_DOSE { get; set; }

        /// <summary>
        /// 维持量
        /// </summary>
        public decimal? KEEP_DOSE { get; set; }

        /// <summary>
        /// 透析液
        /// </summary>
        public string DIALYSATE_NAME { get; set; }

        /// <summary>
        /// 透前体重
        /// </summary>
        public decimal? BEFORE_WEIGHT { get; set; }

        /// <summary>
        /// 干体重
        /// </summary>
        public decimal? DRY_WEIGHT { get; set; }

        /// <summary>
        /// 透前收缩压
        /// </summary>
        public decimal? BEFORE_SBP { get; set; }

        /// <summary>
        /// 透前舒张压
        /// </summary>
        public decimal? BEFORE_SP { get; set; }

        /// <summary>
        /// 透前心率
        /// </summary>
        public decimal? BEFORE_HR { get; set; }

        /// <summary>
        /// 透前体温
        /// </summary>
        public decimal? BEFORE_TEMPERATURE { get; set; }

        /// <summary>
        /// 预设超滤量
        /// </summary>
        public decimal? PRESET_UF { get; set; }

        /// <summary>
        /// 实际超滤量
        /// </summary>
        public decimal? ACTUAL_UF { get; set; }

        /// <summary>
        /// 预设治疗时间
        /// </summary>
        public decimal? DEFAULT_TREAT_TIME { get; set; }

        /// <summary>
        /// 透后体重
        /// </summary>
        public decimal? AFTER_WEIGHT { get; set; }

        /// <summary>
        /// 透后收缩压
        /// </summary>
        public decimal? AFTER_SBP { get; set; }

        /// <summary>
        /// 透后舒张压
        /// </summary>
        public decimal? AFTER_SP { get; set; }

        /// <summary>
        /// 透后心率
        /// </summary>
        public decimal? AFTER_HR { get; set; }

        /// <summary>
        /// 透后体温
        /// </summary>
        public decimal? AFTER_TEMPERATURE { get; set; }

    }

    /// <summary>
    /// 设备监测数据
    /// </summary>
    public class DeviceTreatDataView
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID { get; set; }

        /// <summary>
        /// 治疗ID
        /// </summary>
        public string TREATMENT_ID { get; set; }

        /// <summary>
        /// 中心ID
        /// </summary>
        public string CENT_ID { get; set; }

        /// <summary>
        /// 治疗日期
        /// </summary>
        public DateTime TRAETMENT_DATE { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime? RECORD_TIME { get; set; }

        /// <summary>
        /// 预设治疗时间
        /// </summary>
        public decimal? DEFAULT_TREAT_TIME { get; set; }

        /// <summary>
        /// 是否上机
        /// </summary>
        public bool? IS_UP { get; set; }

        /// <summary>
        /// 是否下机
        /// </summary>
        public bool? IS_DOWN { get; set; }

        /// <summary>
        /// 已治疗时间
        /// </summary>
        public decimal? ELAPSEDTIME { get; set; }

        /// <summary>
        /// 已超滤量
        /// </summary>
        public decimal? UF { get; set; }
    }

    /// <summary>
    /// 治疗监测数据
    /// </summary>
    public class MonitorDataView
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID { get; set; }

        /// <summary>
        /// 治疗ID
        /// </summary>
        public string TREATMENT_ID { get; set; }

        /// <summary>
        /// 中心ID
        /// </summary>
        public string CENT_ID { get; set; }

        /// <summary>
        /// 治疗日期
        /// </summary>
        public DateTime TRAETMENT_DATE { get; set; }

        /// <summary>
        /// 记录时间
        /// </summary>
        public DateTime? RECORD_TIME { get; set; }

        /// <summary>
        /// 静脉压
        /// </summary>
        public decimal? VENOUS_PRESSURE { get; set; }

        /// <summary>
        /// 动脉压
        /// </summary>
        public decimal? ARTERIAL_PRESSURE { get; set; }

        /// <summary>
        /// 跨膜压
        /// </summary>
        public int? TRANS_PRESSURE { get; set; }

        /// <summary>
        /// 血流量
        /// </summary>
        public decimal? BLOOD_FLOW { get; set; }

        /// <summary>
        /// 置换液流量
        /// </summary>
        public decimal? RP_FLUID_FLOW { get; set; }

        /// <summary>
        /// 超滤率
        /// </summary>
        public decimal? UF_RATE { get; set; }

        /// <summary>
        /// 超滤量
        /// </summary>
        public decimal? UF { get; set; }

        /// <summary>
        /// 呼吸
        /// </summary>
        public decimal? BREATHE { get; set; }

        /// <summary>
        /// 透析液温度
        /// </summary>
        public decimal? DIALYSATE_TEMPERATURE { get; set; }

        /// <summary>
        /// 体温
        /// </summary>
        public decimal? BODY_TEMPERATURE { get; set; }

        /// <summary>
        /// 收缩压
        /// </summary>
        public decimal? SYSTOLIC_BLOOD_PRESSURE { get; set; }

        /// <summary>
        /// 舒张压
        /// </summary>
        public decimal? STRETCH_PRESSURE { get; set; }

        /// <summary>
        /// 心率
        /// </summary>
        public decimal? HEART_RATE { get; set; }

        /// <summary>
        /// 电导率
        /// </summary>
        public decimal? ELECTRICAL_CONDUCTIVITY { get; set; }

        /// <summary>
        /// 透析液流量
        /// </summary>
        public decimal? DIALYSATE_FLOW { get; set; }

        /// <summary>
        /// 肝素追加
        /// </summary>
        public decimal? ATICOAGULANT_ADD { get; set; }

        /// <summary>
        /// 体征状态
        /// </summary>
        public string SIGNS_STATUS { get; set; }

        /// <summary>
        /// 体征描述
        /// </summary>
        public string EVENT_BIREF { get; set; }

        /// <summary>
        /// KTV
        /// </summary>
        public decimal? KTV { get; set; }
    }

    /// <summary>
    /// 治疗医嘱数据
    /// </summary>
    public class TreatOrderView
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID { get; set; }

        /// <summary>
        /// 治疗ID
        /// </summary>
        public string TREATMENT_ID { get; set; }

        /// <summary>
        /// 中心ID
        /// </summary>
        public string CENT_ID { get; set; }

        /// <summary>
        /// 治疗日期
        /// </summary>
        public DateTime TRAETMENT_DATE { get; set; }

        /// <summary>
        /// 医嘱名称
        /// </summary>
        public string ORDER_NAME { get; set; }

        /// <summary>
        /// 执行方法
        /// </summary>
        public string EXEC_METHOD { get; set; }

        /// <summary>
        /// 是否执行
        /// </summary>
        public bool IS_EXECED { get; set; }

        /// <summary>
        /// 开嘱人
        /// </summary>
        public string SUBMIT_USER { get; set; }

        /// <summary>
        /// 执行人
        /// </summary>
        public string EXEC_USER { get; set; }
    }

    /// <summary>
    /// Pad手动报警数据
    /// </summary>
    public class PadPoliceView
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
        /// 治疗ID
        /// </summary>
        public string TREATMENT_ID { get; set; }
        /// <summary>
        /// 报警模块类型
        /// </summary>
        public string POLICE_TYPE { get; set; }
        /// <summary>
        /// 报警名称
        /// </summary>
        public string POLICE_TITLE { get; set; }
        /// <summary>
        /// 报警描述
        /// </summary>
        public string POLICE_DESCRIPTION { get; set; }
        /// <summary>
        /// 状态 1 生效警报 0 失效警报（被移除的）
        /// </summary>
        public int STATE { get; set; }
        /// <summary>
        /// 创建人ID
        /// </summary>
        public string CREATE_USER_ID { get; set; }
        /// <summary>
        /// 创建人
        /// </summary>
        public string CREATE_USER_NAME { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CREATE_AT { get; set; }
        /// <summary>
        /// 中心ID
        /// </summary>
        public string CENT_ID { get; set; }
        /// <summary>
        /// 机构ID
        /// </summary>
        public string INST_ID { get; set; }
    }

}
