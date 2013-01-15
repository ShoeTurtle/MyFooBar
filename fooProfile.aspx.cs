using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    SqlConnection con;
    String conStr;
    GlobalMeth gObj = new GlobalMeth();
    
    String relationStatus = "owner";
    String userID, myUserID;
    
    StringBuilder sb = new StringBuilder();
    StringBuilder sbContactInfo = new StringBuilder();
    StringBuilder sbEducationInfo = new StringBuilder();
    
    StringBuilder sbSchool = new StringBuilder();
    StringBuilder sbHighSchool = new StringBuilder();
    StringBuilder sbCollege = new StringBuilder();

    StringBuilder sbAboutMe = new StringBuilder();
    StringBuilder sbFavMovies = new StringBuilder();
    StringBuilder sbFavTVShows = new StringBuilder();
    
    
    int flg = 0;

    int chk1 = 0, chk2 = 0, chk3 = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        conStr = WebConfigurationManager.ConnectionStrings["fooDBcon"].ConnectionString;
        con = new SqlConnection(conStr);
        userID = null;

        
        try
        {
            userID = Request.QueryString["AccountID"].ToString();
        }
        catch
        {
            //query string is empty//
        }

        myUserID = Session["UserName"].ToString();

        if ((userID != null) && (userID != myUserID))
        {
            //Change the profile view as a stranger is trying to access this profile//
            //call a global function to see what is the relationship with this guy//
            //set the visibilty accordingly to the privacy table//

            //Finding the relationship of the user//
            relationStatus = gObj.relationMap(userID, myUserID);

            loadProfilePic(userID);
            fillName(userID);
            fillStatus(userID);
            hideMenuItems();
            changeLinkToCurrentUserID(userID);
            loadProfileInfo(userID);
        }
        if ((userID == myUserID) || (userID == null))
        {
            loadProfilePic(myUserID);
            fillName(myUserID);
            fillStatus(myUserID);
            loadProfileInfo(myUserID);
        }
    }

    protected void fillName(String usrKey)
    {
        String cmdStr = "Select * from General_Information where UName = '" + usrKey + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();
        rd = scom.ExecuteReader();
        rd.Read();
        litName.Text = rd["UserName"].ToString();

        rd.Close();
        con.Close();
    }

    protected void loadProfilePic(String usrKey)
    {
        imgMain.ImageUrl = gObj.getImageURL(usrKey);

    }

    protected void hideMenuItems()
    {
        LinkButton4.Visible = false;
        LinkButton7.Visible = false;
    }

    protected void changeLinkToCurrentUserID(String usrKey)
    {
        LinkButton1.PostBackUrl = "~/fooProfile.aspx?AccountID=" + usrKey;
        LinkButton2.PostBackUrl = "~/fooFriend.aspx?AccountID=" + usrKey;
        LinkButton3.PostBackUrl = "~/fooPhoto.aspx?AccountID=" + usrKey;
    }

    protected void loadProfileInfo(String usrKey)
    {

        //Generating General Information//
        gen_DOB_Sex_HomeAdd(usrKey);

        if (flg != 0)
        {
            litBasicInfo.Text = sb.Append("</table>").ToString();
        }
        flg = 0;
        //Generating Contact Info//
        gen_Email_PhoneNo_CurrentAdd(usrKey);

        if (flg != 0)
        {
            litContactInfo.Text = sbContactInfo.Append("</table>").ToString();
        }
        flg = 0;
        //Generating Educational Info//
        gen_EducationalInfo(usrKey);
        sbEducationInfo.Append(sbSchool.ToString());
        sbEducationInfo.Append(sbHighSchool.ToString());
        sbEducationInfo.Append(sbCollege.ToString());

        if (flg != 0)
        {
            litEducationalInfo.Text = sbEducationInfo.Append("</table>").ToString();
        }
        flg = 0;
    
    
        //Generate About Me//
        gen_About_Me(usrKey);
        
        //if (flg != 0)
        //{
            litAboutMe.Text = sbAboutMe.Append("</table>").ToString();
            //litFavMovies.Text = sbFavMovies.Append("</td></tr></table>").ToString();
            //litFavTVShows.Text = sbFavTVShows.Append("</td></tr></table>").ToString();
        //}

    }

    protected void gen_DOB_Sex_HomeAdd(String usrKey)
    {
        String cmdStr = "Select * from General_Information where UName = '" + usrKey + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();

        rd = scom.ExecuteReader();
        rd.Read();

        String dob = Convert.ToDateTime(rd["DOB"].ToString()).ToShortDateString();
        String sex = rd["sex"].ToString();
        String homeAdd = rd["FromCity"].ToString();

        rd.Close();
        con.Close();


        cmdStr = "Select * from Privacy where UName = '" + usrKey + "'";
        scom = new SqlCommand(cmdStr, con);

        //sb.Append(cmdStr);
        con.Open();

        rd = scom.ExecuteReader();
        rd.Read();

        String flgdob = "1", flgSex = "1", flgHomeAdd = "1";
        try
        {

            flgdob = rd["DOB"].ToString();
            flgSex = rd["Sex"].ToString();
            flgHomeAdd = rd["FromCity"].ToString();
        }
        catch
        {
            //Do Nothing//
        }
        finally
        {
            rd.Close();
            con.Close();
        }

        sb.Append("<table id = \"basicInfo\">");
        sb.Append("<tr><td><div class=\"divContainerTitle\">Basic Info</div></td></tr>");

        switch (relationStatus)
        {
            case "owner":
                flg++;
                sb.Append("<tr><td><div class=\"divInnerRowHeader\">BirthDay:</div></td><td><div class=\"divInnerCell\">" +
                        dob + "</div></td></tr>");
                sb.Append("<tr><td><div class=\"divInnerRowHeader\">Sex:</div></td><td><div class=\"divInnerCell\">" +
                        sex + "</div></td></tr>");
                sb.Append("<tr><td><div class=\"divInnerRowHeader\">Home Add:</div></td><td><div class=\"divInnerCell\">" +
                        homeAdd + "</div></td></tr>");

                break;

            case "friend":

                if ((flgdob == "2") || (flgdob == "1"))
                {
                    sb.Append("<tr><td><div class=\"divInnerRowHeader\">BirthDay:</div></td><td><div class=\"divInnerCell\">" +
                        dob + "</div></td></tr>");
                    flg++;
                }
                if ((flgSex == "2") || (flgSex == "1"))
                {
                    sb.Append("<tr><td><div class=\"divInnerRowHeader\">Sex:</div></td><td><div class=\"divInnerCell\">" +
                        sex + "</div></td></tr>");
                    flg++;
                }
                if ((flgHomeAdd == "2") || (flgHomeAdd == "1"))
                {
                    sb.Append("<tr><td><div class=\"divInnerRowHeader\">Home Add:</div></td><td><div class=\"divInnerCell\">" +
                        homeAdd + "</div></td></tr>");
                    flg++;
                }
                break;

            case "notfriend":
                if (flgdob == "2")
                {
                    sb.Append("<tr><td><div class=\"divInnerRowHeader\">BirthDay:</div></td><td><div class=\"divInnerCell\">" +
                        dob + "</div></td></tr>");
                    flg++;
                }
                if (flgSex == "2")
                {
                    sb.Append("<tr><td><div class=\"divInnerRowHeader\">Sex:</div></td><td><div class=\"divInnerCell\">" +
                        sex + "</div></td></tr>");
                    flg++;
                }
                if (flgHomeAdd == "2")
                {
                    sb.Append("<tr><td><div class=\"divInnerRowHeader\">Home Add:</div></td><td><div class=\"divInnerCell\">" +
                        homeAdd + "</div></td></tr>");
                    flg++;
                }
                break;
        }


    }
    
    protected void gen_Email_PhoneNo_CurrentAdd(String usrKey)
    {
        String cmdStr = "Select * from General_Information where UName = '" + usrKey + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();

        rd = scom.ExecuteReader();
        rd.Read();

        String email = rd["Email"].ToString();
        String phoneNo = rd["PhoneNo"].ToString();
        String currentCity = rd["CurrentCity"].ToString();

        rd.Close();
        con.Close();

        cmdStr = "Select * from Privacy where UName = '" + usrKey + "'";
        scom = new SqlCommand(cmdStr, con);

        //sb.Append(cmdStr);
        con.Open();

        rd = scom.ExecuteReader();
        rd.Read();

        String flgEmail = "1", flgPhoneNo = "1", flgCurrentCity = "1";

        try
        {
            flgEmail = rd["Email"].ToString();
            flgPhoneNo = rd["PhoneNo"].ToString();
            flgCurrentCity = rd["CurrentCity"].ToString();
        }
        catch
        {
            //Leave It Blank//
        }
        finally
        {
            con.Close();
        }
        
        sbContactInfo.Append("<table id = \"contactInfo\">");
        sbContactInfo.Append("<tr><td><div class=\"divContainerTitle\">Contact Info</div></td></tr>");

        switch (relationStatus)
        {
            case "owner":
                flg++;
                sbContactInfo.Append("<tr><td><div class=\"divInnerRowHeader\">Email:</div></td><td><div class=\"divInnerCell\">" +
                        email + "</div></td></tr>");
                sbContactInfo.Append("<tr><td><div class=\"divInnerRowHeader\">Phone No:</div></td><td><div class=\"divInnerCell\">" +
                        phoneNo + "</div></td></tr>");
                sbContactInfo.Append("<tr><td><div class=\"divInnerRowHeader\">Current Add:</div></td><td><div class=\"divInnerCell\">" +
                        currentCity + "</div></td></tr>");
                break;

            case "friend":

                if ((flgEmail == "2") || (flgEmail == "1"))
                {
                    sbContactInfo.Append("<tr><td><div class=\"divInnerRowHeader\">Email:</div></td><td><div class=\"divInnerCell\">" +
                        email + "</div></td></tr>");
                    flg++;
                }
                if ((flgPhoneNo == "2") || (flgPhoneNo == "1"))
                {
                    sbContactInfo.Append("<tr><td><div class=\"divInnerRowHeader\">Phone No:</div></td><td><div class=\"divInnerCell\">" +
                        phoneNo + "</div></td></tr>");
                    flg++;
                }
                if ((flgCurrentCity == "2") || (flgCurrentCity == "1"))
                {
                    sbContactInfo.Append("<tr><td><div class=\"divInnerRowHeader\">Current Add:</div></td><td><div class=\"divInnerCell\">" +
                        currentCity + "</div></td></tr>");
                    flg++;
                }
                break;

            case "notfriend":
                if (flgEmail == "2")
                {
                    sbContactInfo.Append("<tr><td><div class=\"divInnerRowHeader\">Email:</div></td><td><div class=\"divInnerCell\">" +
                        email + "</div></td></tr>");
                    flg++;
                }
                if (flgPhoneNo == "2")
                {
                    sbContactInfo.Append("<tr><td><div class=\"divInnerRowHeader\">Phone No:</div></td><td><div class=\"divInnerCell\">" +
                        phoneNo + "</div></td></tr>");
                    flg++;
                }
                if (flgCurrentCity == "2")
                {
                    sbContactInfo.Append("<tr><td><div class=\"divInnerRowHeader\">Current Add:</div></td><td><div class=\"divInnerCell\">" +
                        currentCity + "</div></td></tr>");
                    flg++;
                }
                break;
        }
    }
    
    protected void gen_EducationalInfo(String usrKey) 
    {
        String cmdStr = "Select * from Education where UName = '" + usrKey + "'";
        SqlCommand scom = new SqlCommand(cmdStr, con);
        SqlDataReader rd;

        con.Open();
        rd = scom.ExecuteReader();

        SqlConnection tmpCon = new SqlConnection(conStr);
        String tmpCmdStr = "Select * from Privacy where UName = '" + usrKey + "'";
        SqlDataReader tmpRd;
        SqlCommand tmpCom = new SqlCommand(tmpCmdStr, tmpCon);

        tmpCon.Open();
        tmpRd = tmpCom.ExecuteReader();
        tmpRd.Read();

        String flgEduInfo = "1";

        try
        {
            tmpRd["EducationalInfo"].ToString();
        }
        catch
        {

        }
        finally
        {
            tmpRd.Close();
            tmpCon.Close();
        }
 
        
        sbEducationInfo.Append("<table id = \"educationalInfo\">");
        sbEducationInfo.Append("<tr><td><div class=\"divContainerTitle\">Educational Info</div></td></tr>");
        
        sbSchool.Append("<tr><td><div class=\"divInnerRowHeader\">School:</div></td>");
        sbHighSchool.Append("<tr><td><div class=\"divInnerRowHeader\">HighSchool:</div></td>");
        sbCollege.Append("<tr><td><div class=\"divInnerRowHeader\">College:</div></td>");
        
        while (rd.Read())
        {
            switch (rd["category"].ToString())
            {
                case "school":
                    if (relationStatus == "friend")
                    {
                        if ((flgEduInfo == "2") || (flgEduInfo == "1"))
                        {
                            chk1++; genSchoolInfo(rd); flg++;
                        }
                    }
                    else if (relationStatus == "notfriend")
                    {
                        if ((flgEduInfo == "2") || (flgEduInfo == "1"))
                        {
                            chk1++; genSchoolInfo(rd); flg++;
                        }
                    }
                    else
                    {
                        chk1++; genSchoolInfo(rd); flg++;
                    }
                    break;

                case "highschool":
                    if (relationStatus == "friend")
                    {
                        if ((flgEduInfo == "2") || (flgEduInfo == "1"))
                        {
                            chk2++; genHighSchoolInfo(rd); flg++;
                        }
                    }
                    else if (relationStatus == "notfriend")
                    {
                        if ((flgEduInfo == "2") || (flgEduInfo == "1"))
                        {
                            chk2++; genHighSchoolInfo(rd); flg++;
                        }
                    }
                    else
                    {
                        chk2++; genHighSchoolInfo(rd); flg++;
                    }
                    break;

                 case "college":
                    if (relationStatus == "friend")
                    {
                        if ((flgEduInfo == "2") || (flgEduInfo == "1"))
                        {
                            chk3++; genCollegeInfo(rd); flg++;
                        }
                    }
                    else if (relationStatus == "notfriend")
                    {
                        if ((flgEduInfo == "2") || (flgEduInfo == "1"))
                        {
                            chk3++; genCollegeInfo(rd); flg++;
                        }
                    }
                    else
                    {
                        chk3++; genCollegeInfo(rd); flg++; 
                    }
                    break;
            }
        }
        rd.Close();
        con.Close();

    }
          
    protected void genSchoolInfo(SqlDataReader rd)
    {

        DateTime test = Convert.ToDateTime(rd["Batch"].ToString());
        String myDate = test.Year.ToString();
        
        
        if(chk1 == 1)
        {
           sbSchool.Append("<td ><div class=\"divInnerCell\">" +  
           rd["InstitutionName"].ToString() + "&nbsp;-&nbsp;" +
           rd["DegreeTitle"].ToString() + "&nbsp;-&nbsp;" + Convert.ToDateTime(rd["Batch"].ToString()).Year +
           "</div></td></tr>");
        }
        else
        {
           sbSchool.Append("<tr><td></td><td><div class=\"divInnerCell\">" +  
           rd["InstitutionName"].ToString() + "&nbsp;-&nbsp;" +
           rd["DegreeTitle"].ToString() + "&nbsp;-&nbsp;" + Convert.ToDateTime(rd["Batch"].ToString()).Year +
           "</div></td></tr>");
        }
            
    }
        
    protected void genCollegeInfo(SqlDataReader rd)
    {
        if(chk3 == 1)
        {
           sbCollege.Append("<td><div class=\"divInnerCell\">" +  
           rd["InstitutionName"].ToString() + "&nbsp;-&nbsp;" +
           rd["DegreeTitle"].ToString() + "&nbsp;-&nbsp;" + Convert.ToDateTime(rd["Batch"].ToString()).Year +
           "</div></td></tr>");
        }
        else
        {
           sbCollege.Append("<tr><td></td><td><div class=\"divInnerCell\">" +  
           rd["InstitutionName"].ToString() + "&nbsp;-&nbsp;" +
           rd["DegreeTitle"].ToString() + "&nbsp;-&nbsp;" + Convert.ToDateTime(rd["Batch"].ToString()).Year +
           "</div></td></tr>");
        }
            
    }

    protected void genHighSchoolInfo(SqlDataReader rd)
    {
        if (chk2 == 1)
        {
            sbHighSchool.Append("<td><div class=\"divInnerCell\">" +
            rd["InstitutionName"].ToString() + "&nbsp;-&nbsp;" +
            rd["DegreeTitle"].ToString() + "&nbsp;-&nbsp;" + Convert.ToDateTime(rd["Batch"].ToString()).Year +
            "</div></td></tr>");
        }
        else
        {
            sbHighSchool.Append("<tr><td ></td><td><div class=\"divInnerCell\">" +
            rd["InstitutionName"].ToString() + "&nbsp;-&nbsp;" +
            rd["DegreeTitle"].ToString() + "&nbsp;-&nbsp;" + Convert.ToDateTime(rd["Batch"].ToString()).Year +
            "</div></td></tr>");
        }
    }


    protected void gen_About_Me(String usrKey)
    {
        String tmpCmdStr = "Select * From Privacy where UName = '" + usrKey + "'";
        SqlDataReader tmpRd;
        SqlCommand scom = new SqlCommand(tmpCmdStr, con);

        con.Open();
        tmpRd = scom.ExecuteReader();
        tmpRd.Read();

        String flgPrivacy = "1";

        try
        {
            flgPrivacy = tmpRd["AboutMe"].ToString();
        }
        catch
        {

        }
        finally
        {
            tmpRd.Close();
            con.Close();
        }
         
        
        String cmdStr = "Select * from AboutMe where UName = '" + usrKey + "'";
        SqlDataReader rd;
        scom = new SqlCommand(cmdStr, con);       
        
        
        
        sbAboutMe.Append("<table id = \"aboutMeInfo\">");
        sbAboutMe.Append("<tr><td><div class=\"divContainerTitle\">About Me</div></td></tr>");

        con.Open();
        rd = scom.ExecuteReader();
        rd.Read();

        sbAboutMe.Append("<tr><td><div class=\"divInnerRowHeader\">In a Nut Shell</div></td><td>");
        sbAboutMe.Append("<div class=\"divInnerCellAboutMe\">" + rd["AboutMe"].ToString() + "</div></td></tr>");
              
        rd.Close();
        con.Close();


        /*cmdStr = "Select * from Movies where UName = '" + usrKey + "'";
        scom = new SqlCommand(cmdStr, con);

        con.Open();
        rd = scom.ExecuteReader();

        sbFavMovies.Append("<table id = \"aboutMeInfo\">");
        sbFavMovies.Append("<tr><td><div class=\"divInnerRowHeader\">Fav Movies</div></td><td>");
        
        while (rd.Read())
        {
            sbFavMovies.Append("<div class=\"divInnerCell\">" + rd["MovieName"].ToString().Trim() + "</div>");
        }
        rd.Close();
        con.Close();


        cmdStr = "Select * from TVShows where UName = '" + usrKey + "'";
        scom = new SqlCommand(cmdStr, con);

        con.Open();
        rd = scom.ExecuteReader();

        sbFavTVShows.Append("<table id = \"aboutMeInfo\">");
        sbFavTVShows.Append("<tr><td><div class=\"divInnerRowHeader\">Fav TV Shows</div></td><td>");

        while (rd.Read())
        {
            sbFavTVShows.Append("<div class=\"divInnerCell\">" + rd["TVShowName"].ToString().Trim() + "</div>");
        }
        rd.Close();
        con.Close();*/

    }

    
    /***New Additions***/

    protected void fillStatus(String usr)
    {
        String cmdStr = "Select * from AboutMe where UName = '" + usr + "'";
        SqlDataReader rd;
        SqlCommand scom = new SqlCommand(cmdStr, con);
              
        con.Open();
        rd = scom.ExecuteReader();

        rd.Read();
        try
        {
            litStatus.Text = rd["MyStatus"].ToString();
        }
        catch
        {
            //Leave the Field Blank//
        }
        finally
        {
            rd.Close();
            con.Close();
        }
    }



}