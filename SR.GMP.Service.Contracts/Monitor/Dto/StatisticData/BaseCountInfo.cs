using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor.Dto.StatisticData
{
    /// <summary>
    /// 床位/患者/医护数量信息
    /// </summary>
    public class BaseCountInfo
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
    }
}
