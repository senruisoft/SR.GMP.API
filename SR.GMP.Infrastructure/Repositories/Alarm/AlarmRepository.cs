using Microsoft.EntityFrameworkCore;
using SR.GMP.DataEntity.Alarm;
using SR.GMP.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Infrastructure.Repositories.Alarm
{
    public class AlarmRepository : Repository<GMP_ALARM_ITEM, Guid>, IAlarmRepository
    {
        public AlarmRepository(GMPContext context) : base(context)
        {
        }
    }

}
