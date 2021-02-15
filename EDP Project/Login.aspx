<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="EDP_Project.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
          <link rel="stylesheet" href="css/style.css" type="text/css" media="all" />
            <script src="https://kit.fontawesome.com/af562a2a63.js" crossorigin="anonymous"></script>

    <div>
   
            <section class="w3l-workinghny-form">

        <div class="workinghny-form-grid">
            <div class="wrapper">
                <div class="logo">
                    <h1><a class="brand-logo " href="#index.html">
                            <img src="img/60ff0e073848b5a5d525e8adac5a03dfb7b17bc5_hq.jpg"  title="Hotel Haven" style="height:100px;" />
                        </a></h1>
                
                </div>
                <div class="workinghny-block-grid">
                    <div class="form-right-inf">
                        <h2>Login </h2>
                        <div class="social-media">
                            <a href="#facebook" class="fb"><span class="fab fa-facebook" aria-hidden="true"></span> Login with facebok</a>
                            <a href="#twitter" class="tw"><span class="fab fa-twitter" aria-hidden="true"></span> Login with twitter</a>
                        </div>
                        <div class="login-form-content">
                            <h2>Login with Account</h2>
                            <form action="#" class="signin-form" method="post">
                                <div class="one-frm">
                                <asp:TextBox ID="tbName" runat="server" placeholder="Username" required=""></asp:TextBox>
                                <div class="one-frm">                                 
                                <asp:TextBox ID="tbPwd"  type="password" runat="server" placeholder="Password" required=""></asp:TextBox>
                                </div>
                                  <asp:Button class="btn btn-style mt-3" ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Login" Width="200px" />
                                  <asp:Label ID="lbl_error" runat="server" ForeColor="Red"></asp:Label>
                                <p class="already">Don't have an account? <a href="SignUp.aspx">Sign up</a></p>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    
    </div>
</asp:Content>
