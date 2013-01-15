<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Login.aspx.cs" Inherits="_Default" %>

<%@ Register src="UserControls/createUser.ascx" tagname="createUser" tagprefix="uc1" %>

<%@ Register src="UserControls/Login.ascx" tagname="Login" tagprefix="uc2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style type="text/css">
        #form1
        {
            width: 1280px;
            height: 1021px;
        }
        .style9
        {
            width: 169px;
        }
        </style>
</head>
<body style="background-color:#ffffff">
    <form id="form1" runat="server">
        
        <div id="topContent" 
            style="margin-top: 0px; position:absolute; z-index:-1; top: 0px; left: 0px; background-color: #3B5998; color: White;
            font-size: x-large;
            text-decoration: none;
            font-weight: bold;
	        height: 95px;
            width:100%;">
            <div id="imgButtonFooBar" 
                style="float:left; margin-left:50px; margin-top:30px; margin-bottom: 0px;">
                <asp:ImageButton ID="ImageButton1" runat="server" 
                    ImageUrl="~/images/foobarbutton.jpg" style="margin-top: 0px"/>            
            </div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        </div>
        
        <div>
        
        <div style="float:right; height: 46px; width: 637px;">
            <uc2:Login ID="Login1" runat="server" />
        </div>
        </div>
        
        <div style="height: 500px; position: absolute; left: 55%; top: 110px; width: 535px;">
            <uc1:createUser ID="createUser1" runat="server" />
                
    </div>
    
    
    <div style="position:absolute; top: 170px; left: 10%; height: 58px; width: 422px;">
        <asp:Image ID="imgTheme1" runat="server" ImageUrl="images/theme.jpg" />
    </div>
    
    <div style="position:absolute; top: 230px; left: 8%;">
        <asp:Image ID="imgTheme2" runat="server" ImageUrl="images/social-networking-4.jpg" />    
    </div>
    
    
    </form>
    </body>
</html>
