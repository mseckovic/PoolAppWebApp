using Model;
using System.Collections.Generic;

namespace DAL.Interface
{
    public interface IKorisnikRepository
    {
        List<Korisnik> GetAllKorisnik();

        Korisnik GetKorisnikByID(int korisnikID);

        int AddKorisnik(Korisnik korisnik);

        int UpdateKorisnik(Korisnik korisnik);

        int DeleteKorisnik(int korisnikID);
    }
}
