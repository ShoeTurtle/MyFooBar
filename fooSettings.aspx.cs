using System;
using System.Collections;
using System.Configuration;
using System.Web.Configuration;
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
    SqlConnection con;
    GlobalMeth gObj = new GlobalMeth();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        String conStr = WebConfigurationManager.ConnectionStrings["fooDBcon"].ConnectionString;
        con = new SqlConnection(conStr);

        String myUserID = Session["UserName"].ToString();
        fillName(myUserID);
        
    }


    protected void fillName(String usrKey)
    {
        lblName.Text = gObj.getName(usrKey);   
    }
}
