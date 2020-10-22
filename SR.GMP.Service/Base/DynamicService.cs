using Panda.DynamicWebApi;
using Panda.DynamicWebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Base
{
    /// <summary>
    /// 动态生成Controller API的抽象服务
    /// </summary>
    [DynamicWebApi]
    public abstract class DynamicService : IDynamicWebApi
    {
    }
}
