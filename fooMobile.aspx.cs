using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        GlobalMeth gObj = new GlobalMeth();
        lblName.Text = gObj.getName(Session["UserName"].ToString());
    }
}
