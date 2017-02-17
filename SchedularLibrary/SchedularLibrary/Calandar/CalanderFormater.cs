using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace ExperimentalProc.Calandar
{
    /*
     Used translate calander data for interpetation to simplify comunication to and from the database
         */
    class CalanderFormater
    {
        protected GregorianCalendar GC = new GregorianCalendar();
        protected int year;

        protected List<Month> months;
        protected List<Day> days;

        /*
         creates a data object that organizes target year into two lists.
         Formater works by asigning every day an ID defined by how many days into the year that day occurs,
         also asigns every month an ID defined with the same logic,
         every month contains a list of the days that occur within it.
         [List:months] contains an ordered list of [Calander/Month.cs] class objects, index starting at 0
         [List:days] contains an ordered list of [Calander/day.cs] class objects, index starting at 0
            Parmeters(defined):
            year(int) : target year of the Gergorian calander to be formated
             */
        public CalanderFormater(int year)
        {
            this.year = year;

            months = new List<Month>();
            days = new List<Day>();
            int day = 1;
            int month = 1;//start with the first month
            months.Add(new Month(this.year, month));//add the first month to list
            for (int i = 1; i <= GC.GetDaysInYear(this.year); i++)
            {
                
                if(day > GC.GetDaysInMonth(this.year, month))//if day does not fit in current month add a new one
                {
                    day = 1;
                    month++;
                    months.Add(new Month(this.year, month));//add new month to list of months
                }
                days.Add(new Day(this.year, i));//add current day to list
                months[month - 1].Days.Add(days[i - 1]);//add reffrence to current day to its respective month
                day++;
            }
        }

        
    }
}
