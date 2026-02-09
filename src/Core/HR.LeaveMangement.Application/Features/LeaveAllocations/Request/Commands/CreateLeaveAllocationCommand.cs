using HR.LeaveMangement.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Features.LeaveAllocations.Request.Commands
{
    public class CreateLeaveAllocationCommand : IRequest<int>
    {
        public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
