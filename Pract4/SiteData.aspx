<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SiteData.aspx.cs" Inherits="Pract4.SiteData" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <h3>Create Site</h3>
    <table style="width:100%;">
        <tr>
            <td class="auto-style1" style="width: 134px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">&nbsp;</td>
            <td>
                <asp:Label ID="lbMsg" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    </div>
        <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="False" CellPadding="0" CssClass="myDatagrid">
            <Columns>
                <asp:BoundField DataField="Nric" HeaderText="Name" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Description" ReadOnly="True" />
                <asp:BoundField DataField="Dept" HeaderText="Img" ReadOnly="True" />
                <asp:BoundField DataField="BirthDate" HeaderText="Opening Time" ReadOnly="True" />
                <asp:BoundField DataField="MthlySalary"  HeaderText="Price($)" ReadOnly="True" />
                

            </Columns>
        </asp:GridView>
    <br />
    <asp:Panel ID="PanelErrorResult" Visible="false" runat="server" CssClass="alert alert-dismissable alert-danger">
            <button type="button" class="close" data-dismiss="alert">
                <span aria-hidden="true">&times;</span>
            </button>
            <asp:Label ID="Lbl_err" runat="server"></asp:Label>
            </asp:Panel>
    <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Search</h3>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="lbEmpId" runat="server" Text="Site Name:"></asp:Label>
                        <asp:TextBox ID="tbEmpId" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                    <asp:Button ID="btnGetEmp" runat="server" CssClass="btn btn-default" Text="Get" OnClick="btnGetEmp_Click" />
                    <asp:Button ID="btnDelEmp" runat="server" CssClass="btn btn-default" Text="Delete" OnClick="btnDelEmp_Click" />
                </div>
            </div>.










 ....           <asp:Panel ID="PanelCust" Visible="false" runat="server">
                <div class="panel panel-info">
                    <div class="panel-heading">Results:</div>
                    <div class="panel-body">
                        <div class="row">
                            <label for="Lbl_nric" class="col-sm-2 col-form-label">Description :</label>
                            <div class="col-sm-4">
                                <asp:Label ID="Lbl_nric" runat="server"></asp:Label>
                            </div>
                            <label for="Lbl_name" class="col-sm-2 col-form-label">Img:</label>
                            <div class="col-sm-4">
                                <asp:Label ID="Lbl_name" runat="server"></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <label for="Lbl_birthday" class="col-sm-2 col-form-label">Starting Time :</label>
                            <div class="col-sm-4">
                                <asp:Label ID="Lbl_birthday" runat="server"></asp:Label>
                            </div>
                            <label for="Lbl_mthlySalary" class="col-sm-2 col-form-label">Price:</label>
                            <div class="col-sm-4">
                                <asp:Label ID="Lbl_mthlySalary" runat="server"></asp:Label>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>
            <div class="row">   
                <asp:HyperLink ID="HyplinkAdd" CssClass="col-sm-12" NavigateUrl="~/TermDepositForm.aspx" Visible="false" runat="server">Edit</asp:HyperLink>
            </div>
</asp:Content>
