using Microsoft.EntityFrameworkCore;
using SR.GMP.DataEntity.Alarm;
using SR.GMP.DataEntity.DictEnum;
using SR.GMP.DataEntity.Dictionary;
using SR.GMP.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Infrastructure.Repositories.Alarm
{
    public class AlarmRecordRepository : Repository<GMP_ALARM_RECORD, Guid>, IAlarmRecordRepository
    {

        public AlarmRecordRepository(GMPContext context) : base(context)
        {
        }

        /// <summary>
        /// 处理报警记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> HandleRecord(Guid id)
        {
            var entity = await FindAsync(id);
            if (entity == null) 
            {
                return false;
            }
            entity.STATE = AlarmStateEnum.已处理;
            entity.HANDLE_TIME = DateTime.Now;
            return true;
        }
    }
}
