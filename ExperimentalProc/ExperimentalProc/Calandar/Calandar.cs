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
    /*Will organize Month/Week/Day on back end so database dosen't NEED to differentiate them but it would be helpfull
    what i need right now is the ability to add a specificy day that contains enough information to place it on a gregorian calandar
    and add it to the database, it will also need to have the ablity to a relation with a variable number of room dataObjects
    */
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
