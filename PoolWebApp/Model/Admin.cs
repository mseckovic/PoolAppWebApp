using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Admin
    {
        #region Properties

        public int IDAdmin { get; set; }

        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        #endregion

        #region Constructors

        public Admin()
        {

        }

        public Admin(int idAdmin, string ime, string prezime, string username, string password)
        {
            this.IDAdmin = idAdmin;
            this.Ime = ime;
            this.Prezime = prezime;
            this.Username = username;
            this.Password = password;
        }

        #endregion
    }
}
