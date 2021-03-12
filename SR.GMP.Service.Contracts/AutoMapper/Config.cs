using AutoMapper;
using SR.GMP.Common.Helper;
using SR.GMP.DataEntity.Alarm;
using SR.GMP.DataEntity.System;
using SR.GMP.DataEntity.ViewModel;
using SR.GMP.Service.Contracts.Monitor.Dto.AlarmConfig;
using SR.GMP.Service.Contracts.Monitor.Dto.StatisticData;
using SR.GMP.Service.Contracts.Monitor.Dto.View;
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

            CreateMap<PatientGeneralView, PatientGeneralInfo>()
                .ForMember(d => d.DIALYSIS_AGE, opt => { opt.MapFrom(s => s.TREATMENT_START_DATE.HasValue ? CommonHelper.GetAge(s.TREATMENT_START_DATE.Value, DateTime.Now) : null); });
            CreateMap<MonitorDataView, MonitorDataDto>();
            CreateMap<TreatOrderView, TreatOrderDto>();

            CreateMap<GMP_ALARM_ITEM, AlarmItemDto>()
                 .ForMember(d => d.RuleList, opt => { opt.MapFrom(s => s.ALARM_ITEM_RULE_LIST); });
            CreateMap<GMP_ALARM_ITEM_RULE, AlarmItemRuleDto>()
                .ForMember(d => d.ConfigList, opt => { opt.MapFrom(s => s.ALARM_RULE_CONFIG_LIST); });
            CreateMap<GMP_ALARM_RULE_CONFIG, AlarmRuleConfigDto>();
            CreateMap<AlarmItemCreatInput, GMP_ALARM_ITEM>()
                .ForMember(d => d.ALARM_ITEM_RULE_LIST, opt => { opt.MapFrom(s => s.RuleList); });
            CreateMap<ItemRuleCreatInput, GMP_ALARM_ITEM_RULE>()
               .ForMember(d => d.ALARM_RULE_CONFIG_LIST, opt => { opt.MapFrom(s => s.ConfigList); });
            CreateMap<RuleConfigCreatInput, GMP_ALARM_RULE_CONFIG>();

            CreateMap<GMP_ALARM_RECORD, AlarmRecordDto>()
                .ForMember(d => d.IS_AUTO, opt => opt.MapFrom(s => true))
                .ForMember(d => d.RECORD_DATA_LIST, opt => { opt.MapFrom(s => s.ALARM_RECORD_DATA_LIST); });
            CreateMap<GMP_ALARM_RECORD_DATA, AlarmRecordDataDto>();

            CreateMap<SYS_INST_CENTER, CenterDto>().ReverseMap();
            CreateMap<CenterInput, SYS_INST_CENTER>();

            CreateMap<PadPoliceView, AlarmRecordDto>()
               .ForMember(d => d.PATIENT_EXT_ID, opt => opt.MapFrom(s => s.PATIENT_ID))
               .ForMember(d => d.PATIENT_NAME, opt => opt.MapFrom(s => s.PATIENT_NAME))
               .ForMember(d => d.ALARM_ITEM_NAME, opt => opt.MapFrom(s => s.POLICE_TYPE))
               .ForMember(d => d.DATA_RECORD_TIME, opt => opt.MapFrom(s => s.CREATE_AT))
               .ForMember(d => d.PRIORITY, opt => opt.MapFrom(s => DataEntity.DictEnum.PriorityEnum.高))
               .ForMember(d => d.STATE, opt => opt.MapFrom(s => DataEntity.DictEnum.AlarmStateEnum.未处理))
               .ForMember(d => d.IS_AUTO, opt => opt.MapFrom(s => false))
               .ForMember(d => d.RECORD_DATA_LIST, opt => opt.MapFrom(s => new List<AlarmRecordDataDto>()));
        }
    }
}
