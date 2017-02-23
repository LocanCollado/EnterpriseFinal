using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using System.Diagnostics;

//Contians problems that must be fixed before push to master [MASTER]
//Contains problems that *SHOULD* be fixed before end of alpha phase [ALPHA]
//Contains problems that would be nice to resolve [TODO]

namespace ExperimentalProc.DataBase
{
    public class Server
    {
        private string DataBaseConectionString = null;
        protected SqlConnection connection;
        public Server()
        {

            StreamReader config = new StreamReader(Path.GetDirectoryName(Uri.UnescapeDataString(new UriBuilder(Assembly.GetAssembly(typeof(Server)).CodeBase).Path)) + "/DataBaseConfig.txt");

            while (!config.EndOfStream ) {//load config functions
                string[] line = config.ReadLine().Split(':');

                if(line[0] == "DataBase Conection String") { DataBaseConectionString = line[1]; }//database conection string

                //TODO add ADMIN config [ALPHA]
            }

            //DataBaseConectionString = "server=stusql;uid=lc10;database=EnterpriseFinalBBB;";//deadcode: replaced with config
            //config path: WebApp/Bin/DataBaseConfig.txt
            
            try
            {
                connection = new SqlConnection();
                connection.ConnectionString = DataBaseConectionString;
                Debug.WriteLine("Connection Made");
                Debug.WriteLine(DataBaseConectionString);
            }
            catch(SqlException excp)
            {
                Debug.WriteLine(DataBaseConectionString);
                Debug.WriteLine("Connection Failed: " + excp);
            }
            
        }

        //TODO: Change this to allow for defined parameters for insert, so it can serve an actual use
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
                Debug.WriteLine("Failed to run InsertIntoDataBase: " + excp);
                connection.Close();
                return false;
            }

