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


public partial class _Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();
    GlobalMeth gObj = new GlobalMeth();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        object us = Session["UserName"];
        
        if (Session["UserName"] == null)
            Response.Redirect("Login.aspx");
        else
        {
            String user = Session["UserName"].ToString();
            con = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=snetworking;Persist Security Info=True;User ID=aniket;Password=dakgator123;");

                      
            fillInfoBar(user);
            loadProfileImage();
            fillPhoto(user);
            fillFriends(user);
            //fillStatus(user);
            fillEmployer(user);
            
        }
        
    }

    public void fillInfoBar(String usr) {

        String cmdStr = "select * from General_Information where UName='" + usr + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();
        rd = scom.ExecuteReader();
        bool flg = rd.Read();

        if (flg != false)
        {
            /**Creating image path for the Cover Pic**/
            String coverURL;

            coverURL = "~/fooPicDB/" + rd["UName"] + "/Profile/" + rd["CoverPic"];
            imgCover.ImageUrl = coverURL;

            lblUName.Text = rd[0].ToString();
            lblSex.Text = rd[3].ToString();
            lblHomeAdd.Text = rd["FromCity"].ToString();
            lblCurrAdd.Text = rd["CurrentCity"].ToString();
            lblPhone.Text = rd["PhoneNo"].ToString();
            lblEmail.Text = rd["Email"].ToString();
            
            DateTime db;
            db = Convert.ToDateTime(rd["DOB"].ToString());
            lblBirthDay.Text = db.ToShortDateString();            
        }
        else
        {
            //Reader is Empty//
        }
        rd.Close();
        con.Close();

        cmdStr = "Select * from Education where uname='" + usr + "' and category='college' order by batch desc";
        scom = new SqlCommand(cmdStr, con);
        
        DateTime gradYear;

        try
        {
            con.Open();
            rd = scom.ExecuteReader();
            rd.Read();
            gradYear = Convert.ToDateTime(rd["Batch"].ToString());
            lblCollege.Text = rd["InstitutionName"].ToString() + ", " + gradYear.Year;
        }
        catch
        {
            //Leave It Blank
        }

        finally
        {
            rd.Close();
            con.Close();
        }

        cmdStr = "Select * from Education where uname='" + usr + "' and category='school' order by batch desc";
        scom = new SqlCommand(cmdStr, con);

       try
        {
            con.Open();
            rd = scom.ExecuteReader();
            rd.Read();
            gradYear = Convert.ToDateTime(rd["Batch"].ToString());

            lblHighSchool.Text = rd["InstitutionName"].ToString() + ", " + gradYear.Year;
        }

        catch
        {
            //Leave It Blank
        }

        finally 
        {
            rd.Close();
            con.Close();
        }
    
    }

    protected void loadProfileImage()
    {
        imgMain.ImageUrl = gObj.getImageURL(Session["UserName"].ToString());
    }

    //new changes start from here//


    protected void fillPhoto(String usr)
    {
        String cmdStr = "Select * from AlbumFolder where UName = '" + usr + "' order by AlbumDateTime desc";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;
        String[] folderPath = new String[4];
        String[] albumTitle = new String[4];

        con.Open();

        rd = scom.ExecuteReader();

        for (int count = 0; count < 4; count++)
        {
            bool flag = rd.Read();

            if (flag == false)
                break;
            else
            {
                String imgURL = "~/fooPicDB/" + usr + "/" + rd["AlbumFolder_PK"] + "/" + rd["AlbumCover"];
                folderPath[count] = imgURL;
                albumTitle[count] = rd["AlbumName"].ToString();
            }          
        }

        img1.ImageUrl = folderPath[0];
        img2.ImageUrl = folderPath[1];
        img3.ImageUrl = folderPath[2];
        img4.ImageUrl = folderPath[3];

        lblAlbum1.Text = albumTitle[0];
        lblAlbum2.Text = albumTitle[1];
        lblAlbum3.Text = albumTitle[2];
        lblAlbum4.Text = albumTitle[3];
                      
        rd.Close();
        con.Close();

        cmdStr = "Select count(*) from AlbumFolder where uname='" + usr + "'";
        scom = new SqlCommand(cmdStr, con);

        con.Open();
        rd = scom.ExecuteReader();
        rd.Read();
        lblPicCount.Text = rd[0].ToString();
        rd.Close();
        con.Close();
    }


    protected void fillFriends(String usr)
    {
        String cmdStr = "select * from General_Information where UName IN (select FriendID from Friends where UName = '" + usr + "')";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;
        String[] profilePic = new String[6];
        String[] friendName = new String[6];

        con.Open();
        
        rd = scom.ExecuteReader();

        for (int count = 0; count < 6; count++)
        {
            bool flag = rd.Read();

            if (flag == false)
                break;
            else
            {
                String imgURL = "~/fooPicDB/" + rd["UName"].ToString() + "/Profile/" + rd["ProfilePic"].ToString();
                profilePic[count] = imgURL;
                friendName[count] = rd["UserName"].ToString();
            }
        }

        imgFriend1.ImageUrl = profilePic[0];
        imgFriend2.ImageUrl = profilePic[1];
        imgFriend3.ImageUrl = profilePic[2];
        imgFriend4.ImageUrl = profilePic[3];
        imgFriend5.ImageUrl = profilePic[4];
        imgFriend6.ImageUrl = profilePic[5];

        lblFriendName1.Text = friendName[0];
        lblFriendName2.Text = friendName[1];
        lblFriendName3.Text = friendName[2];
        lblFriendName4.Text = friendName[3];
        lblFriendName5.Text = friendName[4];
        lblFriendName6.Text = friendName[5];

        rd.Close();
        con.Close();

        cmdStr = "select COUNT(*) from General_Information where UName IN (select FriendID from Friends where UName = '" + usr + "')";
        scom = new SqlCommand(cmdStr, con);

        con.Open();
        rd = scom.ExecuteReader();
        rd.Read();

        lblFriendCount.Text = rd[0].ToString();

        rd.Close();
        con.Close();

    }

    protected void fillStatus(String usr)
    {

        String cmdStr = "Select * from AboutMe where UName = '" + usr + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();
        rd = scom.ExecuteReader();

        rd.Read();
        //lblStatus.Text = rd["MyStatus"].ToString();

        rd.Close();
        con.Close();
    }

    protected void fillEmployer(String usr)
    {
        String cmdStr = "SELECT * FROM Work WHERE UName = '" + usr + "' ORDER BY YearOfJoining DESC";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();
        rd = scom.ExecuteReader(); 
        rd.Read();

        try
        {
            lblEmp.Text = rd["CompanyName"].ToString() + ", " + rd["City"];
        }
        catch
        {
            //Leave The Field Blank//
        }
        finally
        {
            rd.Close();
            con.Close();
        }
    }


}
