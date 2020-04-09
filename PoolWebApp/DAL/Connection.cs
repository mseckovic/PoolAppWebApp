using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Connection
    {
        SqlConnection con;

        public Connection() 
        {
            con = new SqlConnection(@"Data Source = (local)\SqlExpress; Initial Catalog = PoolApp; Integrated Security = True");
        }

        public SqlConnection PoolConnection() 
        {
            return con;
        }

        public void OpenConnection() 
        {
            con.Open();
        }

        public void CloseConnection()
        {
            con.Close();
        }
    }
}
