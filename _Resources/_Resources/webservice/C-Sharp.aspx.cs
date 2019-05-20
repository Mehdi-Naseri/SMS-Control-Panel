using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        WebService.Send sms = new WebService.Send();
        long[] rec = null;
        byte[] status = null;

        //retval :
        // InvalidUserPass=0,
        // Successfull = 1,
        // NoCredit = 2,
        // DailyLimit = 3,
        // SendLimit = 4,
        // InvalidNumber = 5

        //Status :
        // Sent=0,
        // Failed=1

        int retval = sms.SendSms("demo", "demo", new string[] { "912245....", "9374659..." }, "1000...", "سلام", false, "", ref rec, ref status);

        Response.Write(retval);
        Response.Write("<br>");
        for (int i = 0; i < status.Length; i++)
        {
            Response.Write(status[i]);
        }
    }
}