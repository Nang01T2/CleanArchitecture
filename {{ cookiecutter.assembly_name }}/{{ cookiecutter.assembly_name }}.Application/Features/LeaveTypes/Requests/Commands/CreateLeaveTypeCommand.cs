using {{ cookiecutter.assembly_name }}.Application.DTOs.LeaveType;
using {{ cookiecutter.assembly_name }}.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace {{ cookiecutter.assembly_name }}.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }

    }
}
