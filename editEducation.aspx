<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="editEducation.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divMidTop" 
        style="border: thin solid #808080; height: 76px; position: absolute; left: 111px; top: 79px; width: 618px;">
            <br />
            <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                Width="541px" Font-Names="Lucida Sans" Height="40px"></asp:Label>
    </div>
    
    
    <div id="divEducation"
        style="position:absolute; border: thin solid #808080; top: 155px; left: 111px; width: 618px; height: 424px; overflow:auto;">

         <div id="divInnerEducation" 
             style="position:absolute; top: 26px; left: 6px; text-align:left;">
             <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
             
             <asp:ListView ID="lvEducation" runat="server" OnItemDataBound="lvEducation_ItemDataBound" 
                        OnItemInserting="lvEducation_ItemInserting" OnItemUpdating="lvEducation_ItemUpdating"
                 InsertItemPosition="FirstItem">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder ID="itemPlaceHolder"  runat="server"> </asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
            
                    <InsertItemTemplate>
                        <p>                                            
                            <asp:Label ID="lblInstitutionName" runat="server" Text="Insitution:" Width="120px" CssClass="lblSide"></asp:Label>                            
                            <asp:TextBox ID="txtInstitution" style="margin-left:30px;" Width="200px" runat="server"></asp:TextBox>
                        </p>                    
                        <p>
                            <asp:Label ID="lblDegree" runat="server" Text="Degree:" Width="120px" CssClass="lblSide"></asp:Label>                            
                            <asp:TextBox ID="txtDegree" style="margin-left:30px;" Width="200px" runat="server"></asp:TextBox>                            
                        </p>
                        <p>
                            <asp:Label ID="lblCategory" runat="server" Text="Category:" Width="120px" CssClass="lblSide"></asp:Label>
                            <asp:DropDownList ID="DDCategory" style="margin-left:30px;" Width="205px" Height="25px" runat="server">
                                    <asp:ListItem>school</asp:ListItem>
                                    <asp:ListItem>highschool</asp:ListItem>
                                    <asp:ListItem>college</asp:ListItem>                                
                            </asp:DropDownList>
                        </p>
                        <p>
                            <asp:Label ID="lblBatch" runat="server" Text="Batch:" Width="120px" CssClass="lblSide"></asp:Label>                            
                            <asp:TextBox ID="txtBatch" style="margin-left:30px;" Width="200px" runat="server"></asp:TextBox>
                            <asp:LinkButton ID="lnkInsert" CommandName="Insert" runat="server" Font-Underline="False" style="margin-left:24px;" ForeColor="#006666" Font-Names="Tahoma" Font-Size="Small">ADD EDUCATION</asp:LinkButton>
                        </p>
                       
                        <p>.</p>                 
                    </InsertItemTemplate>
            
                    <ItemTemplate>                        
                            
                            <asp:Literal Visible="false" ID="litInstitutionName" 
                                Text='<%#Eval("InstitutionName") %>' runat="server"></asp:Literal>
                            <asp:Literal Visible="false" ID="litDegreeTitle"
                                Text='<%#Eval("DegreeTitle") %>' runat="server"></asp:Literal>
                            <asp:Literal Visible="false" ID="litBatch"
                                Text='<%#Eval("Batch") %>' runat="server"></asp:Literal>
                            <asp:Literal Visible="false" ID="litCategory"
                                Text='<%#Eval("Category") %>' runat="server"></asp:Literal>
                            <asp:Literal Visible="false" ID="litPK"
                                Text='<%#Eval("Education_PK") %>' runat="server"></asp:Literal>    
                            
                            <p>
                                <asp:Label ID="lblInstitutionName" runat="server" Text="Insitution:" Width="120px" CssClass="lblSide"></asp:Label>                            
                                <asp:TextBox ID="txtInstitutionName" runat="server" style="margin-left:30px;" Width="200px"></asp:TextBox>
                               
                            </p>
                            
                            <p>
                                <asp:Label ID="lblDegreeTitle" runat="server" Text="Degree:" Width="120px" CssClass="lblSide"></asp:Label>
                                <asp:TextBox ID="txtDegreeTitle" runat="server" style="margin-left:30px;" Width="200px"></asp:TextBox>
                            </p>
                            
                            <p>
                                <asp:Label ID="lblCategory" runat="server" Text="Category:" Width="120px" CssClass="lblSide"></asp:Label>
                                <asp:DropDownList ID="DDCategory" style="margin-left:30px;" Width="205px" Height="25px" runat="server">
                                    <asp:ListItem>school</asp:ListItem>
                                    <asp:ListItem>highschool</asp:ListItem>
                                    <asp:ListItem>college</asp:ListItem>                                
                                </asp:DropDownList>
                                
                                <asp:LinkButton ID="lnkSave" runat="server" CommandName="Update" Font-Underline="False" style="margin-left:20px;" ForeColor="#006666" Font-Names="Tahoma" Font-Size="Small">UPDATE</asp:LinkButton>
                            </p>
                            
                            <p>
                                <asp:Label ID="lblBatch" runat="server" Text="Batch:" Width="120px" CssClass="lblSide"></asp:Label>
                                <asp:TextBox ID="txtBatch" runat="server" style="margin-left:30px;" Width="200px"></asp:TextBox>
                                <asp:LinkButton ID="lnkRemove" runat="server" OnClick="lnkRemove_Click" Font-Underline="False" style="margin-left:20px;" ForeColor="#006666" Font-Names="Tahoma" Font-Size="Small">REMOVE</asp:LinkButton>
                            
                            </p>
                            
                            <br />
                    
                    </ItemTemplate>
                    <EditItemTemplate>
                        <p>
                            <asp:LinkButton ID="lnkUpdate" CommandName="Update" runat="server">UPDATE</asp:LinkButton>
                            <asp:LinkButton ID="lnkCancel" runat="server">LinkButton</asp:LinkButton>
                        
                        </p>
                    
                    </EditItemTemplate>                               

                </asp:ListView>
         </div>
         <asp:Label ID="lblErrorInsert" runat="server" Visible="False" Width="400px"></asp:Label>
     </div>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

