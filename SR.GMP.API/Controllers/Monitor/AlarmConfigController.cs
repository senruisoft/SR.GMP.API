using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SR.GMP.Service.Contracts.Monitor;
using SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig;

namespace SR.GMP.API.Controllers.Monitor
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlarmConfigController : ControllerBase
    {
        public IAlarmConfigService alarmService;

        public AlarmConfigController(IAlarmConfigService alarmService)
        {
            
            this.alarmService = alarmService;
        }

        /// <summary>
        /// 查询床位/患者/医护数量信息
        /// </summary>
        /// <param name="id">中心ID</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<AlarmItemDto> GetAlarmInfo(Guid id)
        {
            
            return await alarmService.GetAsync(id);
        }
    }
}
