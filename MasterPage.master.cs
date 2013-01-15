using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class MasterPage : System.Web.UI.MasterPage
{
    SqlConnection con;
        
    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=snetworking;Persist Security Info=True;User ID=aniket;Password=dakgator123;");
        
    }


    //User Logs Out the UStatus Now Changes to 0//
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        string UserKey = Session["UserName"].ToString();

        String cmdStr = "update ULogin set UStatus = 0 where UName = " + "'" + UserKey + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        
        con.Open();
        scom.ExecuteNonQuery();
        con.Close();

        Server.Transfer("Login.aspx");
        
    }


    protected void Button1_Click(object sender, EventArgs e)
    {

        Server.Transfer("~/editBasicInfo.aspx");
        
    }
           
    protected void Button2_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/fooCrop.aspx");

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/editEducationWork.aspx");

    }
  
    protected void Button5_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/editManageFriend.aspx");

    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/editManageGallary.aspx");
 
    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/editActivitiesInterests.aspx");

    }
    protected void Button8_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/editContacts.aspx");

    }
    

    protected void Button9_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/editEducation.aspx");
    }
    
    protected void LinkButton5_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/editBasicInfo.aspx");
    }

    protected void Button10_Click(object sender, EventArgs e)
    {

        Server.Transfer("~/editCoverPic.aspx");

    }
    protected void btnMobile_Click(object sender, EventArgs e)
    {
        Server.Transfer("~/fooMobile.aspx");
    }
}
