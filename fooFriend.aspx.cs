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
    GlobalMeth gObj = new GlobalMeth();
    SqlConnection con;
    String userID = null, myUserID;        

    protected void Page_Load(object sender, EventArgs e)
    {
        con = new SqlConnection(WebConfigurationManager.ConnectionStrings["fooDBcon"].ConnectionString);
        

        try
        {
            userID = Request.QueryString["AccountID"].ToString();
        }
        catch
        {
            //query string is empty//
        }

        myUserID = Session["UserName"].ToString();

        if (userID != null)
        {
            //Change the profile view as a stranger is trying to access this profile//
            //call a global function to see what is the relationship with this guy//
            //set the visibilty accordingly to the privacy table//
            loadProfilePic(userID);
            //fillName(userID);
            hideMenuItems();
            changeLinkToCurrentUserID(userID);
            loadFriendList(userID);            
        }
        else
        {
            loadProfilePic(myUserID);
            //fillName(myUserID);
            loadFriendList(myUserID);            
        }
    }
    
    protected void loadProfilePic(String usrKey)
    {
        imgMain.ImageUrl = gObj.getImageURL(usrKey);
    }

    protected void hideMenuItems()
    {
        LinkButton4.Visible = false;
        LinkButton7.Visible = false;
    }

    protected void changeLinkToCurrentUserID(String usrKey)
    {
        LinkButton1.PostBackUrl = "~/fooProfile.aspx?AccountID=" + usrKey;
        LinkButton2.PostBackUrl = "~/fooFriend.aspx?AccountID=" + usrKey;
        LinkButton3.PostBackUrl = "~/fooPhoto.aspx?AccountID=" + usrKey;
    }

    //repFriendList_ItemDataBound 
    

    protected void repFriendList_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton lnkUnfriend = (LinkButton)e.Item.FindControl("lnkUnfriend") as LinkButton;
        Literal litFriendID = (Literal)e.Item.FindControl("litFriendID") as Literal;
               
        lnkUnfriend.Attributes.Add("UName",litFriendID.Text);

        
        //****This Determines If I should hide the UN-FRIEND Link****//
        if (userID != null)
        {
            //Hide the link//
            lnkUnfriend.Visible = false;

        }
        else
        {
            //Don't Hide the Link//
            lnkUnfriend.Visible = true;
        }

    }


    protected void loadFriendList(String usrKey)
    {

        String cmdStr = "select * from General_Information where UName IN (select FriendID from Friends where UName = '" + usrKey + "')";

        SqlDataReader rd;
        SqlCommand scom = new SqlCommand(cmdStr, con);

        con.Open();
        rd = scom.ExecuteReader();
        
        repFriendList.DataSource = rd;
        repFriendList.DataBind();

        rd.Close();
        con.Close();
    }

    protected void lnkUnfriend_Click(Object sender, EventArgs e)
    {
        LinkButton lnkUnfriend = sender as LinkButton;

        String UName = lnkUnfriend.Attributes["UName"].ToString();

        String cmdStr = "DELETE FROM Friends WHERE(UName = '" + Session["UserName"].ToString() + "' AND FriendID = '" +
            UName + "')";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        con.Open();
        scom.ExecuteNonQuery();
        con.Close();
        
        cmdStr = "DELETE FROM Friends WHERE(UName = '" + UName + "' AND FriendID = '" +
            Session["UserName"].ToString() + "')";
        scom = new SqlCommand(cmdStr, con);
        con.Open();
        scom.ExecuteNonQuery();
        con.Close();


        cmdStr = "DELETE FROM FriendInvitation WHERE ((Sender = '" + UName +
            "' AND Receiver = '" + Session["UserName"].ToString() + "')" + 
            " OR (Sender = '" + Session["UserName"].ToString() +
            "' AND Receiver = '" + UName + "'))";
        scom = new SqlCommand(cmdStr, con);
        con.Open();
        scom.ExecuteNonQuery();
        con.Close();       


        Server.Transfer("fooFriend.aspx");

    }

}
