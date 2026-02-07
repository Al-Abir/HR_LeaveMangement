using HR.LeaveMangement.Application.DTOs.LeaveRequest;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestListRequest: IRequest<List<LeaveRequestListDto>>
    {
    }
}
