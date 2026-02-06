using HR.LeaveMangement.Application.DTOs.Common;
using HR.LeaveMangement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.DTOs.LeaveRequest
{
    public class LeaveRequestDto:BaseDto
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public LeaveTypeDto LeaveType { get; set; } = default!;

        public int LeaveTypeId { get; set; }

        public DateTime DateRequested { get; set; }

        public string? RequestCommnents { get; set; }


        public DateTime DateActioned { get; set; }

        public bool? Aprroved { get; set; }

        public bool Cancelled { get; set; }
    }
}
