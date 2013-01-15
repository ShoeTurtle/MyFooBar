using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


    public partial class Controls_ChatPanel : System.Web.UI.UserControl
    {
        SqlConnection scon;
        protected void Page_Load(object sender, EventArgs e)
        {
            control_gen();
        }

        void control_gen()
        {
            scon = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=snetworking;Persist Security Info=True;User ID=aniket;Password=dakgator123;");
            SqlDataReader rd;
            bool online;
            string StatusPic;
            SqlCommand scom = new SqlCommand("select ul.UName,ul.UStatus,gi.UserName from General_Information gi INNER JOIN ULogin ul ON gi.UName = ul.UName where(ul.UName in(select Receiver from FriendInvitation where Status='True' and Sender='" + Session["UserName"].ToString() + "') ) or (ul.UName in(select Sender from FriendInvitation where Status='True' and Receiver='" + Session["UserName"].ToString() + "') )  ", scon);
            scon.Open();
            rd = scom.ExecuteReader();
            while (rd.Read())
            {
                if (rd["UStatus"].ToString() == "0")
                {
                    StatusPic = "~/images/offLine.png";
                    online=false;
                }
                else
                {
                    StatusPic = "~/images/onLine.png";
                    online=true;
                }
                GlobalMeth gm=new GlobalMeth();

                Panel1.Controls.Add(filler(rd["UserName"].ToString(), rd["UName"].ToString(), gm.getImageURL(rd["UName"].ToString()), StatusPic, online));
            }
        }
        Controls_ChatPanelItem filler(string name,string username,string profilepic,string statusPic,bool online)
        {

            Controls_ChatPanelItem uci = LoadControl("~/UserControls/ChatPanelItem.ascx") as Controls_ChatPanelItem;
            uci.setName = name;
            uci.setUserName = username;
            uci.setProfilePic = profilepic;
            uci.setStatusPic = statusPic;
            uci.setOnline = online;      
            return uci;
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            UpdatePanel1.Update();
        }
}


