using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProc.DataBase
{
    public class TimeItem
    {
        private short hours;
        private short minutes;

        //defualt constructor
        public TimeItem(string hours, string minutes)
        {
            short temp;
            if (short.TryParse(hours, out temp))
            {
                if ((temp >= 1) && (temp <= 24))
                {
                    this.hours = temp;
                }
                else
                {
                    throw new FormatException("Parmeter:(hours) cannot be greater than 24 or less than 1");
                }
            }
            else
            {
                throw new FormatException("Failed to convert string parameter (hours) to dataType SHORT");
            }

            if (short.TryParse(minutes, out temp))
            {
                if ((temp >= 0) && (temp <= 59))
                {
                    this.minutes = temp;
                }
                else
                {
                    throw new FormatException("Parmeter:(minutes) cannot be greater than 59 or less than 0");
                }
            }
            else
            {
                throw new FormatException("Failed to convert string parameter (minutes) to dataType SHORT");
            }
        }//end constructor

        //single value constructor
        public TimeItem(string hoursMinutes)
        {
            string[] splitString = hoursMinutes.Split(':');
            
            if(splitString.Length == 2)
            {
                short temp;
                if (short.TryParse(splitString[0], out temp))
                {
                    if ((temp >= 1) && (temp <= 24))
                    {
                        this.hours = temp;
                    }
                    else
                    {
                        throw new FormatException("Parmeter:(hours) cannot be greater than 24 or less than 1");
                    }
                }
                else
                {
                    throw new FormatException("Failed to convert string parameter (hours) to dataType SHORT");
                }

                if (short.TryParse(splitString[1], out temp))
                {
                    if ((temp >= 0) && (temp <= 59))
                    {
                        this.minutes = temp;
                    }
                    else
                    {
                        throw new FormatException("Parmeter:(minutes) cannot be greater than 59 or less than 0");
                    }
                }
                else
                {
                    throw new FormatException("Failed to convert string parameter (hours) to dataType SHORT");
                }
            }
            else
            {
                throw new FormatException("Failed to seperate parameter into hours and minutes");
            }
        }


        //OverRides

        public override string ToString()
        {
            return hours.ToString("00") + ":" + minutes.ToString("00");
        }


        //Overloads

        //GreaterThan overload
        public static bool operator >(TimeItem LO, TimeItem RO)
        {
            if (LO.hours > RO.hours)
            {
                return true;
            }
            else if (LO.hours < RO.hours)
            {
                return false;
            }
            else if (LO.minutes > RO.minutes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//end GreaterThan overload

        //LessThan overload
        public static bool operator <(TimeItem LO, TimeItem RO)
        {
            if (LO.hours < RO.hours)
            {
                return true;
            }
            else if (LO.hours > RO.hours)
            {
                return false;
            }
            else if (LO.minutes < RO.minutes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//end LessThan overload

        //GreaterThanEqualToo overload
        public static bool operator >=(TimeItem LO, TimeItem RO)
        {
            if (LO.hours > RO.hours)
            {
                return true;
            }
            else if (LO.hours < RO.hours)
            {
                return false;
            }
            else if (LO.minutes >= RO.minutes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//end GreaterThanEqualToo overload

        //LessThanEqualToo overload
        public static bool operator <=(TimeItem LO, TimeItem RO)
        {
            if (LO.hours < RO.hours)
            {
                return true;
            }
            else if (LO.hours > RO.hours)
            {
                return false;
            }
            else if (LO.minutes <= RO.minutes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }//end LessThanEqualToo overload

    }
}
