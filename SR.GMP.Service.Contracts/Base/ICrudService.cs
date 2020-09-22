using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Service.Contracts.Base
{
    public interface ICrudService<TKey, TGetOutputDto, TGetListOutputDto, TGetListInput, TCreateInput, TUpdateInput>
        where TGetOutputDto : IEntityDto<TKey>
        where TGetListOutputDto : IEntityDto<TKey>
    {
        Task<TGetOutputDto> GetAsync(TKey id);
        Task<List<TGetListOutputDto>> GetListAsync(TGetListInput input);
        Task<TGetOutputDto> CreateAsync(TCreateInput input);
        Task DeleteAsync(TKey id);
        Task<TGetOutputDto> UpdateAsync(TKey id, TUpdateInput input);
    }
}
