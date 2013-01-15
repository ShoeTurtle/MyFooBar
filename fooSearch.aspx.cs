using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con1;
    SqlConnection con2;
    GlobalMeth gObj = new GlobalMeth();

    protected void Page_Load(object sender, EventArgs e)
    {
        String conStr = WebConfigurationManager.ConnectionStrings["fooDBcon"].ConnectionString;
        con1 = new SqlConnection(conStr);
        con2 = new SqlConnection(conStr);
        loadProfilePic();

    }


    protected void loadProfilePic()
    {
        imgMain.ImageUrl = gObj.getImageURL(Session["UserName"].ToString());
    }


    protected void butSearch_Click(object sender, EventArgs e)
    {
        String txtInput = txtSearch.Text.ToString();
        String cmdStr = "SELECT * FROM General_Information " +
            "WHERE (UName LIKE '%" + txtInput + "%' or UserName LIKE '%" + txtInput +
            "%' or email LIKE '%" + txtInput + "%')";
        //txtSearch.Text = cmdStr;

        SqlDataReader rdGeneralInfo;
        SqlCommand scom = new SqlCommand(cmdStr, con1);

        con1.Open();
        rdGeneralInfo = scom.ExecuteReader();

        repAccounts.DataSource = rdGeneralInfo;
        repAccounts.DataBind();

        rdGeneralInfo.Close();
        con1.Close();  
        
    }


    protected void repAccounts_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Literal litUsrKey = (Literal)(e.Item.FindControl("litUsrKey")) as Literal;
        Button butAddFriend = (Button)(e.Item.FindControl("butAddFriend")) as Button;

        String friendID = litUsrKey.Text;
        String myID = Session["UserName"].ToString();

        String cmdStr = "SELECT COUNT(*) as ChkVal from Friends WHERE UName = '" + myID + "' AND FriendID = '" + friendID + "'";

        SqlCommand scom = new SqlCommand(cmdStr, con2);
        SqlDataReader rd;

        con2.Open();
        rd = scom.ExecuteReader();
        rd.Read();

        if (String.Compare(rd["ChkVal"].ToString(), "0") > 0)
        {
            butAddFriend.Visible = false;            
        }

        if (String.Compare(friendID, myID) == 0)
        {
            butAddFriend.Visible = false;
        }

        rd.Close();
        con2.Close();
        

        //Saving Whom To Send The Invitation//
        butAddFriend.Attributes.Add("SendInvitationTo", friendID); 
    

        //***Check to see if the request has been already sent***//

        cmdStr = "SELECT count(*) as ChkVal FROM FriendInvitation WHERE ((Sender = '" + myID + "' AND Receiver = " +
            "'" + friendID + "')" + "OR (Sender = '" + friendID + "' AND Receiver = '" + myID + "'))";

        scom = new SqlCommand(cmdStr, con2);
        
        con2.Open();
        rd = scom.ExecuteReader();
        rd.Read();

        if (String.Compare(rd["ChkVal"].ToString(), "0") > 0)
        {
            butAddFriend.Text = "Request Pending";
        }

        rd.Close();
        con2.Close();

    }

    protected void butAddFriend_Click(Object sender, EventArgs e)
    {
        //Code to Send an invitation//
        //Will update the Invitation Table//
        //When Users log in it will check the invitation table and show all the invitation//

        Button butAddFriend = sender as Button;
        
        String myID = Session["UserName"].ToString();
        String SendInvitationTo = butAddFriend.Attributes["SendInvitationTo"].ToString();
        
        //Updating the Invitation Table//

      
      
        String cmdStr = "SELECT count(*) as ChkVal FROM FriendInvitation WHERE ((Sender = '" + myID + "' AND Receiver = " +
            "'" + SendInvitationTo + "')" + "OR (Sender = '" + SendInvitationTo + "' AND Receiver = '" + myID + "'))";


        SqlCommand scom = new SqlCommand(cmdStr, con1);
        SqlDataReader rd;

        con1.Open();
        rd = scom.ExecuteReader();

        rd.Read();

        int val = String.Compare(rd["ChkVal"].ToString(), "0");

        rd.Close();
        con1.Close();

        if (val == 0)
        {
            cmdStr = "INSERT INTO FriendInvitation VALUES('" + myID + "', '" + SendInvitationTo + "', " +
                "'', '" + DateTime.Now + "', '0')";

            scom = new SqlCommand(cmdStr, con1);
            con1.Open();
            scom.ExecuteNonQuery();
            con1.Close();
        }

        Server.Transfer("fooSearch.aspx");
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {

    }
}
