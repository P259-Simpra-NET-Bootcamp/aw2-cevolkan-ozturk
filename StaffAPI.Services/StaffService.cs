using StaffAPI.Core.Entities;
using StaffAPI.Core.Intefaces;
using StaffAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffAPI.Services
{
    public class StaffService : IStaffService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StaffService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateStaff(Staff staff)
        {
            if (staff == null)
            {
                return false;
            }

            await _unitOfWork.Staffs.Add(staff);
            return _unitOfWork.Save()>0;
        }

        public async Task<bool> DeleteStaff(int staffId)
        {
            if (staffId > 0)
            {
                var staff = await _unitOfWork.Staffs.GetById(staffId);
                if (staff != null)
                {
                    _unitOfWork.Staffs.Delete(staff);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<IEnumerable<Staff>> GetAllStaffs()
        {
            return await _unitOfWork.Staffs.GetAll();
        }

        public async Task<Staff?> GetStaffById(int staffId)
        {
            if (staffId > 0)
            {
                var staff = await _unitOfWork.Staffs.GetById(staffId);
                if (staff != null)
                {
                    return staff;
                }   
            }
            return null;
        }

        public Task<bool> UpdateStaff(Staff staff)
        {
            throw new NotImplementedException();
        }
    }
}
