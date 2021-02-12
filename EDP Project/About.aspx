<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="EDP_Project.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>I LOVE BEE MOVIE.</h3>
    <p>Use this area to provide additional information.</p>
    <asp:Image ID="Image1" runat="server" ImageUrl="~/images/download.jfif" />
</asp:Content>
