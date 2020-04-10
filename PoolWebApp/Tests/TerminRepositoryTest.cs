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
    public class TerminRepositoryTest
    {
        #region AddTerminTest
        [TestMethod]
        public void AddTerminTest()
        {
            Termin termin = new Termin();

            termin.VremeOd = TimeSpan.Parse("19:04:30");
            termin.VremeDo = TimeSpan.Parse("20:04:30");
            termin.DatumTermina = DateTime.Parse("2020-04-15");
            termin.IDBazen = 1;
            termin.IDRezervacija = 4;
            termin.IDAdmin = 1;

            TerminRepository repo = new TerminRepository();
            int id = repo.AddTermin(termin);
            Assert.IsNotNull(id > 0);
        }
        #endregion

        #region UpdateTerminTest
        [TestMethod]
        public void UpdateTerminTest()
        {
            Termin termin = new Termin();
            termin.IDTermin = 7; 
            termin.DatumTermina = DateTime.Parse("2020-04-15");
            termin.IDBazen = 2;
            termin.IDRezervacija = 4;
            termin.IDAdmin = 1;

            TerminRepository repo = new TerminRepository();
            int id = repo.UpdateTermin(termin);
            Assert.IsNotNull(id > 0);
        }
        #endregion

        #region DeleteTerminTest
        [TestMethod]
        public void DeleteTerminTest()
        {
            TerminRepository repo = new TerminRepository();
            int id = repo.DeleteTermin(7);
            Assert.IsNotNull(repo);
        }
        #endregion

        #region GetAllTerminTest
        [TestMethod]
        public void GetAllTerminTest()
        {
            TerminRepository repo = new TerminRepository();
            repo.GetAllTermin();
            Assert.IsNotNull(repo);
        }
        #endregion

        #region GetTerminByIDTest
        [TestMethod]
        public void GetTerminByIDTest()
        {
            TerminRepository repo = new TerminRepository();
            Termin termin = repo.GetTerminByID(6);
            Assert.IsNotNull(repo);
        }
        #endregion
    }
}
