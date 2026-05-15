using HR.LeaveMangement.Application.DTOs.Common;
using HR.LeaveMangement.Application.DTOs.LeaveType;
using HR.LeaveMangement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.DTOs.LeaveRequest
{

    public class LeaveRequestDto 
    {

        public int Id { get; set; }

        public string LeaveTypeName { get; set; } =string.Empty;

        public string RequestingEmployeeId { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime DateRequested { get; set; }

        public bool? Approved { get; set; }

        public string? Status { get; set; }
    }
}
