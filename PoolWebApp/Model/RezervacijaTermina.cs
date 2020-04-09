using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class RezervacijaTermina
    {
        #region Properties

        public int IDRezervacija { get; set; }
        public int IDKorisnik { get; set; }
        public int IDTermin { get; set; }
        public int IDAdmin { get; set; }

        #endregion

        #region Constructors 

        public RezervacijaTermina()
        {

        }

        public RezervacijaTermina(int idRezervacija, int idKorisnik, int idTermin, int idAdmin)
        {
            this.IDRezervacija = idRezervacija;
            this.IDKorisnik = idKorisnik;
            this.IDTermin = idTermin;
            this.IDAdmin = idAdmin;
        }

        #endregion
    }
}
