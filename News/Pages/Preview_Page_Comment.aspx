<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Preview_Page_Comment.aspx.cs" Inherits="News.Pages.Preview_Page_Comment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Xem trước</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Xem trước</li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>

        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-md-8">
                    <div class="card card-outline card-info">
                        <div class="card-header">
                            <h3 class="card-title">Preview </h3>
                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <div class="row">
                                <h2>
                                    <asp:Label runat="server" ID="lbten">
                                    </asp:Label>
                                </h2>
                            </div>
                            <div class="row">
                                <p>
                                    <asp:Label runat="server" ID="lbmo">
                                    </asp:Label>
                                </p>
                            </div>
                        </div>
                        <div class="card-footer ">
                            <div class="row">
                                <div class="col-md-10"></div>
                                <div class="col-md-2">
                                    <asp:Button runat="server" ID="btnduyet" class="btn btn-primary " type="submit" Text="Duyệt bài" OnClick="btnduyet_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="col-md-4">

                    <!-- DIRECT CHAT -->
                    <div class="card direct-chat direct-chat-primary">
                        <div class="card-header">
                            <h3 class="card-title">Chat</h3>

                            <div class="card-tools">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>

                        <!-- /.card-header -->
                        <div class="card-body">

                            <!-- Contacts are loaded here -->
                            <div class="direct-chat-messages">
                                <asp:Repeater runat="server" ID="rpLS">
                                    <ItemTemplate>
                                        <div class="contacts-list">
                                            <a href="#">
                                                <img class="contacts-list-img" src="<%#"../Images/Users/"+ getANV(int.Parse(Eval("ID_User").ToString()))%>" alt=".">
                                                <div class="contacts-list-info">
                                                    <span class="contacts-list-name" style="color: black;">
                                                        <%# getTenNV(int.Parse(Eval("ID_User").ToString())) %>
                                                        <small class="contacts-list-date float-right"><%# (Eval("Time","{0:dd/M/yyyy}")).ToString() %></small>
                                                    </span>
                                                    <span class="contacts-list-msg"><%# (Eval("GhiChu").ToString())%></span>
                                                </div>
                                                <!-- /.contacts-list-info -->
                                            </a>
                                        </div>
                                    </ItemTemplate>

                                </asp:Repeater>
                                <!-- /.contacts-list -->
                            </div>
                            <!-- /.direct-chat-pane -->
                        </div>
                        <!-- /.card-body -->
                        <div class="card-footer">
                            <div class="input-group">
                                <asp:TextBox runat="server" name="message" placeholder="Type Message ..." CssClass="form-control" ID="txtghichu"></asp:TextBox>
                                <span class="input-group-append">
                                    <asp:Button runat="server" ID="btnsave" class="btn btn-primary  right" type="submit" Text="Post" OnClick="btnsave_Click" />
                                </span>
                            </div>
                        </div>
                        <!-- /.card-footer-->
                    </div>
                    <!--/.direct-chat -->
                </div>
                <!-- /.col-->
            </div>
        </section>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <!-- jQuery -->
    <script src="../../plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="../../plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- Select2 -->
    <script src="../../plugins/select2/js/select2.full.min.js"></script>
    <!-- Bootstrap4 Duallistbox -->
    <script src="../../plugins/bootstrap4-duallistbox/jquery.bootstrap-duallistbox.min.js"></script>
    <!-- InputMask -->
    <script src="../../plugins/moment/moment.min.js"></script>
    <script src="../../plugins/inputmask/jquery.inputmask.min.js"></script>
    <!-- date-range-picker -->
    <script src="../../plugins/daterangepicker/daterangepicker.js"></script>
    <!-- bootstrap color picker -->
    <script src="../../plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.min.js"></script>
    <!-- Tempusdominus Bootstrap 4 -->
    <script src="../../plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>
    <!-- Bootstrap Switch -->
    <script src="../../plugins/bootstrap-switch/js/bootstrap-switch.min.js"></script>
    <!-- BS-Stepper -->
    <script src="../../plugins/bs-stepper/js/bs-stepper.min.js"></script>
    <!-- dropzonejs -->
    <script src="../../plugins/dropzone/min/dropzone.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../../dist/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../../dist/js/demo.js"></script>
    <!-- Page specific script -->
    <script>
        $(function () {
            //Initialize Select2 Elements
            $('.select2').select2()

            //Initialize Select2 Elements
            $('.select2bs4').select2({
                theme: 'bootstrap4'
            })
        })
    </script>
</asp:Content>
