using AutoMapper;
using SR.GMP.DataEntity.BaseEntity;
using SR.GMP.Infrastructure.Repositories;
using SR.GMP.Infrastructure.UnitOfWork;
using SR.GMP.Service.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Service.Base
{
    public abstract class CrudAppService<TEntity, TKey, TGetOutputDto, TGetListOutputDto, TGetListInput, TCreateInput, TUpdateInput>
        : ApplicationService, ICrudService<TKey, TGetOutputDto, TGetListOutputDto, TGetListInput, TCreateInput, TUpdateInput>
        where TEntity : Entity<TKey>
        where TGetOutputDto : IEntityDto<TKey>
        where TGetListOutputDto : IEntityDto<TKey>
    {
        IRepository<TEntity, TKey> repository;

        protected CrudAppService(IMapper _mapper, IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository) : base(_mapper, unitOfWork)
        {
            this.repository = repository;
        }

        public async Task<TGetOutputDto> GetAsync(TKey id)
        {
            var entity = await repository.FindAsync(id);
            return _mapper.Map<TEntity, TGetOutputDto>(entity);
        }

        public Task<List<TGetListOutputDto>> GetListAsync(TGetListInput input)
        {
            return null;
        }

        public Task<TGetOutputDto> CreateAsync(TCreateInput input)
        {
            return null;
        }

        public Task DeleteAsync(TKey id)
        {
            return null;
        }

        public Task<TGetOutputDto> UpdateAsync(TKey id, TUpdateInput input)
        {
            return null;
        }
    }
}
