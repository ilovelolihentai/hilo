<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SiteCreation.aspx.cs" Inherits="Pract4.SiteCreation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div>
    <h3>Create Site</h3>
    <table style="width:100%;">
        <tr>
            <td class="auto-style1" style="width: 134px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">Name:</td>
            <td>
                <asp:TextBox ID="tbNric" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px" >Description:</td>
            <td>
                <asp:TextBox ID="tbName" runat="server" ></asp:TextBox>
            </td>
        </tr>
        <tr>

            <td class="auto-style1" style="width: 134px">Opening Time</td>
            <td>
                <asp:TextBox ID="tbBirthDate" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">Img</td>
            <td>
                <asp:TextBox ID="ddlDept" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">Price</td>
            <td>
                <asp:TextBox ID="tbMthlySalary" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" style="width: 134px">&nbsp;</td>
            <td>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Add" Width="77px" />
            </td>
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
</asp:Content>
