<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="fooFriend.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<script type="text/javascript" language="javascript">
        window.onload = function init()
        {
            var imgMain = document.getElementById("ctl00_ContentPlaceHolder2_imgMain");
            var num = imgMain.clientHeight;
            num = num + 170;
            document.getElementById("divLeftMenu").style.top = num + "px";
            
            var litFlg = document.getElementById("ctl00_ContentPlaceHolder1_litFlg");
            
        }     
    
    </script>
    
    <div id="divFriendHeader" style="position: absolute; top: 88px; left: 3px ";>
        <asp:Image ID="Image1" ImageUrl="~/images/infoFriends.jpg"  Height="23px" Width="841px" runat="server" />
    </div>

    <!-- Here Goes the Script to Populate Friends -->
    
    <div style="position:absolute; top: 200px; left: 150px; width: 485px;">
        <asp:Repeater ID="repFriendList" runat="server" OnItemDataBound="repFriendList_ItemDataBound">
                <ItemTemplate>      
                    <asp:Literal ID="litFriendID" Visible="false" runat="server" Text='<%#Eval("UName") %>'></asp:Literal>
                    <table style="width: 500px;">
                        <tr>
                            <td align="left">
                                 <a href= 'fooProfile.aspx?AccountID=<%#Eval("UName") %>'>
                                        <img alt="" src='fooPicDB/<%#Eval("UName") %>/Profile/<%#Eval("ProfilePic") %>'  style="height:100px; width:80px; padding:3px;"/>
                                 </a>                
                                
                            </td>
                            <td align="left" style="width:300px; padding-left:15px;">
                                <asp:Label ID="lblFullName" runat="server" Text='<%#Eval("UserName") %>' style=" font-size:20px; font-family:Comic Sans MS; color:#3B5998; font-weight:normal; height:20px; padding-left:15px;"></asp:Label><br />
                                <asp:Label ID="lblFromCity" runat="server" Text='<%#Eval("CurrentCity") %>' style="height:15px; font-size:17px; color:Gray; padding-left:15px;"></asp:Label>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="lnkUnfriend" onclick="lnkUnfriend_Click" runat="server" Font-Underline="False" style="margin-left:1px;" ForeColor="#006666" Font-Names="Tahoma" Font-Size="Small">UN-FRIEND</asp:LinkButton>
                            </td>
                        </tr>
                    </table><br /><br />
                </ItemTemplate>       
            </asp:Repeater>
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>        
        
   </div>


</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
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



