using AutoMapper;
using HR.LeaveMangement.Application.DTOs.LeaveType.Validators;
using HR.LeaveMangement.Application.Exceptions;
using HR.LeaveMangement.Application.Features.LeaveTypes.Requests.Commands;
using HR.LeaveMangement.Application.Persistence.Contracts;
using HR.LeaveMangement.Application.Responses;
using HR.LeaveMangement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Features.LeaveTypes.Handlers.Commands
{
    public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommnandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;

        public CreateLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository , IMapper mapper)
        {
            _leaveTypeRepository = leaveTypeRepository;
            _mapper = mapper;
        }
        public async Task<BaseCommnandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
           var response = new BaseCommnandResponse();
           var validator = new CreateLeaveTypeDtoValidator();
           var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

         
            if (validationResult.IsValid == false) {
               response.Success = false;
               response.Message = "Creation Filed";
               response.Errors = validationResult.Errors.Select(x => x.ErrorMessage).ToList();
            }
            else
            {

                var leaveType = _mapper.Map<LeaveType>(request.LeaveTypeDto);

                leaveType = await _leaveTypeRepository.Add(leaveType);

               
                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = leaveType.Id;


            }

            return response;
        }
    }
}
