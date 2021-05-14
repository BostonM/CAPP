using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CAPP
{

    public class Database
    {
        private string dataBaseName;
        private string passwd;
        private string root;
        private MySql.Data.MySqlClient.MySqlConnection conn;
        public Database()
        {
            this.dataBaseName = "shopping";
            this.passwd = "Bosaul23@";
            this.root = "root";
            this.connection();
        }
        public void connection()
        {
            this.conn = new MySqlConnection();
            this.conn.ConnectionString = "Server=localhost;Database='" + this.dataBaseName + "';Uid='" + this.root+"';Pwd = '"+ this.passwd+"';";

        }

        public void push()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = "Select *  from shopmanager";
            cmd.Connection = this.conn;

            this.conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            this.conn.Close();

        }

        public void displayItems()
        {
            Console.WriteLine("Current Items  in  the  database");

            using (MySqlConnection con = new MySqlConnection())
            {
                con.ConnectionString = "Server=localhost;Database=shopping;Uid=root;Pwd=Bosaul23@;";
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = "Select * from shopmanager";

                cmd.Connection = con; con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine("id " + reader[0]);
                    Console.WriteLine("product name =>" + reader[1]);
                    Console.WriteLine("Category =>" + reader[2]);
                    Console.WriteLine("Priority =>" + reader[3]);
                    Console.WriteLine("purschased =>" + reader[5]);
                    Console.WriteLine("Date  inserted => " + reader[4]);
                }

            }


        }
        public void editName(int id, string name)
        {
            using (MySqlConnection con = new MySqlConnection())
            {
                Console.WriteLine("this is it");

                con.ConnectionString = "Server=localhost;Database=shopping;Uid=root;Pwd=Bosaul23@;";

                string sql = "UPDATE shopmanager SET productName = '" + name + "'  WHERE  id =" + id + "";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void editCategory(int id, string val)
        {
            using (MySqlConnection con = new MySqlConnection())
            {


                con.ConnectionString = "Server=localhost;Database=shopping;Uid=root;Pwd=Bosaul23@;";

                string sql = "UPDATE shopmanager SET category = '" + val + "'  WHERE  id =" + id + "";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public void editPrior(int id, string prior)
        {
            using (MySqlConnection con = new MySqlConnection())
            {
                Console.WriteLine("Almost there");

                con.ConnectionString = "Server=localhost;Database=shopping;Uid=root;Pwd=Bosaul23@;";

                string sql = "UPDATE shopmanager SET productName = '" + prior + "'  WHERE  id =" + id + "";

                MySqlCommand cmd = new MySqlCommand(sql, con);

                cmd.Connection = con;
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        public int getCount()
        {

            int temp = 0;

            string sql = "SELECT *  FROM shopmanager ";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);

            cmd.Connection = this.conn;

            this.conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                temp++;
            }
            this.conn.Close();
            return temp;


        }
        public int findById(int id)
        {
            int temp = 0;

            string sql = "SELECT id  FROM shopmanager WHERE id =" + id + "";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);

            cmd.Connection = this.conn;

            this.conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (reader[0].ToString() == Convert.ToString(id))
                {

                    temp = Convert.ToInt32(reader[0].ToString());
                }

            }
            this.conn.Close();

            return temp;

        }
        public bool searchById(int id)
        {
            bool temp = false;

            string sql = "SELECT id FROM shopmanager WHERE id ='" + id + "'";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);

            cmd.Connection = this.conn;

            this.conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (Convert.ToInt32(reader[0].ToString()) == id)
                {
                    temp = true;
                }

            }
            this.conn.Close();

            return temp;
        }

        public string findByName(string name)
        {

            string temp = "";

            string sql = "SELECT productName FROM shopmanager WHERE productName ='" + name + "'";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);

            cmd.Connection = this.conn;

            this.conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                if (reader[0].ToString() == name)
                {
                    temp = reader[0].ToString();
                }

            }
            this.conn.Close();

            return temp;

        }
        public void RemoveData(int id)
        {

            Console.WriteLine("Almost There");

            string sql = "DELETE  FROM shopmanager WHERE id =" + id + "";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);

            cmd.Connection = this.conn;

            this.conn.Open();

            cmd.ExecuteNonQuery();

        }
        public void storeData(int id, string productName, string category, string priority, string dateAdded, string purchased)
        {
            //this.conn.Close();
            Console.WriteLine("Almost there  is   removeData function");

            string sql = "INSERT INTO shopmanager (id, productName, category,  priority, dateAdded, purchased) VALUES (@id, @productName,@category, @priority, @dateAdded, @purchased)";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);

            cmd.Parameters.AddWithValue("@id", id);

            cmd.Parameters.AddWithValue("@productName", productName);
            cmd.Parameters.AddWithValue("@category", category);

            cmd.Parameters.AddWithValue("@priority", priority);
            cmd.Parameters.AddWithValue("@dateAdded", dateAdded);
            cmd.Parameters.AddWithValue("@purchased", purchased);

            cmd.Connection = this.conn;
            this.conn.Open();
            cmd.ExecuteNonQuery();
            this.conn.Close();


        }

        public void sortByNameDesc()
        {


            string sql = "SELECT id, productName, category, priority, dateAdded,  purchased   FROM shopmanager ORDER  BY productName DESC";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);

            cmd.Connection = this.conn;

            this.conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("id" + reader[0]);
                Console.WriteLine("productName " + reader[1]);
                Console.WriteLine("category " + reader[2]);
                Console.WriteLine("prioprity " + reader[3]);
                Console.WriteLine("dateAdded " + reader[4]);
                Console.WriteLine("purchased " + reader[4]);
            }
            this.conn.Close();


        }

        public void sortByNameAsc()
        {
            string sql = "SELECT id, productName, category, priority, dateAdded,  purchased   FROM shopmanager ORDER  BY productName ASC";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);

            cmd.Connection = this.conn;

            this.conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine("id" + reader[0]);
                Console.WriteLine("productName " + reader[1]);
                Console.WriteLine("category " + reader[2]);
                Console.WriteLine("prioprity " + reader[3]);
                Console.WriteLine("dateAdded " + reader[4]);
                Console.WriteLine("purchased " + reader[4]);
            }
            this.conn.Close();

        }

        public void update(int id, MySqlDataReader reader)
        {
            reader.Close();
            string state = "true";

            string sqlPurchased = "UPDATE  shopmanager  SET  purchased ='" + state + "' WHERE id ='" + id + "'";

            MySqlCommand cmd = new MySqlCommand(sqlPurchased, this.conn);

            cmd.Connection = this.conn;

            //this.conn.Open();

            cmd.ExecuteNonQuery();

            this.conn.Close();
        }
        public bool markAsPurchased(int id)
        {
            bool temp = false;

            string sql = "SELECT id FROM shopmanager WHERE id ='" + id + "'";

            MySqlCommand cmd = new MySqlCommand(sql, this.conn);

            cmd.Connection = this.conn;

            this.conn.Open();

            MySqlDataReader reader = cmd.ExecuteReader();


            if (reader.Read())
            {
                if (Convert.ToInt32(reader[0].ToString()) == id)
                {
                    int r = Convert.ToInt32(reader[0].ToString());

                    update(Convert.ToInt32(reader[0].ToString()), reader);

                    temp = true;
                }

            }
            this.conn.Close();


            return temp;
        }
    }
}


