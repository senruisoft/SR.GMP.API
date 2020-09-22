using AutoMapper;
using SR.GMP.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Base
{
     public abstract class ApplicationService
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
