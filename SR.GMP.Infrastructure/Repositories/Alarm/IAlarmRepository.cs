using SR.GMP.DataEntity.Alarm;
using SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Infrastructure.Repositories.Alarm
{
    public interface IAlarmRepository : IRepository<GMP_ALARM_ITEM, Guid>
    {
        /// <summary>
        /// 获取报警规则信息
        /// </summary>
        /// <param name="cent_id"></param>
        /// <param name="idList"></param>
        /// <param name="containRule"></param>
        /// <returns></returns>
        public List<AlarmItemDto> GetAlarmItemsInfo(Guid cent_id, List<Guid> idList = null, bool containRule = false);

        /// <summary>
        /// 删除报警规则
        /// </summary>
        /// <param name="item_id"></param>
        /// <returns></returns>
        public Task<bool> DeleteAlarmItem(Guid item_id);

        /// <summary>
        /// 更新报警规则
        /// </summary>
        /// <param name="item_id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task<GMP_ALARM_ITEM> UpdateAlarmItem(Guid item_id, AlarmItemCreatInput input);

        /// <summary>
        /// 查询监测项字典
        /// </summary>
        /// <returns></returns>
        public AlarmMonitorDic GetMonitorItemDic();
    }
}
