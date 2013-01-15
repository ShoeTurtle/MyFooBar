<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" MaintainScrollPositionOnPostback="true"  AutoEventWireup="true" CodeFile="fooChat.aspx.cs" Inherits="_Default" Title="My Chat Room" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
              
<script id="MyScript" type="text/javascript">
            
        window.onload = function init()
        {
            var imgMain = document.getElementById("ctl00_ContentPlaceHolder2_imgMain");
            var num = imgMain.clientHeight;
            num = num + 170;
            document.getElementById("divLeftMenu").style.top = num + "px";         
            //window.scrollTo(20,100);
              
        }     

        
        function invokeMeMaster() 
        {
            alert('I was invoked from Master');
        }
        
        function SetScrollPosition()
        {
            //alert('Hello !!!');
            var div = document.getElementById('divMessages');
            div.scrollTop = 10000;
            //var txtMessage = document.getElementById("ctl00_ContentPlaceHolder1_txtMessage")
       
        }
             
        
         function SetToEnd(txtMessage)
        {                    
           if (txtMessage.createTextRange)
            {
                var fieldRange = txtMessage.createTextRange();
                fieldRange.moveStart('character', txtMessage.value.length);
                alert(txtMessage.value.length);
                fieldRange.collapse();
                fieldRange.select();
            }
        }
              
                              
    </script>
    
  
    <div id="divChatHeader">
    <asp:Image ID="Image1" runat="server" ImageUrl="images/infoChat.jpg" Height="23px" Width="841px"/>
    </div>
    
    <script type="text/javascript">
        var xPos, yPos;
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(BeginRequestHandler);
        prm.add_endRequest(EndRequestHandler);
        
        function BeginRequestHandler(sender, args) {
            //xPos = $get('scrollDiv').scrollLeft;
            //yPos = $get('scrollDiv').scrollTop;
            xPos = document.body.scrollLeft;
            yPos = document.body.scrollTop;
            //alert(xPos);
            //alert(yPos);
            prm._scrollPosition = null;

        }
        function EndRequestHandler(sender, args) {
            //$get('scrollDiv').scrollLeft = xPos;
            //$get('scrollDiv').scrollTop = yPos;
            //window.scroll(0, 40);
            
        }
    </script>
   
     

    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    
    <Triggers> 
        <asp:AsyncPostBackTrigger ControlID="Timer1" />
    </Triggers>
   
    <ContentTemplate>
         <div id="divChatRoom">
            <table border="0" cellpadding="0" cellspacing="0" 
                style=" position:absolute; top:-100px; height: 344px; clip: rect(auto, auto, auto, auto);">
                    <tr>
                        <td style="width: 500px;">
                            <div id="divMessages" 
                                style="border: 1px solid Black; overflow:auto; background-color: White; height:300px; width:592px; font-size: 11px; padding: 4px 4px 4px 4px; margin-left:10px; text-align:left ">
                                <asp:Literal Id="litMessages" runat="server"   />
                            </div>                    
                        </td>
                        
                        <td>
                            <div id="divUsers" 
                                style="border: 1px solid Black; background-color: White; height:300px; width:120px; font-size: 11px;  padding: 4px 4px 4px 4px; margin-left: 5px; text-align:left">
                               <asp:Literal Id="litUsers" runat="server"  />
                            </div>
                        </td>
                    </tr>
             </table>                
    
        </div>
    
        
    </ContentTemplate>
    
    </asp:UpdatePanel>
    
    <asp:Timer ID="Timer1" interval="2000" ontick="Timer1_OnTick" runat="server"/>
    
    <div id="divChatTextBox">
        <asp:Panel ID = "panel1" runat ="server"  DefaultButton="btnsend">              
                            
            <!--OnClientClick="SetScrollPosition()" OnClick="BtnSend_Click" /-->           
            <table style="width: 100%; position: absolute; top:-100px; margin-left:10px" align="left">
                <tr>
                    <td>
                        <asp:TextBox Id="txtMessage" onfocus="SetToEnd(this)" runat="server" MaxLength="100" Width="590px"  style="margin-left: 0px" Height="21px"/>
                        &nbsp;
                    </td>
                    
                    <td align="center">
                        <asp:Button Id="btnSend" runat="server" Text="Send" Width="100px"
                            Height="23px" style="margin-left: 20px" onclick="btnSend_Click" />
                            &nbsp;
                    </td>
                           
                 </tr>
                        
             </table>
         </asp:Panel>   
                            
                                                              
    </div>                                           
                        
   
 </asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder2">                                            
    <asp:Image ID="imgMain" runat="server" style="margin-top: 30px" /> <br />
</asp:Content>


<asp:Content ID="Content3" runat="server" contentplaceholderid="ContentPlaceHolder4">
</asp:Content>



