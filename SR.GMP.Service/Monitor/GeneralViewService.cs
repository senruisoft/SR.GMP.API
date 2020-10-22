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
    }
}
