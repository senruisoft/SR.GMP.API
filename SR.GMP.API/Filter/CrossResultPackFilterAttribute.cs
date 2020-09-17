using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SR.GMP.API.Filter
{
    /// <summary>
    /// 用于标记不经过结果封装过滤器的方法
    /// </summary>
    public class CrossResultPackAttribute : ResultFilterAttribute
    {
    }
}
