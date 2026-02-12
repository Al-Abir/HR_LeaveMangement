using AutoMapper;
using HR.LeaveMangement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveMangement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveMangement.Application.Persistence.Contracts;
using HR.LeaveMangement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Features.LeaveRequests.Handlers.Commands
{

    
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestTypeRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
        {
            _leaveRequestTypeRepository = leaveRequestRepository;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
           
            
        }
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);

            var validationResult = await validator.ValidateAsync(request.CreateLeaveRequestDto);

            if (validationResult.IsValid==false) {
                throw new Exception();
            }
            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);
  
            leaveRequest = await _leaveRequestTypeRepository.Add(leaveRequest);
            return leaveRequest.Id; 

        }
    }
}
