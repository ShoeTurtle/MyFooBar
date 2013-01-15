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
            /****Query That will extract the date in a proper foramt****/
            String cmdStr = "SELECT UName, Category, CONVERT(VARCHAR(10),Batch, 101) as Batch, DegreeTitle, InstitutionName, Education_PK " +
                ", Batch as ordval FROM Education where UName = '" + myUserID + "' order by ordval DESC";
            SqlCommand scom = new SqlCommand(cmdStr, con);
            SqlDataReader rd;

            con.Open();
            rd = scom.ExecuteReader();
            lvEducation.DataSource = rd;
            lvEducation.DataBind();
            rd.Close();
            con.Close();
        }
        
        
    }

    protected void fillName()
    {
        lblName.Text = gObj.getName(myUserID);
    }


    protected void lvEducation_ItemUpdating(object sender, ListViewUpdateEventArgs e)
    {
        TextBox txtInstitutionName = (TextBox)(lvEducation.Items[e.ItemIndex].FindControl("txtInstitutionName")) as TextBox;
        TextBox txtDegreeTitle = (TextBox)(lvEducation.Items[e.ItemIndex].FindControl("txtDegreeTitle")) as TextBox;
        DropDownList DDCategory = (DropDownList)(lvEducation.Items[e.ItemIndex].FindControl("DDCategory")) as DropDownList;
        TextBox txtBatch = (TextBox)(lvEducation.Items[e.ItemIndex].FindControl("txtBatch")) as TextBox;
        Literal litPK = (Literal)(lvEducation.Items[e.ItemIndex].FindControl("litPK")) as Literal;

        String InstitutionName = "", DegreeTitle = "", Category = "", Batch = "";

        InstitutionName = txtInstitutionName.Text;
        DegreeTitle = txtDegreeTitle.Text;
        Category = DDCategory.Text;
        Batch = txtBatch.Text;

        String cmdStr = "UPDATE Education SET Category = '" + Category + "', Batch = '" + Batch + "', " +
            "DegreeTitle = '" + DegreeTitle + "', InstitutionName = '" + InstitutionName + "' " +
            "WHERE Education_PK = '" + litPK.Text + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        con.Open();

        Boolean flg = false;   //If there is an error no PostBack//

        if ((InstitutionName == "") || (DegreeTitle == "") || (Category == "") || (Batch == ""))
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
            Server.Transfer("editEducation.aspx");
        }

    }

    protected void lvEducation_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        String InstitutionName = "", DegreeTitle = "", Category = "", Batch = "";
        
        TextBox txtInstitutionName = (TextBox)e.Item.FindControl("txtInstitution") as TextBox;
        TextBox txtDegreeTitle = (TextBox)e.Item.FindControl("txtDegree") as TextBox;
        DropDownList DDCategory = (DropDownList)e.Item.FindControl("DDCategory") as DropDownList;
        TextBox txtBatch = (TextBox)e.Item.FindControl("txtBatch") as TextBox;
        

        InstitutionName = txtInstitutionName.Text;
        DegreeTitle = txtDegreeTitle.Text;
        Category = DDCategory.Text;
        Batch = txtBatch.Text;


        String PK = gObj.getNextPK("Education");    
        
        String cmdStr = "Insert into Education values ('" + myUserID + "', '" + Category + "'," +
            " '" + Batch + "', '" + DegreeTitle + "', '" + InstitutionName + "', '" + PK + "')";
        SqlCommand scom = new SqlCommand(cmdStr, con);

        con.Open();

        Boolean flg = false;   //If there is an error no PostBack//

        
        if ((InstitutionName == "") || (DegreeTitle == "") || (Category == "") || (Batch == ""))
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
            Server.Transfer("editEducation.aspx");
        }
                
    }

    
    protected void lvEducation_ItemDataBound(object sender, ListViewItemEventArgs e)
    {

        TextBox txtInstitutionName = (TextBox)e.Item.FindControl("txtInstitutionName") as TextBox;
        TextBox txtDegreeTitle = (TextBox)e.Item.FindControl("txtDegreeTitle") as TextBox;
        DropDownList DDCategory = (DropDownList)e.Item.FindControl("DDCategory") as DropDownList;
        TextBox txtBatch = (TextBox)e.Item.FindControl("txtBatch") as TextBox;

        Literal litInstitutionName = (Literal)e.Item.FindControl("litInstitutionName") as Literal;
        Literal litDegreeTitle = (Literal)e.Item.FindControl("litDegreeTitle") as Literal;
        Literal litBatch = (Literal)e.Item.FindControl("litBatch") as Literal;
        Literal litCategory = (Literal)e.Item.FindControl("litCategory") as Literal;
        Literal litPK = (Literal)e.Item.FindControl("litPK") as Literal;

        txtInstitutionName.Text = litInstitutionName.Text;
        txtDegreeTitle.Text = litDegreeTitle.Text;
        DDCategory.Text = litCategory.Text;
        txtBatch.Text = litBatch.Text;

        LinkButton lnkRemove = (LinkButton)e.Item.FindControl("lnkRemove") as LinkButton;

        lnkRemove.Attributes.Add("InstitutionName", litInstitutionName.Text);
        lnkRemove.Attributes.Add("DegreeTitle", litDegreeTitle.Text);
        lnkRemove.Attributes.Add("Category", litCategory.Text);
        lnkRemove.Attributes.Add("Batch", litBatch.Text);

    }


    protected void lnkRemove_Click(object sender, EventArgs e)
    {
        /*Creating a object of LinkButton so all the attributes are passed*/
        LinkButton linkRemove = sender as LinkButton;

        String InstitutionName, DegreeTitle, Category, Batch;
        
        InstitutionName = linkRemove.Attributes["InstitutionName"].ToString();
        DegreeTitle = linkRemove.Attributes["DegreeTitle"].ToString();
        Category = linkRemove.Attributes["Category"].ToString();
        Batch = linkRemove.Attributes["Batch"].ToString();

        /**Query to Remove Education Record From the Education Table**/

        String cmdStr = "Delete From Education where (Uname = '" + Session["UserName"].ToString() + "' AND " +
            "InstitutionName = '" + InstitutionName + "' AND " + "DegreeTitle = '" + DegreeTitle + "' " +
            "AND Category = '" + Category + "' AND Batch = '" + Batch + "')";
        SqlCommand scom = new SqlCommand(cmdStr, con);

        con.Open();
        scom.ExecuteNonQuery();
        con.Close();

        Server.Transfer("editEducation.aspx");
                
    }
    
}

