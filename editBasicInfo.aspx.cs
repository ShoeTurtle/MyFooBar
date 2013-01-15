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

        RangeValidator1.Type = ValidationDataType.Date;
        RangeValidator1.MaximumValue = "12/12/2003";
        RangeValidator1.MinimumValue = "12/12/1912";

        
        if (!IsPostBack)
        {
            populate_year();
            fillForms();
           
        }
            
           
    }

    protected void fillName()
    {
        lblName.Text = gObj.getName(myUserID);
    }
   
    private void populate_year()
    {
        UserGeneralInfo UGI = new UserGeneralInfo();
        txtDob.Text=UGI.Query_dob(Session["UserName"].ToString());
        
    }
    
    
    protected void cmdSave_Click(object sender, EventArgs e)
    {
        String cmdStr;
        String bday = txtDob.Text;
        
        
        String UserName = txtFirstName.Text + " " + txtLastName.Text;


        /*Update About Me*/
        cmdStr = "UPDATE AboutMe SET AboutMe = '" + txtAbt.Text + "', MyStatus = '" + txtMyStatus.Text + "' WHERE UName = '" + myUserID + "'";
        SqlCommand scom2 = new SqlCommand(cmdStr, con);

        con.Open();
        scom2.ExecuteNonQuery();
        con.Close();
        
             
        
        /*Update General_Information*/
        cmdStr = "UPDATE General_Information SET DOB='" + bday + "', sex='" + DDSex.Text + "',UserName =  '" + UserName + "' WHERE UName = '" + myUserID + "'";
        SqlCommand scom1 = new SqlCommand(cmdStr, con);
        con.Open();

        Boolean flg = false;   //If there is an error no PostBack//

        if ((txtFirstName.Text == "") || (txtLastName.Text == ""))
        {
            lblErrorInsert.Text = "Check the Entries, Names Cannot Be Blank!!!";
            lblErrorInsert.Visible = true;
            flg = true;
        }


        try
        {
            if (!flg)
            {
                scom1.ExecuteNonQuery();
            }
        }

        catch
        {
            //Most Probably it is the date issue//
            //Give a msg saying the date should be in correct format//
            //And Recheck other entries//

            lblErrorInsert.Text = "Check the Entries, Names Cannot Be Blank!!!";
            lblErrorInsert.Visible = true;
            flg = true;
        }

        finally
        {
            con.Close();
        }

        if (!flg)
        {
            Server.Transfer("editBasicInfo.aspx");
        }       
    }


    /*****CHANGES MADE*****/

    protected void fillForms()
    {

        String cmdStr1 = "SELECT * from General_Information where UName = '" + myUserID + "'";
        SqlCommand scom1 = new SqlCommand(cmdStr1, con);
        SqlDataReader rd;

        con.Open();
        rd = scom1.ExecuteReader();
        if (rd.Read())
        {
            String UserName = rd["UserName"].ToString();

            String[] SplitName = UserName.Split(' ');
            txtFirstName.Text = SplitName[0];
            txtLastName.Text = SplitName[1];

            DDSex.Text = rd["Sex"].ToString();

        }
        rd.Close();
        con.Close();
        
        /***Updating the AboutMe Table, first fetching data and filling the textboxes***/
        String cmdStr2 = "SELECT * from AboutMe where UName = '" + myUserID + "'";
        SqlCommand scom2 = new SqlCommand(cmdStr2, con);

        try
        {
            con.Open();
            rd = scom2.ExecuteReader();
            rd.Read();

            txtAbt.Text = rd["AboutMe"].ToString();
            txtMyStatus.Text = rd["MyStatus"].ToString();
        }

        catch
        {
            //Leave The Text Box Blank, User will fill in the information//
            //But make sure before user can upadte all the entries are filled//
        }

        finally
        {
            con.Close();
        }

    }

}
