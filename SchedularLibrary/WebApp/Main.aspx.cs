using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExperimentalProc.Calandar;

namespace WebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        CalanderFormater CF;

        protected void Page_Load(object sender, EventArgs e)
        {
            CF = new CalanderFormater(2017);
        }
        public void GetMonth()
        {
            
        }
    }
}