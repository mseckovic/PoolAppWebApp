using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Termin
    {
        #region Properties

        public int IDTermin { get; set; }
        public TimeSpan VremeOd { get; set; }
        public TimeSpan VremeDo { get; set; }
        public DateTime DatumTermina { get; set; }
        public int IDBazen { get; set; }
        public int IDRezervacija { get; set; }
        public int IDAdmin { get; set; }

        #endregion

        #region Constructors 

        public Termin()
        {

        }

        public Termin(int idTermin, TimeSpan vremeOd, TimeSpan vremeDo, DateTime datumTermina, int idBazen, int idRezervacija, int idAdmin)
        {
            this.IDTermin = idTermin;
            this.VremeOd = vremeOd;
            this.VremeDo = vremeDo;
            this.DatumTermina = datumTermina;
            this.IDBazen = idBazen;
            this.IDRezervacija = idRezervacija;
            this.IDAdmin = idAdmin;
        }

        #endregion
    }
}
