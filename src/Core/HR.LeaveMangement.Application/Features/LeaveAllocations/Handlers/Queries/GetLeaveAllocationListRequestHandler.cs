using AutoMapper;
using HR.LeaveMangement.Application.DTOs.LeaveAllocation;
using HR.LeaveMangement.Application.DTOs.LeaveRequest;
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

    
    public class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationsDto>>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationsDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var LeaveRequestAllocation = await _leaveAllocationRepository.GetLeaveAllocationWithDetails();
            return _mapper.Map<List<LeaveAllocationsDto>>(LeaveRequestAllocation);


          
        }
    }
}
