<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChatPanelItem.ascx.cs" Inherits="Controls_ChatPanelItem" %>




<style type="text/css">
    .style1
    {
        height: 23px;
    }
    .style2
    {
        height: 23px;
        width: 48px;
    }
    .style3
    {
        height: 23px;
        width: 176px;
    }
</style>
<table style="height: 49px;">
    <tr>
        <td class="style2">
            <asp:Image ID="Image1" runat="server" Height="43px" style="margin-left: 0px" 
                Width="47px" />
        </td>
        <td class="style3">
            <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="style1">
            <asp:Image ID="Image2" runat="server" Height="28px" 
                ImageUrl="~/images/onLine.png" style="margin-left: 0px" Width="28px" />
        </td>
    </tr>
</table>
