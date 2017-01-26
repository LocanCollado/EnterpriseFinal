using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProc
{
    class Data
    {
        //anything to be inherited to all data is to go in this class
        protected Data()//Data class constructor
        {

        }
    }

    class Student : Data
    {
        //anything to be inherited by all students go in this class

        private string StudentName = null;

        protected Student()//Student class constructor
        {

        }

        public void setStudentName(string StudentName)
        {
            this.StudentName = StudentName;
        }

        public string getStudentName()
        {
            return StudentName;
        }
    }
}
