<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="fooSearch.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script type="text/javascript" language="javascript">
        window.onload = function init()
        {
            var imgMain = document.getElementById("ctl00_ContentPlaceHolder2_imgMain");
            var num = imgMain.clientHeight;
            num = num + 170;
            document.getElementById("divLeftMenu").style.top = num + "px";           
            
        }     
   

 
    </script>
    
    <div style=" position:absolute; top:98px; left:-10px; float:left; width: 615px;">
    <h1 align="center" 
            style="font-family:'Tekton Pro Ext'; font-weight:bolder; color:black;  font-size: 30px;">FooSearch Engine</h1><br />
        
       
        <asp:Button ID="butSearch" runat="server" 
            Text="Search" style="position:absolute; top: 87px; left: 519px; width: 105px;" 
            onclick="butSearch_Click" TabIndex="2"/>
        
       
        <asp:TextBox ID="txtSearch" runat="server"           
            style="position:absolute; top: 85px; left: 70px; height: 22px; width: 430px;" 
            TabIndex="1" ontextchanged="txtSearch_TextChanged" AutoPostBack="True"></asp:TextBox>
        
       
    </div>
    
   
    <div style="position:absolute; top: 239px; left: 41px;">   

    </div>  
   
   <div style="position:absolute; top: 337px; left: 2px; width: 485px;">
        <asp:Repeater ID="repAccounts" runat="server" OnItemDataBound="repAccounts_ItemDataBound">
                <ItemTemplate>                      
                    <table style="width: 500px;">
                        <asp:Literal ID="litUsrKey" text='<%#Eval("UName") %>' runat="server" Visible="false"></asp:Literal>
                        <tr>
                            <td align="left">
                                 <a href= 'fooProfile.aspx?AccountID=<%#Eval("UName") %>'>
                                        <img alt="" src='fooPicDB/<%#Eval("UName") %>/Profile/<%#Eval("ProfilePic") %>'  style="height:100px; width:80px; padding:3px;"/>
                                 </a>                
                                
                            </td>
                            <td align="left" style="width:300px">
                                <asp:Label ID="lblFullName" runat="server" Text='<%#Eval("UserName") %>'  style=" font-size:20px; font-family:Comic Sans MS; color:#3B5998; font-weight:normal; height:20px;"></asp:Label><br />
                                <asp:Label ID="lblFromCity" runat="server" Text='<%#Eval("CurrentCity") %>' style="height:15px; font-size:17px; color:Gray"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:Button ID="butAddFriend" runat="server" Text="Request Friendship" onclick="butAddFriend_Click" style="position:absolute; left:110%"/>
                            </td>
                        </tr>
                    </table><br /><br />
                </ItemTemplate>
                     
            </asp:Repeater>
   </div>



  

</asp:Content>


<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <asp:Image ID="imgMain" runat="server" style="margin-top: 30px" /><br />
            
</asp:Content>




<asp:Content ID="Content4" runat="server" contentplaceholderid="ContentPlaceHolder4">
</asp:Content>





