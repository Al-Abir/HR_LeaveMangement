using HR.LeaveMangement.Application.Persistence.Contracts;
using HR.LeaveMangement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {

        private readonly LeaveMangementDbContext _dbContext;
        public LeaveRequestRepository(LeaveMangementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        
        }
        
        public Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
            throw new NotImplementedException();
        }

        public Task<LeaveRequest> GetLeaveRequestsWithDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            throw new NotImplementedException();
        }
    }
}
