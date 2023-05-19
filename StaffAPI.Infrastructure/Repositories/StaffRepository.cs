using StaffAPI.Core.Entities;
using StaffAPI.Core.Intefaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffAPI.Infrastructure.Repositories
{
    public class StaffRepository : GenericRepository<Staff>, IStaffRepository
    {
        public StaffRepository(DbContextClass dbContext) : base(dbContext)
        {
        }
    }
}
