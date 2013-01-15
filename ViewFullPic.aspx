<%@ Page Language="C#" MasterPageFile="~/MasterPage.master"  MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeFile="ViewFullPic.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
        window.onload = function init()
        {
            var imgMain = document.getElementById("ctl00_ContentPlaceHolder2_imgMain");
            var num = imgMain.clientHeight;
            num = num + 170;
            document.getElementById("divLeftMenu").style.top = num + "px";
        }     
        
        function raiseAsyncPostback(src)
        {
            var myVal = document.getElementById("<%= text.ClientID %>");
            myVal.value = src;           
            __doPostBack('<%= this.lnkButTrigger.UniqueID %>', '');
        }
    </script>
    
    <div id="divPhotoHeader" style="position: absolute; top: 88px; left: 0px ";>
        <asp:Image ID="Image1" ImageUrl="~/images/infoPhoto.jpg" Height="23px" Width="841px" runat="server" />
    </div> <br />
    
    <asp:ScriptManager ID ="scriptManger2" runat = "server" />
    
    <asp:UpdatePanel ID = "updatePanel2" runat = "server">
        <Triggers> 
            <asp:AsyncPostBackTrigger ControlID="lnkButTrigger" />
        </Triggers>       
        
        <ContentTemplate>
            
            <div style="position:absolute; top:130px; left:0px; margin-left:130px">
                <asp:Image ID="imgFull" runat="server"  ImageAlign="Middle" width = "700" Height = "480"/>
            </div>  
            
        </ContentTemplate>
    
    </asp:UpdatePanel>
    
    <asp:LinkButton ID="lnkButTrigger" runat="server" OnClick="magicButton_Click" style="display:none"></asp:LinkButton>
          
    <div id="lvFullPic" style="background-color: White; border-color:Black;border-width:1px;border-style:hidden;height:500px;width:110px; font-size: 11px; padding: 4px 4px 4px 4px; position:absolute; overflow:auto; top:130px; left:0px">
        <asp:ListView ID="lvViewFullPic" runat="server" >
            <LayoutTemplate>
                <div class ="menu">
                <ul>
                  <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </ul>
                </div>
            </LayoutTemplate>
        
            <ItemTemplate>
              <li style="float:left; padding-left:10px  ">
                           
                 <asp:Literal ID = "litImageName" Visible="false" text='<%#Eval("PicTitle") %>' runat="server"></asp:Literal>                
                 <img width = "80px" height="60px" onclick="raiseAsyncPostback('fooPicDB/<%#Eval("UName") %>/<%#Eval("AlbumFolder_PK") %>/<%#Eval("PicTitle") %>')" alt="" src="fooPicDB/<%#Eval("UName") %>/<%#Eval("AlbumFolder_PK") %>/<%#Eval("PicTitle") %>" /> <br />
                 
              </li>
            </ItemTemplate>
    
            <EmptyDataTemplate>The Folder Is Empty!!!</EmptyDataTemplate>
        </asp:ListView>
     </div>
    
    <asp:TextBox ID="text" runat="server" style="display:none;"></asp:TextBox>
    
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



