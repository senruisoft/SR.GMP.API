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
        Task<OnlineStatsInfo> GetOnlineTreatmentStatsInfo(Guid cent_id);

        /// <summary>
        /// 查询治疗统计数据
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <param name="type">查询类型</param>
        Task<StatsInfo> GetNewPatientInfo(Guid cent_id, int type);

        /// <summary>
        /// 处理报警记录
        /// </summary>
        /// <param name="record_id">记录主键</param>
        /// <returns></returns>
        Task<bool> HandleAlarmRecord(Guid record_id);
    }
}
