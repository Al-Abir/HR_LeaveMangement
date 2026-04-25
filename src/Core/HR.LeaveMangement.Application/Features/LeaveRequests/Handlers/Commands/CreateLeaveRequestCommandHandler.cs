using AutoMapper;
using HR.LeaveMangement.Application.Contracts.Infrastructure;
using HR.LeaveMangement.Application.Contracts.Persistence;
using HR.LeaveMangement.Application.DTOs.LeaveRequest.Validators;
using HR.LeaveMangement.Application.Exceptions;
using HR.LeaveMangement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveMangement.Application.Models;
using HR.LeaveMangement.Application.Responses;
using HR.LeaveMangement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Features.LeaveRequests.Handlers.Commands
{

    
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, BaseCommnandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveRequestRepository _leaveRequestTypeRepository;
        private readonly IEmailSender _emailSender;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository,ILeaveTypeRepository leaveTypeRepository, IEmailSender emailSender, IMapper mapper)
        {
            _leaveRequestTypeRepository = leaveRequestRepository;
            _emailSender = emailSender;
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
           
            
        }
        public async Task<BaseCommnandResponse> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommnandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (validationResult.IsValid==false) {
                response.Success = false;
                response.Message = "Request Failed";
                response.Errors = validationResult.Errors.Select(e=>e.ErrorMessage).ToList();
            }
            else
            {
                var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);

                leaveRequest = await _leaveRequestTypeRepository.Add(leaveRequest);

                response.Success = true;
                response.Message = " Request Created Successfully ";
                response.Id = leaveRequest.Id;


                var email = new Email
                {
                    To = "employee@org.com",
                    Body = $"Your Leave request for {request.LeaveRequestDto.StartDate:D} to {request.LeaveRequestDto.EndDate:D}" + $"has been submitted suceessfully.",
                    Subject = "Leave Request Submitted"
                };


                try
                {
                    await _emailSender.SendEmail(email);
                }
                catch (Exception ex)
                { 
                
                }
            }
               
            return response; 

        }
    }
}
