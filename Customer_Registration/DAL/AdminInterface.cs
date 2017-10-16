using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Customer_Registration.Models;
namespace Customer_Registration.DAL
{
    public class AdminInterface
    {
        public static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public static bool GetAdminData(string id, string password)
        {
            if(id.Equals("Guest") && password.Equals("Guest@123"))
            {
                return true;
            }
            else
            {
                return false;
            }
          /*  List<Customer> customer = new List<Customer>();
            SqlCommand cmd = new SqlCommand("select * from Customer order by cid desc", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                customer.Add(new Customer()
                {
                    cid = dr[0].ToString(),
                    name = dr[1].ToString(),
                    surname = dr[2].ToString(),
                    email = dr[3].ToString(),
                    username = dr[4].ToString()
                });
            }
            con.Close();
            return customer;*/

        }
    }
}