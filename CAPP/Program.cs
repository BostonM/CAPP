using System;
using MySql.Data.MySqlClient;


namespace CAPP
{
    using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = "Server=localhost;Database=shopping;Uid=root;Pwd=Bosaul23@;"; 
                MySqlCommand cmd = new MySqlCommand();
                 cmd.CommandText = "Select *  from shopmanager";
   
                cmd.Connection = con; 
                con.Open(); 
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0]);
                    Console.WriteLine(reader[1]);
                    Console.WriteLine(reader[2]);
                    Console.WriteLine(reader[3]);
                    Console.WriteLine(reader[4]);
                }
Console.ReadLine();
}

 