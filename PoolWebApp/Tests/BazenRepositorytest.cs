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
    public class BazenRepositoryTest
    {
        #region AddBazenTest
        [TestMethod]
        public void AddBazenTest()
        {
            Bazen bazen = new Bazen();

            bazen.TipBazena = "test";

            BazenRepository repo = new BazenRepository();
            int id = repo.AddBazen(bazen);
            Assert.IsNotNull(id > 0);
        }
        #endregion

        #region UpdateBazenTest
        [TestMethod]
        public void UpdateBazenTest()
        {
            Bazen bazen = new Bazen();
            bazen.IDBazen = 3;
            bazen.TipBazena = "takmicarski";

            BazenRepository repo = new BazenRepository();
            int id = repo.UpdateBazen(bazen);
            Assert.IsNotNull(id > 0);
        }
        #endregion

        #region DeleteBazenTest
        [TestMethod]
        public void DeleteBazenTest()
        {
            BazenRepository repo = new BazenRepository();
            int id = repo.DeleteBazen(4);
            Assert.IsNotNull(repo);
        }
        #endregion

        #region GetAllBazenTest
        [TestMethod]
        public void GetAllBazenTest()
        {
            BazenRepository repo = new BazenRepository();
            repo.GetAllBazen();
            Assert.IsNotNull(repo);
        }
        #endregion

        #region GetBazenByIDTest
        [TestMethod]
        public void GetBazenByIDTest()
        {
            BazenRepository repo = new BazenRepository();
            Bazen bazen = repo.GetBazenByID(1);
            Assert.IsNotNull(repo);
        }
        #endregion
    }
}
