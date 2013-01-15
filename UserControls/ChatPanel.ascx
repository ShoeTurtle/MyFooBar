<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChatPanel.ascx.cs" Inherits="Controls_ChatPanel" %>

<%@ Register src="ChatPanelItem.ascx" tagname="ChatPanelItem" tagprefix="uc1" %>

<asp:Timer ID="Timer1" runat="server" Interval="6000" ontick="Timer1_Tick">
</asp:Timer>
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="Panel1" runat="server" Height="100%" 
    BackColor="#E6EBF0" Width="231px">
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

