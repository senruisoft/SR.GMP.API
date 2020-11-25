using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SR.GMP.Common.Model.Exceptions;
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Service.Monitor
{
    public class AlarmConfigService : CrudAppService<GMP_ALARM_ITEM, Guid, AlarmItemDto, AlarmItemCreatInput, AlarmItemCreatInput>
        , IAlarmConfigService
    {
        public AlarmConfigService(IMapper _mapper, IUnitOfWork unitOfWork, IAlarmRepository repository) 
            : base(_mapper, unitOfWork, repository)
        {
            
        }

        /// <summary>
        /// 查询监测项字典
        /// </summary>
        /// <returns></returns>
        public AlarmMonitorDic GetMonitorItemDic() 
        {
            return ((IAlarmRepository)repository).GetMonitorItemDic();
        }

        /// <summary>
        /// 根据中心ID查询报警配置列表
        /// </summary>
        /// <param name="cent_id">机构ID</param>
        /// <returns></returns>
        public List<AlarmItemDto> GetListAsync(Guid cent_id)
        {
            return ((IAlarmRepository)repository).GetAlarmItemsInfo(cent_id, null, true);
        }

        /// <summary>
        /// 删除报警配置记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public override async Task<bool> DeleteAsync(Guid id)
        {
            var result = await ((IAlarmRepository)repository).DeleteAlarmItem(id);
            if (!result) 
            {
                throw new ServerException("报警项记录为空！");
            }
            unitOfWork.Commit();
            return result;
        }

        /// <summary>
        /// 更新报警配置记录
        /// </summary>
        /// <param name="id"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public override async Task<AlarmItemDto> UpdateAsync(Guid id, AlarmItemCreatInput input)
        {
            var result = await ((IAlarmRepository)repository).UpdateAlarmItem(id, input);
            if (result == null) 
            {
                throw new ServerException("报警项记录为空！");
            }
            unitOfWork.Commit();
            return _mapper.Map<GMP_ALARM_ITEM, AlarmItemDto>(result);
        }
    }
}
