using AutoMapper;
using HR.LeaveMangement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveMangement.Application.Exceptions;
using HR.LeaveMangement.Application.Features.LeaveAllocations.Request.Commands;
using HR.LeaveMangement.Application.Persistence.Contracts;
using HR.LeaveMangement.Application.Responses;
using HR.LeaveMangement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Features.LeaveAllocations.Handlers.Commands
{
    public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommnandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveAllocationCommandHandler(ILeaveAllocationRepository leaveAllocationRepository,ILeaveTypeRepository leaveTypeRepository,IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommnandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommnandResponse();
            var validator = new CreateLeaveAllocationDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveAllocationDto);
            if (validationResult.IsValid==false) {
                response.Success = false;
                response.Message = "Allocation Failed";
                response.Errors = validationResult.Errors.Select(x=>x.ErrorMessage).ToList();
            }
            else
            {
                var leaveAllocation = _mapper.Map<LeaveAllocation>(request.LeaveAllocationDto);
                leaveAllocation = await _leaveAllocationRepository.Add(leaveAllocation);
                response.Success= true;
                response.Message = "Allocation Successful";
                response.Id = leaveAllocation.Id;
            }
              

            return response;
        }
    }
}
