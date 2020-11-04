using SR.GMP.DataEntity.Alarm;
using SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Infrastructure.Repositories.Alarm
{
    public interface IAlarmRepository : IRepository<GMP_ALARM_ITEM, Guid>
    {
        /// <summary>
        /// 获取报警规则信息
        /// </summary>
        /// <param name="idList"></param>
        /// <returns></returns>
        public List<AlarmItemDto> GetAlarmItemsInfo(List<Guid> idList);
    }
}
