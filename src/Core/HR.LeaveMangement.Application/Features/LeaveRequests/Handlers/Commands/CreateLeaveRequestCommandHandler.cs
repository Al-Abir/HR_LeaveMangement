using AutoMapper;
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
        private readonly ILeaveRequestRepository _leaveTypeRepository;
        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveTypeRepository = leaveRequestRepository;
            _mapper = mapper;
           
            
        }
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {

            var leaveRequest = _mapper.Map<LeaveRequest>(request.CreateLeaveRequestDto);
            leaveRequest = await _leaveTypeRepository.Add(leaveRequest);
            return leaveRequest.Id; 

        }
    }
}
