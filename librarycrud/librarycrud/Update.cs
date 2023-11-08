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
    internal class Update
    {
        public static string title;
        public static string publisher;
        public static string booktype;
        public static int edition;
        public static DateTime publisheddate;
        public static int bookid;
        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=Library;Persist Security Info=True;User ID=sa;Password=sql@123";

        public static void Updatebook()
        {
            libraryADO.GetbookById();
            Console.WriteLine("Please enter the details to be updated");
            Insert.GetUserInput();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("updatebook", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bookid", bookid);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@publisher", publisher);
                    cmd.Parameters.AddWithValue("@booktype", booktype);
                    cmd.Parameters.AddWithValue("@edition", edition);
                    cmd.Parameters.AddWithValue("publisheddate", publisheddate);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("book details successfully updated");


                }
            }
        }
    }
}
