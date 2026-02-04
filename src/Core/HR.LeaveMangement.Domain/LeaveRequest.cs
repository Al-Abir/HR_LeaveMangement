using HR.LeaveMangement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Domain
{
    public class LeaveRequest : BaseDomainEntity
    {

       
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public LeaveType LeaveType { get; set; } = default!;

        public int LeaveTypeId { get; set; }

        public DateTime DateRequested { get; set; }

        public string? RequestCommnents {  get; set; }


        public DateTime DateActioned { get; set; }

        public bool? Aprroved { get; set; }

        public bool Cancelled { get; set; }
    }
}
