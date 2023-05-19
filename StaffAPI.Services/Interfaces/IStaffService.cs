using StaffAPI.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffAPI.Services.Interfaces
{
    public interface IStaffService
    {
        Task<bool> CreateStaff(Staff staff);

        Task<IEnumerable<Staff>> GetAllStaffs();

        Task<Staff> GetStaffById(int productId);

        Task<bool> UpdateStaff(Staff staff);

        Task<bool> DeleteStaff(int staffId);
    }
}
