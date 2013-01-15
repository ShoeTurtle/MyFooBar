<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ProfileDisplay.ascx.cs" Inherits="ProfileDisplay" %>




<div style="float:left;">
    <div style="height:130px;float:left;">
        <a href="../fooProfile.aspx?AccountID=<asp:Literal id='litAccountID' runat='server'></asp:Literal>">
              <img alt="" src="../fooPicDB/mike/Profile/mypic2" style="width:100px; height:100px"/><br />
&nbsp;  </a>
        
        <asp:Label ID="lblUsername" runat="server" Text='<%#Eval("UName") %>'></asp:Label><br />
        <asp:Label ID="lblFullName" runat="server" Text='<%#Eval("UserName") %>'></asp:Label><br />
        
        <br />
           
    </div>
</div>