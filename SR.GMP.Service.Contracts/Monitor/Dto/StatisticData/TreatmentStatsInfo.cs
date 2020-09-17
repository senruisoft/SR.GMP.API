using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor.Dto.StatisticData
{
    /// <summary>
    /// 治疗统计信息
    /// </summary>
    public class TreatmentStatsInfo
    {
        /// <summary>
        /// 月份
        /// </summary>
        public int Month { get; set; }

        /// <summary>
        /// 治疗数量
        /// </summary>
        public int Count { get; set; }
    }
}
