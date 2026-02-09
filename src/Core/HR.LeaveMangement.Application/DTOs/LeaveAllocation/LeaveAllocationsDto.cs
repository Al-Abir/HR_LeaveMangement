using HR.LeaveMangement.Application.DTOs.Common;
using HR.LeaveMangement.Application.DTOs.LeaveType;
using HR.LeaveMangement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.DTOs.LeaveAllocation
{
    public class LeaveAllocationsDto: BaseDto
    {

        public int NumberOfDays { get; set; }
        public LeaveTypeDto LeaveType { get; set; } = default!;
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }

    }
}
