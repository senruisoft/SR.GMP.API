using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SR.GMP.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SR.GMP.API.Filter
{
    /// <summary>
    /// 全局返回结果过滤器
    /// 封装ApiResult
    /// </summary>
    public class GlobalResultFilterAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            base.OnResultExecuting(context);
            if (context.Filters.Where(filter => filter.GetType() == typeof(CrossResultPackAttribute)).Count() == 0) 
            {
                var result = context.Result as ObjectResult;
                if (result != null && !(result.Value is ApiResult)) 
                {
                    result.Value = ApiResult.GetSuccess(result.Value);
                }
            }
        }
    }
}
