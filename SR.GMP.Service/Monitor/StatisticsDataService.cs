using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SR.GMP.Common.Model;
using SR.GMP.Common.Model.Exceptions;
using SR.GMP.DataEntity.System;
using SR.GMP.DataEntity.ViewModel;
using SR.GMP.EFCore;
using SR.GMP.Infrastructure.Repositories;
using SR.GMP.Service.Contracts.Monitor;
using SR.GMP.Service.Contracts.Monitor.Dto.StatisticData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Service.Monitor
{
    public class StatisticsDataService : IStatisticsDataService
    {
        IMapper _mapper;
        GMPContext dbcontext;
        IRepository<SYS_INST_CENTER, Guid> centRepository;

        public StatisticsDataService(IMapper _mapper, GMPContext dbcontext, IRepository<SYS_INST_CENTER, Guid> centRepository) 
        {
            this.dbcontext = dbcontext;
            this.centRepository = centRepository;
            this._mapper = _mapper;
        }

        /// <summary>
        /// 查询床位/患者/医护数量信息
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        public async Task<BaseCountInfo> GetBaseCountInfo(Guid cent_id) 
        {
            var center = centRepository.Find(cent_id);
            if (center == null) 
            {
                throw new ServerException("中心信息错误！");
            }
            var result = await dbcontext.Set<BaseCountView>().Where(x => x.CENT_ID == center.EXT_ID).FirstOrDefaultAsync();
            return _mapper.Map<BaseCountView, BaseCountInfo>(result);
        }

        /// <summary>
        /// 查询设备信息
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        public async Task<List<EquipmentCountInfo>> GetEquipmentCountInfo(Guid cent_id)
        {
            var center = centRepository.Find(cent_id);
            if (center == null)
            {
                throw new ServerException("中心信息错误！");
            }
            var result = await dbcontext.Set<EquipmentCountView>().Where(x => x.CENT_ID == center.EXT_ID).ToListAsync();
            return _mapper.Map<List<EquipmentCountView>, List<EquipmentCountInfo>>(result);
        }

        /// <summary>
        /// 查询患者数量统计信息
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        public async Task<TreatmenCountInfo> GetTreatmenCountInfo(Guid cent_id)
        {
            var center = centRepository.Find(cent_id);
            if (center == null)
            {
                throw new ServerException("中心信息错误！");
            }
            var result = await dbcontext.Set<TreatmenCountView>().Where(x => x.CENT_ID == center.EXT_ID).FirstOrDefaultAsync();
            return _mapper.Map<TreatmenCountView, TreatmenCountInfo>(result);
        }

        /// <summary>
        /// 查询治疗统计信息
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        public async Task<List<TreatmentStatsInfo>> GetTreatmentStatsInfo(Guid cent_id)
        {
            var center = centRepository.Find(cent_id);
            if (center == null)
            {
                throw new ServerException("中心信息错误！");
            }
            var result = await dbcontext.Set<TreatmentStatsView>().Where(x => x.CENT_ID == center.EXT_ID).OrderBy(x => x.Month).ToListAsync();
            return _mapper.Map<List<TreatmentStatsView>, List<TreatmentStatsInfo>>(result);
        }

        /// <summary>
        /// 查询在线治疗统计信息
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        public async Task<List<OnlineTreatmentStatsInfo>> GetOnlineTreatmentStatsInfo(Guid cent_id)
        {
            var center = centRepository.Find(cent_id);
            if (center == null)
            {
                throw new ServerException("中心信息错误！");
            }
            var result = await dbcontext.Set<OnlineTreatmentStatsView>().Where(x => x.CENT_ID == center.EXT_ID).OrderBy(x => x.SortNum).ToListAsync();
            return _mapper.Map<List<OnlineTreatmentStatsView>, List<OnlineTreatmentStatsInfo>>(result);
        }
    }
}
