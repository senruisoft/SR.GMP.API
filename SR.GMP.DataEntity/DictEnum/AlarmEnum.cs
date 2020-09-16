using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.DataEntity.DictEnum
{
    public enum PriorityEnum
    {
        低 = 0,
        中 = 1,
        高 = 2
    }

    public enum AlarmLogicEnum
    {
        and = 0,
        or = 1
    }

    public enum AlarmRuleEnum
    { 
        监测数据 = 0,
        临床事件 = 1,
    }

    public enum AlarmStateEnum
    {
        未处理 = 0,
        处理中 = 1,
        已处理 = 2,
    }
}
