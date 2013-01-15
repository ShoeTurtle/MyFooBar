using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_mobileVarification : System.Web.UI.UserControl
{
    static string varificationCode;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnSend_Click(object sender, EventArgs e)
    {
        Random rf=new Random(DateTime.Now.DayOfYear);
        varificationCode = rf.NextDouble().ToString().Substring(3,6);

        MailAndSms ms = new MailAndSms("COM25");
        ms.Open();
        ms.sendMsg(txtMobileNo.Text, varificationCode);
            lblStatus.Text = "Message sent";
        ms.Close();
    }
    protected void btnVerify_Click(object sender, EventArgs e)
    {
        if (txtVerifyCode.Text == varificationCode)
        {
            this.Visible = false;
            Response.Redirect("fooMobile.aspx");

        }
        else
        {
            lblStatus.Text = "Code not matched.";
        }
    }
}
