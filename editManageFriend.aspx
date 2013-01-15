<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="editManageFriend.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

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
            <asp:Label ID="lblFriend" runat="server" Text="Pending Friend Requests" 
                Font-Names="Comic Sans MS" Font-Size="20px" ForeColor="#006666" Height="43px" 
                Width="100%"></asp:Label>
            <br />
            <asp:Repeater ID="repFriendRequest"  
                OnItemDataBound="repFriendRequest_ItemDataBound" runat="server" 
                onitemcommand="repFriendRequest_ItemCommand">
                <ItemTemplate>
                    <asp:Literal ID="litFriendID" visible="false" Text='<%#Eval("Sender") %>' runat="server"></asp:Literal>
                    <table style="width:100%;">
                        <tr>
                            <td style="width:100px; padding-left:15px;">
                                <asp:Image ID="imgFriend" style="height:100px; width:80px; padding:3px;" runat="server" />
                            </td>
                            <td style="width:250px; padding-left:30px; text-align:left;">
                                <asp:Label ID="lblFriend" style=" font-size:20px; font-family:Comic Sans MS; color:#3B5998; font-weight:normal; height:20px;" runat="server"></asp:Label>
                            </td>
                            <td align="left">
                               <asp:LinkButton ID="butAccept" OnClick="butAccept_Click" runat="server" CssClass="editLnkButton">Accept</asp:LinkButton>
                            </td>
                            <td align="left">
                                <asp:LinkButton ID="butReject" OnClick="butReject_Click" runat="server" CssClass="editLnkButton">Reject</asp:LinkButton>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:Repeater>         
               
        </div>
    </div>     
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

