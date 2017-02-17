using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ExperimentalProc.Calandar
{
    class Month
    {
        private int monthID;
        public List<Day> Days;

        /*
         Used by CalanderFormater to identify days of month.
         [List:Days]contains referances to days defined in CalanderFormater. Populated by CalanderFormater constructor
            Parameters(defined):
            year(int):calander year as defined by year of instatance of CalanderFormater
            monthID(int):identifier defined by number of months into calander year this moth occurs

            Functions:
            (int) getDaysInMonth(): returns number of days in this month
             */
        public Month(int year, int monthID)
        {
            GregorianCalendar GC = new GregorianCalendar();
            this.monthID = monthID;
            Days = new List<Day>();
            
        }

        /*
         * (int) getDaysInMonth(): returns number of days in this month
         */
        public int getDaysInMonth()
        {
            return Days.Count;
        }

        
    }
}
