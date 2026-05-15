using HR.LeaveMangement.Application.Contracts.Persistence;
using HR.LeaveMangement.Application.Features.LeaveRequests.Requests.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Features.LeaveRequests.Handlers.Commands
{

    public class ChangeLeaveRequestApprovalCommandHandler
    : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;

        public ChangeLeaveRequestApprovalCommandHandler(
            ILeaveRequestRepository leaveRequestRepository, ILeaveAllocationRepository leaveAllocationRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _leaveAllocationRepository = leaveAllocationRepository;
        }

        public async Task<Unit> Handle(
            ChangeLeaveRequestApprovalCommand request,
            CancellationToken cancellationToken)
        {
            var leaveRequest =
                await _leaveRequestRepository.Get(request.Id);

            leaveRequest.Approved = request.Approved;
            leaveRequest.DateActioned = DateTime.Now;
            
            if (request.Approved==true)
            {
                var allocation =
                    await _leaveAllocationRepository.GetUserAllocation(
                        leaveRequest.RequestingEmployeeId,
                        leaveRequest.LeaveTypeId,
                        leaveRequest.StartDate.Year);

                var numberOfDays = (leaveRequest.EndDate - leaveRequest.StartDate).Days + 1;
                allocation.NumberOfDays -= numberOfDays;

                await _leaveAllocationRepository.Update(allocation);
            }

            await _leaveRequestRepository.Update(leaveRequest);

            return Unit.Value;
        }
    }
}
