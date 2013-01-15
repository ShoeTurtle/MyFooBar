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

public partial class UserControls_MyGallary : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //***Information I need***//
    //***Source to the image***//

    String ImgTitle;


    public string setImgTitle
    {
        get
        {
            return lblTitle.Text;
        }

        set
        {
            ImgTitle = value;
            lblTitle.Text = ImgTitle.ToString();
        }
    }
}
