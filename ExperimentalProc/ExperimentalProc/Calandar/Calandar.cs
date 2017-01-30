using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProc.Calandar
{
    //currently not setup to retrive session specific data
    //this should be fixed before alpha version
    class Calandar : Data
    {
        private struct Month
        {

        }

        private struct Week
        {
            public int weekID;
            public Day[] days;

            public Week(int weekID, Day sunday, Day monday, Day tuesday, Day wensday, Day thursday, Day friday, Day saturday)
            {
                this.weekID = weekID;
                days = new[] {sunday, monday, tuesday, wensday, thursday, friday, saturday};
            }
        }

        private struct Day
        {
            public int dayID;
            public List<Room> rooms; 
            public Day(int dayID)
            {
                this.dayID = dayID;
                rooms = new List<Room>();
                //TODO retrive calander information on this specific day from database and add it too the list:rooms 
            }
        }
        
        
        protected Calandar()//organizes information for upload to database
        {

        }
        


        //hard code time slots
    }
}
