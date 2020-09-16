using AutoMapper;
using SR.GMP.DataEntity.Alarm;
using SR.GMP.Service.Contracts.Test.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SR.GMP.Service.AutoMapper
{
    public class Config : Profile
    {
        public Config() 
        {
            CreateMap<TestDto, GMP_ALARM_ITEM>().ReverseMap();
        }
    }
}
