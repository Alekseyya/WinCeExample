using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
//using AutoMapper;
using SmartDeviceProjectTest.Models;

namespace SmartDeviceProjectTest.Extensions
{
    public class AutomapperConfig
    {
        //public static void Init()
        //{
        //    Mapper.Initialize(cfg =>
        //    {

        //        cfg.CreateMap<ContainerDTO, Container>().ForMember(x => x.ContainerNum, m => m.MapFrom(prop => prop.CONTAINER));
        //        cfg.CreateMap<ScanJobDTO, ScanJob>()
        //         .ForMember(x => x.AirportCode, m => m.MapFrom(prop => prop.AIRPORT_CODE))
        //         .ForMember(x => x.JobType, m => m.MapFrom(prop => CovertToStartEnum(prop.JOB_TYPE)))
        //         .ForMember(x => x.JobSource, m => m.MapFrom(prop => CovertToStartEnum(prop.JOB_SOURCE)))
        //         .ForMember(x => x.ConfirmStatus, m => m.MapFrom(prop => CovertToStartEnum(prop.CONFIRM_STATUS)))
        //         .ForMember(x => x.AviaCode, m => m.MapFrom(prop => prop.AVIA))
        //         .ForMember(x => x.ConfirmStatus, m => m.MapFrom(prop => prop.CONFIRM_STATUS))
        //         .ForMember(x => x.FlightNum, m => m.MapFrom(prop => prop.RNUM))
        //         .ForMember(x => x.FlightDate, m => m.MapFrom(prop => prop.RDATE))
        //         .ForMember(x => x.PlanContainersTotalNum, m => m.MapFrom(prop => prop.PLAN_TOTAL_COUNT))
        //         .ForMember(x => x.PlanContainsTotalWidth, m => m.MapFrom(prop => prop.PLAN_TOTAL_WEIGHT))
        //         .ForMember(x => x.SourceElementId, m => m.MapFrom(prop => prop.ID_JOB))
        //         .ForMember(x => x.Containers, m => m.MapFrom(prop => prop.Containers));
        //    });
        //}

        public static ScanJobType CovertToStartEnum(int value)
        {
            return (ScanJobType)value;
        }
    }
}
