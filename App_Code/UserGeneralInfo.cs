using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
/// <summary>
/// Summary description for UserGeneralInfo
/// </summary>
public class UserGeneralInfo
{
    SqlConnection scon;
	public UserGeneralInfo()
	{

        scon=new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=snetworking;Persist Security Info=True;User ID=aniket;Password=dakgator123;");
		//
		// TODO: Add constructor logic here
		//
    }
    /******************************************************************************************************************************
   * 
   *                                                  Insertion :)
   * 
   * 
   * *****************************************************************************************************************************/
    #region Insertion
    public bool insert_GeneralInfo(string name,string UserName,string dob,string sex, string email)
    {
        string pic = "";
        if (sex == "Male") pic = "noneMale.png";
        else
            pic = "noneFemale.png";
        SqlCommand scom = new SqlCommand("insert into General_Information(UserName,Uname,DOB,Sex,Email,ProfilePic,CoverPic) values('" + name + "','" + UserName + "','" + dob + "','" + sex + "','" + email + "','unknown','unknown')", scon);
        scon.Open();
        if (scom.ExecuteNonQuery() > 0)
        { scon.Close();
            return true;
        }
        else
        {
        scon.Close();
            return false;
        }


    }
    public bool insert_Ulogin(string UserName, string Password)
    {

        SqlCommand scom = new SqlCommand("insert into ULogin values('" + UserName + "','" + Password + "','user',0,'" + DateTime.Now + "')", scon); 
        scon.Open();
        if (scom.ExecuteNonQuery() > 0)
        {   scon.Close();
            return true;
        }
        else
        {   scon.Close();
            return false;
        }
    }
    public bool insert_aboutMe(string userName)
    {
        SqlCommand scom = new SqlCommand("insert into AboutMe values('" + userName + "',' ',' ')", scon);
        scon.Open();
        if (scom.ExecuteNonQuery() > 0)
        {
            scon.Close();
            return true;
        }
        else
        {
            scon.Close();
            return false;
        }
    }
    public bool User_Registration(string name, string UserName, string dob, string sex, string email, string Password)
    {
        if (insert_GeneralInfo(name, UserName, dob, sex, email) && insert_Ulogin(UserName, Password) && insert_aboutMe(UserName))
            return true;
        else
            return false;

    }

    #endregion

    /******************************************************************************************************************************
     * 
     *                                                  Query :)
     * 
     * 
     * *****************************************************************************************************************************/
    #region Query
    public string Query_ProfilePic(string uname)
    {
        SqlCommand scom = new SqlCommand("select ProfilePic from General_Information where UName='" + uname + "'", scon);
        scon.Open();
        SqlDataReader rd = scom.ExecuteReader();
        if (rd.Read())
        {
            string pic = rd[0].ToString();
            scon.Close();
            return pic;
        }
        else
        {
            scon.Close();
            return null;
     
        }
    }
    public string Query_Name(string uname)
    {
        SqlCommand scom = new SqlCommand("select UName from General_Information where UName='" + uname + "'", scon);
        scon.Open();
        SqlDataReader rd = scom.ExecuteReader();
        if (rd.Read())
        {
            string name = rd[0].ToString();
            scon.Close();
            return name;
        }
        else
        {
            scon.Close();
            return null;

        }
    }

    public string Query_sex(string username)
    {
        SqlCommand scom = new SqlCommand("select Sex from General_Information where UName='" + username + "'", scon);
        scon.Open();
        SqlDataReader rd = scom.ExecuteReader();
        if (rd.Read())
        {
            string sex = rd[0].ToString();
            scon.Close();
            return sex;
        }
        else
        {
            scon.Close();
            return null;

        }
    }
    public bool Query_email(string email)
    {
        SqlCommand scom = new SqlCommand("select * from General_Information where Email='" + email + "'", scon);
        scon.Open();
        SqlDataReader rd= scom.ExecuteReader();
        if (rd.Read())
        {
            scon.Close();
            return false;
        }
        else
        {
            scon.Close();
            return true; 
        }
    }
    public bool Query_UserName(string UserName)
    {
        SqlCommand scom = new SqlCommand("select * from ULogin where UName='" + UserName + "'", scon);
        scon.Open();
        SqlDataReader rd = scom.ExecuteReader();
        if (rd.Read())
        {
            scon.Close();
            return false;
        }
        else
        {
            scon.Close();
            return true;
        }
    }
    public string Query_Password(string UserName)
    {
        string pass = null;
        SqlCommand scom = new SqlCommand("select UPassword from ULogin where UName='" + UserName + "'", scon);
        scon.Open();
        SqlDataReader rd = scom.ExecuteReader();
        if (rd.Read())
        {
            pass = rd[0].ToString();
            scon.Close();
        }
        return pass;
        
    }
    public string Query_dob(string uname)
    {
         string[] dob = new string[2];
        dob[0]="";
        SqlCommand scom = new SqlCommand("select dob from General_Information where UName='" + uname + "'", scon);
        scon.Open();
        SqlDataReader rd = scom.ExecuteReader();
        if (rd.Read())
        {
            dob = rd[0].ToString().Split(' ');
            scon.Close();
        }
        return dob[0];
    }
    #endregion
    /******************************************************************************************************************************
     * 
     *                                                 Updatation :D
     * 
     * 
     * *****************************************************************************************************************************/
    #region Updation 
    public bool update_GeneralInfo(string name, string UserName, string dob, string sex, string email)
    {

        SqlCommand scom = new SqlCommand("update General_Information set UName='"+name+"',DOB='"+dob+"',Sex='"+sex+"',Email='"+email+"' where UserName='"+UserName+"'",scon);
        scon.Open();
        if (scom.ExecuteNonQuery() > 0)
        {
            scon.Close();
            return true;
        }
        else
        {
            scon.Close();
            return false;
        }

    }
    public bool update_Password(string UserName, string Password)
    {

        SqlCommand scom = new SqlCommand("update ULogin set UPassword='" + Password +"' where UserName='" + UserName+"'", scon);
        scon.Open();
        if (scom.ExecuteNonQuery() > 0)
        {
            scon.Close();
            return true;
        }
        else
        {
            scon.Close();
            return false;
        }

    }
    public bool update_Login(string UserName, int value)
    {
        SqlCommand scom;
        if (value == 0)
            scom = new SqlCommand("update ULogin set UStatus=" + value + " where UName='" + UserName + "'", scon);
        else
            scom = new SqlCommand("update ULogin set UStatus=" + value + ",LastLogin='" + DateTime.Now + "' where UName='" + UserName + "'", scon);
        scon.Open();
        if (scom.ExecuteNonQuery() > 0)
        {
            scon.Close();
            return true;
        }
        else
        {
            scon.Close();
            return false;
        }

    }
    #endregion

}
