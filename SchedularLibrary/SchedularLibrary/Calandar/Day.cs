using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProc.Calandar
{
    class Day
    {
        private int dayID;

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
    }
}
