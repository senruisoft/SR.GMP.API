using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig
{
    public class MonitorItemDto
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ITEM_NAME { get; set; }

        /// <summary>
        /// 项目Code
        /// </summary>
        public string ITEM_CODE { get; set; }

        public MonitorItemDto() 
        {
        }

        public MonitorItemDto(string name, string code)
        {
            ITEM_NAME = name;
            ITEM_CODE = code;
        }
    }

    public class AlarmMonitorDic
    { 
        /// <summary>
        /// 监测数据项字典
        /// </summary>
        public List<MonitorItemDto> monitorDic { get; set; }

        /// <summary>
        /// 监测事件字典
        /// </summary>
        public List<MonitorItemDto> eventDic { get; set; }
    }
}
