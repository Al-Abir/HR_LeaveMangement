using HR.LeaveMangement.Application.Exceptions;
using HR.LeaveMangement.Application.Contracts.Persistence;
using HR.LeaveMangement.Domain;
using Microsoft.EntityFrameworkCore;
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
        
        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool? ApprovalStatus)
        {
             leaveRequest.Aprroved = ApprovalStatus;
             _dbContext.Entry(leaveRequest).State = EntityState.Modified;     
             await _dbContext.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestsWithDetails(int id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync(q => q.Id == id);
           
            if (leaveRequest == null)
            {
                throw new NotFoundException(nameof(LeaveRequest), id);
            }

            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails()
        {
            var leaveRequests = await _dbContext.LeaveRequests
              .Include(q => q.LeaveType)
              .ToListAsync();

            return leaveRequests;
        }
    }
}
