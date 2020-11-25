using SR.GMP.Service.Contracts.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig
{
    public class AlarmRuleConfigDto : EntityDto<Guid>
    {
        /// <summary>
        /// 最大值
        /// </summary>
        public decimal? MAX_VALUE { get; set; }

        /// <summary>
        /// 是否包含最大值
        /// </summary>
        public bool IS_CONTAINMAX { get; set; }

        /// <summary>
        /// 最小值
        /// </summary>
        public decimal? MIN_VALUE { get; set; }

        /// <summary>
        /// 是否包含最小值
        /// </summary>
        public bool IS_CONTAINMIN { get; set; }

        /// <summary>
        /// 是否前后数据差值
        /// </summary>
        public bool IS_DIFFVALUE { get; set; }
    }
}
