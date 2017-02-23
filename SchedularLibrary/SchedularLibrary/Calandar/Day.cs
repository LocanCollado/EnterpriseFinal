using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProc.Calandar
{
    public class Day
    {
        private int dayID;

        //TODO: get what day of the week this day is EX:"monday"
        //Update: I made CalanderFormater do it instead because it already had a GregorianCalander object

        /*
         used by Calander formater to identify days of year.
            Parameters(defined):
            year(int):calander year as defined by year of instatance of CalanderFormater
            dayID(int):identifier defined by number of days into calander year this day occurs
             */
        public Day(int year, int dayID)
        {
            this.dayID = dayID;//if you need this to be explained... god help you
        }

        /*
         * (int) getDayID(): returns the identifier of this day, synomonus with the number of days into the year this day occurs
         */
        public int getDayID()
        {
            return dayID;
        }
    }
}
