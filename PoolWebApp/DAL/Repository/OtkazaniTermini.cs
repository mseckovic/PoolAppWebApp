using DAL.Interface;
using InfrastructuredServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public class OtkazaniTermini : IOtkazaniTerminiRepository
    {
        #region Logger
        Logger logger = new Logger();
        #endregion

        #region AddOtkazaniTermin
        public void AddOtkazaniTermin(Model.OtkazaniTermini otkazaniTermin)
        {
            if (otkazaniTermin == null)
            {
                throw new NullReferenceException();
            }

            Connection con = new Connection();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = con.PoolConnection();
                command.CommandType = CommandType.Text;
                command.CommandText = @"Insert into [PoolApp].[dbo].[OtkazaniTermini] ([IDRezervacija]) Values (@IDRezervacija);";

                command.Parameters.Add("@IDRezervacija", SqlDbType.Int).Value = otkazaniTermin.IDRezervacija;

                command.ExecuteNonQuery();
                logger.LogInfo(DateTime.Now, "AddOtkazaniTermin method has sucessfuly invoked.");
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to add new OtkazaniTermin." + ex.Message);
                throw new Exception("Error while trying to add new OtkazaniTermin." + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        #endregion
        #region OtkazaniTerminiList
        //Smisliti ovaj deo
        #endregion
    }
}
