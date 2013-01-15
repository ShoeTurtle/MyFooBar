<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MyGallary.ascx.cs" Inherits="UserControls_MyGallary" %>
<style type="text/css">
    .style1
    {
        height: 66px;
        
    }
    .style2
    {
        height: 44px;
    }
    .style3
    {
        height: 55px;
    }
</style>
<table style="width: 20%;">
    <tr>
        <td class="style1" align="center">
            <asp:Image ID="imgThumbNail" runat="server" Width = "160px" Height="120px" />
        </td>
    </tr>
    <tr>
        <td class="style2" align="center"> 
            <asp:Label ID="lblTitle" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style3" align="center">
            <asp:LinkButton ID="lnkRemove" runat="server">Remove</asp:LinkButton>
        </td>
    </tr>
</table>
