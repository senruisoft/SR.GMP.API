using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor.Dto.StatisticData
{
    /// <summary>
    /// 在线治疗统计信息
    /// </summary>
    public class OnlineTreatmentStatsInfo
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
        /// 治疗总人数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 治疗中人数
        /// </summary>
        public int TreatingCount { get; set; }

        /// <summary>
        /// 治疗完成人数
        /// </summary>
        public int CompleteCount { get; set; }
    }
}
