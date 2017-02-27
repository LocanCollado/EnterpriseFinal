using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExperimentalProc
{
    class Admin : Client
    {
        
        public Admin(string UserName, string Password) : base(UserName, Password)
        {
        }
    }
}
