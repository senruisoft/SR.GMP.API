using SR.GMP.DataEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.DataEntity.ViewModel
{
    /// <summary>
    /// 床位/患者/医护数量信息
    /// </summary>
    public class BaseCountView : IHasCenterInfo<string>
    {
        /// <summary>
        /// 床位数
        /// </summary>
        public int BedCount { get; set; }

        /// <summary>
        /// 患者数量
        /// </summary>
        public int PatientCount { get; set; }

        /// <summary>
        /// 医生数量
        /// </summary>
        public int DoctorCount { get; set; }

        /// <summary>
        ///  护士数量
        /// </summary>
        public int NurseCount { get; set; }

        /// <summary>
        /// 中心ID
        /// </summary>
        public string CENT_ID { get; set; }
    }

    /// <summary>
    /// 设备信息
    /// </summary>
    public class EquipmentCountView : IHasCenterInfo<string>
    {
        /// <summary>
        /// 设备名称
        /// </summary>
        public string EquipmentName { get; set; }

        /// <summary>
        /// 设备Code
        /// </summary>
        public string EquipmentCode { get; set; }

        /// <summary>
        /// 设备数量
        /// </summary>
        public int EquipmentCount { get; set; }

        public string CENT_ID { get; set; }
    }

    /// <summary>
    /// 患者数量统计信息
    /// </summary>
    public class TreatmenCountView : IHasCenterInfo<string>
    {
        /// <summary>
        /// 总人数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 男性数量
        /// </summary>
        public int ManCount { get; set; }

        /// <summary>
        /// 女性数量
        /// </summary>
        public int WomanCount { get; set; }

        /// <summary>
        /// 阴性数量
        /// </summary>
        public int NegativeCount { get; set; }

        /// <summary>
        /// 阳性数量
        /// </summary>
        public int PositiveCount { get; set; }

        public string CENT_ID { get; set; }
    }

    /// <summary>
    /// 治疗统计信息
    /// </summary>
    public class TreatmentStatsView : IHasCenterInfo<string>
    {
        /// <summary>
        /// 月份
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 治疗数量
        /// </summary>
        public int Count { get; set; }

        public string CENT_ID { get; set; }
    }

    /// <summary>
    /// 在线治疗统计信息
    /// </summary>
    public class OnlineTreatmentStatsView : IHasCenterInfo<string>
    {
        /// <summary>
        /// 班次名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 班次ID
        /// </summary>
        public string ClassID { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortNum { get; set; }

        /// <summary>
        /// 治疗总人数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 治疗中人数
        /// </summary>
        public int TreatingCount { get; set; }

        public string CENT_ID { get; set; }
    }
}
