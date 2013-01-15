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
    SqlConnection con;
    String myUserID;
    GlobalMeth gObj = new GlobalMeth();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        String conStr = WebConfigurationManager.ConnectionStrings["fooDBcon"].ConnectionString;
        con = new SqlConnection(conStr);

        myUserID = Session["UserName"].ToString();
        fillName();

    }

    protected void fillName()
    {
        lblName.Text = gObj.getName(myUserID);
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Int32 X1, Y1, Width, Height;

        X1 = Int32.Parse(hidX1.Value.ToString());
        Y1 = Int32.Parse(hidY1.Value.ToString());
        Width = Int32.Parse(hidWidth.Value.ToString());
        Height = Int32.Parse(hidHeight.Value.ToString());
        CropFile(X1, Y1, Width, Height);
    }


    public void CropFile(Int32 X, Int32 Y, Int32 Width, Int32 Height)
    {
        string ppname = hidPicName.Value.ToString();
        string pathToImage = Server.MapPath("~/fooPicDB/tmp/") + ppname;

        System.Drawing.Image img = System.Drawing.Image.FromFile(pathToImage);
        Bitmap bmpCropped = new Bitmap(Width, Height);
        Graphics g = Graphics.FromImage(bmpCropped);

        Rectangle rectDestination = new Rectangle(0, 0, bmpCropped.Width, bmpCropped.Height);
        Rectangle rectCropArea = new Rectangle(X, Y, Width, Height);

        g.DrawImage(img, rectDestination, rectCropArea, GraphicsUnit.Pixel);
        g.Dispose();

        ppname = "Cover" + Session["UserName"].ToString() + ".jpg";
        string profilePicPath = Server.MapPath("~/fooPicDB/" + Session["UserName"].ToString() + "/Profile/"+ppname.ToString());

        bmpCropped.Save(profilePicPath, System.Drawing.Imaging.ImageFormat.Jpeg);
              
        String cmdStr = "UPDATE General_Information SET CoverPic = '" + ppname + "' WHERE UName = '" + myUserID + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);

        con.Open();
        scom.ExecuteNonQuery();
        con.Close();
    }


    protected void UploadButton_Click(object sender, EventArgs e)
    {
        if (FileUploadProfilePic.HasFile)
        {
            try
            {
                if (FileUploadProfilePic.PostedFile.ContentType == "image/jpeg")
                {
                    if (FileUploadProfilePic.PostedFile.ContentLength / 1000 < 1000)
                    {
                        string filename = Path.GetFileName(FileUploadProfilePic.FileName);
                        hidPicName.Value = filename;

                        FileUploadProfilePic.SaveAs(Server.MapPath("~/fooPicDB/tmp/") + filename);
                        imgCropImage.ImageUrl = "~/fooPicDB/tmp/" + filename;
                        StatusLabel.Text = "Upload status: File uploaded!";

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
    }

}
