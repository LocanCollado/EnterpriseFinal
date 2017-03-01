using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ExperimentalProc;


namespace WebApp
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ExperimentalProc.DataBase.Server dat = new ExperimentalProc.DataBase.Server();
        }

        public void  openWin(object sender, EventArgs e)
        {
            
            Response.Redirect("http://localhost:53291/signuppage.html");
        }
        public void openWin2(object sender, EventArgs e)
        {

            Response.Redirect("http://localhost:51538/WebForm1");
        }
    }
}