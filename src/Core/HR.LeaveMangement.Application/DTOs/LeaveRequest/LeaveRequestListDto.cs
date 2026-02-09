using HR.LeaveMangement.Application.DTOs.Common;
using HR.LeaveMangement.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDto: BaseDto
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequest { get; set; }
        public bool? Approved { get; set; }
    }
}
