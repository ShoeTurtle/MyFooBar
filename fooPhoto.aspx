 <%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="fooPhoto.aspx.cs" Inherits="_Default" Title="Untitled Page"  MaintainScrollPositionOnPostback="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript" language="javascript">
        
        window.onload = function init()
        {
            var imgMain = document.getElementById("ctl00_ContentPlaceHolder2_imgMain");
            var num = imgMain.clientHeight;
            num = num + 170;
            document.getElementById("divLeftMenu").style.top = num + "px";           
        
            //Get The Value Of the Query String//
        
        } 
        
     </script> 
    
    
    
    <div id="divPhotoHeader" style="position: absolute; top: 88px; left: 3px;">
    
    <asp:Image ID="Image1" ImageUrl="~/images/infoPhoto.jpg" Height="23px" Width="841px" runat="server" />
          
        <asp:ListView ID="lvAlbums" runat="server" OnItemDataBound="lbAlbums_ItemDataBound">
            <LayoutTemplate>
                <ul class="albumList">
                    <asp:PlaceHolder ID="itemPlaceHolder"  runat="server"> </asp:PlaceHolder>
                </ul>
            </LayoutTemplate>
            
            <ItemTemplate>
                    <li class="albumList">
                    <img  width="160" height="120" id="albumCover" alt="" src='fooPicDB/<%#Eval("UName") %>/<%#Eval("AlbumFolder_PK") %>/<%#Eval("AlbumCover") %>' /> <br />
                    
                    <b><%#Eval("AlbumName") %></b><br/>
                    
                    <asp:HyperLink CssClass="editLnkButton" 
                            ID="linkViewAlbum" NavigateUrl="~/ViewAlbum.aspx"  Text="View" runat="server"></asp:HyperLink>
                    
                    <asp:Literal Visible="false" ID="litFolderID" 
                        Text = '<%#Eval("AlbumFolder_PK") %>' runat="server"></asp:Literal>
                    <asp:Literal Visible="false" ID="litUsrKey"
                        Text = '<%#Eval("UName") %>' runat="server"></asp:Literal>
                                       
                    </li>             
                    
            </ItemTemplate>
            
            <EmptyDataTemplate>You Do Not Have Any Data To Display</EmptyDataTemplate>        
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



 <asp:Content ID="Content4" runat="server" 
     contentplaceholderid="ContentPlaceHolder4">

            
 </asp:Content>




