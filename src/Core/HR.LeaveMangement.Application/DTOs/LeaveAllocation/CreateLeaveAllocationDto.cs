using HR.LeaveMangement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.DTOs.LeaveAllocation
{
   public class CreateLeaveAllocationDto:BaseDto
    { 
        public int NumberofDays { get; set; }
        public int LeaveTypeId {  get; set; }
        public int Period { get; set; }
    }
}
