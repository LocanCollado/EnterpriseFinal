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
            this.week1day1.InnerText = "hello dare";//this string will be placed on the HTML page as raw HTML code
            //this.Month.InnerText = GetMonth(1);
        }
        public string GetMonth(int monthID)//current content is temporay, meant only to be used as referance
        {
            switch (monthID)
            {
                case 1:
                    return @"January";//the @ allows the string to be placed on page
                    break;//these breaks are redundant because of the return
                case 2:
                    return @"Febuary";
                    break;
                case 3:
                    return @"March";
                    break;
                case 4:
                    return @"April";
                    break;
            }
            return "Month Data Not recognize";
        }
        public void GetDay(int dayID)
        {
            this.week1day1.InnerText = "I know yur in der";//this is put on the page only when this method is called

        }
    }
}