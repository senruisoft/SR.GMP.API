using SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor.Dto.StatisticData
{
    /// <summary>
    /// 在线治疗统计信息
    /// </summary>
    public class OnlineTreatmentStatsInfo
    {
        public OnlineTreatmentStatsInfo() 
        {
            AlarmItems = new List<ScheClassAlarmInfo>();
        }

        /// <summary>
        /// 班次名称
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 班次ID
        /// </summary>
        public string ClassID { get; set; }

        /// <summary>
        /// 治疗总人数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 治疗中人数
        /// </summary>
        public int TreatingCount { get; set; }

        /// <summary>
        /// 治疗完成人数
        /// </summary>
        public int CompleteCount { get; set; }

        /// <summary>
        /// 班次报警信息
        /// </summary>
        public List<ScheClassAlarmInfo> AlarmItems { get; set; }

        /// <summary>
        /// 报警总数
        /// </summary>
        public int AlarmTotalCount { get; set; }
    }

    /// <summary>
    /// 班次报警信息
    /// </summary>
    public class ScheClassAlarmInfo
    {
        /// <summary>
        /// 报警名称
        /// </summary>
        public string AlarmName { get; set; }

        /// <summary>
        /// 报警数量
        /// </summary>
        public int AlarmCount { get; set; }
    }

    /// <summary>
    /// 在线统计信息
    /// </summary>
    public class OnlineStatsInfo 
    {
        public OnlineStatsInfo(List<OnlineTreatmentStatsInfo> treatment_stats, List<AlarmRecordDto> alarm_list, List<AlarmItemDto> alarm_items,string centName)
        {
            searchTime = DateTime.Now;
            this.treatment_stats = treatment_stats;
            this.alarm_list = alarm_list.OrderByDescending(a=>a.DATA_RECORD_TIME).ToList();
            this.alarm_items = alarm_items;
            CentName = centName;
            if (treatment_stats != null) 
            {
                CompleteCount = treatment_stats.Sum(x => x.CompleteCount);
                TreatingCount = treatment_stats.Sum(x => x.TreatingCount);
                TotalCount = treatment_stats.Sum(x => x.TotalCount);
            }
        }

        /// <summary>
        /// 在线治疗统计信息
        /// </summary>
        public List<OnlineTreatmentStatsInfo> treatment_stats { get; set; }

        /// <summary>
        /// 报警记录列表
        /// </summary>
        public List<AlarmRecordDto> alarm_list { get; set; }

        /// <summary>
        /// 报警配置列表
        /// </summary>
        public List<AlarmItemDto> alarm_items { get; set; }

        /// <summary>
        /// 查询时间
        /// </summary>
        public DateTime searchTime { get; set; }

        /// <summary>
        /// 治疗中人数
        /// </summary>
        public int TreatingCount { get; set; }

        /// <summary>
        /// 治疗完成人数
        /// </summary>
        public int CompleteCount { get; set; }

        /// <summary>
        /// 治疗总人数
        /// </summary>
        public int TotalCount { get; set; }

        /// <summary>
        /// 中心名称
        /// </summary>
        public string CentName { get; set; }
    }
}
