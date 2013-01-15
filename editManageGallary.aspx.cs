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
using System.Drawing;
using System.IO;
using System.Data.SqlClient;
using System.Web.Configuration;


public partial class _Default : System.Web.UI.Page
{
    String myUserID;
    SqlConnection con;
    GlobalMeth gObj = new GlobalMeth();
    Boolean flgErr = true;

    protected void Page_Load(object sender, EventArgs e)
    {
        String conStr = WebConfigurationManager.ConnectionStrings["fooDBcon"].ConnectionString;
        con = new SqlConnection(conStr);
        
        myUserID = Session["UserName"].ToString();
        fillName();
        
        pnlNewAlbum.Visible = false;
        pnlAlbumPicture.Visible = false;
        pnlGallaryMain.Visible = true;

        createGallary();
        
    }

    protected void fillName()
    {
        lblName.Text = gObj.getName(myUserID);
    }

    //***When the Main UPDATE ALBUM is clicked gallary is created****//
    
    protected void butUpdate_Click(object sender, EventArgs e)
    {
        pnlAlbumPicture.Visible = false;
        pnlGallaryMain.Visible = true;

        createGallary();
    }

    //***Creating Gallary***//
    protected void createGallary()
    {
        String cmdStr = "SELECT * FROM AlbumFolder WHERE UName = '" + myUserID + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();
        rd = scom.ExecuteReader();
        
        lvAlbums.DataSource = rd;
        lvAlbums.DataBind();

        rd.Close();
        con.Close();

    }

