using SR.GMP.DataEntity.DictEnum;
using SR.GMP.Service.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor.Dto.StatisticData
{
    /// <summary>
    /// 报警记录
    /// </summary>
    public class AlarmRecordDto : EntityDto<Guid>
    {
        /// <summary>
        /// 患者ID
        /// </summary>
        public string PATIENT_EXT_ID { get; set; }

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
        /// 报警项目ID
        /// </summary>
        public Guid ALARM_ITEM_ID { get; set; }

        /// <summary>
        /// 报警项目名称
        /// </summary>
        public string ALARM_ITEM_NAME { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public PriorityEnum PRIORITY { get; set; }

        /// <summary>
        /// 数据记录时间
        /// </summary>
        public DateTime DATA_RECORD_TIME { get; set; }

        /// <summary>
        /// 报警状态
        /// </summary>
        public AlarmStateEnum STATE { get; set; }

        /// <summary>
        /// 班次
        /// </summary>
        public string CLASS_NAME { get; set; }

        /// <summary>
        /// 是否自动报警
        /// </summary>
        public bool IS_AUTO { get; set; }

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
        /// 治疗ID
        /// </summary>
        public string TREATMENT_ID { get; set; }

        /// <summary>
        /// 报警监测数据
        /// </summary>
        public List<AlarmRecordDataDto> RECORD_DATA_LIST { get; set; }
    }

    public class AlarmRecordDataDto
    {
        /// <summary>
        /// 监控项名称
        /// </summary>
        public string MONITOR_ITEM_NAME { get; set; }

        /// <summary>
        /// 监控项CODE
        /// </summary>
        public string MONITOR_ITEM_CODE { get; set; }

        /// <summary>
        /// 监控项数值
        /// </summary>
        public string MONITOR_ITEM_VALUE { get; set; }

        /// <summary>
        /// 是否为报警项
        /// </summary>
        public bool IS_ALARM { get; set; }

        /// <summary>
        /// 数据项类型
        /// </summary>
        public AlarmRuleEnum RULE_TYPE { get; set; }
    }
}
