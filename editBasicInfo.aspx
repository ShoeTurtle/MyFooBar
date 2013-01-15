<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="editBasicInfo.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divMidTop" 
        style="border: thin solid #808080; height: 76px; position: absolute; left: 111px; top: 79px; width: 618px;">
            <br />
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                Width="541px" Font-Names="Lucida Sans" Height="40px"></asp:Label>
    </div>
     
    <div id="divBasicInfo"        
        
        
        style="position:absolute; border: thin solid #808080; top: 155px; left: 111px; width: 618px; height: 424px; overflow:auto;">
                 <asp:Label ID="lblErrorInsert" runat="server" Width="400px"></asp:Label>
                 <br />
                 
                 <table style="width: 100%; height: 379px;">
                     <tr>
                         <td align="left" style="height: 40px; padding-left:45px;">
                             <asp:Label ID="lblFirstName" runat="server" Text="First Name:" Width="130px" 
                                 Font-Bold="True" Font-Names="Lucida Sans"></asp:Label>
                         </td>
                         <td style="height: 40px; padding-right:40px;">
                             <asp:TextBox ID="txtFirstName" runat="server" Width="300px"></asp:TextBox>
                         </td>
                         
                     </tr>
                     <tr>
                         <td align="left" style="height: 40px; padding-left:45px;">
                             <asp:Label ID="lblLastName" runat="server" Text="Last Name:" Width="120px" 
                                 Font-Bold="True" Font-Names="Lucida Sans"></asp:Label>
                         </td>
                         <td style="height: 40px; padding-right:40px;">
                              <asp:TextBox ID="txtLastName" runat="server" Width="300px"></asp:TextBox>
                         </td>
                         
                     </tr>
                     <tr>
                         <td align="left" style="height: 40px; padding-left:45px;">
                             <asp:Label ID="lblSex" runat="server" Text="I Am:" Width="120px" 
                                 Font-Bold="True" Font-Names="Lucida Sans"></asp:Label>
                         </td>
                         <td style="height: 40px; padding-right:40px;">
                             <asp:DropDownList ID="DDSex" runat="server" Width="70px">
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                             </asp:DropDownList>
                         </td>
                         
                     </tr>
                     <tr>
                        <td align="left" style="height: 40px; padding-left:45px;">
                            <asp:Label ID="lblBirthDay" runat="server" Text="Birth Day:" Width="120px" 
                                Font-Bold="True" Font-Names="Lucida Sans"></asp:Label>
                        </td>
                        
                        <td style="height: 40px">
                        <asp:TextBox ID="txtDob" runat="server" BorderStyle="Solid"></asp:TextBox>
                            <asp:CalendarExtender ID="txtDob_CalendarExtender" runat="server" 
                                Enabled="True" TargetControlID="txtDob">
                            </asp:CalendarExtender>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" 
                            ControlToValidate="txtDob" ErrorMessage="Invalid date"></asp:RangeValidator>
                        
                        </td>
                     </tr>
                    
                    <tr>
                        <td align="left" style="height: 70px; padding-left:45px;">
                            <asp:Label ID="lblAbout" runat="server" Text="About Me:" Font-Bold="True" 
                                Font-Names="Lucida Sans" Width="120px"></asp:Label>
                        </td> 
                        <td style="height: 70px; padding-right:40px;">
                            <asp:TextBox ID="txtAbt" runat="server" Height="65px" Width="300px" 
                                MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    
                    <tr>
                        <td align="left" style="height: 70px; padding-left:45px;">
                            <asp:Label ID="lblStatus" runat="server" Text="My Status:" Font-Bold="True" 
                                Font-Names="Lucida Sans" Width="120px"></asp:Label>
                        </td>
                        <td style="height: 70px; padding-right:40px;">
                            <asp:TextBox ID="txtMyStatus" runat="server" Height="65px" Width="300px" 
                                MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    
                    </tr>
                 
                 </table>
         
            <asp:Button ID="cmdSave" runat="server" Text="Save Changes" onclick="cmdSave_Click" />
                <br />
                <br />
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

