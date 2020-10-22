using AutoMapper;
using Panda.DynamicWebApi;
using Panda.DynamicWebApi.Attributes;
using SR.GMP.Infrastructure.UnitOfWork;
using SR.GMP.Service.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Base
{
    /// <summary>
    /// 应用抽象服务
    /// </summary>
    public abstract class ApplicationService : DynamicService, IApplicationService
    {
        public IMapper _mapper { get; }
        public IUnitOfWork unitOfWork { get; }

        public ApplicationService(IMapper _mapper, IUnitOfWork unitOfWork)
        {
            this._mapper = _mapper;
            this.unitOfWork = unitOfWork;
        }
    }
}
