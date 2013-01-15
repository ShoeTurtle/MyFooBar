<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="fooMobile.aspx.cs" Inherits="_Default" %>
<%@ Register src="UserControls/mobileVarification.ascx" tagname="mobileVarification" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divMidTop" 
        style="border: thin solid #808080; height: 76px; position: absolute; left: 111px; top: 79px; width: 618px;">
            <br />
            <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                Width="541px" Font-Names="Lucida Sans" Height="40px"></asp:Label>
      </div>
    <div id="divFriendMain"
        style="position:absolute; border: thin solid #808080; top: 155px; left: 111px; width: 618px; height: 424px; overflow:auto;">
<div id="divFriendRequest">
            <br />
            <asp:Label ID="lblFriend" runat="server" Text="Mobile : " 
                Font-Names="Comic Sans MS" Font-Size="20px" ForeColor="#006666" Height="43px" 
                Width="100%"></asp:Label>
            <br />
             
                 <uc1:mobileVarification ID="mobileVarification1" runat="server" />            
        </div>
        </div>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>


