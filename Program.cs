// See https://aka.ms/new-console-template for more information
//using System.Data.SqlClient;
using System;
using System.Data.SqlClient;
using ADONetPrac;

class Program
{
    static void Main(string[] args)
    {
        AdSqlCommands cmd = new AdSqlCommands();
       
        bool con = true;
        while (con)
        {
            Console.WriteLine("1: Enter 1 for Add Data \n2: Enter 2 for Read Data \n3: Enter 3 for Delete \n4: Enter 4 for exit");
            int choice = int.Parse(Console.ReadLine());
            cmd.con.Open();
            try
            {
                switch (choice)
                {

                    case 1:


                        cmd.Write();

                        break;
                    case 2:


                        cmd.Read();

                        break;

                    case 3:

                        cmd.ChkId(3,"To Delete Record");

                        break;
                    case 4:

                        cmd.ChkId(4, "To Update Record");

                        break;
                    case 5:
                        con = false;
                        break;


                }
                cmd.con.Close();
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
        }

         



        


    }
}