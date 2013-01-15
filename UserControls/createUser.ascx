<%@ Control Language="C#" AutoEventWireup="true" CodeFile="createUser.ascx.cs" Inherits="Controls_WebUserControl2" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<%@ Register assembly="AfterEdge.Web" namespace="AfterEdge.Web.UI" tagprefix="cc1" %>
<%@ Register src="Login.ascx" tagname="Login" tagprefix="uc1" %>
<style type="text/css">
   .Watermark
   {
   	    font-style:italic;
   	    color:Gray;
   	   
   	}
    .style2
    {
        width: 590px;
    }
    .style5
    {
        width: 590px;
        height: 84px;
    }
    .style9
    {
        width: 590px;
        height: 23px;
    }
    .style12
    {
        width: 590px;
        height: 9px;
    }
    .style15
    {
        height: 9px;
    }
    .style16
    {
        width: 116px;
        height: 23px;
    }
    .style17
    {
        width: 116px;
    }
    .style18
    {
        width: 116px;
        height: 84px;
    }
    .style19
    {
        height: 9px;
        width: 116px;
    }
</style>

    <table align="left" 
    style="width: 519px; height: 427px; border-left-style: solid; border-left-width: 1px;">
    <tr>
        <td align="right" class="style15" colspan="2">
            <div align="center">
                <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" 
                    ForeColor="#333300" Text="User Registrartion"></asp:Label>
            </div>
        </td>
    </tr>
    <tr>
        <td align="right" class="style19">
            First
            Name:</td>
        <td class="style12" align="left">
            <asp:TextBox ID="txtFName" runat="server" BorderStyle="Solid" Width="149px"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="txtFName_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txtFName" 
                WatermarkText="First Name" WatermarkCssClass="Watermark">
            </asp:TextBoxWatermarkExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtFName" ErrorMessage="Name Can not be Blank"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="style19">
            Last NameL:</td>
        <td class="style12" align="left">
            <asp:TextBox ID="txtLName" runat="server" BorderStyle="Solid" Width="149px"></asp:TextBox>
         
            <asp:TextBoxWatermarkExtender ID="txtLName_TextBoxWatermarkExtender2" 
                runat="server" Enabled="True" TargetControlID="txtLName" 
                WatermarkText="Last Name" WatermarkCssClass="Watermark">
            </asp:TextBoxWatermarkExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                ControlToValidate="txtLName" ErrorMessage="Name Can not be Blank"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="style16">
            Address</td>
        <td class="style9" align="left">
            <asp:TextBox ID="txtAddr" runat="server" Height="88px" TextMode="MultiLine" 
                Width="284px" BorderStyle="Solid" ontextchanged="txtAddr_TextChanged"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="txtAddr_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txtAddr" 
                WatermarkText="Address" WatermarkCssClass="Watermark">
            </asp:TextBoxWatermarkExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtAddr" ErrorMessage="Address Can not be left Blank"></asp:RequiredFieldValidator>
            
        </td>
    </tr>
    <tr>
        <td align="right" class="style17" style="vertical-align: middle">
            Date of Birth</td>
        <td class="style2" align="left">
                        <asp:TextBox ID="txtDob" runat="server" BorderStyle="Solid" ReadOnly="True"></asp:TextBox>
                        <asp:TextBoxWatermarkExtender ID="txtDob_TextBoxWatermarkExtender" 
                            runat="server" Enabled="True" TargetControlID="txtDob" 
                            WatermarkText="Date Of Birth" WatermarkCssClass="Watermark">
                        </asp:TextBoxWatermarkExtender>
                        <asp:CalendarExtender ID="txtDob_CalendarExtender" runat="server" 
                            Enabled="True" TargetControlID="txtDob"
                            >
                        </asp:CalendarExtender>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" 
                            ControlToValidate="txtDob" 
                            ErrorMessage="We Won't tell your age, It will be safe with us"></asp:RequiredFieldValidator>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" 
                            ControlToValidate="txtDob" ErrorMessage="Invalid date"></asp:RangeValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="style17">
            Sex</td>
        <td class="style2" align="left">
            <asp:DropDownList ID="ddSex" runat="server">
                <asp:ListItem></asp:ListItem>
                <asp:ListItem>Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                ControlToValidate="ddSex" Display="Dynamic" ErrorMessage="Select Sex"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="style17">
            Mobile no</td>
        <td class="style2" align="left">
            <asp:TextBox ID="txtMobile" runat="server" BorderStyle="Solid" Width="128px"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="txtMobile_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txtMobile" 
                WatermarkText="Mobile No" WatermarkCssClass="Watermark">
            </asp:TextBoxWatermarkExtender>
            <asp:MaskedEditExtender ID="txtMobile_MaskedEditExtender" runat="server" 
                CultureAMPMPlaceholder="" CultureCurrencySymbolPlaceholder="" 
                CultureDateFormat="" CultureDatePlaceholder="" CultureDecimalPlaceholder="" 
                CultureThousandsPlaceholder="" CultureTimePlaceholder="" Enabled="True" 
                Mask="9999999999" MaskType="Number" TargetControlID="txtMobile">
            </asp:MaskedEditExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtMobile" Display="Dynamic" 
                ErrorMessage="What are you entering ??" ValidationExpression="\d{10}"></asp:RegularExpressionValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="style18">
            User name</td>
        <td class="style5" align="left">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server" RenderMode="Inline">
                <ContentTemplate>
                    <cc1:Prompt ID="Prompt1" runat="server">
                    </cc1:Prompt>
                    <asp:TextBox ID="txtUserName" runat="server" BorderStyle="Solid" 
                        AutoCompleteType="Disabled" AutoPostBack="True" 
                        ontextchanged="txtUserName_TextChanged" Height="24px" 
                        style="margin-bottom: 0px" Width="237px"></asp:TextBox>
                    <asp:TextBoxWatermarkExtender ID="txtUserName_TextBoxWatermarkExtender" 
                        runat="server" Enabled="True" TargetControlID="txtUserName" 
                        WatermarkText="Only Letters and digits with '.'" 
                        WatermarkCssClass="Watermark">
                    </asp:TextBoxWatermarkExtender>
                    <asp:FilteredTextBoxExtender ID="txtUserName_FilteredTextBoxExtender" 
                        runat="server" Enabled="True" FilterMode="InvalidChars" 
                        InvalidChars="&quot;~!@#$%^&amp;*()-_+={}[]:'&quot;&lt;&gt;?`&quot;/\|," 
                        TargetControlID="txtUserName">
                    </asp:FilteredTextBoxExtender>
                    <asp:Label ID="UserChecker" runat="server" Font-Size="Medium" 
                        ForeColor="#0066FF"></asp:Label>
                    
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                        ControlToValidate="txtUserName" Display="Dynamic" 
                        ErrorMessage="User Name Can not be left Blank"></asp:RequiredFieldValidator>
                    
        </td>
    </tr>
    <tr>
        <td align="right" class="style17">
            Pasword</td>
        <td class="style2" align="left">
            <asp:TextBox ID="txtPass" runat="server" TextMode="Password" 
                BorderStyle="Solid"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="txtPass_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txtPass" 
                WatermarkText="********" WatermarkCssClass="Watermark">
            </asp:TextBoxWatermarkExtender>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                ControlToValidate="txtPass" Display="Dynamic" ErrorMessage="Field Left blank"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="style17">
            Confirm Password</td>
        <td class="style2" align="left">
            <asp:TextBox ID="txtRePass" runat="server" Height="22px" TextMode="Password" 
                BorderStyle="Solid"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="txtRePass_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txtRePass" 
                WatermarkText="********" WatermarkCssClass="Watermark">
            </asp:TextBoxWatermarkExtender>
            <asp:CompareValidator ID="CompareValidator1" runat="server" 
                ControlToCompare="txtPass" ControlToValidate="txtRePass" Display="Dynamic" 
                ErrorMessage="Password Not Matched"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td align="right" class="style17">
            Email address:    <td class="style2" align="left">
            <asp:TextBox ID="txtEmail" runat="server" BorderStyle="Solid" Height="22px" 
                Width="192px"></asp:TextBox>
            <asp:TextBoxWatermarkExtender ID="txtEmail_TextBoxWatermarkExtender" 
                runat="server" Enabled="True" TargetControlID="txtEmail" 
                WatermarkText="youremail@example.com" WatermarkCssClass="Watermark">
            </asp:TextBoxWatermarkExtender>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                ControlToValidate="txtEmail" 
                ErrorMessage="We Asked you to enter your Email Address Not %#!$%#$" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                Display="Dynamic"></asp:RegularExpressionValidator>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                ControlToValidate="txtEmail" Display="Dynamic" 
                ErrorMessage="Email address canot be left blank"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="style17">
            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
        </td>
        <td class="style2" align="left">
           
            <table style="width:100%;">
                <tr>
                    <td align="right">
                        &nbsp;</td>
                    <td>
            <asp:Button ID="Button2" runat="server" class="register" onclick="Button2_Click" 
                style="height: 26px" Text="Submit" BorderStyle="None" Height="23px" Width="306px" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
</table>
