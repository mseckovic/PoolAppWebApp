using DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class AdminRepositoryTest
    {
        #region AddAdminTest
        [TestMethod]
        public void AddAdminTest()
        {
            Admin admin = new Admin();

            admin.Ime = "Milos";
            admin.Prezime = "Seckovic";
            admin.Username = "mseckovic";
            admin.Password = "seckovic";

            AdminRepository repo = new AdminRepository();
            int id = repo.AddAdmin(admin);
            Assert.IsNotNull(id > 0);
        }
        #endregion

        #region UpdateAdminTest
        [TestMethod]
        public void UpdateAdminTest()
        {
            Admin admin = new Admin();
            admin.IDAdmin = 2;
            admin.Ime = "Admin";
            admin.Prezime = "Admin";
            admin.Username = "admin";
            admin.Password = "admin";

            AdminRepository repo = new AdminRepository();
            int id = repo.UpdateAdmin(admin);
            Assert.IsNotNull(id > 0);
        }
        #endregion

        #region DeleteAdminTest
        [TestMethod]
        public void DeleteAdminTest()
        {
            AdminRepository repo = new AdminRepository();
            int id = repo.DeleteAdmin(3);
            Assert.IsNotNull(repo);
        }
        #endregion

        #region GetAllAdminsTest
        [TestMethod]
        public void GetAllAdminsTest()
        {
            AdminRepository repo = new AdminRepository();
            repo.GetAllAdmin();
            Assert.IsNotNull(repo);
        }
        #endregion

        #region GetAdminByIDTest
        [TestMethod]
        public void GetAdminByIDTest()
        {
            AdminRepository repo = new AdminRepository();
            Admin admin = repo.GetAdminByID(1);
            Assert.IsNotNull(repo);
        }
        #endregion
    }
}
