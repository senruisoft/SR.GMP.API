using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SR.GMP.Common.Model.Exceptions;
using SR.GMP.DataEntity.System;
using SR.GMP.DataEntity.ViewModel;
using SR.GMP.EFCore;
using SR.GMP.Infrastructure.Repositories;
using SR.GMP.Service.Base;
using SR.GMP.Service.Contracts.Base;
using SR.GMP.Service.Contracts.Monitor.Dto.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Service.Monitor
{
    public class GeneralViewService : DynamicService
    {
        IMapper _mapper;
        GMPContext dbcontext;
        IHttpService httpService;
        IRepository<SYS_INST_CENTER, Guid> centRepository;

        public GeneralViewService(IMapper _mapper, GMPContext dbcontext, IHttpService httpService, IRepository<SYS_INST_CENTER, Guid> centRepository)
        {
            this._mapper = _mapper;
            this.dbcontext = dbcontext;
            this.httpService = httpService;
            this.centRepository = centRepository;
        }

        /// <summary>
        /// 查询患者基本信息
        /// </summary>
        /// <param name="patient_ext_id">患者外部ID</param>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        public async Task<PatientGeneralInfo> GetPatientGeneralInfo(Guid cent_id, string patient_ext_id)
        {
            //var data = await httpService.SendAsync<dynamic>(HttpMethod.Post, "http://localhost:50610/api/pad/dictionary/GetFrequencyDict", new { st = 1 });
            var center = centRepository.Find(cent_id);
            if (center == null)
            {
                throw new ServerException("中心信息错误！");
            }
            var result = await dbcontext.Set<PatientGeneralView>().Where(x => x.PATIENT_ID == patient_ext_id && x.CENT_ID == center.EXT_ID && x.TRAETMENT_DATE == DateTime.Now.Date).FirstOrDefaultAsync();
            return _mapper.Map<PatientGeneralView, PatientGeneralInfo>(result);
        }

        /// <summary>
        /// 查询患者治疗基本信息
        /// </summary>
        /// <param name="patient_ext_id">患者外部ID</param>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        public async Task<PatientBasicTreatInfo> GetPatientBasicTreatInfo(Guid cent_id, string patient_ext_id)
        {
            var center = centRepository.Find(cent_id);
            if (center == null)
            {
                throw new ServerException("中心信息错误！");
            }
            
            var data = await dbcontext.Set<PatientBasicTreatView>().Where(x => x.PATIENT_ID == patient_ext_id && x.CENT_ID == center.EXT_ID).OrderByDescending(x => x.TRAETMENT_DATE).Take(7).ToListAsync();
            PatientBasicTreatInfo result = new PatientBasicTreatInfo(data);
            return result;
        }


        /// <summary>
        /// 查询患者监测数据
        /// </summary>
        /// <param name="cent_id">中心ID</param>
        /// <param name="patient_ext_id">患者外部ID</param>
        /// <returns></returns>
        public async Task<TreatMonitorData> GetPatientMonitorData(Guid cent_id, string patient_ext_id)
        {
            var center = centRepository.Find(cent_id);
            if (center == null)
            {
                throw new ServerException("中心信息错误！");
            }
            TreatMonitorData result = new TreatMonitorData();
            // 查询设备检测数据
            var data = await dbcontext.Set<DeviceTreatDataView>().Where(x => x.PATIENT_ID == patient_ext_id && x.CENT_ID == center.EXT_ID 
                && x.TRAETMENT_DATE == DateTime.Now.Date).OrderByDescending(x => x.RECORD_TIME).FirstOrDefaultAsync();
            var IS_UP = await dbcontext.Set<DeviceTreatDataView>().Where(x => x.PATIENT_ID == patient_ext_id && x.CENT_ID == center.EXT_ID
                && x.TRAETMENT_DATE == DateTime.Now.Date && x.IS_UP == true).FirstOrDefaultAsync() != null;
            var IS_DOWN = await dbcontext.Set<DeviceTreatDataView>().Where(x => x.PATIENT_ID == patient_ext_id && x.CENT_ID == center.EXT_ID
                && x.TRAETMENT_DATE == DateTime.Now.Date && x.IS_DOWN == true).FirstOrDefaultAsync() != null;
            if (data != null) 
            {
                result.DEFAULT_TREAT_TIME = data.DEFAULT_TREAT_TIME;
                result.UF = data.UF;
                if (IS_DOWN)
                {
                    result.ELAPSEDTIME = data.DEFAULT_TREAT_TIME;
                }
                else if (IS_UP)
                {
                    if (DateTime.Now > data.RECORD_TIME)
                    {
                        result.ELAPSEDTIME = data.ELAPSEDTIME + (DateTime.Now - data.RECORD_TIME).Value.Seconds;
                        result.ELAPSEDTIME = result.ELAPSEDTIME > result.DEFAULT_TREAT_TIME ? result.DEFAULT_TREAT_TIME : result.ELAPSEDTIME;
                    }
                    else
                    {
                        result.ELAPSEDTIME = data.ELAPSEDTIME;
                    }
                }
            }
            // 查询体征监测数据
            var monitorData = await dbcontext.Set<MonitorDataView>().Where(x => x.PATIENT_ID == patient_ext_id && x.CENT_ID == center.EXT_ID
             && x.TRAETMENT_DATE == DateTime.Now.Date).OrderBy(x => x.RECORD_TIME).ToListAsync();
            result.MonitorDataList = _mapper.Map<List<MonitorDataView>, List<MonitorDataDto>>(monitorData);
            return result;
        }

        /// <summary>
        /// 查询患者治疗基本信息
        /// </summary>
        /// <param name="patient_ext_id">患者外部ID</param>
        /// <param name="cent_id">中心ID</param>
        /// <returns></returns>
        public async Task<List<TreatOrderDto>> GetPatientTreatOrderInfo(Guid cent_id, string patient_ext_id)
        {
            var center = centRepository.Find(cent_id);
            if (center == null)
            {
                throw new ServerException("中心信息错误！");
            }

            var result = await dbcontext.Set<TreatOrderView>().Where(x => x.PATIENT_ID == patient_ext_id && x.CENT_ID == center.EXT_ID && x.TRAETMENT_DATE == DateTime.Now.Date).ToListAsync();
            return _mapper.Map<List<TreatOrderView>, List<TreatOrderDto>>(result);
        }
    }
}
