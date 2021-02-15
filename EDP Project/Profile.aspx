<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="EDP_Project.Profile" %>
<!DOCTYPE html>


    <link rel="stylesheet" href="css/StyleSheet1.css" type="text/css" media="all" />
     <style type="text/css">
         .auto-style1 {
             position: relative;
             display: block;
             background-color: #fff;
             left: -1px;
             top: 0px;
         }
         .auto-style2 {
             position: relative;
             display: block;
             background-color: #fff;
             left: 1px;
             top: 0px;
         }
     </style>

<form id="form1" runat="server">
<div class="container">
    <div class="mt-1">
        <h2 class="mt-2">Your Account</h2>
        <div class="row mt-3">
            <div class="col-lg-3">
                <div class="list-group" id="list-tab" role="tablist">
                    <a class="list-group-item list-group-item-action active" id="list-home-list" data-toggle="list" href="#list-details" role="tab" aria-controls="home">Account Details</a>
                </div>
            </div>
            <div class="col-lg-9">
                <div class="tab-content mt-2" id="nav-tabContent">
                    <div class="tab-pane fade show active" id="list-details" role="tabpanel" aria-labelledby="list-home-list">
                        <ul class="list-group">
                            <li class="auto-style2">
                                <div class="d-flex w-100 justify-content-between">
                                    <h5 class="mb-1">Username</h5>
                                </div>
                                <p class="mb-0">
                                    <asp:TextBox ID="lbl_name" runat="server" ></asp:TextBox>
                                </p>
                            </li>
                            <li class="auto-style1">
                                <div class="d-flex w-100 justify-content-between">
                                    <h5 class="mb-1">Email Address</h5>
                                </div>
                                <p class="mb-0">
                                    <asp:TextBox ID="lbl_email" runat="server"></asp:TextBox>
                                </p>
                            </li>
                            <li class="list-group-item">
                                <div class="d-flex w-100 justify-content-between">
                                    <h5 class="mb-0">&nbsp;</h5>
                                    <p class="mb-0">
                                        <asp:Button ID="Chg_pwd" runat="server" Height="37px" OnClick="Button1_Click" Text="Change Password" Width="128px" />
                                    </p>
                                    <p class="mb-0">
                                        <asp:Button ID="Edit" runat="server" Height="37px" OnClick="BtnClickUpdate" Text="Update profile" Width="128px" />
                                    </p>
                                </div>
                            </li>
                           
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
    <asp:Label ID="lbl_error" runat="server" Text="Label"></asp:Label>
</form>

