using AutoMapper;
using SR.GMP.DataEntity.ViewModel;
using SR.GMP.Service.Contracts.Monitor.Dto.StatisticData;
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
        }
    }
}
