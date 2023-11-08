using librarycrud;
using System.Security.Cryptography.X509Certificates;

class program
{
    public static void Main(string[] args)
    {
        //libraryADO obj= new libraryADO();
        //obj.InsertBook();
        //obj.Updatebook();
        //obj.Getbook();
        //obj.Deletebook();
        Console.WriteLine("Welcome to Library !");
        Console.WriteLine("Admin users can login & do their functions here!!");
        Console.WriteLine("--------------------------------------------------------------");
        program obj = new program();
        login lg=new login();
        lg.logincheck();

    }

    public static void Menu()
    {


        while (true)
        {
            Console.WriteLine("--------------------------------------------------------------");
            Console.WriteLine("Choose \n 1.Insert Book \n 2.Update Book \n 3.Get Book \n 4.Delete Book \n 5.Exit");
            Console.WriteLine("What do you Need ????");
            int options = Convert.ToInt32(Console.ReadLine());


            switch (options)
            {

                case 1:
                    Insert.InsertBook();
                    break;
                case 2:
                    Update.Updatebook();
                    break;
                case 3:
                    Fetch.Getbook();
                    break;
                case 4:
                    Delete.Deletebook();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;

            }
        }
    }

}