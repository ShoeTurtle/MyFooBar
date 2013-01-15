using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

    public partial class Controls_ChatPanelItem : System.Web.UI.UserControl
    {
        static bool chatbox;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        string username;
        bool online;
        string name;
        string ProfileImageUrl;
        string StatusImageUrl;
        public string setUserName
        {
            get { return username; }
            set
            {
                username = value;
            }

        }
        public bool setOnline
        {
            get { return online; }
            set
            {
                online= value;
                
            }

        }
        public string setName
        {
            get { return name; }
            set
            {
                name = value;
                lblName.Text = name;
            }

        }
        public string setProfilePic
        {
            get { return ProfileImageUrl; }
            set
            {
                ProfileImageUrl = value;
                Image1.ImageUrl = ProfileImageUrl;
            }

        }
        public string setStatusPic
        {
            get { return StatusImageUrl; }
            set
            {
                StatusImageUrl = value;
                Image2.ImageUrl = StatusImageUrl;
            }

        }
 
 
    }
