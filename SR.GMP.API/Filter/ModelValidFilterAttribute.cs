using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SR.GMP.Common.Model;
using SR.GMP.Common.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SR.GMP.API.Filter
{
    /// <summary>
    /// 模型验证过滤器
    /// </summary>
    public class ModelValidFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                foreach (var item in context.ModelState.Values)
                {
                    if (item.Errors.Any()) 
                    {
                        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Result = new ObjectResult(ApiResult.GetError(ApiResultCode.DATA_IS_WRONG, item.Errors.First().ErrorMessage));
                        return;
                    }
                }
            }
        }
    }
}
