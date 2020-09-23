using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SR.GMP.DataEntity.BaseEntity;
using SR.GMP.Infrastructure.Repositories;
using SR.GMP.Infrastructure.UnitOfWork;
using SR.GMP.Service.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.Service.Base
{
    /// <summary>
    /// CRUD基础服务
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">主键类型</typeparam>
    /// <typeparam name="TGetOutputDto">输出Dto类型</typeparam>
    /// <typeparam name="TCreateInput">创建实体类型</typeparam>
    /// <typeparam name="TUpdateInput">更新实体类型</typeparam>
    public abstract class CrudAppService<TEntity, TKey, TGetOutputDto, TCreateInput, TUpdateInput>
        : ApplicationService, ICrudService<TKey, TGetOutputDto, TCreateInput, TUpdateInput>
        where TEntity : Entity<TKey>
        where TGetOutputDto : IEntityDto<TKey>
    {
        protected IRepository<TEntity, TKey> repository;

        protected CrudAppService(IMapper _mapper, IUnitOfWork unitOfWork, IRepository<TEntity, TKey> repository) : base(_mapper, unitOfWork)
        {
            this.repository = repository;
        }

        /// <summary>
        /// 根据主键查询实体
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns></returns>
        public virtual async Task<TGetOutputDto> GetAsync(TKey id)
        {
            var entity = await repository.FindAsync(id);
            return _mapper.Map<TEntity, TGetOutputDto>(entity);
        }

        /// <summary>
        /// 创建实体对象
        /// </summary>
        /// <param name="input">实体对象</param>
        /// <returns></returns>
        public virtual async Task<TGetOutputDto> CreateAsync(TCreateInput input)
        {
            var entity = _mapper.Map<TCreateInput, TEntity>(input);
            var result = await repository.AddAsync(entity);
            unitOfWork.Commit();
            return _mapper.Map<TEntity, TGetOutputDto>(result);
        }

        /// <summary>
        /// 根据主键删除实体
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns></returns>
        public virtual async Task<bool> DeleteAsync(TKey id)
        {
            var result = await repository.RemoveAsync(id);
            unitOfWork.Commit();
            return result;
        }

        /// <summary>
        /// 修改实体对象
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <param name="input">实体对象</param>
        /// <returns></returns>
        public virtual async Task<TGetOutputDto> UpdateAsync(TKey id, TUpdateInput input)
        {
            var entity = await repository.FindAsync(id);
            var result = repository.Update(entity, input);
            unitOfWork.Commit();
            return _mapper.Map<TEntity, TGetOutputDto>(result);

            //foreach (var item in typeof(TEntity).GetProperties())
            //{
            //    var property = input.GetType().GetProperty(item.Name);
            //    if (property != null)
            //    {
            //        object value = input.GetType().GetProperty(item.Name).GetValue(input, null);
            //        item.SetValue(result, value, null);
            //    }
            //}
            //repository.Update(result);
        }
    }
}
