using SR.GMP.DataEntity.DictEnum;
using SR.GMP.Service.Contracts.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig
{
    public class AlarmItemDto : EntityDto<Guid>
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ITEM_NAME { get; set; }

        /// <summary>
        /// 优先级
        /// </summary>
        public PriorityEnum PRIORITY { get; set; }

        /// <summary>
        /// 中心ID
        /// </summary>
        public Guid CENT_ID { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public StateEnum STATE { get; set; }
    }
}
