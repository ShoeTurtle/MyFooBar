<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="fooHome.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="ContentHome" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <script type="text/javascript" language="ecmascript">
        window.onload = function init()
        {
            var imgMain = document.getElementById("ctl00_ContentPlaceHolder2_imgMain");
            var num = imgMain.clientHeight;
            num = num + 170;
            document.getElementById("divLeftMenu").style.top = num + "px";           
            
        }
    </script>
    
    <table style="width: 70%; height: 1023px;  padding-top: 82px">
           <tr>
            <td style="height: 30px; width: 822px;" colspan="2">
                <asp:Image ID="Image13" runat="server" Height="23px" Width="841px" 
                    ImageUrl="~/images/foobar.jpg"/>    
            </td>
            </tr>      
            
            <tr>
            <td style="height: 111px; width: 822px;" colspan="2">
                <asp:Image ID="imgCover" runat="server" Height="202px" 
                    ImageUrl="~/images/testCoverPic.jpg" Width="834px" />
            </td>
             </tr>
                    
                    <tr>
                        <td align="left" style="height: 3px; width: 822px;" colspan="2">
                            <asp:Image ID="Image1" runat="server" Height="23px" 
                                ImageUrl="~/images/infoBar.jpg" Width="841px" />
                        </td>
                    </tr>
                    <tr>
                       <td align="left" style="width: 822px; margin-left: 120px;" colspan="2">
                              
                                        
                            <table style="width: 102%; height: 171px;">
                                <tr>
                                    <td style="width: 450px; height: 30px">
                                        <asp:Label ID="lblName" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Text="Name:" Font-Bold="False" Font-Names="Tahoma"></asp:Label>
                                        &nbsp; <asp:Label ID="lblUName" runat="server" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblEmployer" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Text="Employer:" Font-Bold="False" Font-Names="Tahoma"></asp:Label>
                                        &nbsp; <asp:Label ID="lblEmp" runat="server" Font-Names="Tahoma"></asp:Label>                                            
                                    </td>                                
                                </tr>
                                <tr>
                                    <td style="width: 450px; height: 30px">
                                        <asp:Label ID="lblName0" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Text="Sex:" Font-Bold="False" Font-Names="Tahoma"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lblSex" runat="server" Font-Names="Tahoma"></asp:Label>
                                    </td>                         
                                </tr>
                                <tr>
                                    <td style="width: 450px; height: 31px">
                                        <asp:Label ID="lblName1" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Text="Birthday:" Font-Bold="False" Font-Names="Tahoma"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lblBirthDay" runat="server" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Text="Phone No:" Font-Bold="False" Font-Names="Tahoma"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lblPhone" runat="server" Font-Names="Tahoma"></asp:Label>                                    
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 450px; height: 31px">
                                        <asp:Label ID="lblName2" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Text="Home Town:" Font-Bold="False" Font-Names="Tahoma"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lblHomeAdd" runat="server" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label2" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Text="Email:" Font-Bold="False" Font-Names="Tahoma"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lblEmail" runat="server" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                
                                </tr>
                                <tr>
                                    <td style="width: 450px; height: 31px">
                                        <asp:Label ID="lblName3" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Text="College:" Font-Bold="False" Font-Names="Tahoma"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lblCollege" runat="server" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCurrentAddress" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Text="Current Address:" Font-Bold="False" Font-Names="Tahoma"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lblCurrAdd" runat="server" Font-Names="Tahoma"></asp:Label>
                                    
                                    </td>    
                                
                                </tr>
                                <tr>
                                    <td style="width: 450px; height: 31px">
                                        <asp:Label ID="lblName6" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Text="High School:" Font-Bold="False" Font-Names="Tahoma"></asp:Label>
                                        &nbsp;
                                        <asp:Label ID="lblHighSchool" runat="server" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="width: 822px" colspan="2">
                            <asp:Image ID="Image2" runat="server" Height="23px" 
                                ImageUrl="~/images/infoPhoto.jpg" Width="841px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 822px" align="left" colspan="2">
                            <table style="width: 822px; height: 240px;">
                                <tr>
                                    <td colspan="4" style="height: 41px">
                                        <asp:Label ID="lblName7" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Text="Total No of Albums:" Font-Bold="False" Font-Names="Tahoma"></asp:Label>
