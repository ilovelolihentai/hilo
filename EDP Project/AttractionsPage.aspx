<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AttractionsPage.aspx.cs" Inherits="EDP_Project.AttractionsPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<section class="mb-5">
  <div class="row">
    <div class="col-md-6 mb-4 mb-md-0">

      <div id="mdb-lightbox-ui"></div>

      <div class="mdb-lightbox">

        <div class="row product-gallery mx-1">

          <div class="col-12 mb-0">
            <figure class="view overlay rounded z-depth-1 main-img">
              <a href="https://mdbootstrap.com/img/Photos/Horizontal/E-commerce/Vertical/15a.jpg"
                data-size="710x823">
                  <asp:Image ID="Prod_Image1" CssClass="img1" runat="server" />
              </a>
           
          </div>
          <div class="col-12">
            <div class="row">
              <div class="col-3">
                <div class="view overlay rounded z-depth-1 gallery-item">
                   <asp:Image ID="Prod_Image2" CssClass="img1" runat="server" />
                  <div class="mask rgba-white-slight"></div>
                </div>
              </div>
            </div>
          </div>
        </div>

      </div>

    </div>
    <div class="col-md-6">

        <asp:Label ID="Product_Name" runat="server" Text="Label"></asp:Label>
        <asp:Label ID="Product_Price" runat="server" Text="Label" font-style="Bold"></asp:Label>
        <br />
        <asp:Label ID="Product_Desc" runat="server" Text="Label"></asp:Label>
      <div class="table-responsive">
        <table class="table table-sm table-borderless mb-0">
          <tbody>
            <tr>
              <th class="pl-0 w-25" scope="row"><strong>Model</strong></th>
              <td>Shirt 5407X</td>
            </tr>
            <tr>
              <th class="pl-0 w-25" scope="row"><strong>Category</strong></th>
              <td>
                  <asp:Label ID="Prod_Category" runat="server" Text="Label"></asp:Label>
              </td>
            </tr>
            <tr>
              <th class="pl-0 w-25" scope="row"><strong>Delivery</strong></th>
              <td>USA, Europe</td>
            </tr>
          </tbody>
        </table>
      </div>
      <hr>
      <div class="table-responsive mb-2">
        <table class="table table-sm table-borderless">
          <tbody>
            <tr>
              <td class="pl-0 pb-0 w-25">Quantity</td>
              <td class="pb-0">Select size</td>
            </tr>
            <tr>
              <td class="pl-0">
                <div class="def-number-input number-input safari_only mb-0">
                  <button onclick="this.parentNode.querySelector('input[type=number]').stepDown()"
                    class="minus"></button>
                  <input class="quantity" min="0" name="quantity" value="1" type="number">
                  <button onclick="this.parentNode.querySelector('input[type=number]').stepUp()"
                    class="plus"></button>
                </div>
              </td>
              <td>
                <div class="mt-1">
                  <div class="form-check form-check-inline pl-0">
                    <input type="radio" class="form-check-input" id="small" name="materialExampleRadios"
                      checked>
                    <label class="form-check-label small text-uppercase card-link-secondary"
                      for="small">Small</label>
                  </div>
                  <div class="form-check form-check-inline pl-0">
                    <input type="radio" class="form-check-input" id="medium" name="materialExampleRadios">
                    <label class="form-check-label small text-uppercase card-link-secondary"
                      for="medium">Medium</label>
                  </div>
                  <div class="form-check form-check-inline pl-0">
                    <input type="radio" class="form-check-input" id="large" name="materialExampleRadios">
                    <label class="form-check-label small text-uppercase card-link-secondary"
                      for="large">Large</label>
                  </div>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
      <button type="button" class="btn btn-primary btn-md mr-1 mb-2">Buy now</button>
      <button type="button" class="btn btn-light btn-md mr-1 mb-2"><i
          class="fas fa-shopping-cart pr-2"></i>Add to cart</button>
    </div>
  </div>

</section>
</asp:Content>
