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
    SqlConnection con;
    String albumName;
    GlobalMeth gObj = new GlobalMeth();

    protected void Page_Load(object sender, EventArgs e)
    {
        albumName = Request.QueryString["AlbumID"];
        
        String conStr = WebConfigurationManager.ConnectionStrings["fooDBcon"].ConnectionString;
        con = new SqlConnection(conStr);

        String userID, myUserID;
        userID = null;

        try
        {
            userID = Request.QueryString["AccountID"].ToString();
        }
        catch
        {
            //query string is empty//
        }

        myUserID = Session["UserName"].ToString();

        if ((userID != null) && (userID != myUserID))
        {
            //Change the profile view as a stranger is trying to access this profile//
            //call a global function to see what is the relationship with this guy//
            //set the visibilty accordingly to the privacy table//
            loadProfilePic(userID);
            //fillName(userID);
            hideMenuItems();
            changeLinkToCurrentUserID(userID);
            loadAlbumPic(userID);
        }
        else
        {
            loadProfilePic(myUserID);
            loadAlbumPic(myUserID);
        }   
    }

    protected void loadAlbumPic(String usrKey)
    {

        String cmdStr = "Select * from AlbumPics where (AlbumFolder_PK = '" + albumName + "')";
       
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();
        rd = scom.ExecuteReader();

        lvGallery.DataSource = rd;
        lvGallery.DataBind();

        rd.Close();
        con.Close();

    }
    
    protected void lvAlbum_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
    
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
}
