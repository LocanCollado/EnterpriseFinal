using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//clients

//admins

namespace ExperimentalProc
{
    class Data
    {
        //anything to be inherited to all data is to go in this class
        public Data()//Data class constructor
        {

        }
    }

    public class Client
    {
        //anything to be inherited by all clients go in this class

        private string UserID = null;
        private string UserName = null;//these will eventually be used to temporailly store data retrived from database
        //lastname
        //firstname
        private string Password = null;

        public Client(string UserName,string Password)//client class constructor
        {
            this.UserName = UserName;
            this.Password = Password;
        }

        public Client(DataBase.Server datBase)
        {
            //TODO:retrive client info from database
        }

        public void setUserName(string UserName)
        {
            this.UserName = UserName;
        }

        public string getUserName()
        {
            return UserName;
        }

        public void setPassword(string Password)
        {
            this.Password = Password;
        }

        public string getPassword()
        {
            return Password;
        }

        
    }

    

    
    

    

    
}
