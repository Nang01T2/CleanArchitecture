using System;
using System.Collections.Generic;
using System.Text;

namespace {{ cookiecutter.assembly_name }}.Application.DTOs.LeaveAllocation
{
    public interface ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
    }
}
