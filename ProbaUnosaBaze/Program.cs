using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProbaUnosaBaze
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BeletrixDatabase;Integrated Security=True;");

            //string sifra;
            //for (int i = 0; i < 8; i++) {
            //    sifra = "S";
            //    sifra += i;
            //    for (int j = 1; j < 5; j++) {
            //        sifra = "S"+i;
            //        sifra += j;
            //        connection.Open();
            //        SqlCommand command = connection.CreateCommand();
            //        command.CommandText = $"insert into Positions values ('{sifra+5}','0')";
            //        command.ExecuteNonQuery();
            //        connection.Close();
            //        Console.WriteLine(sifra+5);
            //    }
            //}
            //connection.Open();
            //SqlCommand command = connection.CreateCommand();
            //command.CommandText = "update Positions set Slobodno = 1";
            //command.ExecuteNonQuery();
            //connection.Close();

            //connection.Open();
            //SqlCommand command = connection.CreateCommand();
            //command.CommandText = "delete from Entrance";
            //command.ExecuteNonQuery();
            //connection.Close();


            Console.WriteLine("Uspesno ubaceno");

            Console.ReadLine();
        }
    }
}
