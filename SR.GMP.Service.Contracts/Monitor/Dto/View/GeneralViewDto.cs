using SR.GMP.DataEntity.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor.Dto.View
{
    /// <summary>
    /// 患者概览信息
    /// </summary>
    public class PatientGeneralInfo
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_ID { get; set; }

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
        /// 透析龄
        /// </summary>
        public string DIALYSIS_AGE { get; set; }
    }

    /// <summary>
    /// 患者治疗基本信息
    /// </summary>
    public class PatientBasicTreatInfo
    {
        /// <summary>
        /// 今日透前体征
        /// </summary>
        public SignData todayBeforeData { get; set; }

        /// <summary>
        /// 上次透前体征
        /// </summary>
        public SignData lastBeforeData { get; set; }

        /// <summary>
        /// 上次透后体征
        /// </summary>
        public SignData lastAfterData { get; set; }

        /// <summary>
        /// 今日治疗方案
        /// </summary>
        public TreatPlanData treatPlanData { get; set; }

        /// <summary>
        /// 最近治疗记录
        /// </summary>
        public List<TreatRecord> treatRecords { get; set; }

        public PatientBasicTreatInfo() 
        {
            todayBeforeData = new SignData();
            lastBeforeData = new SignData();
            lastAfterData = new SignData();
            treatPlanData = new TreatPlanData();
            treatRecords = new List<TreatRecord>();
        }

        /// <summary>
        /// 构造基本信息数据
        /// </summary>
        /// <param name="data"></param>
        public PatientBasicTreatInfo(List<PatientBasicTreatView> data) : base()
        {
            if (data.Count > 0)
            {
                todayBeforeData = new SignData(data[0], false);
                treatPlanData = new TreatPlanData(data[0]);
                treatRecords = data.Select(x => new TreatRecord 
                { 
                    TREATMENT_ID = x.TREATMENT_ID, 
                    TRAETMENT_DATE = x.TRAETMENT_DATE,
                    BEFORE_WEIGHT = x.BEFORE_WEIGHT,
                    AFTER_WEIGHT = x.AFTER_WEIGHT,
                    BEFORE_SBP = x.BEFORE_SBP,
                    BEFORE_SP = x.BEFORE_SP,
                    AFTER_SBP = x.AFTER_SBP,
                    AFTER_SP = x.AFTER_SP,
                }).ToList();
            }
            if (data.Count > 1) 
            {
                lastBeforeData = new SignData(data[1], false);
                lastAfterData = new SignData(data[1], true);
            }
        }
    }

    /// <summary>
    /// 体征数据
    /// </summary>
    public class SignData
    {
        /// <summary>
        /// 体重
        /// </summary>
        public decimal? WEIGHT { get; set; }

        /// <summary>
        /// 干体重
        /// </summary>
        public decimal? DRY_WEIGHT { get; set; }

        /// <summary>
        /// 收缩压
        /// </summary>
        public decimal? SBP { get; set; }

        /// <summary>
        /// 舒张压
        /// </summary>
        public decimal? SP { get; set; }

        /// <summary>
        /// 心率
        /// </summary>
        public decimal? HR { get; set; }

        /// <summary>
        /// 体温
        /// </summary>
        public decimal? TEMPERATURE { get; set; }

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

        public SignData() 
        {
        }

        /// <summary>
        /// 加载体征数据
        /// </summary>
        /// <param name="data">原始数据</param>
        /// <param name="is_after">是否透后</param>
        public SignData(PatientBasicTreatView data, bool is_after) 
        {
            DRY_WEIGHT = data.DRY_WEIGHT;
            PRESET_UF = data.PRESET_UF;
            ACTUAL_UF = data.ACTUAL_UF;
            DEFAULT_TREAT_TIME = data.DEFAULT_TREAT_TIME / 60;
            if (is_after)
            {
                WEIGHT = data.AFTER_WEIGHT;
                SBP = data.AFTER_SBP;
                SP = data.AFTER_SP;
                HR = data.AFTER_HR;
                TEMPERATURE = data.AFTER_TEMPERATURE;
            }
            else 
            {
                WEIGHT = data.BEFORE_WEIGHT;
                SBP = data.BEFORE_SBP;
                SP = data.BEFORE_SP;
                HR = data.BEFORE_HR;
                TEMPERATURE = data.BEFORE_TEMPERATURE;
            }
        }
    }

    /// <summary>
    /// 治疗方案
    /// </summary>
    public class TreatPlanData 
    {
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

        public TreatPlanData() 
        {
        }

        /// <summary>
        /// 加载治疗方案数据
        /// </summary>
        /// <param name="data"></param>
        public TreatPlanData(PatientBasicTreatView data)
        {
            TREATMENT_MODE = data.TREATMENT_MODE;
            DIALYZER_NAME = data.DIALYZER_NAME;
            ATICOAGULANT_NAME = data.ATICOAGULANT_NAME;
            FIRST_DOSE = data.FIRST_DOSE;
            KEEP_DOSE = data.KEEP_DOSE;
            DIALYSATE_NAME = data.DIALYSATE_NAME;
        }
    }

    /// <summary>
    /// 治疗记录
    /// </summary>
    public class TreatRecord 
    {
        /// <summary>
        /// 治疗ID
        /// </summary>
        public string TREATMENT_ID { get; set; }

        /// <summary>
        /// 治疗日期
        /// </summary>
        public DateTime TRAETMENT_DATE { get; set; }

        /// <summary>
        /// 透前体重
        /// </summary>
        public decimal? BEFORE_WEIGHT { get; set; }

        /// <summary>
        /// 透后体重
        /// </summary>
        public decimal? AFTER_WEIGHT { get; set; }

        /// <summary>
        /// 透前收缩压
        /// </summary>
        public decimal? BEFORE_SBP { get; set; }

        /// <summary>
        /// 透前舒张压
        /// </summary>
        public decimal? BEFORE_SP { get; set; }

        /// <summary>
        /// 透后收缩压
        /// </summary>
        public decimal? AFTER_SBP { get; set; }

        /// <summary>
        /// 透后舒张压
        /// </summary>
        public decimal? AFTER_SP { get; set; }

    }

    /// <summary>
    /// 监测数据
    /// </summary>
    public class TreatMonitorData 
    {
        /// <summary>
        /// 预设治疗时间
        /// </summary>
        public decimal? DEFAULT_TREAT_TIME { get; set; }

        /// <summary>
        /// 已治疗时间
        /// </summary>
        public decimal? ELAPSEDTIME { get; set; }

        /// <summary>
        /// 已超滤量
        /// </summary>
        public decimal? UF { get; set; }

        /// <summary>
        /// 体征监测数据
        /// </summary>
        public List<MonitorDataDto> MonitorDataList { get; set; }
    }

    /// <summary>
    /// 体征监测数据
    /// </summary>
    public class MonitorDataDto 
    {
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
    public class TreatOrderDto 
    {
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
}
