using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Common.Model.Exceptions
{
    /// <summary>
    /// 全局服务异常
    /// </summary>
    public class ServerException : Exception, IKnownException
    {
        public ServerException(string message, int errorCode = 0, params object[] errorData) : base(message)
        {
            this.ErrorCode = errorCode;
            this.ErrorData = errorData;
        }

        public int ErrorCode { get; private set; }

        public object[] ErrorData { get; private set; }
    }
}
