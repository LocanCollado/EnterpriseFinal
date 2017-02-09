using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;//depriciated
using System.IO;
using System.Data.SqlClient;


namespace ExperimentalProc.DataBase
{
    class Server
    {
        private string DataBaseConectionString = null;
        protected SqlConnection connection;
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
                connection = new SqlConnection();
                connection.ConnectionString = DataBaseConectionString;
                System.Console.WriteLine("Connection Made");
                System.Console.WriteLine(DataBaseConectionString);
            }
            catch(MySqlException excp)
            {
                System.Console.WriteLine(DataBaseConectionString);
                System.Console.WriteLine("Connection Failed: " + excp);
            }
            
        }

        public Boolean InsertIntoDataBase()
        {
            
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO Rooms (Room_ID,Room_Name) VALUES("+ 404 +","+ "Art Room" +"); ";//alter this to be an insert statment
                cmd.ExecuteNonQuery();
            }
            catch(SqlException excp)
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
