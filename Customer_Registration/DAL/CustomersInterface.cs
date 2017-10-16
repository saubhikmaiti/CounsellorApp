using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using Customer_Registration.Models;
using System.Data;
namespace Customer_Registration.DAL
{
    public class CustomersInterface
    {
        public static SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        public static SqlConnection con1 = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

        public static void Insert_Customer_Info(string name, string surname, string email, string username, string password, string dateofBirth)
        {

            SqlCommand cmd = new SqlCommand("insert into Customer values (@a,@b,@c,@d,@e,@f,@g)", con);
            cmd.Parameters.Add(new SqlParameter("@a", name));
            cmd.Parameters.Add(new SqlParameter("@b", surname));
            cmd.Parameters.Add(new SqlParameter("@c", email));
            cmd.Parameters.Add(new SqlParameter("@d", username));
            cmd.Parameters.Add(new SqlParameter("@e", password));
            cmd.Parameters.Add(new SqlParameter("@f", DateTime.Now));
            cmd.Parameters.Add(new SqlParameter("@g", Convert.ToDateTime(dateofBirth)));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public static void UpdateCustomerFields(string cid, string val, string field)
        {
            if (field.Equals("email"))
                field = "email";
            else if (field.Equals("username"))
                field = "username";
            else if (field.Equals("name"))
                field = "cname";
            else if (field.Equals("surname"))
                field = "surname";
            else if (field.Equals("DateOfBirth"))
                field = "DateOfBirth";
            
            
            SqlCommand cmd = new SqlCommand("update Customer set "+field +" = @val where cid= @cid", con);
            cmd.Parameters.Add(new SqlParameter("@val", val));
            cmd.Parameters.Add(new SqlParameter("@cid", cid));

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

        }

        public static List<Customer> GetCustomersData()
        {
            DateTime created_time;
            DateTime DateofBirth;
            List<Customer> customer = new List<Customer>();
            SqlCommand cmd = new SqlCommand("select * from Customer order by cid desc", con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (dr[6].ToString().Equals(String.Empty))
                    created_time = DateTime.Now;
                else
                    created_time = Convert.ToDateTime(dr[6]);
                if (dr[7].ToString().Equals(String.Empty))
                    DateofBirth = DateTime.Now;
                else
                    DateofBirth = Convert.ToDateTime(dr[7]);

                customer.Add(new Customer() { cid = dr[0].ToString(), name = dr[1].ToString(), surname = dr[2].ToString(), email = dr[3].ToString(), username = dr[4].ToString(), DateOfBirth = DateofBirth, Created_Time = created_time });
            }
            con.Close();
            return customer;

        }

        public static List<Customer_Info> GetBreakDownByAge()
        {
          List<Customer_Info> customer_info = new List<Customer_Info>();
          SqlCommand cmd = new SqlCommand("select FLOOR(DATEDIFF(DAY,dateofBirth, getdate() ) / 365.25) as dateofBirth, count(cid) as total_users from customer where  dateofBirth is not null group by FLOOR(DATEDIFF(DAY,dateofBirth, getdate() ) / 365.25)", con);
          con.Open();
          SqlDataReader dr = cmd.ExecuteReader();
          while (dr.Read())
          {
            customer_info.Add(new Customer_Info() { dateofbirth = dr[0].ToString(), count_customer = dr[1].ToString() });
          }
          con.Close();
          return customer_info;
        }

        public static List<Customer_Info> GetUsersPerHour()
        {
          List<Customer_Info> customer_info = new List<Customer_Info>();
          //cast(created_date as date) as create_time,
          string sql ="select datepart(hour,created_date) as onHour, count(cid) as total_users from customer where  created_date is not null and cast(created_date as date)  =cast(getdate() as date) group by cast(created_date as date),  datepart(hour, created_date)";
         // string sql = "SELECT [Hourly], COUNT(*) as [Count]  FROM  (SELECT dateadd(hh, datediff(hh, '20010101', [created_date]), '20010101') as [Hourly] FROM customer where created_date is not null) idat GROUP BY [Hourly]";
          SqlCommand cmd = new SqlCommand(sql, con1);
         con1.Open();
          SqlDataReader dr = cmd.ExecuteReader();
          while (dr.Read())
          {
            customer_info.Add(new Customer_Info() { Created_Time = dr[0].ToString(), count_customer = dr[1].ToString() });
          }
          con1.Close();
          return customer_info;
        }

        private bool IsValidConnection(IDbConnection connection)
        {
          return (connection != null && connection.State == ConnectionState.Open);
        }

    }
}