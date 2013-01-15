<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="fooProfile.aspx.cs" Inherits="_Default" Title="Untitled Page"  MaintainScrollPositionOnPostback="true"%>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript">
            window.onload = function init()
            {
                var myVal = document.getElementById("ctl00_ContentPlaceHolder2_imgMain");
                var num = myVal.clientHeight;
                num = num + 170;                              
                document.getElementById("divLeftMenu").style.top = num + "px";                    
                
                var divBasicInfo = document.getElementById("divBasicInfo");
                var divContactInfo = document.getElementById("divContactInfo");
                var divEducationalInfo = document.getElementById("divEducationalInfo");
                var divAboutMe = document.getElementById("divAboutMe");
                
                var basicInfo = document.getElementById("basicInfo");
                var contactInfo = document.getElementById("contactInfo");
                var educationalInfo = document.getElementById("educationalInfo");
                var aboutMeInfo = document.getElementById("aboutMeInfo");
                
                var Spacing = 80;
                                
                if(!basicInfo)
                {
                    divContactInfo.style.left = "30px";
                }                
                
                if(!contactInfo)
                {
                    //Upper Section is Missing//
                }
                else
                {
                    Spacing = Spacing + divContactInfo.clientHeight + 30;
                }                
                
                if(!educationalInfo)
                {
                    //Education Block Missing//
                }
                else
                {
                    divEducationalInfo.style.top = Spacing + "px";                
                    Spacing = Spacing + divEducationalInfo.clientHeight;
                } 
                
                divAboutMe.style.top = Spacing + 30 + "px";
            }
                
        </script>
        
    <div id="divProfile" style="top:88px; left:3px; position:absolute;">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/infoProfile.jpg"  Height="23px"
            Width="841px"/>
        
    </div>    
    
    <asp:Panel ID="pnlName" style="position:absolute; top:120px; left:20px" runat="server">
        <div style="font-size:28px; color:#3B5998; text-align:center; margin-left:0px;
              font-family:Lucida Sans; font-weight:bold; color:#3B5998;" onclick="init()"><asp:Literal ID="litName"
                runat="server"></asp:Literal></div>          
    </asp:Panel>
    
    <asp:Panel ID="pnlStatus" style="top:170px; left:70px; position:absolute" runat="server">
        <div style="font-size:15px; color:#3B5998; text-align:center; margin-left:0px; width:700px;
              font-family:Lucida Sans; font-weight:bold; color:#3B5998;">
            <asp:Literal ID="litStatus" runat="server"></asp:Literal>
        
        </div>
    </asp:Panel>
    
    <div id="contentWrapper" style="position:relative; top:150px; left:0px; float:left; width:100%; display:block;">
    
        <div id="divBasicInfo" style="position:absolute; top:80px; left:30px;">
            <asp:Literal ID="litBasicInfo" runat="server"></asp:Literal>
        </div>     

        <div id="divContactInfo" style="position:absolute; top:80px; left:400px;">
            <asp:Literal ID="litContactInfo" runat="server"></asp:Literal>
        </div>      


        <div id="divEducationalInfo" style="position:absolute; top:250px; left:30px;">
            <asp:Literal ID="litEducationalInfo" runat="server"></asp:Literal>
        </div>     

        <div id="divAboutMe" style="position:absolute; top:460px; left:30px;">
            <asp:Literal ID="litAboutMe" runat="server"></asp:Literal>
        </div>    
    
        <div id="divFavMovies" style="position:absolute; top:700px; left:30px">
            <asp:Literal ID="litFavMovies" runat="server"></asp:Literal>
        </div>
   
        <div id="divFavTVShows" style="position:absolute; top:910px; left:30px">
            <asp:Literal ID="litFavTVShows" runat="server"></asp:Literal>
        </div>
   
        <div id="divEnd" style="position:absolute; top:1200px; left:30px;">
            <asp:Literal ID="litEnd" runat="server">.</asp:Literal>
        </div>    
    </div>   

</asp:Content>



<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
    <asp:Image ID="imgMain" runat="server" style="margin-top:30px;" />
    <br />
</asp:Content>


<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder4">
</asp:Content>

<asp:Content ID="Content5" runat="server" 
    contentplaceholderid="ContentPlaceHolder3">
                    
                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="sideMenuMain"
                            PostBackUrl="~/fooProfile.aspx" >Profile</asp:LinkButton>
                  
                         <br />
                         <asp:LinkButton ID="LinkButton2" runat="server" CssClass="sideMenuMain"
                             PostBackUrl="~/fooFriend.aspx">Friends</asp:LinkButton>
                        
                         <br />
                        <asp:LinkButton ID="LinkButton3" runat="server" CssClass="sideMenuMain"
                            PostBackUrl="~/fooPhoto.aspx">Photos</asp:LinkButton>
                   
                  
                         <br />
                        <asp:LinkButton ID="LinkButton4" runat="server" CssClass="sideMenuMain"> 
                            Messages</asp:LinkButton>
                            
                         <br />
                        <asp:LinkButton ID="LinkButton7" runat="server"  
                            PostBackUrl="~/fooChat.aspx" CssClass="sideMenuMain">ChatRoom</asp:LinkButton>
                         <br />
                   
                    

</asp:Content>





