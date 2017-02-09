using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ExperimentalProc
{
    class Program
    {
        static void Main(string[] args)//Testing stuff
        {
            
            DataBase.Server test = new DataBase.Server();

            test.InsertIntoDataBase();

            System.Console.WriteLine("Hello, world! again edit");
        }
    }
}
