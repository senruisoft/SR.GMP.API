using SR.GMP.Service.Contracts.Base;
using SR.GMP.Service.Contracts.System.Dto.Center;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Service.Contracts.System
{
    public interface ICenterService : ICrudService<Guid, CenterDto, CenterInput, CenterInput>
    {
        /// <summary>
        /// 根据机构ID查询中心列表
        /// 机构ID为空时查询所有中心
        /// </summary>
        /// <param name="inst_id">机构ID</param>
        /// <returns></returns>
        Task<List<CenterDto>> GetListAsync(Guid? inst_id);
    }
}
