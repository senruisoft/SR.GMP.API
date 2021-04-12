using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SR.GMP.Common.Model;
using SR.GMP.Common.Model.Exceptions;
using SR.GMP.DataEntity.Alarm;
using SR.GMP.DataEntity.DictEnum;
using SR.GMP.DataEntity.System;
using SR.GMP.DataEntity.ViewModel;
using SR.GMP.EFCore;
using SR.GMP.Infrastructure.Repositories;
using SR.GMP.Infrastructure.Repositories.Alarm;
using SR.GMP.Infrastructure.UnitOfWork;
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
        IAlarmRepository alarmRepository;
        IAlarmRecordRepository alarmRecordRepository;
        IUnitOfWork unitOfWork;

        public StatisticsDataService(IMapper _mapper, GMPContext dbcontext, IRepository<SYS_INST_CENTER, Guid> centRepository,
            IAlarmRepository alarmRepository, IAlarmRecordRepository alarmRecordRepository, IUnitOfWork unitOfWork)
        {
            this.dbcontext = dbcontext;
            this.centRepository = centRepository;
            this._mapper = _mapper;
            this.alarmRepository = alarmRepository;
            this.alarmRecordRepository = alarmRecordRepository;
            this.unitOfWork = unitOfWork;
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
        public async Task<OnlineStatsInfo> GetOnlineTreatmentStatsInfo(Guid cent_id)
        {
            var center = centRepository.Find(cent_id);
            if (center == null)
            {
                throw new ServerException("中心信息错误！");
            }
            var centName = await dbcontext.SYS_INST_CENTER.Where(x => x.ID == cent_id).Select(x => x.NAME).FirstOrDefaultAsync();

            // 视图数据
            var viewData = await dbcontext.Set<OnlineTreatmentStatsView>().Where(x => x.CENT_ID == center.EXT_ID).OrderBy(x => x.SortNum).ToListAsync();
            var treatment_stats = _mapper.Map<List<OnlineTreatmentStatsView>, List<OnlineTreatmentStatsInfo>>(viewData);

            // 当天报警记录
            var alarm_record = await dbcontext.GMP_ALARM_RECORD.Where(x => x.CENT_ID == cent_id 
                && x.DATA_RECORD_TIME >= DateTime.Now.Date).Include(x => x.ALARM_RECORD_DATA_LIST).OrderByDescending(x => x.PRIORITY).ToListAsync();
            var alarm_list = _mapper.Map<List<GMP_ALARM_RECORD>, List<AlarmRecordDto>>(alarm_record);

            //查询今天Pad的报警记录
            var pad_alarm_record = await dbcontext.Set<PadPoliceView>().Where(i => i.CENT_ID == center.EXT_ID && i.CREATE_AT >= DateTime.Now.Date).ToListAsync();
            var pad_alarm_list = _mapper.Map<List<PadPoliceView>, List<AlarmRecordDto>>(pad_alarm_record);
            
            //获取报警项目信息
            pad_alarm_list.ForEach(i => {
                var alarmItem = dbcontext.GMP_ALARM_ITEM
                .Where(a => a.ITEM_NAME == i.POLICE_TYPE && a.STATE == StateEnum.启用)
                .Select(a => new PadAlarmItem()
                {
                    ALARM_ITEM_ID = a.ID,
                    ITEM_NAME = a.ITEM_NAME,
                    TREAT_MEASURE = a.TREAT_MEASURE,
                    TREAT_PROCESS = a.TREAT_PROCESS
                })
                .FirstOrDefault();

                //未处理带出知识库内容
                if (i.STATE == AlarmStateEnum.未处理 && alarmItem != null)
                {
                    i.TREAT_MEASURE = alarmItem.TREAT_MEASURE;
                    i.TREAT_PROCESS = alarmItem.TREAT_PROCESS;
                }
                i.ALARM_ITEM_ID = alarmItem == null ? Guid.Empty : alarmItem.ALARM_ITEM_ID;
                alarm_list.Add(i); 
            });

            // 查询报警规则信息
            var alarm_items = alarmRepository.GetAlarmItemsInfo(cent_id, alarm_list.Select(x => x.ALARM_ITEM_ID).Distinct().ToList());

            // 报警配置项目
            var alarmItems = dbcontext.GMP_ALARM_ITEM.Where(x => x.CENT_ID == cent_id && x.STATE == StateEnum.启用).OrderByDescending(x => x.PRIORITY).Select(x => new
            {
                item_id = x.ID,
                item_name = x.ITEM_NAME,
            }).ToList();

            foreach (var item in treatment_stats)
            {
                item.AlarmItems = (from alarm in alarmItems
                                   join record in alarm_list.Where(x => x.CLASS_ID == item.ClassID).GroupBy(x => x.ALARM_ITEM_ID)
                                   on alarm.item_id equals record.Key into records
                                   from record in records.DefaultIfEmpty()
                                   select new ScheClassAlarmInfo
                                   {
                                       AlarmName = alarm.item_name,
                                       AlarmCount = record == null ? 0 : record.Count()
                                   }).ToList();
                item.AlarmTotalCount = item.AlarmItems.Sum(x => x.AlarmCount);
            }
            var result = new OnlineStatsInfo(treatment_stats, alarm_list, alarm_items, centName);
            return result;
        }

        /// <summary>
        /// 查询查询治疗统计数据
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <param name="type">查询类型</param>
        public async Task<StatsInfo> GetNewPatientInfo(Guid cent_id, int type) 
        {
            var center = centRepository.Find(cent_id);
            if (center == null)
            {
                throw new ServerException("中心信息错误！");
            }
            string CountViewName = "";
            string StatsViewName = "";
            switch (type) 
            {
                case 0:
                    CountViewName = "view_YearNewPatientCountInfo";
                    StatsViewName = "view_YearNewPatientMonthlyCountInfo";
                    break;
                case 1:
                    CountViewName = "view_YearPatientCountInfo";
                    StatsViewName = "view_YearPatientMonthlyCountInfo";
                    break;
                case 2:
                    CountViewName = "view_YearTreatCountInfo";
                    StatsViewName = "view_YearTreatMonthlyCountInfo";
                    break;
                default:
                    throw new ServerException("查询类型错误！");
            }
            string CountQuery = string.Format("select * from  dbo.{1} where CENT_ID = '{0}'", center.EXT_ID, CountViewName);
            string StatsQuery = string.Format("select * from  dbo.{1} where CENT_ID = '{0}' order by Month", center.EXT_ID, StatsViewName);
            var TreatmenCount =  await dbcontext.Set<TreatmenCountView>().FromSqlRaw(CountQuery).ToListAsync();
            var TreatmentStats = await dbcontext.Set<TreatmentStatsView>().FromSqlRaw(StatsQuery).ToListAsync();
            var result = new StatsInfo 
            {
                treatmenCountInfo = _mapper.Map<TreatmenCountView, TreatmenCountInfo>(TreatmenCount.FirstOrDefault()),
                treatmentStatsInfo = _mapper.Map< List<TreatmentStatsView>, List<TreatmentStatsInfo>>(TreatmentStats)
            };
            return result;
        }

        /// <summary>
        /// 处理报警记录
        /// </summary>
        /// <param name="record_id"></param>
        /// <returns></returns>
        public async Task<bool> HandleAlarmRecord(Guid record_id) 
        {
            var result = await alarmRecordRepository.HandleRecord(record_id);
            if (!result)
            {
                throw new ServerException("报警记录不存在！");
            }
            unitOfWork.Commit();
            return result;
        }

        /// <summary>
        /// 获取手动报警文件列表
        /// </summary>
        /// <param name="police_id"></param>
        /// <returns></returns>
        public async Task<List<PoliceFileOutput>> GetPoliceFileAsync(string police_id)
        {
            var result = await dbcontext
                .Set<PadPoliceFileView>()
                .Where(x => x.POLICE_ID == police_id)
                .Select(x => new PoliceFileOutput() { 
                    ID = x.ID, 
                    POLICE_ID = x.POLICE_ID, 
                    FILE_CONTENT = x.FILE_CONTENT 
                })
                .ToListAsync();
            return result;
        }

    }
}
