<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewAttractions1.aspx.cs" Inherits="EDP_Project.ViewAttractions1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <br />  


    <div class="row" style="padding-top:50px">
       <asp:repeater ID="rptrProducts" runat="server">
           <ItemTemplate>
        <div class="col-sm-3 col-md-3">
            <a href="AttractionsPage.aspx?Id=<%# Eval("Id") %>" style="text-decoration:none;">
          <div class="thumbnail"> 
              <img src="Images\<%# Eval("image") %>"/>
              
     
             
              <div class="caption"> 
                   
                   <div class="proName"> <%# Eval ("name") %> </div>
                   <div class="proPrice"> <span class="proOgPrice" > <%# Eval ("price","{0:c}") %> </div> 
                   
              </div>
          </div>
                </a>
        </div>
               
               </ItemTemplate>
       </asp:repeater>
    </div>



    <%--second product--%>


</asp:Content>
