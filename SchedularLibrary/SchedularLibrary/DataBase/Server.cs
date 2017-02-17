using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;




namespace ExperimentalProc.DataBase
{
    public class Server
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
            catch(SqlException excp)
            {
                System.Console.WriteLine(DataBaseConectionString);
                System.Console.WriteLine("Connection Failed: " + excp);
            }
            
        }

        //generic insert into database statment
        public bool InsertIntoDataBase()
        {
            
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO Rooms (Room_ID,Room_Name) VALUES("+ (int) 404 +","+ "'Art Room'" +"); ";//alter this to be an insert statment
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


        /*
         Attempts a brute force insert of all data considered valid by target parameters.
         Does not check against data inside database.
         If a target parameters are not valid within given context, function will imediantly terminate and no data will be inserted into database [returns false].
             
             Parmeters(implicit):
             Target Database: Defined by [DataBase Connetion String] in [DataBase/DataBaseConfig.txt]

             Parmeters(defined):
             year(string): target year for upload into database. used by (Calander Logic) and [Calandar/CalanderFormater.cs]
             month(string): target month to upload target data. if left as (null) or (0) all months will be targeted
             week(string): target day of week to upload target data. if left as (null) or (0) all weeks will be targeted
             day(string): target day of target month(s) to upload target data. if left as (null) or (0) all days will be targeted
             room(string): roomID of target data to upload into database
             course(string): courseID of target data to upload into database
             */
        public bool InsertSchedualItem(string year, string month, string week, string day, string room, string course)
        {

            //Convert Year Logic
            int yearParse;
            if(int.TryParse(year,out yearParse))
            {
                //Pre insert Year Logic Here:

            }else
            {
                System.Console.WriteLine("Failed to Parse <STRING_YEAR: "+ year +"> too INT");
                return false;
            }


            //Convert Month Logic
            int monthParse;
            if (int.TryParse(month, out monthParse))
            {
                //Pre insert Month Logic Here:

            }else if(month == null)
            {
                monthParse = 0;
            }else
            {
                System.Console.WriteLine("Failed to Parse <STRING_MONTH: " + month + "> too INT");
                return false;
            }


            //Convert Week Logic
            int weekParse;
            if (int.TryParse(week, out weekParse))
            {
                //Pre insert Day Logic Here:

            }
            else if (week == null)
            {
                weekParse = 0;
            }
            else
            {
                System.Console.WriteLine("Failed to Parse <STRING_WEEK: " + week + "> too INT");
                return false;
            }


            
            //Convert Day Logic
            int dayParse;
            if (int.TryParse(day, out dayParse))
            {
                //Pre insert Day Logic Here:

            }
            else if (day == null)
            {
                dayParse = 0;
            }
            else
            {
                System.Console.WriteLine("Failed to Parse <STRING_DAY: " + day + "> too INT");
                return false;
            }


            //Convert Room Logic
            int roomParse;
            if (int.TryParse(room, out roomParse))
            {
                //Pre insert Room Logic Here:

            }
            else if (room == null)
            {
                roomParse = 0;
            }
            else
            {
                System.Console.WriteLine("Failed to Parse <STRING_ROOM: " + room + "> too INT");
                return false;
            }


            //Convert Week Logic
            int courseParse;
            if (int.TryParse(course, out courseParse))
            {
                //Pre insert Course Logic Here:

            }
            else if (course == null)
            {
                courseParse = 0;
            }
            else
            {
                System.Console.WriteLine("Failed to Parse <STRING_COURSE: " + course + "> too INT");
                return false;
            }

            //Dan : Calandar logic

            //TODO: paused work on this funtion here untill Data/Calandar/CalandarFormater.cs can be used to handle finding valid days logic
            //Should be ready to impliment, still needs to be tested though

            //Dan : find valid days logic
            SqlCommand cmd = new SqlCommand();
            GregorianCalendar GC = new GregorianCalendar();
            int nonSpecMonth = 1;
            int nonSpecWeek = 1;
            int nonSpecDay = 1;
            
            for (int curDay = 0; curDay <= GC.GetDaysInYear(yearParse); curDay++)
            {


                if (monthParse == 0)//month not specified
                {
                    if (weekParse == 0)//week not specified
                    {
                        if (dayParse == 0)//day not specified
                        {

                        }//end day not specified

                    }//end week not specified

                }//end month not specified

            }//for days in year

            

            try
            {
                connection.Open();
                //SqlCommand cmd = new SqlCommand();//moved to : find valid days logic
                cmd.Connection = connection;
                //cmd.CommandText = null;//moved to : find valid days logic
                cmd.ExecuteNonQuery();
            }
            catch (SqlException excp)
            {
                System.Console.WriteLine("Failed to run InsertIntoDataBase: " + excp);
                connection.Close();
                return false;
            }

            return true;
        }



    }
}
