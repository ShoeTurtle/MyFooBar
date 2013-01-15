using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;


public class GlobalMeth
{
    SqlConnection con;
	public GlobalMeth()
	{
        String conStr = WebConfigurationManager.ConnectionStrings["fooDBcon"].ConnectionString;
        con = new SqlConnection(conStr);
	}

       
    public String getImageURL(String UName)
    {
        String cmdStr = "Select * from General_Information where UName = '" + UName + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;
        
        con.Open();
        String imgURL = "";
        rd = scom.ExecuteReader();
        rd.Read();

             imgURL = "~/fooPicDB/" + rd["UName"].ToString() + "/Profile/" + rd["ProfilePic"].ToString();
        
        
      
        rd.Close();
        con.Close();
        return imgURL;
    }

    public String relationMap(String userID, String myUserID)
    {
        String cmdStr = "Select * from Friends where UName = '" + myUserID + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);

        SqlDataReader rd;

        con.Open();
        rd = scom.ExecuteReader();

        while (rd.Read())
        {
            if (userID == rd["FriendID"].ToString())
            {
                rd.Close();
                con.Close();
                return ("friend");
            }
        }

        rd.Close();
        con.Close();
        return ("notfriend"); 
    }

    public String getName(String usrKey)
    {
        String cmdStr = "Select * from General_Information where UName = '" + usrKey + "'";
        String username="";

        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();
        rd = scom.ExecuteReader();
        if (rd.Read())
        {
            username = rd["UserName"].ToString() ;
        }
        rd.Close();
        con.Close();
        return (username.ToString()); 
    }


    public String getNextPK(String tblName)
    {
        String cmdStr = "Select * from " + tblName + " ORDER BY " + tblName + "_PK DESC";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;
        
        con.Open();
        rd = scom.ExecuteReader();
        rd.Read();

        Int16 currKey;

        try
        {
            currKey = Convert.ToInt16(rd[tblName + "_PK"].ToString());
        }

        catch
        {
            return (Convert.ToString(100));
        }

        finally
        {
            rd.Close();
            con.Close();
        }
        
        return (Convert.ToString(currKey + 1));
    }




}
