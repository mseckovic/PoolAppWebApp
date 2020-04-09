using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface
{
    public interface IBazenRepository
    {
        List<Bazen> GetAllBazen();

        Bazen GetBazenByID(int bazenID);

        int AddBazen(Bazen bazen);

        int UpdateBazen(Bazen bazen);

        int DeleteBazen(int bazenID);
    }
}
