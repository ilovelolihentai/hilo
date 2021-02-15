<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="EDP_Project.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="padding-top:50px;">
        <h4 class="MainCart">My Cart</h4>
        <asp:Repeater ID="prtrCartProd" runat="server">
            <ItemTemplate>

            <div class="media" style="border:1px solid black;">
                <div class="media-left">
                    <img class="media-object" width="100px"src="Images\<%# Eval("image") %>"/>
              
            
                </div>
                <div class="media-body">
                   
                    <h4 class="media-heading"><%# Eval ("name") %></h4>
            
                    <span class="PriceView"> <%# Eval ("price","{0:c}") %></span>
                  
                    <p>
                        <asp:Button ID="btnRemoveCart" UseSubmitBehavior="false" CssClass="RemoveButton" runat="server" Text="REMOVE" OnClick="btnRemoveCart_Click" CommandArgument='<%# Eval("ID") %>'/>
                    </p>
                </div>

            </div>
            
            </ItemTemplate>
        </asp:Repeater>

        <div class="col-md-4">
       <%--show detais--%>
            <h5>
               Price Details
            </h5>
            <div>
            <label>Cart Total</label>
            <span class="pull-right priceGray" runat="server" id="spanCartTotal">1400</span>
            </div>
            <div>
                <label>Cart Discount</label>
                <span Class="pull-right priceGreen">200</span>
            </div>
            <div>
                <div class="TotalPriceView">
                <label>Cart Total</label>
                <span class="pull-right">1400</span>
                </div>
                <div>
                    <asp:Button ID="btnBuy" CssClass="buyNowbtn" runat="server" Text="Buy" Height="25px" OnClick="btnBuy_Click" />
                </div>

            </div>



        

        </div>

    </div>
</asp:Content>
