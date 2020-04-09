using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Bazen
    {
        #region Properties
        public int IDBazen { get; set; }
        public string TipBazena { get; set; }

        #endregion

        #region Constructors

        public Bazen()
        {

        }

        public Bazen(int idBazen, string tipBazena)
        {
            this.IDBazen = idBazen;
            this.TipBazena = tipBazena;
        }

        #endregion
    }
}
