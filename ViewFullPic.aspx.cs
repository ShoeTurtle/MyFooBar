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
    String src;
    SqlConnection con;
    String albumName;
    GlobalMeth gObj = new GlobalMeth();

    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(this.LinkButton1);
        String conStr = WebConfigurationManager.ConnectionStrings["fooDBcon"].ConnectionString;
        con = new SqlConnection(conStr);

        src = Request.QueryString["url"];
        albumName = Request.QueryString["album"];

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
            loadTopImageCollection(userID);

        }
        else
        {
            loadProfilePic(myUserID);
            loadTopImageCollection(myUserID);
        }

        loadFullImage(src);
        
    }


    protected void loadFullImage(String src)
    {
        imgFull.ImageUrl = src;
        
    }

    protected void loadTopImageCollection(String usrKey)
    {

        String cmdStr = "Select * from AlbumPics where (AlbumFolder_PK = '" + albumName + "' and UName = '" +
            usrKey + "')";
        
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();
        rd = scom.ExecuteReader();

        lvViewFullPic.DataSource = rd;
        lvViewFullPic.DataBind();

        rd.Close();
        con.Close();
    }

   protected void magicButton_Click(object sender, EventArgs e)
   {
       loadFullImage(text.Text);
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