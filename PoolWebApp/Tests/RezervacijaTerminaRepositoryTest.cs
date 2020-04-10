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
    public class RezervacijaTerminaRepositoryTest
    {
        #region AddRezervacijaTerminaTest
        [TestMethod]
        public void AddRezervacijaTerminaTest()
        {
            RezervacijaTermina rezervacijaTermina = new RezervacijaTermina();

            rezervacijaTermina.IDKorisnik = 1;
            rezervacijaTermina.IDTermin = 4;
            rezervacijaTermina.IDAdmin = 1;

            RezervacijaTerminaRepository repo = new RezervacijaTerminaRepository();
            int id = repo.AddRezervacijaTermina(rezervacijaTermina);
            Assert.IsNotNull(id > 0);
        }
        #endregion

        #region UpdateRezervacijaTerminaTest
        [TestMethod]
        public void UpdateRezervacijaTerminaTest()
        {
            RezervacijaTermina rezervacijaTermina = new RezervacijaTermina();
            rezervacijaTermina.IDRezervacija = 5;
            rezervacijaTermina.IDKorisnik = 2;
            rezervacijaTermina.IDTermin = 4;
            rezervacijaTermina.IDAdmin = 2;

            RezervacijaTerminaRepository repo = new RezervacijaTerminaRepository();
            int id = repo.UpdateRezervacijaTermina(rezervacijaTermina);
            Assert.IsNotNull(id > 0);
        }
        #endregion

        #region DeleteRezervacijaTerminaTest
        [TestMethod]
        public void DeleteRezervacijaTerminaTest()
        {
            RezervacijaTerminaRepository repo = new RezervacijaTerminaRepository();
            int id = repo.DeleteRezervacijaTermina(6);
            Assert.IsNotNull(repo);
        }
        #endregion

        #region GetAllRezervacijaTerminaTest
        [TestMethod]
        public void GetAllRezervacijaTerminaTest()
        {
            RezervacijaTerminaRepository repo = new RezervacijaTerminaRepository();
            repo.GetAllRezervacijaTermina();
            Assert.IsNotNull(repo);
        }
        #endregion

        #region GetRezervacijaTerminaByIDTest
        [TestMethod]
        public void GetRezervacijaTerminaByIDTest()
        {
            RezervacijaTerminaRepository repo = new RezervacijaTerminaRepository();
            RezervacijaTermina rezervacijaTermina = repo.GetRezervacijaTerminaByID(5);
            Assert.IsNotNull(repo);
        }
        #endregion
    }
}
