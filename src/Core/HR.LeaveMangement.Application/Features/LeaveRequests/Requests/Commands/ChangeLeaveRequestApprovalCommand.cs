using MediatR;

namespace HR.LeaveMangement.Application.Features.LeaveRequests.Requests.Commands
{
    public class ChangeLeaveRequestApprovalCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public bool? Approved { get; set; }
    }
}