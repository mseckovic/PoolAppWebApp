using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IAdminRepository
    {
        List<Admin> GetAllAdmin();

        Admin GetAdminByID(int adminID);

        int AddAdmin(Admin admin);

        int UpdateAdmin(Admin admin);

        int DeleteAdmin(int adminID);
    }
}
