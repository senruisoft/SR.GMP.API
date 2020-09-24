using SR.GMP.Common.Model;
using SR.GMP.DataEntity.ViewModel;
using SR.GMP.Service.Contracts.Monitor.Dto.StatisticData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Service.Contracts.Monitor
{
    public interface IStatisticsDataService
    {
        /// <summary>
        /// 查询床位/患者/医护数量信息
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        Task<BaseCountInfo> GetBaseCountInfo(Guid cent_id);

        /// <summary>
        /// 查询设备信息
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        Task<List<EquipmentCountInfo>> GetEquipmentCountInfo(Guid cent_id);

        /// <summary>
        /// 查询在线治疗统计信息
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        Task<List<OnlineTreatmentStatsInfo>> GetOnlineTreatmentStatsInfo(Guid cent_id);

        /// <summary>
        /// 查询今年新增患者人数
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <param name="type">查询类型</param>
        Task<StatsInfo> GetNewPatientInfo(Guid cent_id, string type);
    }
}
