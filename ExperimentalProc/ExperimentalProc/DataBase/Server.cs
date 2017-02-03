using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;


namespace ExperimentalProc.DataBase
{
    class Server
    {
        private string DataBaseConectionString = null;
        protected MySqlConnection connection;
        public Server()
        {

            StreamReader config = new StreamReader("..\\..\\DataBase\\DataBaseConfig.txt");

            while (!config.EndOfStream ) {//load config functions
                string[] line = config.ReadLine().Split(':');

                if(line[0] == "DataBase Conection String") { DataBaseConectionString = line[1]; }//database conection string

                //TODO add ADMIN config
            }

            //DataBaseConectionString = "server=stusql;uid=lc10;database=EnterpriseFinalBBB;";//deadcode: replaced with config
            
            try
            {
                connection = new MySqlConnection(DataBaseConectionString);
                System.Console.WriteLine("Connection Made");
            }
            catch(MySqlException excp)
            {
                System.Console.WriteLine("Connection Failed: " + excp);
            }
            
        }

        public Boolean InsertIntoDataBase()
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "CREATE TABLE Enrollment(FirstName nvarchar(20), LastName nvarchar(20), UserID char(4));";//alter this to be an insert statment
            try
            {
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            catch(MySqlException excp)
            {
                System.Console.WriteLine("Failed to run InsertIntoDataBase: " + excp);
                connection.Close();
                return false;
            }

            connection.Close();
            return true;
        }



    }
}
