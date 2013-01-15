<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewAlbum.aspx.cs" Inherits="_Default" Title="Untitled Page" MaintainScrollPositionOnPostback = "true"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script id = "testScript" type="text/javascript">
        window.onload = function init()
        {
            var imgMain = document.getElementById("ctl00_ContentPlaceHolder2_imgMain");
            var num = imgMain.clientHeight;
            num = num + 170;
            document.getElementById("divLeftMenu").style.top = num + "px";           
        } 
        
        function LoadDiv(pic, album, url, usrKey) 
        {
           window.location = "ViewFullPic.aspx?pic=" + pic + "&album=" + album + "&url=" + url + "&AccountID=" + usrKey;
        }
    </script>
    
    <div id="divPhotoHeader" style="position: absolute; top: 88px; left: 0px ";>
        <asp:Image ID="Image1" ImageUrl="~/images/infoPhoto.jpg" Height="23px" Width="841px" runat="server" />
            <asp:Label ID="Label1" runat="server"></asp:Label>
   
        <asp:ListView ID="lvGallery" runat="server" OnItemDataBound="lvAlbum_ItemDataBound">
        
            <LayoutTemplate>
               <ul class="albumList">
                  <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
              </ul>
            </LayoutTemplate>
        
            <ItemTemplate>
              <li class="albumList">
                           
                 <asp:Literal ID = "litImageName" Visible="false" text='<%#Eval("PicTitle") %>' runat="server"></asp:Literal>                
                 <img width = "160px" height="120px" onclick="LoadDiv('<%#Eval("PicTitle") %>', '<%#Eval("AlbumFolder_PK") %>', 'fooPicDB/<%#Eval("UName") %>/<%#Eval("AlbumFolder_PK") %>/<%#Eval("PicTitle") %>', '<%#Eval("UName") %>')" alt="" src="fooPicDB/<%#Eval("UName") %>/<%#Eval("AlbumFolder_PK") %>/<%#Eval("PicTitle") %>" /> <br />
                 
              </li>
            </ItemTemplate>
    
            <EmptyDataTemplate>The Folder Is Empty!!!</EmptyDataTemplate>
        </asp:ListView>
    </div>
   
  
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">                                   
    <asp:Image ID="imgMain" runat="server" style="margin-top: 30px" /><br />                        
</asp:Content>


<asp:Content ID="Content3" runat="server" 
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
                        <asp:LinkButton ID="LinkButton7" runat="server" CssClass="sideMenuMain"
                            PostBackUrl="~/fooChat.aspx">ChatRoom</asp:LinkButton>
                                          
                         <br />
                    

</asp:Content>



<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder4">

</asp:Content>




