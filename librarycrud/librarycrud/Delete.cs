using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace librarycrud
{
    internal class Delete
    {
        public static string title;
        public static string publisher;
        public static string booktype;
        public static int edition;
        public static DateTime publisheddate;
        public static int bookid;
        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=Library;Persist Security Info=True;User ID=sa;Password=sql@123";
        public static void Deletebook()
        {

            libraryADO.GetbookById();

            Console.WriteLine("Are you sure that you want to delete this book ? (Y /N)");
            char choice = Convert.ToChar(Console.ReadLine());
            if (choice == 'Y')
            {
                using (var con = new SqlConnection(connectionString))
                {
                    using (var cmd = new SqlCommand("deletebook", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@bookid", bookid);
                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                Console.WriteLine("book successfully deleted");
            }
            else
            {
                Console.WriteLine("book not deleted ");

            }
        }
    }
}
