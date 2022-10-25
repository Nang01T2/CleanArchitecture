using {{ cookiecutter.assembly_name }}.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace {{ cookiecutter.assembly_name }}.Domain
{
    public class LeaveType : BaseDomainEntity
    {
        public string? Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
