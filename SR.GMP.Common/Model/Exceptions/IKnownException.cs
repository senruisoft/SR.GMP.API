using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Common.Model.Exceptions
{
    /// <summary>
    /// 已知错误接口
    /// </summary>
    public interface IKnownException
    {
        public string Message { get; }

        public int ErrorCode { get; }

        public object[] ErrorData { get; }
    }
}
