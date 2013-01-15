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
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    GlobalMeth gObj = new GlobalMeth();
    
    protected void Page_Load(object sender, EventArgs e)
    {
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

        if (userID != null)
        {
            //Change the profile view as a stranger is trying to access this profile//
            //call a global function to see what is the relationship with this guy//
            //set the visibilty accordingly to the privacy table//
            loadProfilePic(userID);
            //fillName(userID);
            hideMenuItems();
            changeLinkToCurrentUserID(userID);
            populateAlbum(userID);
            
        }
        else
        {
            loadProfilePic(myUserID);
            //fillName(myUserID);
            populateAlbum(myUserID);
        }

    }


    protected void populateAlbum(String userId)
    {
        String cmdStr = "Select * from AlbumFolder where UName = '" + userId + "';";

        //String cmdStr = "Select* from AlbumPics where (Uname = 'mike' and AlbumName='MikeFolder2');";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;
        //string albumName, folderID, picName;
     
        con.Open();
        rd = scom.ExecuteReader();
        
        lvAlbums.DataSource = rd;
        lvAlbums.DataBind();
        
        rd.Close();
        con.Close();
    }


    protected void lbAlbums_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            //HyperLink linkEditAlbum = e.Item.FindControl("linkEditAlbum") as HyperLink;
            //linkDeleteButton = e.Item.FindControl("linkDeleteAlbum") as LinkButton;
            HyperLink linkViewAlbum = (HyperLink)e.Item.FindControl("linkViewAlbum") as HyperLink;
            Literal litFolderID = (Literal)e.Item.FindControl("litFolderID") as Literal;
            Literal litUsrKey = (Literal)e.Item.FindControl("litUsrKey") as Literal;

            //linkEditAlbum.NavigateUrl += "?AlbumID=" + litFolderID.Text;
            //linkDeleteAlbum.Attributes.Add("OnClick", "javascript: return(confirm(‘Are you sure you want to delete this album?'));");
            //linkDeleteAlbum.Attributes.Add("FolderID", litFolderID.Text);
            //linkViewAlbum.NavigateUrl += "?AlbumID=" + litFolderID.Text;

            linkViewAlbum.NavigateUrl += "?AlbumID=" + litFolderID.Text + "&AccountID=" + litUsrKey.Text;
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


}
