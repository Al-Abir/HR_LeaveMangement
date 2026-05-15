using FluentValidation;
using HR.LeaveMangement.Application.Contracts.Persistence;
using HR.LeaveMangement.Application.DTOs.LeaveRequest;

namespace HR.LeaveMangement.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : LeaveRequestDtoValidator
    {
        public CreateLeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
            : base(leaveTypeRepository)
        {
            // Create specific rules (if needed)
        }
    }
}