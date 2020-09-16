using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Common.Model
{
    public class ApiResult
    {
        public ApiResult()
        { }


        /// <summary>
        /// 判断返回消息
        /// </summary>
        /// <param name="result">影响行数</param>
        /// <param name="errormsg">错误消息</param>
        /// <param name="successmsg">成功消息</param>
        /// <returns></returns>
        public static ApiResult GetIfResult(int result, string errormsg = "", string successmsg = "")
        {
            return result < 1 ? GetError(ApiResultCode.SPECIFIED_ERROR, errormsg) :
                GetSuccess(successmsg);
        }

        /// <summary>
        /// 判断返回消息
        /// </summary>
        /// <param name="result">返回值</param>
        /// <param name="errormsg">错误消息</param>
        /// <param name="successmsg">成功消息</param>
        /// <returns></returns>
        public static ApiResult GetIfResult(dynamic result, string errormsg = "")
        {
            return result == null ? GetError(ApiResultCode.SPECIFIED_ERROR, errormsg, null) :
                GetSuccess(result);
        }


        public static ApiResult GetSuccess(dynamic data = null)
        {
            return new ApiResult(data);
        }
        public static ApiResult GetError(ApiResultCode code, string msg)
        {
            return new ApiResult(code, msg, null);
        }

        public static ApiResult GetError(ApiResultCode code, string msg, dynamic data)
        {
            return new ApiResult(code, msg, data);
        }

        public static ApiResult GetException(Exception ex)
        {
            var result = new ApiResult();
            result.Code = ApiResultCode.INTERFACE_INNER_INVOKE_ERROR;
            result.Message = ex.Message;
            if (ex.InnerException != null)
            {
                result.Message = result.Message + "\r\n" + ex.InnerException.Message;
            }
            return result;
        }

        public ApiResult(dynamic data, string msg = "操作成功")
        {
            Code = ApiResultCode.SUCCESS;
            Message = msg;
            Data = data;
        }

        public ApiResult(ApiResultCode code, string msg, dynamic data)
        {
            Code = code;
            Message = msg;
            Data = data;
        }

        public bool Success
        {
            get
            {
                return Code == ApiResultCode.SUCCESS;
            }
        }

        public ApiResultCode Code { get; set; }

        public string Message { get; set; }

        public dynamic Data { get; set; }

    }

}
