using AutoMapper;
using HR.LeaveMangement.Application.DTOs;
using HR.LeaveMangement.Application.Features.LeaveAllocations.Request.Queries;
using HR.LeaveMangement.Application.Persistence.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationDeatailRequestHandler : IRequestHandler<GetLeaveAllocationDeatailRequest, LeaveAllocationsDto>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;
        public GetLeaveAllocationDeatailRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }

        public async Task<LeaveAllocationsDto> Handle(GetLeaveAllocationDeatailRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails(request.Id);
            return _mapper.Map<LeaveAllocationsDto>(leaveAllocation);
        }
    }

}