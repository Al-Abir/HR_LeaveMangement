using HR.LeaveMangement.Application.Exceptions;
using HR.LeaveMangement.Application.Contracts.Persistence;
using HR.LeaveMangement.Domain;
using HR.LeaveMangement.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveMangementDbContext _dbContext;

        // ১. কনস্ট্রাক্টর (এটি ছাড়া GenericRepository কাজ করবে না)
        public LeaveAllocationRepository(LeaveMangementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // ২. নির্দিষ্ট একটি আইডি দিয়ে ডিটেইলস আনা
        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
        {
            var result = await _dbContext.LeaveAllocation
    .Include(q => q.LeaveType)
    .FirstOrDefaultAsync(q => q.Id == id);

            if (result == null)
            {
                throw new NotFoundException(nameof(LeaveAllocation), id);
            }
            return result;
        }

        // ৩. সব অ্যালোকেশনের লিস্ট ডিটেইলসসহ আনা
        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            return await _dbContext.LeaveAllocation
                .Include(q => q.LeaveType)
                .ToListAsync();
        }
    }
}