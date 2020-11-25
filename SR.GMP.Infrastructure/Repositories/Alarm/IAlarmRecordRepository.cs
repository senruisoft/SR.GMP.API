using SR.GMP.DataEntity.Alarm;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Infrastructure.Repositories.Alarm
{
    public interface IAlarmRecordRepository : IRepository<GMP_ALARM_RECORD, Guid>
    {
        /// <summary>
        /// 处理报警记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> HandleRecord(Guid id);
    }
}
