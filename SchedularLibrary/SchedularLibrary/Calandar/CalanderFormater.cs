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
    public class CalanderFormater
    {
        protected GregorianCalendar GC = new GregorianCalendar();
        protected int year;

        protected List<Month> months;
        protected List<Day> days;


        //Dan: !!!!!!TOUCH THIS AND I WILL SLAUGHTER YOU!!!!!!
        /*
         creates a data object that organizes target year into two lists.
         Formater works by asigning every day an ID defined by how many days into the year that day occurs,
         also asigns every month an ID defined with the same logic,
         every month contains a list of the days that occur within it.
         [List:months] contains an ordered list of [Calander/Month.cs] class objects, index starting at 0
         [List:days] contains an ordered list of [Calander/day.cs] class objects, index starting at 0
            Parmeters(defined):
            year(int) : target year of the Gergorian calander to be formated: must be a 4 digit number that is a part of the gregorian calander that is in the current era
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

        /*
         * (int) GetDaysAmount(): returns the number of days in this year
         */
        public int GetDaysAmount()
        {
            return days.Count;
        }

        /*
         * (Day) getDayByYear(int dayID): returns day object identified by the number of days into the year that day occurs
         */
        public Day getDayByYear(int dayID)
        {
            return days.Find(x => x.getDayID() == dayID);
        }

        /*
         * (Month) getMonthByDay(int dayID): returns month object identified by the month that a specified day is a member of
         */
        public Month getMonthByDay(int dayID)
        {
            foreach (Month index in months)
            {
                if (index.Days.Exists(x => x.getDayID() == dayID)) { return index; }
            }

            return null;//returns null if it didn't find anything
        }

        /*
         * overload for getMonthByDay(int dayID): allows for identification by Day object rather than dayID
         */
        public Month getMonthByDay(Day day)
        {
            foreach (Month index in months)
            {
                if (index.Days.Contains(day)) { return index; }
            }

            return null;//returns null if it didn't find anything
        }

        /*
         * (Month) getMonthByYear(int monthID): returns Month object as idetified by number of months into a year that month occurs
         */
        public Month getMonthByYear(int monthID)
        {
            return months.Find(x => x.getMonthID() == monthID);
        }

        //Dan: note too self: I should probably make this useable by the Day object class... well if it works it works, a tower of ducktape is a tower nonetheless YOU GET WHAT YOU GET! STOP COMPLAINING REGINALD! I'LL END YOU!!!!!!!
        //Dan: if your testing something and your getting problems from this method, if you can't figure it out for yourself i probably know what's up
        /*
         * (int) getDayOfWeek(int dayID): returns the day of the week as deffined by the number of days into a year that day occurs
         * return values: 1 = sunday | 2 = monday | 3 = tuesday | 4 = wensday | 5 = thursday | 6 = friday | 7 = saturday
         */
        public int getDayOfWeek(int dayID)
        {
            return ( (int) GC.GetDayOfWeek(new DateTime(this.year, getMonthByDay(dayID).getMonthID(), getMonthByDay(dayID).getDaysIntoMonth(getDayByYear(dayID)))) ) + 1;         
        }
    }
}
