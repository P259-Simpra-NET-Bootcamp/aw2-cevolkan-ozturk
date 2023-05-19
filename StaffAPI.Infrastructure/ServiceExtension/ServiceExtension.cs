using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StaffAPI.Core.Intefaces;
using StaffAPI.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffAPI.Infrastructure.ServiceExtension
{
    public  static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DbContextClass>(options =>
            {
                options.UseNpgsql("User ID=postgres;Password=12345;Host=localhost;Port=5432;Database=StaffAPIDb");
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStaffRepository, StaffRepository>();

            return services;
        }
    }
}
