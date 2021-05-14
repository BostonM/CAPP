using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Text;

namespace CAPP
{
    public class program
    {
      public static void Main(string[] args)
        {
            Database data = new Database();

            Console.WriteLine("Make a choice");
            string str = Console.ReadLine();
            if(str == "A")
            {
                Console.WriteLine("adding an item");
                data.storeData(1, "mangoes", "food", "prioprity", "05-15-2021" ,"false");
            }

            if(str == "R")
            {
                Console.WriteLine("Removing an item ");
                data.RemoveData(1);
            }
            if (str == "E")

            {

            }





        }


    }
}

    
   