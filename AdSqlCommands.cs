using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONetPrac
{
    internal class AdSqlCommands
    {
       public static string cs = "Data Source=ZEESHANN-LAP\\SQLEXPRESS;Database=AdoDB;Integrated Security=True";
        public SqlConnection con = new SqlConnection(cs);
        public SqlCommand cmd;
        public string query;

        //read data
        public void Read()
        {
            query = "select * from std";
             cmd = new SqlCommand(query, con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader[0] + " " + reader[1] + " " + reader[2] + " " + reader[3]);
            }
            
        }
        //Add record
        public void Write()
        {
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter Student Age");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Student Section");
            string section = Console.ReadLine();


            query = $"insert into std values('{name}','{age}','{section}')";
            cmd=new SqlCommand(query, con);
            cmd.ExecuteNonQuery();

        }
        //delete record
        public void Delete(int id)
        {
            
            query = $"delete from std where Id='{id}'";
            cmd=new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            Console.WriteLine($"Student Record Of ID : {id} Deleted\n");
        }

        //update record
        public void Update(int id)
        {

            Console.WriteLine("Enter Updated name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Updated Age");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Updated Section");
            string section = Console.ReadLine();

            string query = $"UPDATE std SET name='{name}', age={age}, section='{section}' WHERE Id='{id}'";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.ExecuteNonQuery();
            Console.WriteLine("Student Record of ID: " + id + " updated");


        }
        //check exist id or not
        public void ChkId(int ch,string op )
        {
            Console.WriteLine("Enter Student Id "+op);
            int id = int.Parse(Console.ReadLine());
            // check id exist or not 
            string chkQuery = $"select count(*) from std where Id='{id}'";
            cmd = new SqlCommand(chkQuery, con);
            int count = (int)cmd.ExecuteScalar();


                if (count == 1)
                {
                if (ch == 3)
                {

                    Delete(id);
                }
                else Update(id);
                }
                else
                {
                    Console.WriteLine("Id not found");
                ChkId(ch,op);
                }
            
            
        }
    }
}
