using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class OtkazaniTermini
    {
        #region Properties 

        public int IDOtkazaniTermini { get; set; }
        public int IDRezervacija { get; set; }

        #endregion

        #region Constructors

        public OtkazaniTermini()
        {

        }

        public OtkazaniTermini(int idOtkazaniTermini, int idRezervacija)
        {
            this.IDOtkazaniTermini = idOtkazaniTermini;
            this.IDRezervacija = idRezervacija;
        }

        #endregion
    }
}
