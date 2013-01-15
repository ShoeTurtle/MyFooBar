<%@ Control Language="C#" AutoEventWireup="true" CodeFile="mobileVarification.ascx.cs" Inherits="Controls_mobileVarification" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<style type="text/css">
    .style1
    {
        width: 153px;
    }
    .style2
    {
        width: 384px;
    }
</style>
<table style="width: 71%; height: 87px;">
    <tr>
        <td class="style1">
            <asp:Label ID="Label1" runat="server" Text="Enter Your Mobile No :"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="txtMobileNo" runat="server" BorderStyle="Solid" Height="22px" 
                Width="342px"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="txtMobileNo_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txtMobileNo" 
                WatermarkText="Enter Your 10 digit Mobile Number">
            </asp:TextBoxWatermarkExtender>
            <asp:MaskedEditExtender ID="txtMobileNo_MaskedEditExtender" runat="server" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="9999999999" TargetControlID="txtMobileNo">
            </asp:MaskedEditExtender>
            <asp:Button ID="btnSend" runat="server" BorderStyle="None" 
                onclick="btnSend_Click" Text="Send" />
        </td>
        <td>
            <asp:Label ID="lblStatus" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
        <td class="style1">
            <asp:Label ID="Label2" runat="server" Text="Enter Varification Code : "></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="txtVerifyCode" runat="server" BorderStyle="Solid" 
                Height="22px" Width="226px"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="txtVerifyCode_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txtVerifyCode" 
                WatermarkText="Enter Verification code">
            </asp:TextBoxWatermarkExtender>
            <asp:Button ID="btnVerify" runat="server" BorderStyle="None" 
                onclick="btnVerify_Click" Text="Verify" />
        </td>
        <td>
            &nbsp;</td>
    </tr>
</table>
