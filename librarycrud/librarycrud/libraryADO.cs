using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace librarycrud
{
    internal class libraryADO
    {

        public static string title;
        public static string publisher;
        public static string booktype;
        public static int edition;
        public static DateTime publisheddate;
        public static int bookid;
        public static string connectionString = "Data Source=ICPU0076\\SQLEXPRESS;Initial Catalog=Library;Persist Security Info=True;User ID=sa;Password=sql@123";


        public static void GetbookByName(string title)
        {
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("getbookbyname", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@title", title);

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

        public static void GetbookById()
        {
            Console.WriteLine("Enter the book Id :");
            bookid = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("*************************************************");
            Console.WriteLine("Please find the book details below :");
            using (var con = new SqlConnection(connectionString))
            {
                using (var cmd = new SqlCommand("getbookbyid", con))
                {
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@bookid", bookid);

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

