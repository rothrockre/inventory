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
            DataManager dm = new DataManager();
            string[] hashpass = new string[2];

            if (UsernameExists(name))
            {
                hashpass = dm.HashPassword(password);

                SqlCommand cmd = new SqlCommand("adduser", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", name);
                cmd.Parameters.AddWithValue("@password", hashpass[0]);
                cmd.Parameters.AddWithValue("@hashkey", hashpass[1]);
                conn.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                conn.Close();
            }

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
                while(dr.Read())    //really do not need this while just the stuff inside since there is only one entry inside the Items table.
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

        /* UsernameExists
         * 
         * returns false if username does not exist and true if the username exists in the Users Table.
         */
        public bool UsernameExists(string username)
        {
            SqlCommand cmd = new SqlCommand("CheckUsernameExists", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            conn.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            bool exists = false;
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    exists = dr.GetBoolean(0);
                }
            }
            dr.Close();
            conn.Close();
            return !exists;

        }



    }
    
}
