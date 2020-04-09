using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface ITerminRepository
    {
        List<Termin> GetAllTermin();

        Termin GetTerminByID(int terminID);

        int AddTermin(Termin termin);

        int UpdateTermin(Termin termin);

        int DeleteTermin(int terminID);
    }
}