            connection.Close();
            return true;
        }

        //this method must be tested and verified to work [MASTER]
        //Parameters (month,week,day) should be modified to allow for multiple target values [ALPHA]
        //need to add defined parmeters for start and end times, must be finished before push to master [MASTER]
        //UPDATE:Dan: I added the paremeters, now we need logic to handle it so we don't insert bad data to dataBase : timeLogic
        /*
         Attempts a brute force insert of all data considered valid by target parameters.
         Does not check against data inside database.
         If a target parameters are not valid within given context, function will imediantly terminate and no data will be inserted into database [returns false].
             
             Parmeters(implicit):
             Target Database: Defined by [DataBase Connetion String] in [WebApp/Bin/DataBaseConfig.txt]

             Parmeters(defined):
             year(string): target year for upload into database. used by (Calander Logic) and [Calandar/CalanderFormater.cs]
             month(string): target month to upload target data. if left as (null) or (0) all months will be targeted
             week(string): target day of week to upload target data. if left as (null) or (0) all weeks will be targeted
             day(string): target day of target month(s) to upload target data. if left as (null) or (0) all days will be targeted
             room(string): roomID of target data to upload into database
             course(string): courseID of target data to upload into database
             startTime(string): time of day following 12 Clock formated to fit "XX:XX" as a 5 character string, defines begining target time of day for upload into dataBase
             endTime(string): time of day following 12 Clock formated to fit "XX:XX" as a 5 character string, defines ending target time of day for upload into dataBase
             */
        public bool InsertSchedualItem(string year, string month, string week, string day, string room, string course , string startTime, string endTime)
        {

            //Convert Year Logic
            int yearParse;
            if(int.TryParse(year,out yearParse))
            {
                //Pre insert Year Logic Here:

            }else
            {
                Debug.WriteLine("Failed to Parse <STRING_YEAR: "+ year +"> too INT");
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
                Debug.WriteLine("Failed to Parse <STRING_MONTH: " + month + "> too INT");
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
                Debug.WriteLine("Failed to Parse <STRING_WEEK: " + week + "> too INT");
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
                Debug.WriteLine("Failed to Parse <STRING_DAY: " + day + "> too INT");
                return false;
            }


            //Convert Room Logic
            int roomParse;
            if (int.TryParse(room, out roomParse))
            {
                //Pre insert Room Logic Here:

            }
            else if (room == null)//Dan: roomID shouldn't be optional either, need to fix before push to master [MASTER]
            {
                roomParse = 0;
            }
            else
            {
                Debug.WriteLine("Failed to Parse <STRING_ROOM: " + room + "> too INT");
                return false;
            }


            //Convert Course Logic
            int courseParse;
            if (int.TryParse(course, out courseParse))
            {
                //Pre insert Course Logic Here:

            }
            else if (course == null)//Dan: hold up... the course ID shouldn't be optional. this needs fixed before we can update master [MASTER]
            {
                courseParse = 0;
            }
            else
            {
                Debug.WriteLine("Failed to Parse <STRING_COURSE: " + course + "> too INT");
                return false;
            }

            //TODO: make sure the (startTime) and (endTime) parameters are correctly formated to be inserted into database [MASTER] : timeLogic

            //Dan : Calandar logic
            Calandar.CalanderFormater CF = new Calandar.CalanderFormater(yearParse);

            SqlCommand cmd = new SqlCommand();//holds information for interacting with database
            //GregorianCalendar GC = new GregorianCalendar();//deadcode: replaced with CalanderFormater

            //Dan : find valid days logic
            for (int curDay = 1; curDay <= CF.GetDaysAmount(); curDay++)//begin for days in year
            {
                bool isValid = true;

                if (monthParse != 0)//if month specified
                {
                    if(CF.getMonthByDay(curDay).getMonthID() != monthParse)//looks to see if current day is in specified month
                    {
                        isValid = false;//makes invalid if it is
                    }

                }//end if month specified

                if (weekParse != 0)//if week specified
                {
                    if(CF.getDayOfWeek(curDay) != weekParse)//looks to see if current day is specified day of week
                    {
                        isValid = false;
                    }
                }//end if week specified

                if (dayParse != 0)//if day specified
                {
                    if(CF.getMonthByDay(curDay).getDayByMonth(dayParse).getDayID() != curDay)//looks to see if current day is specified days into month
                    {
                        isValid = false;
                    }
                }//end if day specified

                if (isValid)
                {
                    //add a line of text to the SQL command object that inserts the target data into the database : find valid days logic
                    cmd.CommandText += "INSERT INTO Schedule(Class_ID,Room_ID,year,month,week,day,Start_Time,End_Time)\n"
                                    + "VALUES(" + courseParse + "," + roomParse + "," + yearParse + "," + CF.getMonthByDay(curDay).getMonthID() + "," + CF.getDayOfWeek(curDay) + "," + CF.getDayByYear(curDay).getDayID() +",'"+ startTime + "','" + endTime + "');\n";
                }

            }//end for days in year

            

            try
            {
                Debug.WriteLine(cmd.CommandText);
                connection.Open();
                //SqlCommand cmd = new SqlCommand();//moved to : find valid days logic
                cmd.Connection = connection;
                //cmd.CommandText = null;//moved to : find valid days logic
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (SqlException excp)
            {
                Debug.WriteLine("Failed to run InsertIntoDataBase: " + excp);
                connection.Close();
                return false;
            }

            return true;
        }//end InsertSchedualItem

        /*
         * (bool) IsConflict(string selectQuery, string[] collumDats, out string[] badRows)
         * takes a query string that selects a table and compares it too a string array containg a set of row data for that table
         * 
         *      Parameters(implicit):
         *      Target Database: Defined by [DataBase Connetion String] in [WebApp/Bin/DataBaseConfig.txt]
         * 
         *      Parameters(defined):
         *      selectQuery(string): a SQL select statment that must reuturn the primary key as the first element and all data must be returned
         *              as the same element index as the value it is to be compared too in [collumDats]
         *      collumDats(string[]): an array of string values that represent a row of data to compare against, any element index with its value as (null)
         *              will not be checked for conflicts
         *      
         *      Parameters(return):
         *      this method(bool): returns true if no conflicts detected, false if there are
         *      badRows(string[]): creates a string array whose length is the number of rows with conflicting data and each element is the primary key of each row that had conflicting data
         */
        private bool IsConflict(string selectQuery, string[] collumDats, out string[] badRows)
        {

            SqlCommand cmd = new SqlCommand(selectQuery, connection);
            List<string> tempBadRows = new List<string>();
            bool value = true;

            try
            {
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (!reader.Read())//runs for each row
                {
                    for(int i = 0; i < collumDats.Length; i++)//runs for each given collumn
                    {
                        if ((collumDats[i].Equals(reader.GetString(i))) && (collumDats[i] != null))
                        {
                            tempBadRows.Add(reader.GetString(0));
                            value = false;
                            break;
                        }
                    }//end for collumn
                }//end while row
                connection.Close();
            }
            catch (SqlException excp)//currently dosen't warn do anything alert user if function didn't execute, or only partially execute probably want to fix that [TODO]
            {
                Debug.WriteLine("Failed on dataReader: " + excp);
                connection.Close();
                value = false;
            }

            badRows = tempBadRows.ToArray();
            return value;
        }



    }
}
