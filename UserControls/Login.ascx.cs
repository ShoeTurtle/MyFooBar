using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Controls_WebUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Password_TextChanged(object sender, EventArgs e)
    {

    }
    protected void LoginButton_Click(object sender, EventArgs e)
    {
        UserGeneralInfo UGI=new UserGeneralInfo();
        string pass = Login1.Password;
        if (!UGI.Query_UserName(Login1.UserName))
        {
            if (UGI.Query_Password(Login1.UserName) == pass)
            {

                Session["UserName"] = Login1.UserName;
                UGI.update_Login(Login1.UserName, 1);
                Response.Redirect("fooHome.aspx");
                this.Visible = false;

            }
             
        }
        Login1.FailureText = "User Name or Password Mismatched";
   
    }
    protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
    {
        UserGeneralInfo UGI=new UserGeneralInfo();
        string pass = Login1.Password;
        if (!UGI.Query_UserName(Login1.UserName))
        {
            if (UGI.Query_Password(Login1.UserName) == pass)
            {

                Session["UserName"] = Login1.UserName;
                UGI.update_Login(Login1.UserName, 1);
                Response.Redirect("fooHome.aspx");
                this.Visible = false;

            }
             
        }
        Login1.FailureText = "User Name or Password Mismatched";
    }
}
