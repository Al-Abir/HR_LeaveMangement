using FluentValidation;
using HR.LeaveMangement.Application.Contracts.Persistence;
using HR.LeaveMangement.Application.DTOs.LeaveRequest;

namespace HR.LeaveMangement.Application.DTOs.LeaveRequest.Validators
{
    public class LeaveRequestDtoValidator : AbstractValidator<ILeaveRequestDto>
    {
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public LeaveRequestDtoValidator(ILeaveTypeRepository leaveTypeRepository)
        {
            _leaveTypeRepository = leaveTypeRepository;

            RuleFor(p => p.StartDate)
                .LessThan(p => p.EndDate)
                .WithMessage("Start date must be before end date");

            RuleFor(p => p.EndDate)
                .GreaterThan(p => p.StartDate)
                .WithMessage("End date must be after start date");

            RuleFor(p => p.LeaveTypeId)
                .GreaterThan(0)
                .MustAsync(async (id, token) =>
                {
                    return await _leaveTypeRepository.Exists(id);
                })
                .WithMessage("Leave Type does not exist");
        }
    }
}