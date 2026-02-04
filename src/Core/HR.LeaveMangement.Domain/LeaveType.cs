using HR.LeaveMangement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Domain
{
    public class LeaveType : BaseDomainEntity
    {
       
        public string Name { get; set; } = string.Empty;
        public int DefaultDays { get; set; }
       

    }
}
