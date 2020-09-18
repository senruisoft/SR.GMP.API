using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR.GMP.API.Filter
{
    public class LogFilterAttribute : ActionFilterAttribute
    {
        private readonly ILogger<LogFilterAttribute> _logger;

        public LogFilterAttribute(ILogger<LogFilterAttribute> logger) 
        {
            _logger = logger;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);

            var Request = context.HttpContext.Request;
            string requestBody = string.Empty;
            if (Request.ContentLength != null && Request.ContentLength.Value > 0)
            {
                Request.Body.Position = 0;
                using (var reader = new StreamReader(context.HttpContext.Request.Body, Encoding.UTF8, true, 1024, true))
                {
                    requestBody = reader.ReadToEnd();
                }
            }
            _logger.LogInformation(context.Exception, "\r\n Method：{Method} \r\n Path：{Path} \r\n Query：{Query} \r\n Body：{Body} \r\n",
             Request.Method, Request.Path, Request.QueryString, requestBody);
        }
    }
}
