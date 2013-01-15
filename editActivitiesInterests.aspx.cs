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
    }

    protected void fillName()
    {
        lblName.Text = gObj.getName(myUserID);
    }


    protected void Button9_Click(object sender, EventArgs e)
    {

    }
}
