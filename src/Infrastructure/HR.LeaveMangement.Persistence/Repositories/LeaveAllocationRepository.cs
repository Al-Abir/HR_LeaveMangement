using HR.LeaveMangement.Application.Persistence.Contracts;
using HR.LeaveMangement.Domain;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HR.LeaveMangement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        // ১. কনস্ট্রাক্টর (এটি ছাড়া GenericRepository কাজ করবে না)
        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        // ২. নির্দিষ্ট একটি আইডি দিয়ে ডিটেইলস আনা
        public async Task<LeaveAllocation?> GetLeaveAllocationWithDetails(int id)
        {
            return await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType) // LeaveType এর তথ্যসহ লোড হবে
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        // ৩. সব অ্যালোকেশনের লিস্ট ডিটেইলসসহ আনা
        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            return await _dbContext.LeaveAllocations
                .Include(q => q.LeaveType)
                .ToListAsync();
        }
    }
}