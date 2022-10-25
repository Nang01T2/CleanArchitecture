using AutoMapper;
using {{ cookiecutter.assembly_name }}.Application.DTOs.LeaveAllocation;
using {{ cookiecutter.assembly_name }}.Application.DTOs.LeaveRequest;
using {{ cookiecutter.assembly_name }}.Application.DTOs.LeaveType;
using {{ cookiecutter.assembly_name }}.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace {{ cookiecutter.assembly_name }}.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region LeaveRequest Mappings
            CreateMap<LeaveRequest, LeaveRequestDto>().ReverseMap();
            CreateMap<LeaveRequest, LeaveRequestListDto>().ReverseMap();
            #endregion LeaveRequest

            CreateMap<LeaveAllocation, LeaveAllocationDto>().ReverseMap();

            CreateMap<LeaveType, LeaveTypeDto>().ReverseMap();
        }
    }
}
