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
using System.Data.SqlClient;
using System.Text;


public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    GlobalMeth gObj = new GlobalMeth();

    protected void Page_Load(object sender, EventArgs e)
    {

        con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=snetworking;Persist Security Info=True;User ID=aniket;Password=dakgator123;");
        this.getLoggedInUser();
        this.getMessages();

        /*string someScript = "";
        someScript = "<script language='javascript'>alert('Called from CodeBehind');</script>";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "onload", someScript);*/

        //if (!Page.ClientScript.IsStartupScriptRegistered("MyScript"))
        //{
            //Page.ClientScript.RegisterStartupScript
            //    (this.GetType(), "", "invokeMeMaster();", true);
        //}

        
        ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "SetScrollPosition_", "SetScrollPosition();", true);
        //ScriptManager.RegisterStartupScript(this.UpdatePanel1, this.GetType(), "MainPageScroll_", "MainPageScroll()", true);  
        LoadProfilePic();       
   
    }


    private void getLoggedInUser()
    {

        con.Open();
        
        String cmdString = "select ul.UName,ul.UStatus,gi.UserName from General_Information gi INNER JOIN ULogin ul ON gi.UName = ul.UName where(ul.UName in(select Receiver from FriendInvitation where Status='True' and Sender='" + Session["UserName"].ToString() + "') ) or (ul.UName in(select Sender from FriendInvitation where Status='True' and Receiver='" + Session["UserName"].ToString() + "') )  ";
        SqlCommand scom = new SqlCommand(cmdString, con);
        SqlDataReader rd;
        StringBuilder sb = new StringBuilder();

        rd = scom.ExecuteReader();
        string username;

        while (rd.Read())
        {
            if (rd["UStatus"].ToString() == "1")
            {
                username = rd["UserName"].ToString();
                sb.Append("<font size=4 face=verdana color=green >" + username + "</font><br>");

                litUsers.Text = sb.ToString();
            }
        }
        rd.Close();
        con.Close();
       
    }


    private void getMessages()
    {
        String loginDT = null;

        String cmdStr1 = "Select * from ULogin where UName = " + "'" + (string)Session["Username"] + "';";
        SqlDataReader rd;
     
        SqlCommand scom1 = new SqlCommand(cmdStr1, con);

        con.Open();
        rd = scom1.ExecuteReader();


        if (rd.Read())
        {
            loginDT = Convert.ToString(rd.GetDateTime(4));
        }
        rd.Close();

        
        String cmdStr2 = "select * from MessageAndChat where DateTimeTime > " + "'" + loginDT + "';";
        SqlCommand scom2 = new SqlCommand(cmdStr2, con);
               
        rd = scom2.ExecuteReader();
        
        string username, message;
        StringBuilder sb = new StringBuilder();
        
        while (rd.Read())
        {
            username = rd.GetString(0);
            message = rd.GetString(2);
            sb.Append("<font size=3 face=verdana color=blue><b>" + username + ": </font></b>" 
                + "<font size=4>"+ message + "</font><br>");
            
        }

        litMessages.Text = sb.ToString();

        rd.Close();
        con.Close();
    }
    
    protected void btnSend_Click(object sender, EventArgs e)
    {
        string user = Session["UserName"].ToString();
        String cmdString = "insert into MessageAndChat values('" + user + "', 'nothing', " + "'" + txtMessage.Text + "',"+ "'" +DateTime.Now +"'" +")";
        
        if (txtMessage.Text.Length > 0)
        {
            this.getMessages();
            txtMessage.Text = String.Empty;
            con.Open();
            SqlCommand scom = new SqlCommand(cmdString, con);
            scom.ExecuteNonQuery();
            con.Close();
        }
        
        //ScriptManager1.SetFocus(txtMessage);
        
    }
    
    protected void Timer1_OnTick(object sender, EventArgs e)
    {
        this.getLoggedInUser();
        this.getMessages();

        //Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "scriptKey", "invokeMeMaster();", true);

        //Page.ClientScript.RegisterStartupScript
        //        (this.GetType(), "test", "invokeMeMaster();", true);

        //if ((string)Session["IsChatroomInFocus"] == null)
            //ScriptManager1.SetFocus(txtMessage);
    }

    protected void LoadProfilePic()
    {
        try
        {
            imgMain.ImageUrl = gObj.getImageURL(Session["UserName"].ToString());
        }

        catch
        {
        
        }

    }


}

