using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Service.Contracts.Base
{
    public interface ICrudService<TKey, TGetOutputDto, TCreateInput, TUpdateInput> : IApplicationService
        where TGetOutputDto : IEntityDto<TKey>
    {
        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns></returns>
        Task<TGetOutputDto> GetAsync(TKey id);

        /// <summary>
        /// 创建实体对象
        /// </summary>
        /// <param name="input">实体对象</param>
        /// <returns></returns>
        Task<TGetOutputDto> CreateAsync(TCreateInput input);

        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns></returns>
        Task<bool> DeleteAsync(TKey id);

        /// <summary>
        /// 修改实体对象
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <param name="input">实体对象</param>
        /// <returns></returns>
        Task<TGetOutputDto> UpdateAsync(TKey id, TUpdateInput input);
    }
}
