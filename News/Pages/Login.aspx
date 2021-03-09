<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="News.Pages.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <title>Admin | Log in </title>

    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback"/>
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../Css_Js/plugins/fontawesome-free/css/all.min.css" />
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="../Css_Js/plugins/icheck-bootstrap/icheck-bootstrap.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="../Css_Js/dist/css/adminlte.min.css" />
</head>
<body class="hold-transition login-page">
    <form id="form1" runat="server">
        <div class="login-box">
            <!-- /.login-logo -->
            <div class="card card-outline card-primary">
                <div class="card-header text-center">
                    <a href="#" class="h1"><b>Admin</b></a>
                </div>
                <div class="card-body">

                    <div>
                        <div class="input-group mb-3">
                            <asp:TextBox runat="server" type="" CssClass="form-control" placeholder="ID User" ID="txtid"  required=""></asp:TextBox>
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-user"></span>
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
                        <div class="row">
                            <div class="col-8">
                                <div class="icheck-primary">

                                    <asp:CheckBox runat="server" type="checkbox" ID="remember"/>
                                    <label for="remember">
                                        Remember Me
             
                                    </label>
                                    <br />
                                    <asp:Label runat="server" ID="lbError"></asp:Label>
                                </div>
                            </div>
                            <!-- /.col -->
                            <div class="col-4">
                                <asp:Button runat="server" ID="btnlogin" type="submit" CssClass="btn btn-primary btn-block" Text="Sign In" OnClick="btnlogin_Click"/>
                            </div>
                            <!-- /.col -->
                        </div>
                    </div>

                    <p class="mb-1">
                        <a href="forgot-password.html">I forgot my password</a>
                    </p>
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.card -->
        </div>
        <!-- /.login-box -->
    </form>

    <!-- jQuery -->
    <script src="../Css_Js/plugins/jquery/jquery.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../Css_Js/dist/js/adminlte.min.js"></script>
</body>
</html>
