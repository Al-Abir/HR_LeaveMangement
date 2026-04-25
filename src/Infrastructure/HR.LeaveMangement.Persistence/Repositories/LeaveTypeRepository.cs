using HR.LeaveMangement.Application.Contracts.Persistence;
using HR.LeaveMangement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {

        private readonly LeaveMangementDbContext _dbcontext;

        public LeaveTypeRepository(LeaveMangementDbContext dbcontext) :base(dbcontext) 
        {
            _dbcontext = dbcontext;
        }
    }
}
