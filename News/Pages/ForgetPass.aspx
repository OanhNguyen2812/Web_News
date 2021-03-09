<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="ForgetPass.aspx.cs" Inherits="News.Pages.ForgetPass" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <section class="content-header">
            <div class="container-fluid">
            </div>
            <!-- /.container-fluid -->
        </section>
        <section class="content">
            <div class="container-fluid">
                <!-- SELECT2 EXAMPLE -->
                <div class="card card-default">
                    <!-- /.card-header -->
                    <div class="card-body">
                        <p class="login-box-msg">Đổi mật khẩu</p>
                        <div class="row">
                            <div class="col-md-4"></div>
                            <div class="col-md-4">
                                <div class="input-group mb-3">
                                    <asp:TextBox runat="server" type="password" CssClass="form-control" placeholder="Old Password" ID="txtoldpass" required=""></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <span class="fas fa-lock"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="input-group mb-3">
                                    <asp:TextBox runat="server" type="password" CssClass="form-control" placeholder="Password" ID="txtpass" required=""></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <span class="fas fa-lock"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="input-group mb-3">
                                    <asp:TextBox runat="server" type="password" CssClass="form-control" placeholder="RePassword" ID="txtrepass" required=""></asp:TextBox>
                                    <div class="input-group-append">
                                        <div class="input-group-text">
                                            <span class="fas fa-lock"></span>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-8">
                                    </div>
                                    <!-- /.col -->
                                    <div class="col-4">
                                        <asp:Button runat="server" ID="btnrepass" type="submit" CssClass="btn btn-primary btn-block" Text="Đổi" OnClick="btnrepass_Click" />
                                    </div>
                                    <!-- /.col -->
                                </div>
                            </div>
                            <div class="col-md-4"></div>

                        </div>
                    </div>
                </div>
                <!-- /.card -->
            </div>
            <!-- /.container-fluid -->
        </section>
        <!-- /.content -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
