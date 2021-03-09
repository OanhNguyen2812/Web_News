<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AD.aspx.cs" Inherits="News.Pages.AD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Css_Js/dist/css/quangcao/qc.css" rel="stylesheet" />
    <style>
        p {
            font-size: 18px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Quảng Cáo</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Quảng Cáo</li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>
        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-md-12">
                        <div class="card card-outline card-info">
                            <div class="card-header row">
                                <div class="col-md-5">
                                    <h3 class="card-title"></h3>
                                </div>
                                <div class="col-md-5"></div>
                                <div class="col-md-2">
                                    <asp:Button runat="server" ID="btnnew" class="btn btn-success right" Text="Thêm mới quảng cáo" OnClick="btnnew_Click" />
                                </div>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body row">
                                <div class="" id="left">
                                    <asp:Repeater runat="server" ID="rpquangcao">
                                        <ItemTemplate>
                                            <div class="products-listItem" style="width: 500px; margin-left: 20px; padding: 0px">
                                                <div class="products" style="padding: 0px">
                                                    <div class="thumbnail" style="width: 45%; padding: 15px 15px 5px 15px">
                                                        <img src='<%# "../Images/Advertise/" + Eval("URL") %>' />
                                                    </div>
                                                    <div class="product-list-description" style="width: 55%; padding: 0px">
                                                        <div class="productname">
                                                            <%# Eval("CongTy").ToString() %>
                                                        </div>
                                                        <p>
                                                            <%# (Eval("NgayDang","{0:dd/M/yyyy}")).ToString() %>  - <%# (Eval("NgayKetThuc","{0:dd/M/yyyy}")).ToString() %>
                                                        </p>
                                                        <p>
                                                            <%# Eval("MoTa").ToString() %>
                                                        </p>
                                                        <div class="list_bottom">
                                                            <div class="button_group">
                                                                <div class="btn btn-warning" id="btnchitiet" onclick="btnchitiet();">
                                                                    <asp:HyperLink runat="server" ID="HyperLink1" Text="Chi Tiết" NavigateUrl='<%# "Detail_AD.aspx?maqc=" + Eval("ID_QuangCao").ToString() %>' />
                                                                </div>

                                                                <asp:LinkButton runat="server" ID="btnXoa" Text="Xóa"
                                                                    OnClientClick="return valid();"
                                                                    CommandArgument='<%# int.Parse(Eval("ID_QuangCao").ToString()) %>'
                                                                    OnCommand="btnXoa_Command" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </div>
                                <!-- /.card-body -->
                            </div>
                            <div class="card-footer row">
                                <div class="col-md-9">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col-->
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <!-- jQuery -->
    <script src="../Css_Js/plugins/jquery/jquery.min.js"></script>
    <script src="../Css_Js/plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="../Css_Js/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- Select2 -->
    <script src="../Css_Js/plugins/select2/js/select2.full.min.js"></script>
    <!-- Bootstrap4 Duallistbox -->
    <script src="../Css_Js/plugins/bootstrap4-duallistbox/jquery.bootstrap-duallistbox.min.js"></script>
    <!-- InputMask -->
    <script src="../Css_Js/plugins/moment/moment.min.js"></script>
    <script src="../Css_Js/plugins/inputmask/jquery.inputmask.min.js"></script>
    <!-- date-range-picker -->
    <script src="../Css_Js/plugins/daterangepicker/daterangepicker.js"></script>
    <!-- bootstrap color picker -->
    <script src="../Css_Js/plugins/bootstrap-colorpicker/js/bootstrap-colorpicker.min.js"></script>
    <!-- Tempusdominus Bootstrap 4 -->
    <script src="../Css_Js/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>
    <!-- Bootstrap Switch -->
    <script src="../Css_Js/plugins/bootstrap-switch/js/bootstrap-switch.min.js"></script>
    <!-- BS-Stepper -->
    <script src="../Css_Js/plugins/bs-stepper/js/bs-stepper.min.js"></script>
    <!-- dropzonejs -->
    <script src="../Css_Js/plugins/dropzone/min/dropzone.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../Css_Js/dist/js/adminlte.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../Css_Js/dist/js/demo.js"></script>

    <!-- bs-custom-file-input -->
    <script src="../Css_Js/plugins/bs-custom-file-input/bs-custom-file-input.min.js"></script>
    <!-- Page specific script -->
    <script>
        $(function () {
            bsCustomFileInput.init();
        });
    </script>
    <!-- Page specific script -->

    <script>
        $(function () {
            //Datemask dd/mm/yyyy
            $('#datemask').inputmask('dd/mm/yyyy', { 'placeholder': 'dd/mm/yyyy' })
            //Datemask2 mm/dd/yyyy
            $('#datemask2').inputmask('mm/dd/yyyy', { 'placeholder': 'mm/dd/yyyy' })
            //Money Euro
            $('[data-mask]').inputmask()

            //Date range picker
            $('#reservationdate').datetimepicker({
                format: 'L'
            });
            $('#reservationdate1').datetimepicker({
                format: 'L'
            });
            //Date range picker
            $('#reservation').daterangepicker()
            //Date range picker with time picker
            $('#reservationtime').daterangepicker({
                timePicker: true,
                timePickerIncrement: 30,
                locale: {
                    format: 'MM/DD/YYYY hh:mm A'
                }
            })
        })

    </script>
</asp:Content>
