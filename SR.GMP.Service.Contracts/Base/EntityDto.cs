using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.Base
{
    public abstract class EntityDto : IEntityDto
    {

    }

    public abstract class EntityDto<TKey> : EntityDto, IEntityDto<TKey>
    {
        public TKey ID { get; set; }
    }
}
