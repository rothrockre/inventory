using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using System.Data;

namespace Inventory.Database
{
    public class ConnectDatabase {
        private SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
        public void ConnectDB()
        {
            //SqlConnection conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["MyDbConn"].ConnectionString);
            conn.Open();
            
        }

        public void AddNewUser(string name, string password)
        {

            
            SqlCommand cmd = new SqlCommand("adduser", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", name);
            cmd.Parameters.AddWithValue("@password", password);
            conn.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            conn.Close();

        }
      


    }
    
}
