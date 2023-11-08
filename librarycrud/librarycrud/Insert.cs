using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarycrud
{
    internal class Insert
    {
        public static string title;
        public static string publisher;
        public static string booktype;
        public static int edition;
        public static DateTime publisheddate;
        public static int bookid;
        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=Library;Persist Security Info=True;User ID=sa;Password=sql@123";
        public static void GetUserInput()
        {
            Console.WriteLine("Enter the book name :");
            title = Console.ReadLine();

            Console.WriteLine("Enter the  Author name :");
            publisher = Console.ReadLine();

            Console.WriteLine("Enter the type of the book :");
            booktype = (Console.ReadLine());

            Console.WriteLine("Enter the edition :");
            edition = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the published date :");
            publisheddate = Convert.ToDateTime(Console.ReadLine());
        }
        public static void InsertBook()
        {
            GetUserInput();
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("insertbook", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@publisher", publisher);
                    cmd.Parameters.AddWithValue("@booktype", booktype);
                    cmd.Parameters.AddWithValue("@edition", edition);
                    cmd.Parameters.AddWithValue("publisheddate", publisheddate);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("book details successfully added");
                    Console.WriteLine("Please find the book details below :");

                    //GetPropertyById();
                    libraryADO.GetbookByName(title);
                    
                }
            }
        }
    }
}
