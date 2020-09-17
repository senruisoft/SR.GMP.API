using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor.Dto.StatisticData
{
    /// <summary>
    /// 设备信息
    /// </summary>
    public class EquipmentCountInfo
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
        public string EquipmentCount { get; set; }
    }
}
