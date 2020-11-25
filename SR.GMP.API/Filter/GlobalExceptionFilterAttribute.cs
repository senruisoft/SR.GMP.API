using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using SR.GMP.Common.Model;
using SR.GMP.Common.Model.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.API.Filter
{
    /// <summary>
    /// 全局异常过滤器
    /// 区分系统异常和逻辑异常
    /// </summary>
    public class GlobalExceptionFilterAttribute : ExceptionFilterAttribute
    {
        private readonly ILogger<GlobalExceptionFilterAttribute> _logger;

        public GlobalExceptionFilterAttribute(ILogger<GlobalExceptionFilterAttribute> logger) 
        {
            _logger = logger;
        }

        public override void OnException(ExceptionContext context)
        {
            base.OnException(context);
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
            var Request = context.HttpContext.Request;
            string requestBody = string.Empty;
            if (Request.ContentLength != null && Request.ContentLength.Value > 0)
            {
                Request.Body.Position = 0;
                using (var reader = new StreamReader(context.HttpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    requestBody = reader.ReadToEndAsync().Result;
                }
            }
            _logger.LogError(context.Exception, "\r\n Method：{Method} \r\n Path：{Path} \r\n Query：{Query}  \r\n Body：{Body} \r\n Error：{Error} \r\n",
               Request.Method, Request.Path, Request.QueryString, requestBody, context.Exception);
            context.Result = new JsonResult(ApiResult.GetError(ApiResultCode.DATA_IS_WRONG, context.Exception.Message +
                (context.Exception.InnerException == null ? "" : context.Exception.InnerException.Message)))
            {
                ContentType = "application/json; charset=utf-8"
            };
        }
    }
}
