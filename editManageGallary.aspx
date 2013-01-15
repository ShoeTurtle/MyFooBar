<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="editManageGallary.aspx.cs" Inherits="_Default" Title="Untitled Page" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
        <div id="divMidTop" 
            style="border: thin solid #808080; height: 76px; position: absolute; left: 111px; top: 79px; width: 618px;">
                <br />
                <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                    Width="541px" Font-Names="Lucida Sans" Height="40px"></asp:Label>
        </div>   
     
     <div id="divManageGallary" style="position:absolute; border: thin solid #808080; top: 155px; left: 111px; 
         width: 618px; height: 424px; overflow:auto;">
         <p align="center">
             <asp:Button ID="butUpdate" runat="server" Text="Update Album" 
                 style="margin-right:25px;" onclick="butUpdate_Click"/>             
                          
             <asp:Button ID="butNewAlbum" runat="server" Text="Create Album" 
                 style="margin-left:25px;" onclick="butNewAlbum_Click"/>
         </p>         
         
         <asp:Panel ID="pnlGallaryMain" runat="server">
             
                <asp:ListView ID="lvAlbums" runat="server" OnItemDataBound="lbAlbums_ItemDataBound">
                    <LayoutTemplate>
                        <ul class="albumListManage">
                            <asp:PlaceHolder ID="itemPlaceHolder"  runat="server"> </asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
            
                    <ItemTemplate>
                            <li class="albumListManage">
                            <img  width="160" height="120" id="albumCover" alt="" src='fooPicDB/<%#Eval("UName") %>/<%#Eval("AlbumFolder_PK") %>/<%#Eval("AlbumCover") %>' /> <br />
                            
                            <b><%#Eval("AlbumName") %></b><br/>
                            
                            <asp:LinkButton ID="linkUpdateAlbum" OnClick="linkUpdateAlbum_Click"  runat="server" CssClass="editLnkButton">UPDATE</asp:LinkButton>                          
                            
                            <asp:LinkButton ID="linkDeleteAlbum" OnClick="linkDeleteAlbum_Click" runat="server"  CssClass="editLnkButton">REMOVE</asp:LinkButton>
                            <br />
                            
                            <asp:Literal Visible="false" ID="litFolderID" 
                                Text = '<%#Eval("AlbumFolder_PK") %>' runat="server"></asp:Literal>
                            <asp:Literal Visible="false" ID="litUsrKey"
                                Text = '<%#Eval("UName") %>' runat="server"></asp:Literal>
                            </li>
                            
                    </ItemTemplate>
            
                    <EmptyDataTemplate>You Do Not Have Any Data To Display</EmptyDataTemplate>        
            </asp:ListView>
            
            
        </asp:Panel>
         
        <asp:Panel ID="pnlAlbumPicture" runat="server">
                
            <asp:HiddenField ID="hidPicNameUpdateAlbum" runat="server" />
            <asp:HiddenField ID="hidAlbumIDUpdateAlbum" runat="server" />
                <table width="100%">
                     <tr>
                        <td align="left" style="height: 40px; padding-left:20px;">
                             <asp:Label ID="lblUpdateAlbumName" runat="server" Text="Album Name:" Width="130px" 
                                 Font-Bold="True" Font-Names="Lucida Sans"></asp:Label>
                         </td>
                         <td style="height: 40px; padding-right:20px;" align="left">
                             <asp:TextBox ID="txtUpdateAlbumName" runat="server" Width="250px"></asp:TextBox>
                         </td>                  
                        <td align="left">
                            <asp:LinkButton ID="lnkUpdateAlbumName" runat="server" Font-Underline="False" 
                                style="margin-left:0px;" ForeColor="#006666" Font-Names="Tahoma" 
                                Font-Size="Small" OnClick="lnkUpdateAlbumName_OnClick">UPDATE ALBUM NAME</asp:LinkButton>                        
                        </td>                        
                    </tr>
                    <tr>
                         <td align="left" style="height: 40px; padding-left:45px;" colspan="2">
                                <asp:FileUpload ID="FileUploadAlbumPicture" runat="server" Width="219px" />
                         </td>       
                         <td style="height: 40px; padding-right:40px;" align="right">
                                <asp:Button runat="server" id="Button1" text="Upload" 
                                                onclick="UploadButtonAlbumPicture_Click" Height="25px" Width="89px" />
                             <asp:Button ID="butGoBack" runat="server" Text="Go Back" Height="25px" Width="89px" onclick="butGoBack_Click"/>
                         </td>
                    </tr>
                    <tr >
                        <td colspan="1">                       
                                <asp:Label runat="server" id="lblStatus" Visible="false"/>
                        </td>
                    </tr>
                </table>
                    
                <asp:ListView ID="lvGallery" runat="server" OnItemDataBound="lvAlbum_ItemDataBound">
                    <LayoutTemplate>
                       <ul class="albumListManage">
                          <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                      </ul>
                    </LayoutTemplate>
                
                    <ItemTemplate>
                      <li class="albumListManage">                                   
                         <asp:Literal ID = "litImageName" Visible="false" text='<%#Eval("PicTitle") %>' runat="server"></asp:Literal>                
                         <asp:Literal ID = "litFolderID" Visible = "false" text='<%#Eval("AlbumFolder_PK") %>' runat="server"></asp:Literal>
                         
                         <img width = "160px" height="120px" alt="" src="fooPicDB/<%#Eval("UName") %>/<%#Eval("AlbumFolder_PK") %>/<%#Eval("PicTitle") %>" /> <br />
                         <asp:LinkButton ID="linkDeletePicture" OnClick="linkDeletePicture_Click" runat="server"  CssClass="editLnkButton">REMOVE</asp:LinkButton>
                         
                      </li>
                    </ItemTemplate>
            
                    <EmptyDataTemplate>The Folder Is Empty!!!</EmptyDataTemplate>
                </asp:ListView>
        
        </asp:Panel>
        
        <asp:Panel ID="pnlNewAlbum" runat="server">
            
            <asp:HiddenField ID="hidPicName" runat="server" />
            <asp:HiddenField ID="hidAlbumID" runat="server" />
            <table width="100%">
                     <tr>
                        <td align="left" style="height: 40px; padding-left:20px;">
                             <asp:Label ID="lblAlbumName" runat="server" Text="Album Name:" Width="130px" 
                                 Font-Bold="True" Font-Names="Lucida Sans"></asp:Label>
                         </td>
                         <td style="height: 40px; padding-right:20px;" align="left">
                             <asp:TextBox ID="txtAlbumName" runat="server" Width="250px"></asp:TextBox>
                         </td>                  
                        <td align="left">
                            <asp:LinkButton ID="LinkButton1" runat="server" Font-Underline="False" 
                                style="margin-left:0px;" ForeColor="#006666" Font-Names="Tahoma" 
                                Font-Size="Small" Visible="false">UPDATE ALBUM NAME</asp:LinkButton>                        
                        </td>                        
                    </tr>
                    <tr>
                         <td align="left" style="height: 40px; padding-left:45px;" colspan="2">
                                <asp:FileUpload ID="FileUploadProfilePic" runat="server" Width="219px" />
                         </td>       
                         <td style="height: 40px; padding-right:40px;" align="right">
                                <asp:Button runat="server" id="UploadButton" text="Upload" 
                                                onclick="UploadButton_Click" Height="25px" Width="89px" />
                             <asp:Button ID="butGoBackUpload" runat="server" Text="Go Back" Height="25px" Width="89px" onclick="butGoBackToPictureView_Click"/>
                         </td>
                    </tr>
                    <tr >
                        <td colspan="1">                       
                                <asp:Label runat="server" id="StatusLabel" Visible="false"/>
                        </td>
                    </tr>
                </table>
        </asp:Panel>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>


