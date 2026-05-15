using HR.LeaveMangement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Domain
{
    
        public class LeaveAllocation : BaseDomainEntity
        {
            public string EmployeeId { get; set; } = string.Empty;

            public int NumberOfDays { get; set; }

            public int LeaveTypeId { get; set; }

            public LeaveType LeaveType { get; set; } = default!;

            public int Period { get; set; }
        }
    
}
