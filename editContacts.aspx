<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="editContacts.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div id="divMidTop" 
        style="border: thin solid #808080; height: 76px; position: absolute; left: 111px; top: 79px; width: 618px;">
            <br />
            <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                Width="541px" Font-Names="Lucida Sans" Height="40px"></asp:Label>
      </div>
      
      <div id="divBasicInfo"        
        style="position:absolute; border: thin solid #808080; top: 155px; left: 111px; width: 618px; height: 424px; overflow:auto;">
                 <br /><asp:Label ID="lblError" runat="server" Text="Label" Visible="False" 
                     Width="400px"></asp:Label>
                 <table style="width: 100%; height: 231px;">
                     <tr>
                         <td align="left" style="height: 40px; padding-left:45px;">
                             <asp:Label ID="lblCurrentCity" runat="server" Text="Current City:" Width="130px" 
                                 Font-Bold="True" Font-Names="Lucida Sans"></asp:Label>
                         </td>
                         <td style="height: 40px; padding-right:40px; margin-left: 40px;">
                             <asp:TextBox ID="txtCurrentCity" runat="server" Width="300px"></asp:TextBox>
                         </td>
                         
                     </tr>
                     <tr>
                         <td align="left" style="height: 40px; padding-left:45px;">
                             <asp:Label ID="lblHomeTown" runat="server" Text="Home Town:" Width="120px" 
                                 Font-Bold="True" Font-Names="Lucida Sans"></asp:Label>
                         </td>
                         <td style="height: 40px; padding-right:40px;">
                              <asp:TextBox ID="txtHomeTown" runat="server" Width="300px"></asp:TextBox>
                         </td>
                         
                     </tr>
                     <tr>
                         <td align="left" style="height: 40px; padding-left:45px;">
                             <asp:Label ID="lblPhone" runat="server" Text="Phone No:" Width="120px" 
                                 Font-Bold="True" Font-Names="Lucida Sans"></asp:Label>
                         </td>
                         <td style="height: 40px; padding-right:40px;">
                             <asp:TextBox ID="txtPhone" runat="server" Width="300px"></asp:TextBox>
                         </td>
                         
                     </tr>
                     <tr>
                        <td align="left" style="height: 40px; padding-left:45px;">
                            <asp:Label ID="lblEmail" runat="server" Text="Email:" Width="120px" 
                                Font-Bold="True" Font-Names="Lucida Sans"></asp:Label>
                        </td>
                        
                        <td style="height: 40px; padding-right:40px;">
                            <asp:TextBox ID="txtEmail" runat="server" Width="300px"></asp:TextBox>
                                <br />
                                <asp:RegularExpressionValidator id="regEmail" ControlToValidate="txtEmail" 
                                    Text="(Invalid email)" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                                    Runat="server" /> 
                        </td>
                     </tr>
                    
                    </table>
                    
                    <br />         
                    <asp:Button ID="Button1" runat="server" Text="Save Changes" onclick="cmdSave_Click" />
                <br />
                <br />
        </div>     
     
     </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

