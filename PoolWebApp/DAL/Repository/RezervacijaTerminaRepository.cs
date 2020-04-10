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
    public class RezervacijaTerminaRepository : IRezervacijaTerminaRepository
    {
        #region Logger
        Logger logger = new Logger();
        #endregion

        #region AddRezervacijaTermina
        public int AddRezervacijaTermina(RezervacijaTermina rezervacijaTermina)
        {
            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into RezervacijaTermina ( IDKorisnik, IDTermin, IDAdmin) Values ( @IDKorisnik, @IDTermin, @IDAdmin)";

            command.Parameters.Add("@IDKorisnik", SqlDbType.VarChar).Value = rezervacijaTermina.IDKorisnik;
            command.Parameters.Add("@IDTermin", SqlDbType.VarChar).Value = rezervacijaTermina.IDTermin;
            command.Parameters.Add("@IDAdmin", SqlDbType.VarChar).Value = rezervacijaTermina.IDAdmin;

            try
            {
                con.OpenConnection();
                command.ExecuteNonQuery();
                logger.LogInfo(DateTime.Now, "AddRezervacijaTermina method has succesfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to add new RezervacijaTermina. " + ex.Message);
                throw new Exception("Error while trying to add new RezervacijaTermina. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        #endregion

        #region DeleteRezervacijaTermina
        public int DeleteRezervacijaTermina(int rezervacijaTerminaID)
        {
            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Delete from RezervacijaTermina where IDRezervacija = @IDRezervacija";

            command.Parameters.Add("@IDRezervacija", SqlDbType.Int).Value = rezervacijaTerminaID;

            try
            {
                con.OpenConnection();
                command.ExecuteNonQuery();
                logger.LogInfo(DateTime.Now, "DeleteAdmin method has sucessfully invoked on Rezervacija with IDRezervacija = " + rezervacijaTerminaID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to delete Rezervacija with IDRezervacija = " + rezervacijaTerminaID + ex.Message + ".");
                throw new Exception("Error while trying to delete Rezervacija with IDRezervacija = " + rezervacijaTerminaID + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        #endregion

        #region GetAllRezervacijaTermina
        public List<RezervacijaTermina> GetAllRezervacijaTermina()
        {
            List<RezervacijaTermina> rezervacijaList = new List<RezervacijaTermina>();

            Connection con = new Connection();
            SqlCommand command = new SqlCommand();
            command.Connection = con.PoolConnection();
            command.CommandText = "Select * from RezervacijaTermina";

            try
            {
                con.OpenConnection();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    RezervacijaTermina rezervacije = new RezervacijaTermina();
                    rezervacije.IDRezervacija = int.Parse(dataReader["IDRezervacija"].ToString());
                    rezervacije.IDKorisnik = int.Parse(dataReader["IDKorisnik"].ToString());
                    rezervacije.IDTermin = int.Parse(dataReader["IDTermin"].ToString());
                    rezervacije.IDAdmin = int.Parse(dataReader["IDAdmin"].ToString());

                    rezervacijaList.Add(rezervacije);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to get all rezervacija." + ex.Message);
                throw new Exception("Error while trying to get all rezervacija. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
            con.CloseConnection();
            logger.LogInfo(DateTime.Now, "GetAllRezervacijaTermina method has sucessfully invoked.");
            return rezervacijaList;
        }
        #endregion

        #region GetRezervacijaTerminaByID
        public RezervacijaTermina GetRezervacijaTerminaByID(int rezervacijaTerminaID)
        {
            Connection con = new Connection();
            RezervacijaTermina rezervacije = new RezervacijaTermina();
            try
            {
                con.OpenConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = con.PoolConnection();
                command.CommandType = CommandType.Text;

                command.CommandText = @"Select [IDRezervacija], [IDKorisnik], [IDTermin], [IDAdmin] from [PoolApp].dbo.[RezervacijaTermina] where [IDRezervacija] = @IDRezervacija";

                command.Parameters.Add("@IDRezervacija", SqlDbType.Int).Value = rezervacijaTerminaID;

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    rezervacije.IDRezervacija = (int)dataReader[0];
                    rezervacije.IDKorisnik = (int)dataReader[1];
                    rezervacije.IDTermin = (int)dataReader[2];
                    rezervacije.IDAdmin = (int)dataReader[3];
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to get rezervacija by id." + ex.Message);
                throw new Exception("Error while trying to get rezervacija by id. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
            logger.LogInfo(DateTime.Now, "GetRezervacijaByID method has sucessfully invoked.");
            return rezervacije;
        }
        #endregion

        #region UpdateRezervacijaTermina
        public int UpdateRezervacijaTermina(RezervacijaTermina rezervacijaTermina)
        {
            int rezervacijaTerminaID;

            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Update RezervacijaTermina set IDKorisnik = @IDKorisnik, IDTermin = @IDTermin, IDAdmin = @IDAdmin where IDRezervacija = @IDRezervacija";

            command.Parameters.Add("@IDRezervacija", SqlDbType.Int).Value = rezervacijaTermina.IDRezervacija;
            command.Parameters.Add("@IDKorisnik", SqlDbType.Int).Value = rezervacijaTermina.IDKorisnik;
            command.Parameters.Add("@IDTermin", SqlDbType.Int).Value = rezervacijaTermina.IDTermin;
            command.Parameters.Add("@IDAdmin", SqlDbType.Int).Value = rezervacijaTermina.IDAdmin;

            try
            {
                con.OpenConnection();
                rezervacijaTerminaID = Convert.ToInt32(command.ExecuteScalar());
                logger.LogInfo(DateTime.Now, "UpdateRezervacijaTermina method has sucessfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to update rezervacija." + ex.Message);
                throw new Exception("Error while trying to update rezervacija." + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        #endregion


    }
}
