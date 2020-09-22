using AutoMapper;
using SR.GMP.DataEntity.Alarm;
using SR.GMP.Infrastructure.Repositories;
using SR.GMP.Infrastructure.Repositories.Alarm;
using SR.GMP.Infrastructure.UnitOfWork;
using SR.GMP.Service.Base;
using SR.GMP.Service.Contracts.Base;
using SR.GMP.Service.Contracts.Monitor;
using SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Service.Monitor
{
    public class AlarmConfigService : CrudAppService<GMP_ALARM_ITEM, Guid, AlarmItemDto, AlarmItemDto, GMP_ALARM_ITEM, GMP_ALARM_ITEM, GMP_ALARM_ITEM>
        , IAlarmConfigService
    {
        public AlarmConfigService(IMapper _mapper, IUnitOfWork unitOfWork, IAlarmRepository repository) 
            : base(_mapper, unitOfWork, repository)
        {
            
        }

        
    }
}
