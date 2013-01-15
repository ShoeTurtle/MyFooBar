<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="fooBar.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    
    <div id="divNotification">
        <asp:Repeater ID="repFilter" runat="server">
            <ItemTemplate>
                <asp:Label ID="lblMessage" runat="server" 
                    Text="" > </asp:Label>
            </ItemTemplate>
            <SeparatorTemplate>
                <div class="AlertSeparator"></div>
            </SeparatorTemplate>
        </asp:Repeater>
    </div>

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder4">
</asp:Content>


