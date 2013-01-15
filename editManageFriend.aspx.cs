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
    String myUserID;
    SqlConnection con;
    SqlConnection con1;
    GlobalMeth gObj = new GlobalMeth();

    protected void Page_Load(object sender, EventArgs e)
    {
        String conStr = WebConfigurationManager.ConnectionStrings["fooDBcon"].ConnectionString;
        con = new SqlConnection(conStr);
        con1 = new SqlConnection(conStr);

        myUserID = Session["UserName"].ToString();
        fillName();
        bindRepeator();       
        
    }

    protected void fillName()
    {
        lblName.Text = gObj.getName(myUserID);
    }

    protected void bindRepeator()
    {
        String cmdStr = "SELECT * FROM FriendInvitation WHERE (Receiver = '" + myUserID + "' AND" +
            " Status = 'false')";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();
        rd = scom.ExecuteReader();
        repFriendRequest.DataSource = rd;
        repFriendRequest.DataBind();

        rd.Close();
        con.Close();
    }
    
    
    protected void repFriendRequest_ItemDataBound(Object sender, RepeaterItemEventArgs e)
    {
        Image imgFriend = (Image)e.Item.FindControl("imgFriend") as Image;
        Label lblFriend = (Label)e.Item.FindControl("lblFriend") as Label;
        Literal litFriendID = (Literal)e.Item.FindControl("litFriendID") as Literal;
        LinkButton butAccept = (LinkButton)e.Item.FindControl("butAccept") as LinkButton;
        LinkButton butReject = (LinkButton)e.Item.FindControl("butReject") as LinkButton;

        
        String cmdStr = "SELECT * FROM General_Information WHERE UName = '" + litFriendID.Text + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con1);
        SqlDataReader rd;
        
        con1.Open();
        rd = scom.ExecuteReader();
        rd.Read();

        String imgURL = "~/fooPicDB/" + rd["UName"].ToString() + "/Profile/" + rd["ProfilePic"].ToString();
        imgFriend.ImageUrl = imgURL;
        lblFriend.Text = rd["UserName"].ToString();


        butAccept.Attributes.Add("UName", rd["UName"].ToString());
        butReject.Attributes.Add("UName", rd["UName"].ToString());
        
        rd.Close();
        con1.Close();
    }


    protected void butAccept_Click(Object sender, EventArgs e)
    {
        LinkButton butAccept = sender as LinkButton;
        String UName = butAccept.Attributes["UName"].ToString();

        String cmdStr = "INSERT INTO Friends VALUES('" + myUserID + "', '" + UName + "', '" +
            DateTime.Now.ToString() + "')";

        SqlCommand scom = new SqlCommand(cmdStr, con);
        con.Open();
        scom.ExecuteNonQuery();
        con.Close();

        cmdStr = "INSERT INTO Friends VALUES('" + UName + "', '" + myUserID + "', '" +
            DateTime.Now.ToString() + "')";
        scom = new SqlCommand(cmdStr, con);
        con.Open();
        scom.ExecuteNonQuery();
        con.Close();


        cmdStr = "UPDATE FriendInvitation SET Status = 'true' WHERE (Sender = '" + UName + 
            "' AND Receiver = '" + myUserID + "')";
        lblFriend.Text = cmdStr;

        scom = new SqlCommand(cmdStr, con);
        con.Open();
        scom.ExecuteNonQuery();
        con.Close();
        
        Server.Transfer("editManageFriend.aspx");

    }

    protected void butReject_Click(Object sender, EventArgs e)
    {
        LinkButton butReject = sender as LinkButton;
        String UName = butReject.Attributes["UName"].ToString();

        String cmdStr = "DELETE FROM FriendInvitation WHERE (Sender = '" + UName +
            "' AND Receiver = '" + myUserID + "')";

        SqlCommand scom = new SqlCommand(cmdStr, con);
        con.Open();
        scom.ExecuteNonQuery();
        con.Close();

        Server.Transfer("editManageFriend.aspx");   
    }

    protected void repFriendRequest_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }
}
