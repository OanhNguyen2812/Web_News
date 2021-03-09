<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Detail_AD.aspx.cs" Inherits="News.Pages.Detail_AD" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href='http://fonts.googleapis.com/css?family=Roboto:400,300,300italic,400italic,500,700,500italic,100italic,100' rel='stylesheet' type='text/css'>

    <link href="../Css_Js/plugins/daterangepicker/daterangepicker.css" rel="stylesheet" />
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../Css_Js/plugins/fontawesome-free/css/all.min.css">
    <!-- daterange picker -->
    <link rel="stylesheet" href="../Css_Js/plugins/daterangepicker/daterangepicker.css">
    <!-- Tempusdominus Bootstrap 4 -->
    <link rel="stylesheet" href="../Css_Js/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Quảng cáo mới</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Quảng cáo mới</li>
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
                            <div class="card-header">
                                <div class="row">
                                    <h3 class="card-title col-md-3">Thông tin quảng cáo
                                    </h3>
                                    <div class="col-md-1"></div>
                                    <div class="col-md-8" style="color: red">
                                        <asp:Label runat="server" ID="lbthongbao"></asp:Label></div>
                                </div>

                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">ID quảng cáo:</label>
                                            <asp:TextBox runat="server" ID="txtid" placeholder="ID tự động..." CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Công ty:</label>
                                            <asp:TextBox runat="server" ID="txtcongty" placeholder="" CssClass="form-control" required=""></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Mô tả:</label>
                                            <asp:TextBox runat="server" ID="txtmota" placeholder="" CssClass="form-control" required=""></asp:TextBox>
                                        </div>
                                        <!-- Date -->
                                        <div class="form-group">
                                            <label>Ngày bắt đầu:</label>
                                            <div class="input-group date" id="reservationdate" data-target-input="nearest">
                                                <asp:TextBox runat="server" type="text" ID="datebd" CssClass="form-control datetimepicker-input" data-target="#reservationdate" required=""></asp:TextBox>
                                                <div class="input-group-append" data-target="#reservationdate" data-toggle="datetimepicker">
                                                    <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <label>Ngày kết thúc:</label>
                                            <div class="input-group date" id="reservationdate1" data-target-input="nearest">
                                                <asp:TextBox runat="server" type="text" ID="datekt" CssClass="form-control datetimepicker-input" data-target="#reservationdate1" required=""></asp:TextBox>
                                                <div class="input-group-append" data-target="#reservationdate1" data-toggle="datetimepicker">
                                                    <div class="input-group-text"><i class="fa fa-calendar"></i></div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- /.form-group -->
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="exampleInputEmail1">Ảnh quảng cáo:</label>
                                            <div class="input-group">
                                                <div class="custom-file">
                                                    <asp:FileUpload runat="server" type="file" CssClass="custom-file-input" ID="fuqc" />
                                                    <label class="custom-file-label" for="exampleInputFile">Choose file</label>
                                                </div>
                                            </div>
                                        </div>
                                        <asp:Image runat="server" CssClass="" Style="width: 500px; height: auto" ID="imgQC" />
                                    </div>
                                </div>
                                <!-- /.card-body -->
                            </div>
                            <div class="card-footer ">
                                <div class="row">
                                    <div class="col-md-8"></div>
                                    <div class="col-md-3">
                                        <div class="col-sm-2 " id="add">
                                            <asp:Button runat="server" ID="btnAdd" class="btn btn-primary " type="submit" Text="Thêm" OnClick="btnAdd_Click" />
                                        </div>
                                        <div class="col-sm-2" id="save">
                                            <asp:Button runat="server" ID="btnSave" class="btn btn-primary" type="submit" Text="Sửa" OnClick="btnSave_Click" />
                                        </div>
                                    </div>
                                    <div class="col-md-1">
                                        <asp:Button runat="server" type="button" Text="Hủy" CssClass="btn btn-danger " ID="btnhuy" OnClick="btnhuy_Click" />
                                    </div>
                                    
                                    
                                </div>
                            </div>
                            <div style="display: none">
                                <asp:TextBox runat="server" ID="txtngay"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtngay2"></asp:TextBox>
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
    <!-- InputMask -->
    <script src="../Css_Js/plugins/moment/moment.min.js"></script>
    <script src="../Css_Js/plugins/inputmask/jquery.inputmask.min.js"></script>
    <!-- date-range-picker -->
    <script src="../Css_Js/plugins/daterangepicker/daterangepicker.js"></script>
    <!-- Tempusdominus Bootstrap 4 -->
    <script src="../Css_Js/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>


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
