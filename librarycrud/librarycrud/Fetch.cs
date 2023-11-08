using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace librarycrud
{
    internal class Fetch
    {
        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=Library;Persist Security Info=True;User ID=sa;Password=sql@123";
        public static void Getbook()
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("getbook", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"book Id :{reader["bookid"]}," + "\n" +
                                $"book Name :{reader["title"]}," + "\n" +
                                $"Author Name :{reader["publisher"]}," + "\n" +
                                $"type of the book :{reader["booktype"]}," + "\n" +
                                $"Edition :{reader["Edition"]}," + "\n" +
                                $"published date :{reader["publisheddate"]}");
                        }
                    }
                }

            }
        }
    }
}
