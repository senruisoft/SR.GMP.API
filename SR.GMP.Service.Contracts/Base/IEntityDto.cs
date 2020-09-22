using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.Base
{
    public interface IEntityDto
    {

    }

    public interface IEntityDto<TKey>
    {
        TKey ID { get; set; }
    }
}
