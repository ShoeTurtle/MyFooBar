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
using System.Web.Configuration;
using System.Text.RegularExpressions;

public partial class _Default : System.Web.UI.Page
{
    String myUserID;
    SqlConnection con;
    GlobalMeth gObj = new GlobalMeth();

    protected void Page_Load(object sender, EventArgs e)
    {
        String conStr = WebConfigurationManager.ConnectionStrings["fooDBcon"].ConnectionString;
        con = new SqlConnection(conStr);
        myUserID = Session["UserName"].ToString();

        fillName();

        if (!IsPostBack)
        {
            fillform();
        }
    }

    protected void fillName()
    {
        lblName.Text = gObj.getName(myUserID);
    }


    protected void cmdSave_Click(object sender, EventArgs e)
    {
        String CurrentCity = "", HomeTown = "", PhoneNo = "", Email = "";

        CurrentCity = txtCurrentCity.Text;
        HomeTown = txtHomeTown.Text;
        PhoneNo = txtPhone.Text;
        Email = txtEmail.Text;

        String cmdStr = "UPDATE General_Information SET CurrentCity = '" + CurrentCity + "', FromCity = '" +
            HomeTown + "', Email = '" + Email + "', Phoneno = '" + PhoneNo + "' WHERE UName = '" + myUserID + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        
        Boolean flg = false;   //If there is an error no PostBack//

        if ((CurrentCity == "") || (HomeTown == "") || (PhoneNo == "") || (Email == ""))
        {
            lblError.Text = "Please do not leave the entries blank!!!";
            lblError.Visible = true;
            flg = true;
        }

        if (!Regex.IsMatch(PhoneNo, @"^\d{10}$"))
        {
            lblError.Text = "Invalid Phone No!!!";
            lblError.Visible = true;
            flg = true;
        }
        
        
        con.Open();

        try
        {
            if (!flg)
            {
                scom.ExecuteNonQuery();
            }
        }

        catch
        {
            //Most Probably it is the date issue//
            //Give a msg saying the date should be in correct format//
            //And Recheck other entries//

            lblError.Text = "Check the Entries!!!";
            lblError.Visible = true;
            flg = true;
        }

        finally
        {
            con.Close();
        }

        if (!flg)
        {
            Server.Transfer("editContacts.aspx");
        }

    }


    protected void fillform()
    {

        String cmdStr = "SELECT * from General_Information WHERE UName = '" + myUserID + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();
        rd = scom.ExecuteReader();

        rd.Read();

        try
        {
            txtCurrentCity.Text = rd["CurrentCity"].ToString();
            txtEmail.Text = rd["Email"].ToString();
            txtHomeTown.Text = rd["FromCity"].ToString();
            txtPhone.Text = rd["Phoneno"].ToString();
        }
        catch
        {
            //Leave it Blank//
        }
        finally
        {
            rd.Close();
            con.Close();
        }
    }

}
