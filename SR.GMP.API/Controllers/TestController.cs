using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SR.GMP.Common.Model.Exceptions;
using SR.GMP.Service.Contracts.Test;

namespace SR.GMP.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        public ITestService testService;

        public TestController(ITestService testService) 
        {
            this.testService = testService;
        }

        /// <summary>
        /// 测试方法
        /// </summary>
        [HttpPost]
        public string Test(model model) 
        {
            return testService.test();
        }
    }

    public class model
    {
        public string name { get; set; }
        public int age { get; set; }
    }
}
