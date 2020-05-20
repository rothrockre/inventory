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

        public string GetStock()
        {
            SqlCommand cmd = new SqlCommand("getitems", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            string itemName = "";
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    itemName = dr.GetString(1);
                    //int numInStock = dr.GetInt32(2);
                    //string locationInStore = dr.GetString(3);
                    //float price = dr.GetFloat(4);
                    //float priceToMake = dr.GetFloat(5);
                    //float profit = dr.GetFloat(6);
                    //DateTime LastSoldDate = dr.GetDateTime(7);
                    //DateTime LastTruckDate = dr.GetDateTime(8);
                    //DateTime NextTruckDate = dr.GetDateTime(9);
                }
            }
            dr.Close();
            conn.Close();
            return itemName;
        }

    }
    
}
