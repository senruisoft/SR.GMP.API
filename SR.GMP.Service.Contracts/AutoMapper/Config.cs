using AutoMapper;
using SR.GMP.DataEntity.Alarm;
using SR.GMP.DataEntity.System;
using SR.GMP.DataEntity.ViewModel;
using SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig;
using SR.GMP.Service.Contracts.Monitor.Dto.StatisticData;
using SR.GMP.Service.Contracts.System.Dto.Center;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.Contracts.AutoMapper
{
    public class Config : Profile
    {
        public Config()
        {
            CreateMap<BaseCountView, BaseCountInfo>().ReverseMap();
            CreateMap<EquipmentCountView, EquipmentCountInfo>().ReverseMap();
            CreateMap<TreatmenCountView, TreatmenCountInfo>().ReverseMap();
            CreateMap<TreatmentStatsView, TreatmentStatsInfo>().ReverseMap();
            CreateMap<OnlineTreatmentStatsView, OnlineTreatmentStatsInfo>().ReverseMap();


            CreateMap<GMP_ALARM_ITEM, AlarmItemDto>().ReverseMap();
            CreateMap<AlarmItemCreatInput, GMP_ALARM_ITEM>();

            CreateMap<SYS_INST_CENTER, CenterDto>().ReverseMap();
            CreateMap<CenterInput, SYS_INST_CENTER>();
        }
    }
}
