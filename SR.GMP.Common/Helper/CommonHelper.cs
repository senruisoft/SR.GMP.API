using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Common.Helper
{
    public class CommonHelper
    {
        /// <summary>
        /// 计算年龄方法
        /// </summary>
        /// <param name="dtBirthday"></param>
        /// <param name="dtNow"></param>
        /// <returns></returns>
        public static string GetAge(DateTime dtBirthday, DateTime dtNow)
        {
            string strAge = string.Empty; // 年龄的字符串表示
            int intYear = 0; // 岁
            int intMonth = 0; // 月
            int intDay = 0; // 天
            // 如果没有设定出生日期, 返回空
            if (dtBirthday == null)
            {
                return string.Empty;
            }
            // 计算天数
            intDay = dtNow.Day - dtBirthday.Day;
            if (intDay < 0)
            {
                dtNow = dtNow.AddMonths(-1);
                intDay += DateTime.DaysInMonth(dtNow.Year, dtNow.Month);
            }
            // 计算月数
            intMonth = dtNow.Month - dtBirthday.Month;
            if (intMonth < 0)
            {
                intMonth += 12;
                dtNow = dtNow.AddYears(-1);
            }
            // 计算年数
            intYear = dtNow.Year - dtBirthday.Year;
            // 格式化年龄输出
            if (intYear >= 1) // 年份输出
            {
                strAge = intYear.ToString() + "年";
            }
            if (intMonth > 0 && intYear < 1) // 五岁以下可以输出月数
            {
                strAge = intMonth.ToString() + "月";
            }
            if (intDay >= 0 && intMonth < 1) // 一岁以下可以输出天数
            {
                strAge = intDay.ToString() + "日";
            }
            return strAge;
        }
    }
}
