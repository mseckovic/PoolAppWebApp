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
    public class TerminRepository : ITerminRepository
    {
        #region Logger
        Logger logger = new Logger();
        #endregion

        #region AddTermin
        public int AddTermin(Termin termin)
        {
            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into Termin ( VremeOd, VremeDo, DatumTermina, IDBazen, IDRezervacija, IDAdmin) Values ( @VremeOd, @VremeDo, @DatumTermina, @IDBazen, @IDRezervacija, @IDAdmin)";

            command.Parameters.Add("@VremeOd", SqlDbType.Time).Value = termin.VremeOd;
            command.Parameters.Add("@VremeDo", SqlDbType.Time).Value = termin.VremeDo;
            command.Parameters.Add("@DatumTermina", SqlDbType.Date).Value = termin.DatumTermina;
            command.Parameters.Add("@IDBazen", SqlDbType.Int).Value = termin.IDBazen;
            command.Parameters.Add("@IDRezervacija", SqlDbType.Int).Value = termin.IDRezervacija;
            command.Parameters.Add("@IDAdmin", SqlDbType.Int).Value = termin.IDAdmin;

            try
            {
                con.OpenConnection();
                command.ExecuteNonQuery();
                logger.LogInfo(DateTime.Now, "AddTermin method has succesfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to add new Termin. " + ex.Message);
                throw new Exception("Error while trying to add new Termin. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        #endregion

        #region DeleteTermin
        public int DeleteTermin(int terminID)
        {
            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Delete from Termin where IDTermin = @IDTermin";

            command.Parameters.Add("@IDTermin", SqlDbType.Int).Value = terminID;

            try
            {
                con.OpenConnection();
                command.ExecuteNonQuery();
                logger.LogInfo(DateTime.Now, "DeleteTermin method has sucessfully invoked on Termin with IDTermin = " + terminID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to delete Termin with IDTermin = " + terminID + ex.Message + ".");
                throw new Exception("Error while trying to delete Termin with IDTermin = " + terminID + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        #endregion

        #region GetAllTermin
        public List<Termin> GetAllTermin()
        {
            List<Termin> terminList = new List<Termin>();

            Connection con = new Connection();
            SqlCommand command = new SqlCommand();
            command.Connection = con.PoolConnection();
            command.CommandText = "Select * from Termin";

            try
            {
                con.OpenConnection();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Termin termini = new Termin();
                    termini.IDTermin = int.Parse(dataReader["IDTermin"].ToString());
                    termini.VremeOd = TimeSpan.Parse(dataReader["VremeOd"].ToString());
                    termini.VremeDo = TimeSpan.Parse(dataReader["VremeDo"].ToString());
                    termini.DatumTermina = Convert.ToDateTime(dataReader["DatumTermina"].ToString());
                    termini.IDBazen = int.Parse(dataReader["IDBazen"].ToString());
                    termini.IDRezervacija = int.Parse(dataReader["IDRezervacija"].ToString());
                    termini.IDAdmin = int.Parse(dataReader["IDAdmin"].ToString());

                    terminList.Add(termini);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to get all termin." + ex.Message);
                throw new Exception("Error while trying to get all termin. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
            con.CloseConnection();
            logger.LogInfo(DateTime.Now, "GetAllTermin method has sucessfully invoked.");
            return terminList;
        }
        #endregion

        #region GetTerminByID
        public Termin GetTerminByID(int terminID)
        {
            Connection con = new Connection();
            Termin termini = new Termin();
            try
            {
                con.OpenConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = con.PoolConnection();
                command.CommandType = CommandType.Text;

                command.CommandText = @"Select [IDTermin], [VremeOd], [VremeDo], [DatumTermina], [IDBazen], [IDRezervacija], [IDAdmin] from [PoolApp].dbo.[Termin] where [IDTermin] = @IDTermin";

                command.Parameters.Add("@IDTermin", SqlDbType.Int).Value = terminID;

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    termini.IDTermin = int.Parse(dataReader[0].ToString());
                    termini.VremeOd = TimeSpan.Parse(dataReader[1].ToString());
                    termini.VremeDo = TimeSpan.Parse(dataReader[2].ToString());
                    termini.DatumTermina = Convert.ToDateTime(dataReader[3].ToString());
                    termini.IDBazen = int.Parse(dataReader[4].ToString());
                    termini.IDRezervacija = int.Parse(dataReader[5].ToString());
                    termini.IDAdmin = int.Parse(dataReader[6].ToString());
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to get termin by id." + ex.Message);
                throw new Exception("Error while trying to get termin by id. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
            logger.LogInfo(DateTime.Now, "GetTerminByID method has sucessfully invoked.");
            return termini;
        }
        #endregion

        #region UpdateTermin
        public int UpdateTermin(Termin termin)
        {
            int terminID;

            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Update Termin set VremeOd = @VremeOd, VremeDo = @VremeDo, DatumTermina = @DatumTermina, IDBazen = @IDBazen, IDRezervacija = @IDRezervacija, IDAdmin = @IDAdmin where IDTermin = @IDTermin";

            command.Parameters.Add("@IDTermin", SqlDbType.Int).Value = termin.IDTermin;
            command.Parameters.Add("@VremeOd", SqlDbType.Time).Value = termin.VremeOd;
            command.Parameters.Add("@VremeDo", SqlDbType.Time).Value = termin.VremeDo;
            command.Parameters.Add("@DatumTermina", SqlDbType.Date).Value = termin.DatumTermina;
            command.Parameters.Add("@IDBazen", SqlDbType.Int).Value = termin.IDBazen;
            command.Parameters.Add("@IDRezervacija", SqlDbType.Int).Value = termin.IDRezervacija;
            command.Parameters.Add("@IDAdmin", SqlDbType.Int).Value = termin.IDAdmin;

            try
            {
                con.OpenConnection();
                terminID = Convert.ToInt32(command.ExecuteScalar());
                logger.LogInfo(DateTime.Now, "UpdateTermin method has sucessfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to update termin." + ex.Message);
                throw new Exception("Error while trying to update termin." + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        #endregion
    }
}