    //***Binding the Album data***//
    protected void lbAlbums_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {

            Literal litFolderID = (Literal)e.Item.FindControl("litFolderID") as Literal;
            Literal litUsrKey = (Literal)e.Item.FindControl("litUsrKey") as Literal;
            LinkButton linkUpdateAlbum = (LinkButton)e.Item.FindControl("linkUpdateAlbum") as LinkButton;
            LinkButton linkDeleteAlbum = (LinkButton)e.Item.FindControl("linkDeleteAlbum") as LinkButton;          
            
            linkUpdateAlbum.Attributes.Add("FolderID", litFolderID.Text);
            linkDeleteAlbum.Attributes.Add("FolderID", litFolderID.Text);
                       
        }
    }

    //**When Seconday UPDATEALBUM is clicked, picture album is created***//
    protected void linkUpdateAlbum_Click(object sender, EventArgs e)
    {
        pnlGallaryMain.Visible = false;
        pnlAlbumPicture.Visible = true;

        butNewAlbum.Visible = false;
        butUpdate.Visible = false;        

        LinkButton linkUpdateAlbum = sender as LinkButton;

        String FolderID = linkUpdateAlbum.Attributes["FolderID"];       
        
        createAlbumPictures(FolderID);
    }


    //***Creating album pictures***//
    protected void createAlbumPictures(String FolderID)
    {
        String cmdStr = "SELECT * from AlbumFolder where AlbumFolder_PK = '" + FolderID + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();
        rd = scom.ExecuteReader();
        rd.Read();

        txtUpdateAlbumName.Text = rd["AlbumName"].ToString();
        Session["CurrentFolderID"] = rd["AlbumFolder_PK"].ToString();

        rd.Close();
        con.Close();

        cmdStr = "Select * from AlbumPics where (AlbumFolder_PK = '" + FolderID + "' and UName = '" +
            myUserID + "')";

        scom = new SqlCommand(cmdStr, con);
        
        con.Open();
        rd = scom.ExecuteReader();

        lvGallery.DataSource = rd;
        lvGallery.DataBind();

        rd.Close();
        con.Close();
    }


   
    //***Binding Data to the Album List***//
    protected void lvAlbum_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
            
        LinkButton linkDeletePicture = (LinkButton)e.Item.FindControl("linkDeletePicture") as LinkButton;
        Literal litFolderID = (Literal)e.Item.FindControl("litFolderID") as Literal;
        Literal litImageName = (Literal)e.Item.FindControl("litImageName") as Literal;

        linkDeletePicture.Attributes.Add("FolderID", litFolderID.Text);
        linkDeletePicture.Attributes.Add("ImageID", litImageName.Text);
    }
     

    //**Deleting the picture***//
    protected void linkDeletePicture_Click(object sender, EventArgs e)
    {
        //Write the Delete Picture Query Here//
        LinkButton linkDeletePicture = sender as LinkButton;

        String ImageID = linkDeletePicture.Attributes["ImageID"].ToString();

        String cmdStr = "DELETE FROM AlbumPics WHERE PicTitle = '" + ImageID + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        con.Open();
        scom.ExecuteNonQuery();
        con.Close();

        setPanelView(true, false, false);
        setButton(false, false);
        createAlbumPictures(linkDeletePicture.Attributes["FolderID"].ToString());
    }


    //**Deleting the entire album**//
    protected void linkDeleteAlbum_Click(object sender, EventArgs e)
    {
        //Write the Delete Album Query//
        //Write the Delete all Pictures Associated with this album//


        LinkButton linkDeleteAlbum = sender as LinkButton;
        String FolderID = linkDeleteAlbum.Attributes["FolderID"].ToString();

        String cmdStr = "DELETE FROM AlbumFolder WHERE AlbumFolder_PK = '" + FolderID + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);

        con.Open();

        try { scom.ExecuteNonQuery(); }
        catch { }

        con.Close();
        
        cmdStr = "DELETE FROM AlbumPics WHERE AlbumFolder_PK = '" + FolderID + "'";
        scom = new SqlCommand(cmdStr, con);
        
        con.Open();

        try { scom.ExecuteNonQuery(); }
        catch { }
               
        con.Close();

        Server.Transfer("editManageGallary.aspx");
    }        
        
    


    //****** CODE TO CREATE ALBUM  *******//


    protected void butNewAlbum_Click(object sender, EventArgs e)
    {

        setPanelView(false, false, true);
        
        //pnlAlbumPicture.Visible = false;
        //pnlGallaryMain.Visible = false;
        //pnlNewAlbum.Visible = true;

        setButton(false, false);
        //butNewAlbum.Visible = false;
        //butUpdate.Visible = false;

        txtAlbumName.Text = "";
    }


    protected void UploadButton_Click(object sender, EventArgs e)
    {
        String GoToPicView = "";
        flgErr = false;
        
        String FolderID = "";  //The FolderName is the unique identifier//
        FolderID = gObj.getNextPK("AlbumFolder");

        if (txtAlbumName.Text != "")
        {
            if (FileUploadProfilePic.HasFile)
            {
                try
                {
                    if (FileUploadProfilePic.PostedFile.ContentType == "image/jpeg")
                    {
                        if (FileUploadProfilePic.PostedFile.ContentLength / 1000 < 1000)
                        {

                            //********CREATING New Album Folder*********// 
                            String folder2 = "~/foopicDB/" + Session["UserName"].ToString() + "/" + FolderID;
                            Directory.CreateDirectory(Server.MapPath(folder2));

                            //***Inserting The Folder Into The Database****//
                            String cmdStr = "INSERT INTO AlbumFolder VALUES('" + FolderID + "','" + myUserID +
                                "','" + txtAlbumName.Text + "','albumcover','" + DateTime.Now.ToString() + "', " +
                                "'nothing', 2)";

                            SqlCommand scom = new SqlCommand(cmdStr, con);
                            con.Open();
                            scom.ExecuteNonQuery();
                            con.Close();
                            //*************End of Folder Insertion*******//

                            //****Now Trying to Upload the Picture****//
                            
                            String PicID = gObj.getNextPK("AlbumPics");

                            string filename = PicID + "_" + Path.GetFileName(FileUploadProfilePic.FileName);
                            hidPicName.Value = filename; //**File Name For The Picture**//
                            hidAlbumID.Value = FolderID; //**Saving The FolderID*******//

                            FileUploadProfilePic.SaveAs(Server.MapPath("~/fooPicDB/" + myUserID + "/" + FolderID + "/") + filename);

                            StatusLabel.Text = "Upload status: File uploaded!";

                            //***Query To Insert The Picture Into the database****//                           

                            cmdStr = "INSERT INTO AlbumPics VALUES ('" + FolderID + "','" + PicID + "','" +
                                filename + "','nothing','" + myUserID + "','" + DateTime.Now.ToString() + "')";

                            scom = new SqlCommand(cmdStr, con);
                            con.Open();
                            scom.ExecuteNonQuery();
                            con.Close();
                            //******************End of Picture Insertion*********//


                            //****Inserting the latest picture as FolderImage*****//
                            cmdStr = "UPDATE AlbumFolder SET AlbumCover = '" + filename + "' WHERE AlbumFolder_PK = '" + FolderID + "'";
                            scom = new SqlCommand(cmdStr, con);
                            con.Open();
                            scom.ExecuteNonQuery();
                            con.Close();

                            GoToPicView = "true";

                        }
                        else
                        {
                            StatusLabel.Text = "Upload status: The file has to be less than 1 MB!";
                            flgErr = true;
                        }
                    }
                    else
                    {
                        StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                        flgErr = true;
                    }
                }
               
               catch (Exception ex)
               {
                   StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                   flgErr = true;
               }

            }

            setPanelView(false, false, true);
            //pnlNewAlbum.Visible = true;
            //pnlGallaryMain.Visible = false;
            //pnlAlbumPicture.Visible = false;

            setButton(false, false);
            //butNewAlbum.Visible = false;
            //butUpdate.Visible = false;

            flgErr = true;

          }
        else
        {
            setPanelView(false, false, true);
            //pnlAlbumPicture.Visible = false;
            //pnlGallaryMain.Visible = false;
            //pnlNewAlbum.Visible = true;

            setButton(false, false);
            
            //butNewAlbum.Visible = false;
            //butUpdate.Visible = false;

            flgErr = true;
        }

        if (GoToPicView == "true")
        {

            setPanelView(true, false, false);
            //pnlAlbumPicture.Visible = true;
            //pnlGallaryMain.Visible = false;
            //pnlNewAlbum.Visible = false;

            setButton(false, false);
            //butNewAlbum.Visible = false;
            //butUpdate.Visible = false;

            createAlbumPictures(FolderID);
        }
    }
    


    protected void butGoBack_Click(object sender, EventArgs e)
    {
        setPanelView(false, true, false);
        //pnlAlbumPicture.Visible = false;
        //pnlGallaryMain.Visible = true;
        //pnlNewAlbum.Visible = false;

        setButton(true, true);
        //butNewAlbum.Visible = true;
        //butUpdate.Visible = true;

        createGallary();
    }


    protected void butGoBackToPictureView_Click(object sender, EventArgs e)
    {

        if (flgErr == true)
        {
            setButton(true, true);
            setPanelView(false, true, false);
        }
        else
        {
            setButton(false, false);
            setPanelView(true, false, false);
            createAlbumPictures(Session["CurrentFolderID"].ToString());
        }   
    }

    
    protected void UploadButtonAlbumPicture_Click(object sender, EventArgs e)
    {
        String FolderID = "";  //The FolderName is the unique identifier//
        FolderID = Session["CurrentFolderID"].ToString();

        if (txtUpdateAlbumName.Text != "")
        {   
            if (FileUploadAlbumPicture.HasFile)
            {
                
                //****Now Trying to Upload the Picture****//
                try
                {
                    if (FileUploadAlbumPicture.PostedFile.ContentType == "image/jpeg")
                    {
                        if (FileUploadAlbumPicture.PostedFile.ContentLength / 1000 < 1000)
                        {
                            String PicID = gObj.getNextPK("AlbumPics");

                            string filename = PicID + "_" + Path.GetFileName(FileUploadAlbumPicture.FileName);
                            hidPicNameUpdateAlbum.Value = filename; //**File Name For The Picture**//
                            hidAlbumIDUpdateAlbum.Value = FolderID; //**Saving The FolderID*******//
                           
                            FileUploadAlbumPicture.SaveAs(Server.MapPath("~/fooPicDB/" + myUserID + "/" + FolderID + "/") + filename);

                            StatusLabel.Text = "Upload status: File uploaded!";

                            //***Query To Insert The Picture Into the database****//                           

                            String cmdStr = "INSERT INTO AlbumPics VALUES ('" + FolderID + "','" + PicID + "','" +
                                filename + "','nothing','" + myUserID + "','" + DateTime.Now.ToString() + "')";

                            SqlCommand scom = new SqlCommand(cmdStr, con);
                            con.Open();
                            scom.ExecuteNonQuery();
                            con.Close();
                            //******************End of Picture Insertion*********//


                            //****Inserting the latest picture as FolderImage*****//
                            cmdStr = "UPDATE AlbumFolder SET AlbumCover = '" + filename + "' WHERE AlbumFolder_PK = '" + FolderID + "'";
                            scom = new SqlCommand(cmdStr, con);
                            con.Open();
                            scom.ExecuteNonQuery();
                            con.Close();

                        }
                        else
                            StatusLabel.Text = "Upload status: The file has to be less than 1 MB!";
                    }
                    else
                        StatusLabel.Text = "Upload status: Only JPEG files are accepted!";
                }

                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }

            setPanelView(true, false, false);
            //pnlAlbumPicture.Visible = true;
            //pnlGallaryMain.Visible = false;
            //pnlNewAlbum.Visible = false;

            setButton(false, false);
            
            //butNewAlbum.Visible = false;
            //butUpdate.Visible = false;
            
            createAlbumPictures(FolderID);
        
        }
        else
        {
            //Give an Error msg, "Folder Name Cannot Be Blank"
            //StatusLabel.Text = "Folder Name Cannot Be Blank";

            setPanelView(true, false, false);
            
            //pnlAlbumPicture.Visible = true;
            //pnlGallaryMain.Visible = false;
            //pnlNewAlbum.Visible = false;

            setButton(false, false);
            //butNewAlbum.Visible = false;
            //butUpdate.Visible = false;
            
            createAlbumPictures(FolderID);

        }

    }


    protected void lnkUpdateAlbumName_OnClick(object sender, EventArgs e)
    {
        //***Updating The FolderName Into The Database****//
        String cmdStr = "UPDATE AlbumFolder SET AlbumName = '" + txtUpdateAlbumName.Text +
            "' WHERE AlbumFolder_PK = '" + Session["CurrentFolderID"].ToString() + "'";

        SqlCommand scom = new SqlCommand(cmdStr, con);
        con.Open();
        scom.ExecuteNonQuery();
        con.Close();
        //*************End of FolderName Updation*******//

        setButton(false, false);
        setPanelView(true, false, false);
        
        //pnlAlbumPicture.Visible = true;
        //pnlGallaryMain.Visible = false;
        //pnlNewAlbum.Visible = false;

        butUpdate.Visible = false;
        butNewAlbum.Visible = false;

        //createAlbumPictures(Session["CurrentFolderID"].ToString());
    }

    

    protected void setPanelView(Boolean pnlAlbum, Boolean pnlGallary, Boolean pnlNew) 
    {
        pnlAlbumPicture.Visible = pnlAlbum;
        pnlGallaryMain.Visible = pnlGallary;
        pnlNewAlbum.Visible = pnlNew;
    }


    protected void setButton(Boolean updateAlbum, Boolean createAlbum)
    {
        butUpdate.Visible = updateAlbum;
        butNewAlbum.Visible = createAlbum;
    }

        

}
