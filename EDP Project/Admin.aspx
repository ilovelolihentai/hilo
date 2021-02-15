<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="EDP_Project.Admin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <br />
        <br />
        <asp:GridView ID="gvUser" runat="server" AutoGenerateColumns="False" CellPadding="0" CssClass="myDatagrid" Height="166px" Width="1027px">
            <Columns>
                <asp:BoundField DataField="username" HeaderText="Userame" ReadOnly="True" />
                <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" />

                <asp:BoundField DataField="Account" HeaderText="Account Type" ReadOnly="True" />

            </Columns>
        </asp:GridView>
        <br />
        <br />

</div>
    <div class="panel panel-info">
                <div class="panel-heading">
                    <h3 class="panel-title">Search</h3>
                </div>
                <div class="panel-body">
                    <div class="form-group">
                        <asp:Label ID="lbUserId" runat="server" Text="Email:"></asp:Label>
                        <asp:TextBox ID="tbUserName" runat="server" CssClass="form-control" ></asp:TextBox>
                    </div>
                    <asp:Button ID="btnGetUser" runat="server" CssClass="btn btn-default" Text="Get" OnClick="btnGetUser_Click" />
                    <asp:Label ID="Lbl_err" runat="server"></asp:Label>
                </div>
            </div>
    <br>
    <br>
            <asp:Panel ID="PanelCust" Visible="false" runat="server">
                <div class="panel panel-info">
                    <div class="panel-heading">Results:</div>
                    <div class="panel-body">
                        <div class="row">
                            <label for="Lbl_username" class="col-sm-2 col-form-label">Username :</label>
                            <div class="col-sm-4" style="left: 0px; top: 0px; width: 800px">
                                <asp:Label ID="Lbl_username" runat="server"></asp:Label>
                            </div>
                            </div>
                            <br>
                        <div class="row">
                            <label for="Lbl_Email" class="col-sm-2 col-form-label">Email:</label>
                            <div class="col-sm-4" style="left: 0px; top: 0px; width: 798px">
                                <asp:Label ID="Lbl_Email" runat="server"></asp:Label>
                            </div>
                            </div>
                            <br>
                        <div class="row">
                            <label for="Lbl_Delete" class="col-sm-2 col-form-label">Deleted:</label>
                            <div class="col-sm-4" style="left: 0px; top: 0px; width: 798px">
                                <asp:Label ID="Lbl_Delete" runat="server"></asp:Label>
                            </div>
                        </div>
                        </div>
                            <asp:Button ID="btnDelUser" runat="server" CssClass="btn btn-default" OnClick="btnDelUser_Click" Text="Delete" />
                            <asp:Button ID="btnUnDelUser" runat="server" CssClass="btn btn-default" OnClick="btnUnDelUser_Click" Text="Undelete" />
                        </div>

            </asp:Panel>
</asp:Content>
