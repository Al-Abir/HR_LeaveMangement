using HR.LeaveMangement.Application.DTOs.LeaveType;
using HR.LeaveMangement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Features.LeaveTypes.Requests.Commands
{
    public class CreateLeaveTypeCommand : IRequest<BaseCommnandResponse>
    {
        public CreateLeaveTypeDto LeaveTypeDto{ get; set; }

    }
}
