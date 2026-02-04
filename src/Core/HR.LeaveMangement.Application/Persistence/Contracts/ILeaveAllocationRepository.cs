using HR.LeaveMangement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Application.Persistence.Contracts
{
    public interface ILeaveAllocationRepository:IGenericRepository<LeaveAllocation>
    {
    }
}
