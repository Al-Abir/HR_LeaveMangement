using HR.LeaveMangement.Application.DTOs.LeaveRequest;
using HR.LeaveMangement.Application.Features.LeaveRequests.Requests.Commands;
using HR.LeaveMangement.Application.Features.LeaveRequests.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HR.LeaveMangement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeaveRequestsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LeaveRequestsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // ==================================================
        // 👤 EMPLOYEE: Create Leave Request
        // ==================================================
        [HttpPost]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult> Create([FromBody] CreateLeaveRequestDto dto)
        {
            var command = new CreateLeaveRequestCommand
            {
                LeaveRequestDto = dto
            };

            var response = await _mediator.Send(command);
            return Ok(response);
        }

        // ==================================================
        //     EMPLOYEE: Get only my requests
        // ==================================================
        [HttpGet("my-requests")]
        [Authorize(Roles = "Employee")]
        public async Task<ActionResult<LeaveRequestDto>> GetMyRequests()
        {
            var query = new GetLeaveRequestListRequest
            {
                IsAdmin = false
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // ==================================================
        // 🧑‍💼 ADMIN: Get ALL requests
        // ==================================================
        [HttpGet("all")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<List<LeaveRequestListDto>>> GetAll()
        {
            var query = new GetLeaveRequestListRequest
            {
                IsAdmin = true
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        // ==================================================
        // 🔍 COMMON: Get request by id (Admin or Owner)
        // ==================================================
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<List<LeaveRequestDto>>> GetById(int id)
        {
            var query = new GetLeaveRequestDetailRequest
            {
                Id = id
            };

            var result = await _mediator.Send(query);
            return Ok(result);
        }

        
        //ADMIN: Approve / Reject
        // ==================================================
        [HttpPut("changeapproval/{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> ChangeApproval(int id, [FromBody] ChangeLeaveRequestApprovalDto dto)
        {
            var command = new UpdateLeaveRequestCommand
            {
                Id = id,
                ChangeLeaveRequestApprovalDto = dto
            };

            await _mediator.Send(command);
            return NoContent();
        }

        // ==================================================
        // 🧑‍💼 ADMIN: Delete request
        // ==================================================
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Delete(int id)
        {
            var command = new DeleteLeaveRequestCommand
            {
                Id = id
            };

            await _mediator.Send(command);
            return NoContent();
        }
    }
}