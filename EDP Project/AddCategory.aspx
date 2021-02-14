<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="EDP_Project.AddCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
            <div class ="container ">
            <div class ="form-horizontal ">
                <br />
                <br />

                <h2>Add Category</h2>
                <hr />
                <div class ="form-group">
                    <asp:Label ID="Label1" CssClass ="col-md-2 control-label " runat="server" Text="Category Name"></asp:Label>
                    <div class ="col-md-3 ">

                        <asp:TextBox ID="txtCategory" CssClass="form-control" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidatortxtCategoryName" runat="server" CssClass ="text-danger " ErrorMessage="*plz Enter Brandname" ControlToValidate="txtCategory" ForeColor="Red"></asp:RequiredFieldValidator>
                    </div>
                </div>
                


                <div class ="form-group">
                    <div class ="col-md-2 "> </div>
                    <div class ="col-md-6 ">

                        <asp:Button ID="btnAddtxtCategory" CssClass ="btn btn-success " runat="server" Text="Add Category" OnClick="btnAddtxtCategory_Click"   />
                        
                    </div>
                </div>
                

            </div>

             <h1>Categories</h1>
        <hr />

 <div class="panel panel-default">

               <div class="panel-heading"> All Categories</div>


          <asp:GridView 
         ID="gvCategory" 
         runat="server" 
         AutoGenerateColumns="False" 
         Gridlines="None"
         AlternatingRowStyle-CssClass="alt">
            <Columns>
                <asp:BoundField DataField="CatID" HeaderText="CatID" ReadOnly="True" />
                <asp:BoundField DataField="CatName" HeaderText="CatName" ReadOnly="True" />


                <asp:CommandField ShowSelectButton="True" />

                



            </Columns>
        </asp:GridView>

              
                
            

   
</div>

        </div>
</asp:Content>
