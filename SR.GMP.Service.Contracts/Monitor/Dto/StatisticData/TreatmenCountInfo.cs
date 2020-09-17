using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor.Dto.StatisticData
{
    /// <summary>
    /// 患者数量统计信息
    /// </summary>
    public class TreatmenCountInfo
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
    }

}
