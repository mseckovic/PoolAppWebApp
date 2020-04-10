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
    public class AdminRepository : IAdminRepository
    {
        #region Logger
        Logger logger = new Logger();
        #endregion

        #region AddAdmin
        public int AddAdmin(Admin admin)
        {
            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Insert into Admin ( Ime, Prezime, Username, Password) Values ( @Ime, @Prezime, @Username, @Password)";

            command.Parameters.Add("@Ime", SqlDbType.VarChar).Value = admin.Ime;
            command.Parameters.Add("@Prezime", SqlDbType.VarChar).Value = admin.Prezime;
            command.Parameters.Add("@Username", SqlDbType.VarChar).Value = admin.Username;
            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = admin.Password;

            try
            {
                con.OpenConnection();
                command.ExecuteNonQuery();
                logger.LogInfo(DateTime.Now, "AddAdmin method has succesfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to add new Admin. " + ex.Message);
                throw new Exception("Error while trying to add new Admin. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        #endregion

        #region DeleteAdmin
        public int DeleteAdmin(int adminID)
        {
            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Delete from Admin where IDAdmin = @IDAdmin";

            command.Parameters.Add("@IDAdmin", SqlDbType.Int).Value = adminID;

            try
            {
                con.OpenConnection();
                command.ExecuteNonQuery();
                logger.LogInfo(DateTime.Now, "DeleteAdmin method has sucessfully invoked on Admin with IDAdmin = " + adminID + ".");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to delete Admin with IDAdmin = " + adminID + ex.Message + ".");
                throw new Exception("Error while trying to delete Admin with IDAdmin = " + adminID + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        #endregion

        #region GetAdminByID
        public Admin GetAdminByID(int adminID)
        {
            Connection con = new Connection();
            Admin admini = new Admin();
            try
            {
                con.OpenConnection();

                SqlCommand command = new SqlCommand();
                command.Connection = con.PoolConnection();
                command.CommandType = CommandType.Text;

                command.CommandText = @"Select [IDAdmin], [Ime], [Prezime], [Username], [Password] from [PoolApp].dbo.[Admin] where [IDAdmin] = @IDAdmin";

                command.Parameters.Add("@IDAdmin", SqlDbType.Int).Value = adminID;

                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    admini.IDAdmin = (int)dataReader[0];
                    admini.Ime = dataReader[1].ToString();
                    admini.Prezime = dataReader[2].ToString();
                    admini.Username = dataReader[3].ToString();
                    admini.Password = dataReader[4].ToString();
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to get admin by id." + ex.Message);
                throw new Exception("Error while trying to get admin by id. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
            logger.LogInfo(DateTime.Now, "GetAdminByID method has sucessfully invoked.");
            return admini;
        }
        #endregion

        #region GetAllAdmins
        public List<Admin> GetAllAdmin()
        {
            List<Admin> adminList = new List<Admin>();

            Connection con = new Connection();
            SqlCommand command = new SqlCommand();
            command.Connection = con.PoolConnection();
            command.CommandText = "Select * from Admin";

            try
            {
                con.OpenConnection();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Admin admini = new Admin();
                    admini.IDAdmin = int.Parse(dataReader["IDAdmin"].ToString());
                    admini.Ime = dataReader["Ime"].ToString();
                    admini.Prezime = dataReader["Prezime"].ToString();

                    adminList.Add(admini);
                }
                dataReader.Close();
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to get all admins." + ex.Message);
                throw new Exception("Error while trying to get all admins. " + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
            con.CloseConnection();
            logger.LogInfo(DateTime.Now, "GetAllAdmin method has sucessfully invoked.");
            return adminList;
        }
        #endregion

        #region UpdateAdmin
        public int UpdateAdmin(Admin admin)
        {
            int adminID;

            Connection con = new Connection();
            SqlCommand command = new SqlCommand();

            command.Connection = con.PoolConnection();
            command.CommandType = CommandType.Text;
            command.CommandText = "Update Admin set Ime = @Ime, Prezime = @Prezime, Username = @Username, Password = @Password where IDAdmin = @IDAdmin";

            command.Parameters.Add("@IDAdmin", SqlDbType.Int).Value = admin.IDAdmin;
            command.Parameters.Add("@Ime", SqlDbType.VarChar).Value = admin.Ime;
            command.Parameters.Add("@Prezime", SqlDbType.VarChar).Value = admin.Prezime;
            command.Parameters.Add("@Username", SqlDbType.VarChar).Value = admin.Username;
            command.Parameters.Add("@Password", SqlDbType.VarChar).Value = admin.Password;

            try
            {
                con.OpenConnection();
                adminID = Convert.ToInt32(command.ExecuteScalar());
                logger.LogInfo(DateTime.Now, "UpdateAdmin method has sucessfully invoked.");
                return 0;
            }
            catch (Exception ex)
            {
                logger.LogError(DateTime.Now, "Error while trying to update admin." + ex.Message);
                throw new Exception("Error while trying to update admin." + ex.Message);
            }
            finally
            {
                con.CloseConnection();
            }
        }
        #endregion
    }
}