&nbsp;<asp:Label ID="lblPicCount" runat="server" Font-Names="Tahoma"></asp:Label>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 273px; height: 145px" align="center">
                                        <asp:Image ID="img1" runat="server" Height="120px" Width="160px" />
                                    </td>
                                    <td style="width: 273px; height: 145px" align="center">
                                        <asp:Image ID="img2" runat="server" Height="120px" Width="160px" />
                                    </td>
                                    <td style="width: 274px; height: 145px" align="center">
                                        <asp:Image ID="img3" runat="server" Height="120px" Width="160px" />
                                    </td>
                                    <td style="width: 274px; height: 145px" align="center">
                                        <asp:Image ID="img4" runat="server" Height="120px" Width="160px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" style="width: 273px; height: 39px">
                                        <asp:Label ID="lblAlbum1" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Font-Names="Tahoma"></asp:Label>
                                    </td>
                                    <td align="center" style="width: 273px; height: 39px">
                                        <asp:Label ID="lblAlbum2" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Font-Names="Tahoma"></asp:Label>
                                    </td>
                                    <td align="center" style="width: 274px; height: 39px">
                                        <asp:Label ID="lblAlbum3" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Font-Names="Tahoma"></asp:Label>
                                    </td>
                                    <td align="center" style="width: 274px; height: 39px">
                                        <asp:Label ID="lblAlbum4" runat="server" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td align="left" style="height: 21px; width: 822px;" colspan="2">
                            <asp:ImageButton ID="ImageButton6" runat="server" Height="23px" 
                                ImageUrl="~/images/infoFriends.jpg" Width="841px" />
                        </td>
                    </tr>
                    <tr>
                        <td  align="center" style="height: 86px; width: 822px;" colspan="2">
                            <table style="width: 822px;">
                                <tr>
                                    <td align="left" colspan="6" style="margin-left: 40px; height: 46px;">
                                        <asp:Label ID="lblName11" runat="server" Font-Size="Medium" ForeColor="Black" 
                                            Text="Total No of Friends:" Font-Bold="False" Font-Names="Tahoma"></asp:Label>
                                        <asp:Label ID="lblFriendCount" runat="server" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 114px; width: 137px">
                                        <asp:Image ID="imgFriend1" runat="server" Height="100px" Width="80px" />
                                    </td>
                                    <td style="height: 114px; width: 136px">
                                        <asp:Image ID="imgFriend2" runat="server" Height="100px" Width="80px" />
                                    </td>
                                    <td style="height: 114px; width: 137px">
                                        <asp:Image ID="imgFriend3" runat="server" Height="100px" Width="80px" />
                                    </td>
                                    <td style="height: 114px; width: 137px">
                                        <asp:Image ID="imgFriend4" runat="server" Height="100px" Width="80px" />
                                    </td>
                                    <td style="height: 114px; width: 137px">
                                        <asp:Image ID="imgFriend5" runat="server" Height="100px" Width="80px" />
                                    </td>
                                    <td style="height: 114px; width: 137px">
                                        <asp:Image ID="imgFriend6" runat="server" Height="100px" Width="80px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="height: 46px; width: 137px">
                                        <asp:Label ID="lblFriendName1" runat="server" Font-Size="Medium" 
                                            ForeColor="Black" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 136px; height: 46px">
                                        <asp:Label ID="lblFriendName2" runat="server" Font-Size="Medium" 
                                            ForeColor="Black" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 137px; height: 46px">
                                        <asp:Label ID="lblFriendName3" runat="server" Font-Size="Medium" 
                                            ForeColor="Black" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 137px; height: 46px" id="lblFriendName4">
                                        <asp:Label ID="lblFriendName4" runat="server" Font-Size="Medium" 
                                            ForeColor="Black" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 137px; height: 46px">
                                        <asp:Label ID="lblFriendName5" runat="server" Font-Size="Medium" 
                                            ForeColor="Black" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                    <td align="left" style="width: 137px; height: 46px">
                                        <asp:Label ID="lblFriendName6" runat="server" Font-Size="Medium" 
                                            ForeColor="Black" Font-Names="Tahoma"></asp:Label>
                                    </td>
                                </tr>
                                </table>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td  align="left" style="width: 822px" colspan="2">
                            <asp:Image ID="Image3" runat="server" Height="23px" 
                                ImageUrl="~/images/infoWall.jpg" Width="841px" style="margin-top: 0px" 
                                Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td  align="left" style="width: 822px" colspan="2">
                            <br />
                            <table id="theWall" style="width:100%;">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                            <br />
                            <asp:Table ID="Table1" runat="server" Height="85px" Width="833px">
                            </asp:Table>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td  align="left" style="width: 822px" colspan="2">
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
</asp:Content>


<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder2">
    <asp:Image ID="imgMain" runat="server" style="margin-top: 30px" /> <br />
</asp:Content>

<asp:Content ID="Content2" runat="server" contentplaceholderid="ContentPlaceHolder4">
</asp:Content>









