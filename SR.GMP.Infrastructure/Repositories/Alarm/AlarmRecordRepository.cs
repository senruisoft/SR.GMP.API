using Microsoft.EntityFrameworkCore;
using SR.GMP.DataEntity.Alarm;
using SR.GMP.DataEntity.Dictionary;
using SR.GMP.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace SR.GMP.Infrastructure.Repositories.Alarm
{
    public class AlarmRecordRepository : Repository<GMP_ALARM_RECORD, Guid>, IAlarmRecordRepository
    {
        IRepository<GMP_EVENT_ITEM, int> eventItemRepository;
        IRepository<GMP_MONITOR_ITEM, int> monitorItemRepository;

        public AlarmRecordRepository(GMPContext context) : base(context)
        {
        }

        public void GetAlarmRecord(Expression<Func<GMP_ALARM_RECORD, bool>> query)
        {
            this.GetQueryable(query).Include(x => x.ALARM_RECORD_DATA_LIST).Select(x => new 
            {

            });
            
        }
    }
}
