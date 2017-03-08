using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProc.ClientManager
{
    public class Manager
    {
        List<Client> ActiveUsers;

        public Manager()
        {
            ActiveUsers = new List<Client>();
        }

        public Client RetriveClient(int ClientID)
        {
            return ActiveUsers.Find(x => x.getSessionID() == ClientID);//TODO: alter this to use index
        }
    }
}
