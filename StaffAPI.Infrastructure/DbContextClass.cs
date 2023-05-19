using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StaffAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffAPI.Infrastructure
{
        public class DbContextClass : DbContext
        {
            public DbContextClass(DbContextOptions<DbContextClass> contextOptions) : base(contextOptions)
            {

            }

            public DbSet<Staff> Staffs { get; set; }
        }
}