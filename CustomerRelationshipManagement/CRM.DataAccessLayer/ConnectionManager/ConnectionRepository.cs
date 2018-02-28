using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup;

namespace CRM.DataAccessLayer.ConnectionManager
{
   public class ConnectionRepository
    {
        private  string _connectionString;
        public SqlConnection con;
        public ConnectionRepository()
        {
            //_connectionString = ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString;
            //_connectionString = ConfigurationManager.ConnectionStrings["sqlConn"].ConnectionString;
         
            _connectionString = "";

        }
        public string GetConnectionString()
        {
            return _connectionString;
        }
        public SqlConnection GetConnection()
        {
            //return new SqlConnection(_connectionString);
            return new SqlConnection(@"Data Source=WKC001335054\SQLEXPRESS;Database=College;Integrated Security=True;");
        }

        //public SqlConnection GetConnection()
        //{
        //    return new SqlConnection(_connectionString);
        //}
        public void OpenConnection()
        {
            con = GetConnection();
            con.Open();
        }

    }
}
