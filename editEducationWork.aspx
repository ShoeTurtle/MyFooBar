<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="editEducationWork.aspx.cs" Inherits="_Default" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="divMidTop" 
        style="border: thin solid #808080; height: 76px; position: absolute; left: 111px; top: 79px; width: 618px;">
            <br />
            <asp:Label ID="lblName" runat="server" Font-Bold="True" Font-Size="XX-Large" 
                Width="541px" Font-Names="Lucida Sans" Height="40px"></asp:Label>
     </div>
     
        
     <div id="divEducationWork"
        style="position:absolute; border: thin solid #808080; top: 155px; left: 111px; width: 618px; height: 424px; overflow:auto;">
             <div id="div1" 
             style="position:absolute; top: 34px; left: 2px; text-align:left;">
                  
             <asp:ListView ID="lvWork" runat="server" OnItemDataBound="lvWork_ItemDataBound" InsertItemPosition="FirstItem"
                     OnItemInserting="lvWork_ItemInserting" 
                 OnItemUpdating="lvWork_ItemUpdating" ItemPlaceholderID="itemPlaceholder2">
                    <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder ID="itemPlaceHolder2"  runat="server"> </asp:PlaceHolder>
                        </ul>
                    </LayoutTemplate>
            
                    <ItemTemplate>                        
                            
                            <asp:Literal Visible="false" ID="litPosition" 
                                Text='<%#Eval("Position") %>' runat="server"></asp:Literal>
                            <asp:Literal Visible="false" ID="litCompanyName"
                                Text='<%#Eval("CompanyName") %>' runat="server"></asp:Literal>
                            <asp:Literal Visible="false" ID="litCity"
                                Text='<%#Eval("City") %>' runat="server"></asp:Literal>
                            <asp:Literal Visible="false" ID="litJoining"
                                Text='<%#Eval("YearOfJoining") %>' runat="server"></asp:Literal>
                            <asp:Literal Visible="false" ID="litLeaving"
                                Text='<%#Eval("YearOfLeaving") %>' runat="server"></asp:Literal>
                            <asp:Literal Visible="false" ID="litPK"
                                Text='<%#Eval("Work_PK") %>' runat="server"></asp:Literal>
                            
                            
                            <p>
                                <asp:Label ID="lblCompanyName" runat="server" Text="Employer:" Width="120px" CssClass="lblSide"></asp:Label>                            
                                <asp:TextBox ID="txtCompanyName" runat="server" style="margin-left:30px;" Width="200px"></asp:TextBox>
                               
                            </p>
                            
                            <p>
                                <asp:Label ID="lblPosition" runat="server" Text="Position:" Width="120px" CssClass="lblSide"></asp:Label>
                                <asp:TextBox ID="txtPosition" runat="server" style="margin-left:30px;" Width="200px"></asp:TextBox>
                            </p>
                            
                            <p>
                                <asp:Label ID="lblCity" runat="server" Text="City" Width="120px" CssClass="lblSide"></asp:Label>
                                <asp:TextBox ID="txtCity" runat="server" style="margin-left:30px;" Width="200px"></asp:TextBox>
                            </p>

                            <p>                                
                                <asp:Label ID="lblStartDate" runat="server" Text="Joined On:" Width="120px" CssClass="lblSide"></asp:Label>
                                <asp:TextBox ID="txtStartDate" runat="server" style="margin-left:30px;" Width="200px"></asp:TextBox>
                                <asp:LinkButton ID="lnkUpdate" runat="server" CommandName="Update" Font-Underline="False" style="margin-left:30px;" ForeColor="#006666" Font-Names="Tahoma" Font-Size="Small">UPDATE</asp:LinkButton>     
                            </p>
                            
                            <p>
                                <asp:Label ID="lblEndDate" runat="server" Text="Worked Till:" Width="120px" CssClass="lblSide"></asp:Label>
                                <asp:TextBox ID="txtEndDate" runat="server" style="margin-left:30px;" Width="200px"></asp:TextBox>
                                <asp:LinkButton ID="lnkRemove" runat="server" OnClick="lnkRemove_Click" Font-Underline="False" style="margin-left:30px;" ForeColor="#006666" Font-Names="Tahoma" Font-Size="Small">REMOVE</asp:LinkButton>
                            
                            </p>
                            <br />
                    
                    </ItemTemplate>
                            
                    <InsertItemTemplate>
                            <p>
                                <asp:Label ID="lblCompanyName" runat="server" Text="Employer:" Width="120px" CssClass="lblSide"></asp:Label>                            
                                <asp:TextBox ID="txtCompanyName1" runat="server" style="margin-left:30px;" Width="200px"></asp:TextBox>
                               
                            </p>
                            
                            <p>
                                <asp:Label ID="lblPosition" runat="server" Text="Position:" Width="120px" CssClass="lblSide"></asp:Label>
                                <asp:TextBox ID="txtPosition" runat="server" style="margin-left:30px;" Width="200px"></asp:TextBox>
                            </p>
                            
                            <p>
                                <asp:Label ID="lblCity" runat="server" Text="City" Width="120px" CssClass="lblSide"></asp:Label>
                                <asp:TextBox ID="txtCity" runat="server" style="margin-left:30px;" Width="200px"></asp:TextBox>
                            </p>

                            <p>                                
                                <asp:Label ID="lblStartDate" runat="server" Text="Joined On:" Width="120px" CssClass="lblSide"></asp:Label>
                                <asp:TextBox ID="txtStartDate" runat="server" style="margin-left:30px;" Width="200px"></asp:TextBox>   
                            </p>
                            
                            <p>
                                <asp:Label ID="lblEndDate" runat="server" Text="Worked Till:" Width="120px" CssClass="lblSide"></asp:Label>
                                <asp:TextBox ID="txtEndDate" runat="server" style="margin-left:30px;" Width="200px"></asp:TextBox>
                                <asp:LinkButton ID="lnkInsert" CommandName="Insert" runat="server" Font-Underline="False" style="margin-left:30px;" ForeColor="#006666" Font-Names="Tahoma" Font-Size="Small">ADD WORK ENTRY</asp:LinkButton>
                            
                            </p>                        
                            <p>.</p>
                    
                    </InsertItemTemplate>
                
                </asp:ListView>
         </div>
         
         <div id="div2" style="position:fixed; top: 258px; left: 426px;">
         
         </div>
          
          
          <div id="div3" style="position:absolute; top: 165px; left: 5px;">
          
          </div>
         <asp:Label ID="lblErrorInsert" runat="server" Visible="False" Width="400px"></asp:Label>
    </div>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="Server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" Runat="Server">
</asp:Content>

