using SR.GMP.DataEntity.Alarm;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace SR.GMP.Infrastructure.Repositories.Alarm
{
    public interface IAlarmRecordRepository : IRepository<GMP_ALARM_RECORD, Guid>
    {
        public void GetAlarmRecord(Expression<Func<GMP_ALARM_RECORD, bool>> query);
    }
}
