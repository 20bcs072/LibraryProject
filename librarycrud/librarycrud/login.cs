using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarycrud
{
    internal class login
    {
        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=Library;Persist Security Info=True;User ID=sa;Password=sql@123";
        public static string username;
        public static string pwd;
        public void LoginUserInput()
        {
            Console.WriteLine("Enter Admin Username:");
            username = Console.ReadLine();
            Console.WriteLine("Enter password:");
            pwd = Console.ReadLine();
        }

        public void ShowMenu()
        {

            
            program.Menu();
            Console.WriteLine("Would you like to continue (Y / N)");
            char choice = Convert.ToChar(Console.ReadLine());
            while (choice == 'Y' && choice != 'N')
            {
                program.Menu();
            }
        }
        public void logincheck()
        {
            using (var con = new SqlConnection(connectionString))
            {

                LoginUserInput();

                using (var cmd = new SqlCommand("select dbo.logincheck(@username,@pwd)", con))
                {

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pwd", pwd);

                    con.Open();
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count == 1)
                    {

                        Console.WriteLine("welcome " + username);
                        program.Menu();
                        con.Close();

                    }
                    else
                    {
                        Console.WriteLine("Admin Profile Not available!!!");
                        Registration.UserRegistration();

                    }
                }
            }
        }
    }
}
