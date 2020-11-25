using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SR.GMP.API.Filter;
using SR.GMP.Common.Model;
using SR.GMP.Service.Contracts.Monitor;
using SR.GMP.Service.Contracts.Monitor.Dto.StatisticData;

namespace SR.GMP.API.Controllers.Monitor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StatisticsDataController : ControllerBase
    {
        public IStatisticsDataService dataService;

        public StatisticsDataController(IStatisticsDataService dataService)
        {
            this.dataService = dataService;
        }

        /// <summary>
        /// 查询床位/患者/医护数量信息
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<BaseCountInfo> GetBaseCountInfo(Guid cent_id)
        {
            return await dataService.GetBaseCountInfo(cent_id);
        }

        /// <summary>
        /// 查询设备信息
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<List<EquipmentCountInfo>> GetEquipmentCountInfo(Guid cent_id)
        {
            return await dataService.GetEquipmentCountInfo(cent_id);
        }

        /// <summary>
        /// 查询在线治疗统计信息
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<OnlineStatsInfo> GetOnlineTreatmentStatsInfo(Guid cent_id)
        {
            return await dataService.GetOnlineTreatmentStatsInfo(cent_id);
        }

        /// <summary>
        /// 查询治疗统计数据
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <param name="type">查询类型 0:今年新增患者 1：今年治疗统计 2：治疗例数</param>
        [HttpGet]
        public async Task<StatsInfo> GetNewPatientInfo(Guid cent_id, int type)
        {
            return await dataService.GetNewPatientInfo(cent_id, type);
        }


        /// <summary>
        /// 处理报警记录
        /// </summary>
        /// <param name="record_id">记录主键</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<bool> HandleAlarmRecord(Guid record_id)
        {
            return await dataService.HandleAlarmRecord(record_id);
        }
    }

}
