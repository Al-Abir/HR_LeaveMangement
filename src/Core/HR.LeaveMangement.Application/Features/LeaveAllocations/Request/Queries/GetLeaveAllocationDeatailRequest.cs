using HR.LeaveMangement.Application.DTOs.LeaveAllocation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Features.LeaveAllocations.Request.Queries
{
    public class GetLeaveAllocationDeatailRequest: IRequest<LeaveAllocationsDto>
    {
        public int Id { get; set; }
    }
}
