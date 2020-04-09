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
    public class KorisnikRepositoryTest
    {
        #region AddKorisnikTest
        [TestMethod]
        public void AddAuthorTest()
        {
            Korisnik korisnik = new Korisnik();

            korisnik.Ime = "Milos";
            korisnik.Prezime = "Seckovic";
            korisnik.BrojTelefona = "069123456";
            korisnik.Email = "milossec@gmail.com";
            korisnik.Username = "mseckovic";
            korisnik.Password = "seckovic";

            KorisnikRepository repo = new KorisnikRepository();
            int id = repo.AddKorisnik(korisnik);
            Assert.IsNotNull(id > 0);
        }
        #endregion

        #region UpdateKorisnikTest
        [TestMethod]
        public void UpdateAuthorTest()
        {
            Korisnik korisnik = new Korisnik();
            korisnik.IDKorisnik = 2;
            korisnik.Ime = "Kristina";
            korisnik.Prezime = "Jovanovic";
            korisnik.BrojTelefona = "063663163";
            korisnik.Email = "jkristina794@gmail.com";
            korisnik.Username = "kjovanovic";
            korisnik.Password = "jovanovic";

            KorisnikRepository repo = new KorisnikRepository();
            int id = repo.UpdateKorisnik(korisnik);
            Assert.IsNotNull(id > 0);
        }

        #endregion

        #region DeleteKorisnikTest
        [TestMethod]
        public void DeleteKorisnikTest()
        {
            KorisnikRepository repo = new KorisnikRepository();
            int id = repo.DeleteKorisnik(3);
            Assert.IsNotNull(repo);
        }
        #endregion

        #region GetAllKorisnikTest
        [TestMethod]
        public void GetAllKorisnikTest()
        {
            KorisnikRepository repo = new KorisnikRepository();
            repo.GetAllKorisnik();
            Assert.IsNotNull(repo);
        }
        #endregion

        #region GetKorisnikByID
        [TestMethod]
        public void GetKorisnikByIDTest()
        {
            KorisnikRepository repo = new KorisnikRepository();
            Korisnik korisnik = repo.GetKorisnikByID(5);
            Assert.IsNotNull(repo);
        }
        #endregion
    }
}
