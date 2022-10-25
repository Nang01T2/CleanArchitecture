﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CleanArchitecture.Application.DTOs.LeaveType
{
    public class CreateLeaveTypeDto : ILeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
