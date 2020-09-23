using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SR.GMP.Common.Extensions;
using SR.GMP.DataEntity.DictEnum;
using SR.GMP.DataEntity.System;
using SR.GMP.Infrastructure.Repositories;
using SR.GMP.Infrastructure.UnitOfWork;
using SR.GMP.Service.Base;
using SR.GMP.Service.Contracts.System;
using SR.GMP.Service.Contracts.System.Dto.Center;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Service.System
{
    public class CenterService : CrudAppService<SYS_INST_CENTER, Guid, CenterDto, CenterInput, CenterInput>, ICenterService
    {
        public CenterService(IMapper _mapper, IUnitOfWork unitOfWork, IRepository<SYS_INST_CENTER, Guid> repository)
            : base(_mapper, unitOfWork, repository)
        {

        }

        /// <summary>
        /// 根据机构ID查询中心列表
        /// 机构ID为空时查询所有中心
        /// </summary>
        /// <param name="inst_id">机构ID</param>
        /// <returns></returns>
        public async Task<List<CenterDto>> GetListAsync(Guid? inst_id)
        {
            var result = await repository.GetQueryable(x => x.STATE == StateEnum.启用).WhereIf(inst_id != null, x => x.INST_ID == inst_id).OrderBy(x => x.SORT_CODE).ToListAsync();
            return _mapper.Map<List<SYS_INST_CENTER>, List<CenterDto>>(result);
        }
    }
}
