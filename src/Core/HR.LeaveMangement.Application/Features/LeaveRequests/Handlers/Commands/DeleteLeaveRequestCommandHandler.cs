using AutoMapper;
using HR.LeaveMangement.Application.Exceptions;
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
    public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
           _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
          var leaveRquest = await _leaveRequestRepository.Get(request.Id);

            if (leaveRquest == null)
            {
                throw new NotFoundException(nameof(leaveRquest), request.Id);

            }
            await _leaveRequestRepository.Delete(leaveRquest);
            return;
        }
    }
}
