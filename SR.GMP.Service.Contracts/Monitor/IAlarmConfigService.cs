using SR.GMP.DataEntity.Alarm;
using SR.GMP.Service.Contracts.Base;
using SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor
{
    public interface IAlarmConfigService : ICrudService<Guid, AlarmItemDto, AlarmItemDto, GMP_ALARM_ITEM, GMP_ALARM_ITEM, GMP_ALARM_ITEM>
    {
    }
}
