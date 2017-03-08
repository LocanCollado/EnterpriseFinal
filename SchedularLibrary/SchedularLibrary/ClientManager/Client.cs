using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProc.ClientManager
{
    public class Client
    {
        protected int SessionID;

        public Client(int SessionID)
        {


        }

        public int getSessionID()
        {
            return SessionID;
        }
    }
}
