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


        /// <summary>
        /// 查询今年新增患者人数
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <param name="type">查询类型</param>
        public async Task<StatsInfo> GetNewPatientInfo(Guid cent_id, string type) 
        {
            var center = centRepository.Find(cent_id);
            if (center == null)
            {
                throw new ServerException("中心信息错误！");
            }
            switch (type) 
            {
                case "":
                    break;
            }
            var TreatmenCount =  await dbcontext.TreatmenCountView.FromSqlInterpolated($"select * from  dbo.view_YearNewPatientCountInfo where CENT_ID = {center.EXT_ID}").ToListAsync();
            var TreatmentStats = await dbcontext.TreatmentStatsView.FromSqlInterpolated($"select * from  dbo.view_YearNewPatientMonthlyCountInfo where CENT_ID = {center.EXT_ID} order by Month").ToListAsync();
            var result = new StatsInfo 
            {
                treatmenCountInfo = _mapper.Map<TreatmenCountView, TreatmenCountInfo>(TreatmenCount.FirstOrDefault()),
                treatmentStatsInfo = _mapper.Map< List<TreatmentStatsView>, List<TreatmentStatsInfo>>(TreatmentStats)
            };
            return result;
        }
    }
}
