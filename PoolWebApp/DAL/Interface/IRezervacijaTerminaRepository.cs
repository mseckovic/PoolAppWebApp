using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IRezervacijaTerminaRepository
    {
        List<RezervacijaTermina> GetAllRezervacijaTermina();

        RezervacijaTermina GetRezervacijaTerminaByID(int rezervacijaTerminaID);

        int AddRezervacijaTermina(RezervacijaTermina rezervacijaTermina);

        int UpdateRezervacijaTermina(RezervacijaTermina rezervacijaTermina);

        int DeleteRezervacijaTermina(int rezervacijaTerminaID);
    }
}
