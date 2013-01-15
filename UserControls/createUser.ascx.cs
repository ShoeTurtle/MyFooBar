using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
public partial class Controls_WebUserControl2 : System.Web.UI.UserControl
{
    
    


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            RangeValidator1.Type = ValidationDataType.Date;
            RangeValidator1.MaximumValue = DateTime.Now.AddYears(-12).ToShortDateString();
            RangeValidator1.MinimumValue = DateTime.Now.AddYears(-100).ToShortDateString();
        }
    }
    protected void UploadButton_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        bool attempt=false;
        UserGeneralInfo UGI = new UserGeneralInfo();
        if (UGI.Query_UserName(txtUserName.Text))
        {
            if (UGI.Query_email(txtEmail.Text))
            {
                if (UGI.User_Registration(txtFName.Text+" "+txtLName.Text, txtUserName.Text, txtDob.Text, ddSex.Text, txtEmail.Text, txtPass.Text))
                    attempt = true;

            }
            else
                lblError.Text = "Email already Exist";


        }
        else
            lblError.Text = "UserName not available";
        if (attempt)
        {
            MailAndSms ms = new MailAndSms("20");
            ms.SendEmail("mysocial.mooo.com.81@gmail.com", txtEmail.Text, "Email Varification", "please follow the Link http://cmrsocial.moooo.com:81/Authenticate.aspx?uid=" + txtUserName.Text);

            Session["UserName"] = txtUserName.Text;
            //********CREATING FOLDERS FOR THE REGISTERD USERS*********//
            String folder1 = "~/foopicDB/" + Session["UserName"].ToString();
            Directory.CreateDirectory(Server.MapPath(folder1));

            String folder2 = "~/foopicDB/" + Session["UserName"].ToString() + "/Profile";
            Directory.CreateDirectory(Server.MapPath(folder2));

            UGI.update_Login(Session["UserName"].ToString(), 1);
                Response.Redirect("fooHome.aspx");
            
        }
        clear_function();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        clear_function();
    }
    protected void clear_function()
    {

        txtUserName.Text = "";
        txtPass.Text = "";
        txtFName.Text = "";
        txtLName.Text = "";
        txtAddr.Text = "";
        
        ddSex.SelectedIndex = 0;
        txtMobile.Text = "";
        txtRePass.Text = "";


    }
    protected void btnChk_Click(object sender, EventArgs e)
    {
        
    }
    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        
    }
    protected void rdTeacher_CheckedChanged(object sender, EventArgs e)
    {
       
    }
    protected void txtAddr_TextChanged(object sender, EventArgs e)
    {

    }
    protected void txtUserName_TextChanged(object sender, EventArgs e)
    {
       
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
       
    }
    protected void rdStudent_CheckedChanged(object sender, EventArgs e)
    {
      
    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }
}
