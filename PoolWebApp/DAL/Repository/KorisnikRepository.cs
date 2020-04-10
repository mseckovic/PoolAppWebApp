using DAL.Interface;
using InfrastructuredServices;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class KorisnikRepository : IKorisnikRepository
    {
        #region Logger
        Logger logger = new Logger();
        #endregion

        #region AddKorisnik
        public int AddKorisnik(Korisnik korisnik)
        {
            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into Korisnik ( Ime, Prezime, BrojTelefona, Email, Username, Password) Values ( @Ime, @Prezime, @BrojTelefona, @Email, @Username, @Password)";

            command.Parameters.Add("@Ime", SqlDbType.VarChar).Value = korisnik.Ime;
            command.Parameters.Add("@Prezime", SqlDbType.VarChar).Value = korisnik.Prezime;
            command.Parameters.Add("@BrojTelefona", SqlDbType.VarChar).Value = korisnik.BrojTelefona;
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = korisnik.Email;
            command.Parameters.Add("@Username", SqlDbType.VarChar).Value = korisnik.Username;
            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = korisnik.Password;

            try
            {
                con.OpenConnection();
                command.ExecuteNonQuery();
                logger.LogInfo(DateTime.Now, "AddKorisnik method has succesfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to add new Korisnik. " + ex.Message);
                throw new Exception("Error while trying to add new Korisnik. " + ex.Message);
            }
            finally 
            {
                con.CloseConnection();
            }
        }
        #endregion

        #region DeleteKorisnik
        public int DeleteKorisnik(int korisnikID)
        {
            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Delete from Korisnik where IDKorisnik = @IDKorisnik";

            command.Parameters.Add("@IDKorisnik", SqlDbType.Int).Value = korisnikID;

            try
            {
                con.OpenConnection();
                command.ExecuteNonQuery();
                logger.LogInfo(DateTime.Now, "DeleteKorisnik method has sucessfully invoked on Korisnik with IDKorisnik = " + korisnikID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to delete Korisnik with IDKorisnik = " + korisnikID + ex.Message + ".");
                throw new Exception("Error while trying to delete Korisnik with IDKorisnik = " + korisnikID + ex.Message);
            }
            finally 
            {
                con.CloseConnection();
            }
        }

        #endregion

        #region GetAllKorisnik
        public List<Korisnik> GetAllKorisnik()
        {
            List<Korisnik> korisnikList = new List<Korisnik>();

            Connection con = new Connection();
            SqlCommand command = new SqlCommand();
            command.Connection = con.PoolConnection();
            command.CommandText = "Select * from Korisnik";

            try
            {
                con.OpenConnection();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Korisnik korisnici = new Korisnik();
                    korisnici.IDKorisnik = int.Parse(dataReader["IDKorisnik"].ToString());
                    korisnici.Ime = dataReader["Ime"].ToString();
                    korisnici.Prezime = dataReader["Prezime"].ToString();
                    korisnici.BrojTelefona = dataReader["BrojTelefona"].ToString();
                    korisnici.Email = dataReader["Email"].ToString();
                    korisnici.Username = dataReader["Username"].ToString();
                    korisnici.Password = dataReader["Password"].ToString();

                    korisnikList.Add(korisnici);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to get all korisnik." + ex.Message);
                throw new Exception("Error while trying to get all korisnik. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
            con.CloseConnection();
            logger.LogInfo(DateTime.Now, "GetAllKorisnik method has sucessfully invoked.");
            return korisnikList;
        }

        #endregion

        #region GetKorisnikByID

        public Korisnik GetKorisnikByID(int korisnikID)
        {
            Connection con = new Connection();
            Korisnik korisnici = new Korisnik() ;
            try
            {
                con.OpenConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = con.PoolConnection();
                command.CommandType = CommandType.Text;

                command.Parameters.Add("@IDKorisnik", SqlDbType.Int).Value = korisnikID;

                command.CommandText = @"Select [IDKorisnik], [Ime], [Prezime], [BrojTelefona], [Email], [Username], [Password] from [PoolApp].dbo.[Korisnik] where [IDKorisnik] = @IDKorisnik";

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    korisnici.IDKorisnik = (int)dataReader[0];
                    korisnici.Ime = dataReader[1].ToString();
                    korisnici.Prezime = dataReader[2].ToString();
                    korisnici.BrojTelefona = dataReader[3].ToString();
                    korisnici.Email = dataReader[4].ToString();
                    korisnici.Username = dataReader[5].ToString();
                    korisnici.Password = dataReader[6].ToString();
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to get korisnik by id." + ex.Message);
                throw new Exception("Error while trying to get korisnik by id. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
            logger.LogInfo(DateTime.Now, "GetKorisnikByID method has sucessfully invoked.");
            return korisnici;
        }

        #endregion

        #region UpdateKorisnik
        public int UpdateKorisnik(Korisnik korisnik)
        {
            int korisnikID;

            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Update Korisnik set Ime = @Ime, Prezime = @Prezime, BrojTelefona = @BrojTelefona, Email = @Email, Username = @Username, Password = @Password where IDKorisnik = @IDKorisnik";

            command.Parameters.Add("@IDKorisnik", SqlDbType.Int).Value = korisnik.IDKorisnik;
            command.Parameters.Add("@Ime", SqlDbType.VarChar).Value = korisnik.Ime;
            command.Parameters.Add("@Prezime", SqlDbType.VarChar).Value = korisnik.Prezime;
            command.Parameters.Add("@BrojTelefona", SqlDbType.VarChar).Value = korisnik.BrojTelefona;
            command.Parameters.Add("@Email", SqlDbType.VarChar).Value = korisnik.Email;
            command.Parameters.Add("@Username", SqlDbType.VarChar).Value = korisnik.Username;
            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = korisnik.Password;

            try
            {
                con.OpenConnection();
                korisnikID = Convert.ToInt32(command.ExecuteScalar());
                logger.LogInfo(DateTime.Now, "UpdateKorisnik method has sucessfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to update korisnik." + ex.Message);
                throw new Exception("Error while trying to update korisnik." + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }

        #endregion
    }
}
