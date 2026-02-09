using AutoMapper;
using HR.LeaveMangement.Application.DTOs.LeaveAllocation;
using HR.LeaveMangement.Application.DTOs.LeaveRequest;
using HR.LeaveMangement.Application.DTOs.LeaveType;
using HR.LeaveMangement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Profiles
{
    public class MappingProfile: Profile
    {

        public MappingProfile()
        {
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            CreateMap<LeaveAllocation,LeaveAllocationsDto>().ReverseMap();
            CreateMap<LeaveType,LeaveTypeDto>().ReverseMap();

        }
    }
}
 