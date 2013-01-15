<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="Controls_WebUserControl" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<style type="text/css">

    .Watermark
   {
   	    font-style:italic;
   	    color:Gray;
   	   
   	}
    .style1
    {
        width: 223px;
    }
    .style2
    {
        height: 20px;
    }
    .style6
    {}
    .style8
    {
    }
    .style10
    {
        height: 20px;
        width: 72px;
    }
    .style11
    {
        height: 20px;
        width: 162px;
    }
    .style12
    {
        width: 624px;
    }
    .style13
    {
        height: 20px;
        width: 214px;
    }
</style>


<div>
    <asp:Login ID="Login1" runat="server" Height="42px" 
        onauthenticate="Login1_Authenticate" Width="425px" ForeColor="White">
        <LayoutTemplate>
            <table border="0" cellpadding="1" cellspacing="0" 
                style="border-collapse: collapse; width: 603px;">
                <tr>
                    <td class="style12">
                        <table border="0" cellpadding="0" style="width: 618px">
                            <tr>
                                <td align="right" class="style13" style="vertical-align: top">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName" 
                                        Text="UserName" ForeColor="White"></asp:Label>
                                </td>
                                <td class="style11" style="vertical-align: top">
                                    <asp:TextBox ID="UserName" runat="server" BorderStyle="Solid"></asp:TextBox>
                                    <asp:TextBoxWatermarkExtender ID="UserName_TextBoxWatermarkExtender" 
                                        runat="server" Enabled="True" TargetControlID="UserName" 
                                        WatermarkCssClass="Watermark" WatermarkText="User Name">
                                    </asp:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                        ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                        ToolTip="User Name is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="style10" style="vertical-align: top">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password" 
                                        ForeColor="White">Password:</asp:Label>
                                </td>
                                <td class="style2" style="vertical-align: top">
                                    <asp:TextBox ID="Password" runat="server" BorderStyle="Solid" 
                                        ontextchanged="Password_TextChanged" TextMode="Password"></asp:TextBox>
                                    <asp:TextBoxWatermarkExtender ID="Password_TextBoxWatermarkExtender" 
                                        runat="server" Enabled="True" TargetControlID="Password" 
                                        WatermarkCssClass="Watermark" WatermarkText="**********">
                                    </asp:TextBoxWatermarkExtender>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                        ControlToValidate="Password" ErrorMessage="Password is required." 
                                        ToolTip="Password is required." ValidationGroup="ctl00$Login1">*</asp:RequiredFieldValidator>
                                </td>
                                <td class="style2" style="vertical-align: top">
                                    <asp:Button ID="LoginButton" runat="server" BorderStyle="None" 
                                        CommandName="Login" Height="24px" onclick="LoginButton_Click" Text="Log In" 
                                        ValidationGroup="ctl00$Login1" Width="89px" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" class="style6" colspan="2">
                                    <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." 
                                        ForeColor="White" />
                                </td>
                                <td class="style8" colspan="3">
                                    <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td class="style1">
                        &nbsp;</td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:Login>
</div>



