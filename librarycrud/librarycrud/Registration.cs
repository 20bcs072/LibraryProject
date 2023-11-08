using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarycrud
{
    internal class Registration
    {
        public static void UserRegistration()
        {
            login l = new login();
            l.LoginUserInput();
            using var con = new SqlConnection(login.connectionString);


            using (var cmd = new SqlCommand("adminregistration", con))
            {


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", login.username);
                cmd.Parameters.AddWithValue("@pwd", login.pwd);
                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("User registration successfull");
                l.ShowMenu();


            }
        }
    }
}
