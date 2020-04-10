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
    public class BazenRepository : IBazenRepository
    {
        #region Logger
        Logger logger = new Logger();
        #endregion

        #region AddBazen
        public int AddBazen(Bazen bazen)
        {
            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into Bazen ( TipBazena) Values ( @TipBazena)";

            command.Parameters.Add("@TipBazena", SqlDbType.VarChar).Value = bazen.TipBazena;

            try
            {
                con.OpenConnection();
                command.ExecuteNonQuery();
                logger.LogInfo(DateTime.Now, "AddBazen method has succesfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to add new Bazen. " + ex.Message);
                throw new Exception("Error while trying to add new Bazen. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        #endregion

        #region DeleteBazen
        public int DeleteBazen(int bazenID)
        {
            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Delete from Bazen where IDBazen = @IDBazen";

            command.Parameters.Add("@IDBazen", SqlDbType.Int).Value = bazenID;

            try
            {
                con.OpenConnection();
                command.ExecuteNonQuery();
                logger.LogInfo(DateTime.Now, "DeleteAdmin method has sucessfully invoked on Bazen with IDBazen = " + bazenID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to delete Bazen with IDBazen = " + bazenID + ex.Message + ".");
                throw new Exception("Error while trying to delete Bazen with IDBazen = " + bazenID + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        #endregion

        #region GetAllBazen
        public List<Bazen> GetAllBazen()
        {
            List<Bazen> bazenList = new List<Bazen>();

            Connection con = new Connection();
            SqlCommand command = new SqlCommand();
            command.Connection = con.PoolConnection();
            command.CommandText = "Select * from Bazen";

            try
            {
                con.OpenConnection();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Bazen bazeni = new Bazen();
                    bazeni.IDBazen = int.Parse(dataReader["IDBazen"].ToString());
                    bazeni.TipBazena = dataReader["TipBazena"].ToString();

                    bazenList.Add(bazeni);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to get all bazen." + ex.Message);
                throw new Exception("Error while trying to get all bazen. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
            con.CloseConnection();
            logger.LogInfo(DateTime.Now, "GetAllBazen method has sucessfully invoked.");
            return bazenList;
        }
        #endregion

        #region GetBazenByID
        public Bazen GetBazenByID(int bazenID)
        {
            Connection con = new Connection();
            Bazen bazeni = new Bazen();
            try
            {
                con.OpenConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = con.PoolConnection();
                command.CommandType = CommandType.Text;

                command.CommandText = @"Select [IDBazen], [TipBazena] from [PoolApp].dbo.[Bazen] where [IDBazen] = @IDBazen";

                command.Parameters.Add("@IDBazen", SqlDbType.Int).Value = bazenID;

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    bazeni.IDBazen = (int)dataReader[0];
                    bazeni.TipBazena = dataReader[1].ToString();
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to get Bazen by id." + ex.Message);
                throw new Exception("Error while trying to get Bazen by id. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
            logger.LogInfo(DateTime.Now, "GetBazenByID method has sucessfully invoked.");
            return bazeni;
        }
        #endregion

        #region UpdateBazen
        public int UpdateBazen(Bazen bazen)
        {
            int bazenID;

            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Update Bazen set TipBazena = @TipBazena where IDBazen = @IDBazen";

            command.Parameters.Add("@IDBazen", SqlDbType.Int).Value = bazen.IDBazen;
            command.Parameters.Add("@TipBazena", SqlDbType.VarChar).Value = bazen.TipBazena;

            try
            {
                con.OpenConnection();
                bazenID = Convert.ToInt32(command.ExecuteScalar());
                logger.LogInfo(DateTime.Now, "UpdateBazen method has sucessfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to update bazen." + ex.Message);
                throw new Exception("Error while trying to update bazen." + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        #endregion


    }
}
