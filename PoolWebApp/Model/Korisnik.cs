using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Korisnik
    {
        #region Properties

        public int IDKorisnik { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string BrojTelefona { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        #endregion

        #region Constructors

        public Korisnik()
        {

        }

        public Korisnik(int idKorisnik, string ime, string prezime, string brojTelefona, string email, string username, string password)
        {
            this.IDKorisnik = idKorisnik;
            this.Ime = ime;
            this.Prezime = prezime;
            this.BrojTelefona = brojTelefona;
            this.Email = email;
            this.Username = username;
            this.Password = password;
        }

        #endregion
    }
}
