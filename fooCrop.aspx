<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="fooCrop.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <script type="text/javascript">
        window.onload = function init()
        {
            //var divImgCrop = document.getElementById("divImgCrop");
            //var imgCropImage = document.getElementById("ctl00_ContentPlaceHolder1_imgCropImage");
            
            //var divX, divY;
            //var picX, picY;           
            //var myTop;
            
            //divX = divImgCrop;;
            //divY = divImgCrop.clientHeight;
                       
            //picX = imgCropImage.width;
            //picY = imgCropImage.height;            
            
            //myTop = ((divY - (2*picX)) / 4);
            
            //var img=new Image();
            //img.src=""; 
            //img.onload=function(){ alert('Width: '+img.width+', Height:'+img.height); }
        }
    
    
    </script>
    
    
    <!-- Test ImageCropper Tool -->
    <div id="divMidTop" 
        style="border: thin solid #808080; height: 76px; position: absolute; left: 111px; top: 79px; width: 618px;">
            <br />
            <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                Width="541px" Font-Names="Lucida Sans" Height="40px"></asp:Label>
     </div>
     
<script src="cropper/lib/prototype.js" type="text/javascript" language="javascript"></script>
<script src="cropper/lib/scriptaculous.js" type="text/javascript" language="javascript"></script>
<script type="text/javascript" src="cropper/cropper.uncompressed.js" language="javascript"></script>
    <div id="divCrop" style="position:absolute; border: thin solid #808080; top: 155px; left: 111px; width: 618px; height: 424px; overflow:auto;">
                  
            <div id="divFileUpload" 
                style="position:absolute; top:-5px; left: 3px; width: 611px; height: 41px;" 
                align="right">
                        <p align="center">
                            <asp:FileUpload ID="FileUploadProfilePic" runat="server" Width="219px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button runat="server" id="UploadButton" text="Upload" 
                                            onclick="UploadButton_Click" Height="25px" Width="89px" />
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="Button1" runat="server" Text="CROP" onclick="Button1_Click" Width="101px"  /> 
                        </p>
                        <p>
                            <asp:Label runat="server" id="StatusLabel" text="STATUS: "  Visible="false"/>
                        </p>
                           
            </div>
           
            <div id="divImgCrop" 
                style="position:absolute; overflow:auto; top: 51px; left: 2px; height: 367px; width: 612px;">
                <p align="center">
                    <asp:Image ID="imgCropImage" runat="server"/>
                </p>
            </div>
            
    </div>         
    
    
    
    <asp:HiddenField ID="hidX1" runat="server" />
    <asp:HiddenField ID="hidY1" runat="server" />
    <asp:HiddenField ID="hidX2" runat="server" />
    <asp:HiddenField ID="hidY2" runat="server" />
    <asp:HiddenField ID="hidWidth" runat="server" />
    <asp:HiddenField ID="hidHeight" runat="server" />
    <asp:HiddenField ID="hidPicName" runat="server" />
    
    
        
    <script type="text/javascript" language="javascript">
        
        function onEndCrop( coords, dimensions )
        {
         
            $('ctl00_ContentPlaceHolder1_hidX1').value = coords.x1;
            $('ctl00_ContentPlaceHolder1_hidX2').value = coords.x2;
            $('ctl00_ContentPlaceHolder1_hidY1').value = coords.y1;
            $('ctl00_ContentPlaceHolder1_hidY2').value = coords.y2;
            $('ctl00_ContentPlaceHolder1_hidX1').value = coords.x1;
            $('ctl00_ContentPlaceHolder1_hidWidth').value = dimensions.width;
            $('ctl00_ContentPlaceHolder1_hidHeight').value = dimensions.height;                
         
        }        
        
        Event.observe( 
			window, 
			'load', 
			function() { 
				new Cropper.Img( 
					'ctl00_ContentPlaceHolder1_imgCropImage', 
					{ 
						maxWidth: 250,
						maxHeight: 400,						
						displayOnInit: true, 
						onEndCrop: onEndCrop 
					} 
				) 
			} 
		);
    </script>     
    
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

