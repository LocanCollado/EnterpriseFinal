using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace ExperimentalProc.Calandar
{
    public class Month
    {
        private int monthID;
        public List<Day> Days;

        //TODO: add a function that returns the name of the month as a string EX: "september"

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

        /*
         * (int) getMonthID(): returns the identifier of this month, synomonus with the number of months into the year this month occurs 
         */
        public int getMonthID()
        {
            return monthID;
        }

        /*
         * (Day) getDayByMonth(int daysIntoMonth): returns a day object of the day that occurs the specified number of days into this month
         * starts at one to better work with current methodology and readability (the first day of the month would be identified as 1)
         */
        public Day getDayByMonth(int daysIntoMonth)
        {
            return Days[daysIntoMonth - 1];
        }

        public int getDaysIntoMonth(Day day)
        {
            for (int i = 0; i < Days.Count; i++)
            {
                if (Days[i].getDayID() == day.getDayID())
                {
                    return i + 1;
                }
            }

            return 0;//returns 0 if it didn't find anything

        }

        
    }
}
