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
        Int32 cc = getWorkRecordNo();        

        myUserID = Session["UserName"].ToString();
        fillName();

        if (!IsPostBack)
        {
            String cmdStr = "SELECT UName, CompanyName, City, CONVERT(VARCHAR(10), YearOfJoining, 101) as YearOfJoining, " +
                "CONVERT(VARCHAR(10), YearOfLeaving, 101) as YearOfLeaving, Position, Work_PK, YearOfJoining as ordVal " +
                "FROM Work where UName = '" + myUserID + "' ORDER BY ordVal DESC";

            SqlCommand scom = new SqlCommand(cmdStr, con);
            SqlDataReader rd;
                    
            con.Open();
            rd = scom.ExecuteReader();
            lvWork.DataSource = rd;
            lvWork.DataBind();
            rd.Close();
            con.Close();
        }
        
    }

    protected Int32 getWorkRecordNo()
    {
        String cmdStr = "SELECT COUNT(*) from Work where UName = '" + myUserID + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;
        Int32 count;
      
        con.Open();
        rd = scom.ExecuteReader();
        rd.Read();
        count = Int32.Parse(rd[0].ToString());
        con.Close();

        return count;      
    }


    protected void fillName()
    {
        lblName.Text = gObj.getName(myUserID);
    }


    protected void lvWork_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        TextBox txtCompanyName = (TextBox)e.Item.FindControl("txtCompanyName1") as TextBox;
        TextBox txtPosition = (TextBox)e.Item.FindControl("txtPosition") as TextBox;
        TextBox txtCity = (TextBox)e.Item.FindControl("txtCity") as TextBox;
        TextBox txtJoining = (TextBox)e.Item.FindControl("txtStartDate") as TextBox;
        TextBox txtLeaving = (TextBox)e.Item.FindControl("txtEndDate") as TextBox;

        String CompanyName = "", Position = "", City = "", Joining = "", Leaving = "";

        String PK = gObj.getNextPK("Work");

        CompanyName = txtCompanyName.Text;
        Position = txtPosition.Text;
        City = txtCity.Text;
        Joining = txtJoining.Text;
        Leaving = txtLeaving.Text;


        String cmdStr = "INSERT INTO Work VALUES('" + myUserID + "', '" + CompanyName + 
            "', '" + City +"', '" + Joining + "'," + " '" + Leaving + "', '" + Position + 
            "', '" + PK + "')";
        SqlCommand scom = new SqlCommand(cmdStr, con);

        con.Open();

        Boolean flg = false;   //If there is an error no PostBack//

        if ((CompanyName == "") || (Position == "") || (City == "") || (Joining == ""))
        {
            lblErrorInsert.Text = "Check the Entries, Date should be (MM/DD/YYYY)";
            lblErrorInsert.Visible = true;
            flg = true;
        }

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

            lblErrorInsert.Text = "Check the Entries, Date should be (MM/DD/YYYY)";
            lblErrorInsert.Visible = true;
            flg = true;
        }

        finally
        {
            con.Close();
        }

        if (!flg)
        {
            Server.Transfer("editEducationWork.aspx");
        }
        
    }


    protected void lvWork_ItemUpdating(Object sender, ListViewUpdateEventArgs e)
    {
        TextBox txtCompanyName = (TextBox)(lvWork.Items[e.ItemIndex].FindControl("txtCompanyName")) as TextBox;
        TextBox txtPosition = (TextBox)(lvWork.Items[e.ItemIndex].FindControl("txtPosition")) as TextBox;
        TextBox txtCity = (TextBox)(lvWork.Items[e.ItemIndex].FindControl("txtCity")) as TextBox;
        TextBox txtStartDate = (TextBox)(lvWork.Items[e.ItemIndex].FindControl("txtStartDate")) as TextBox;
        TextBox txtEndDate = (TextBox)(lvWork.Items[e.ItemIndex].FindControl("txtEndDate")) as TextBox;
        
        Literal litPK = (Literal)(lvWork.Items[e.ItemIndex].FindControl("litPK")) as Literal;

        String CompanyName = "", City = "", YearOfJoining = "", YearOfLeaving = "", Position = "", Work_PK = "";

        CompanyName = txtCompanyName.Text;
        City = txtCity.Text; ;
        YearOfJoining = txtStartDate.Text;
        YearOfLeaving = txtEndDate.Text;
        Position = txtPosition.Text;
                
        
        String cmdStr = "UPDATE Work SET CompanyName = '" + CompanyName + "', City = '" + City + "', " +
            "YearOfJoining = '" + YearOfJoining + "', YearOfLeaving = '" + YearOfLeaving + "', " +
            "Position = '" + Position + "' WHERE Work_PK = '" + litPK.Text + "'";

        SqlCommand scom = new SqlCommand(cmdStr, con);

        con.Open();

        Boolean flg = false;   //If there is an error no PostBack//

        if ((CompanyName == "") || (YearOfJoining == "") || (City == "") || (Position == ""))
        {
            lblErrorInsert.Text = "Check the Entries, Date should be (MM/DD/YYYY)";
            lblErrorInsert.Visible = true;
            flg = true;
        }

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

            lblErrorInsert.Text = "Check the Entries, Date should be (MM/DD/YYYY)";
            lblErrorInsert.Visible = true;
            flg = true;
        }

        finally
        {
            con.Close();
        }

        if (!flg)
        {
            Server.Transfer("editEducationWork.aspx");
        }
        
    }


    protected void lvWork_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            TextBox txtCompanyName = (TextBox)e.Item.FindControl("txtCompanyName") as TextBox;
            TextBox txtPosition = (TextBox)e.Item.FindControl("txtPosition") as TextBox;
            TextBox txtCity = (TextBox)e.Item.FindControl("txtCity") as TextBox;
            TextBox txtStartDate = (TextBox)e.Item.FindControl("txtStartDate") as TextBox;
            TextBox txtEndDate = (TextBox)e.Item.FindControl("txtEndDate") as TextBox;
            
            
            Literal litCompanyName = (Literal)e.Item.FindControl("litCompanyName") as Literal;
            Literal litPosition = (Literal)e.Item.FindControl("litPosition") as Literal;
            Literal litCity = (Literal)e.Item.FindControl("litCity") as Literal;
            Literal litPK = (Literal)e.Item.FindControl("litPK") as Literal;
            Literal litJoining = (Literal)e.Item.FindControl("litJoining") as Literal;
            Literal litLeaving = (Literal)e.Item.FindControl("litLeaving") as Literal;

            txtCompanyName.Text = litCompanyName.Text;
            txtPosition.Text = litPosition.Text;
            txtCity.Text = litCity.Text;
            txtStartDate.Text = litJoining.Text;
            
            if(litLeaving.Text == "01/01/1900") 
            {
                txtEndDate.Text = "Still Working";
            }
            else
            {
                txtEndDate.Text = litLeaving.Text;
            }


            LinkButton lnkRemove = (LinkButton)e.Item.FindControl("lnkRemove") as LinkButton;            
            lnkRemove.Attributes.Add("CompanyName", litCompanyName.Text);
            lnkRemove.Attributes.Add("Position", litPosition.Text);
            lnkRemove.Attributes.Add("City", litCity.Text);
            lnkRemove.Attributes.Add("LitPK", litPK.Text);
        }
    }
    

    protected void lnkRemove_Click(object sender, EventArgs e)
    {
        /*This Section Removes the Work Entry from the DB*/
        LinkButton lnkRemove= sender as LinkButton;
              
        String cmdStr = "DELETE FROM Work WHERE Work_PK = '" + lnkRemove.Attributes["LitPK"].ToString() + 
            "'";

        SqlCommand scom = new SqlCommand(cmdStr, con);
               
        con.Open();
        scom.ExecuteNonQuery();
        con.Close();

        Server.Transfer("editEducationWork.aspx");
        
    }

 }

