using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Anime
{
    public class DBConnect
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;

        //Constructor
        public DBConnect(string host, string db, string user, string pwd)
        {
            server = host;
            database = db;
            uid = user;
            password = pwd;
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        public bool OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show("Bad error : "+ ex.Number.ToString());
                        break;
                }
                return false;
            }
        }

        //Close connection
        public bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //Insert statement
        public void Save(Dictionary<string, Dictionary<string,string>> manga)
        {
            if(OpenConnection() == true)
            {
                Dictionary<string, string> fields = new Dictionary<string, string>();

                KeyValuePair<string, Dictionary<string, string>> pair = manga.First();
                    fields = pair.Value;
                string query = "";
                query += @"CREATE TABLE IF NOT EXISTS 'tanime' (
  'idAnime' int(11) NOT NULL AUTO_INCREMENT";
                foreach(KeyValuePair<string,string> field in fields)
                {
                    query += @",'"+field.Key+"' varchar(255)";
                }
  query += @"PRIMARY KEY ('idAnime')) ENGINE=MyISAM DEFAULT CHARSET=latin1 AUTO_INCREMENT=1 ;";

            }
        }

        public bool userExist(string pseudo)
        {
            if (OpenConnection() == true)
            {
                string query = "SELECT COUNT(*) AS count FROM tuser WHERE pseudo = \"" + pseudo + "\" ";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);


                int count = int.Parse(cmd.ExecuteScalar()+"");
                    if (count != 0)
                    {
 

                        //close Connection
                        this.CloseConnection();
                        return true;
                    }
                    else
                    {


                        //close Connection
                        this.CloseConnection();
                        return false;
                    }


            }
            else
            {
                CloseConnection();
                return false;
            }
        }

        public void createUser(string pseudo)
        {
            if (OpenConnection() == true)
            {
                string query = "INSERT INTO tuser(pseudo) VALUES (\"" + pseudo + "\")";
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                cmd.ExecuteNonQuery();
            }
        }

        public int getIdUser(string pseudo)
        {
            if (OpenConnection() == true)
            {
                string query = "SELECT idUser FROM tuser WHERE pseudo = \"" + pseudo + "\"";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                return int.Parse(cmd.ExecuteScalar() + "");
            }
            else
            {
                return -1;
            }
        }

        //Update statement
        public void Update()
        {
        }

        //Delete statement
        public void Delete()
        {
        }

        //Select statement
        //public List<string>[] Select()
        //{
            
        //}

        //Count statement
        public int Count()
        {
            return 1;
        }

        //Backup
        public void Backup()
        {
        }

        //Restore
        public void Restore()
        {
        }
    }
}
