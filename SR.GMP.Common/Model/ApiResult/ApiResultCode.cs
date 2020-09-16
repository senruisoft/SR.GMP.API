using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Common.Model
{
    public enum ApiResultCode
    {
        /* 成功状态码 */
        SUCCESS = 200,

        /* 参数错误：10001-19999 */
        /// <summary>
        /// 参数无效
        /// </summary>
        PARAM_IS_INVALID = 10010,

        /// <summary>
        /// 参数为空
        /// </summary>
        PARAM_IS_BLANK = 10020,

        /// <summary>
        /// 参数类型错误
        /// </summary>
        PARAM_TYPE_BIND_ERROR = 10030,

        /// <summary>
        /// 参数缺失
        /// </summary>
        PARAM_NOT_COMPLETE = 10040,


        /* 用户错误：20001-29999*/
        USER_LOGIN_ERROR = 20011,
        /// <summary>
        /// 用户未登录
        /// </summary>
        USER_NOT_LOGGED_IN = 20010,

        /// <summary>
        /// 账号不存在
        /// </summary>
        USER_LOGIN_ERROR_ACC = 20021,

        /// <summary>
        /// 密码错误
        /// </summary>
        USER_LOGIN_ERROR_PWD = 20022,

        /// <summary>
        /// 账号已被禁用
        /// </summary>
        USER_ACCOUNT_FORBIDDEN = 20030,

        /// <summary>
        /// 用户不存在
        /// </summary>
        USER_NOT_EXIST = 20040,

        /// <summary>
        /// 用户已存在
        /// </summary>
        USER_HAS_EXISTED = 20050,


        /* 业务错误：30001-39999 */
        /// <summary>
        /// 某业务出现问题
        /// </summary>
        SPECIFIED_QUESTIONED_USER_NOT_EXIST = 30010,
        /// <summary>
        /// 医嘱不允许成组
        /// </summary>
        MEDICAL_GROUP_NOT_ALLOW = 30011,

        // 业务操作失败
        SPECIFIED_ERROR = 30011,


        /* 系统错误：40001-49999 */
        /// <summary>
        /// 系统繁忙，请稍后重试
        /// </summary>
        SYSTEM_INNER_ERROR = 40010,

        /* 数据错误：50001-599999 */
        /// <summary>
        /// 数据未找到
        /// </summary>
        DATA_RET_NONE = 50010,
        /// <summary>
        /// 数据有误
        /// </summary>
        DATA_IS_WRONG = 50020,
        /// <summary>
        /// 数据已存在
        /// </summary>
        DATA_ALREADY_EXISTED = 50030,

        /// <summary>
        /// 数据验证错误
        /// </summary>
        DATA_CHECK_ERROR = 50040,


        /* 接口错误：60001-69999 */
        /// <summary>
        /// 内部系统接口调用异常
        /// </summary>
        INTERFACE_INNER_INVOKE_ERROR = 60010,
        /// <summary>
        /// 外部系统接口调用异常
        /// </summary>
        INTERFACE_OUTTER_INVOKE_ERROR = 60020,
        /// <summary>
        /// 该接口禁止访问
        /// </summary>
        INTERFACE_FORBID_VISIT = 60030,
        /// <summary>
        /// 接口地址无效
        /// </summary>
        INTERFACE_ADDRESS_INVALID = 60040,
        /// <summary>
        /// 接口请求超时
        /// </summary>
        INTERFACE_REQUEST_TIMEOUT = 60050,
        /// <summary>
        /// 接口负载过高
        /// </summary>
        INTERFACE_EXCEED_LOAD = 60060,

        /* 权限错误：70001-79999 */
        /// <summary>
        /// 无访问权限
        /// </summary>
        PERMISSION_NO_ACCESS = 70010
    }
}
