using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaffAPI.Core.Intefaces
{
    public interface IUnitOfWork : IDisposable
    {
        IStaffRepository Staffs { get; }

        int Save();

    }
}
