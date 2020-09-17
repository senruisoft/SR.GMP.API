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
    /// 全局异常过滤器
    /// 区分系统异常和逻辑异常
    /// </summary>
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            IKnownException knownException = context.Exception as IKnownException;
            if (knownException == null)
            {
                //var logger = context.HttpContext.RequestServices.GetService<ILogger<MyExceptionFilterAttribute>>();
                //logger.LogError(context.Exception, context.Exception.Message);
                context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
            }
            context.Result = new JsonResult(ApiResult.GetError(ApiResultCode.DATA_IS_WRONG, context.Exception.Message))
            {
                ContentType = "application/json; charset=utf-8"
            };
        }
    }
}
