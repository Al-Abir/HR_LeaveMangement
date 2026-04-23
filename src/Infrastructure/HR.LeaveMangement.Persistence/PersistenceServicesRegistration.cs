using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using HR.LeaveMangement.Application.Persistence.Contracts;
using HR.LeaveMangement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

// অন্যান্য প্রয়োজনীয় নেমস্পেস (যেমন আপনার DbContext এবং Repositories)
namespace HR.LeaveMangement.Persistence
{
    

    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            // ১. DbContext কনফিগারেশন (উদাহরণস্বরূপ SQL Server)
            services.AddDbContext<LeaveMangementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("LeaveManagementConnectionString")));

            // ২. রিপোজিটরিগুলো রেজিস্টার করা
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository,LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
            // অন্যান্য রিপোজিটরি...

            return services;
        }
    }
}
