<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Detail.aspx.cs" Inherits="News.Pages.Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Select2 -->
    <link rel="stylesheet" href="../Css_Js/plugins/select2/css/select2.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="../Css_Js/dist/css/adminlte.min.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Advanced Form</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Advanced Form</li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>

        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">
                <!-- SELECT2 EXAMPLE -->
                <div class="card card-default">
                    <div class="card-header">
                        <h3 class="card-title">Select2 (Default Theme)</h3>

                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>
                            <button type="button" class="btn btn-tool" data-card-widget="remove">
                                <i class="fas fa-times"></i>
                            </button>
                        </div>
                    </div>
                    <!-- /.card-header -->
                    <div class="card-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Mã nhân viên:</label>
                                    <asp:TextBox runat="server" ID="txtMaNV" placeholder="Mã tự động..." CssClass="form-control"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Tên nhân viên:</label>
                                    <asp:TextBox runat="server" ID="txtTenNV" placeholder="" CssClass="form-control"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Nghệ danh:</label>
                                    <asp:TextBox runat="server" ID="txtNgheDanh" placeholder="" CssClass="form-control"></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Chuyên mục:</label>
                                    <asp:DropDownList runat="server" CssClass=" form-control m-b" ID="cbbChuyenMuc" data-placeholder="Select a State" Style="width: 100%;">
                                    </asp:DropDownList>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label>Loại tài khoản:</label>
                                    <asp:DropDownList runat="server" ID="cbbLoaiTK" CssClass="form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Giới tính:</label>
                                    <asp:TextBox runat="server" ID="txtGioiTinh" placeholder="" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Email:</label>
                                    <asp:TextBox runat="server" ID="txtEmail" placeholder="" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Địa chỉ:</label>
                                    <asp:TextBox runat="server" ID="txtDiaChi" placeholder="" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <!-- /.col -->
                        </div>
                    </div>
                    <!-- /.row -->
                </div>
                <!-- /.card-body -->
                <div class="card-footer">
                    <div class="col-md-9">
                        <p></p>
                    </div>
                    <div class="col-md-3" style="float: right">
                        <asp:Button runat="server" ID="btnAdd" class="btn btn-primary" type="submit" Text="Add" OnClick="btnAdd_Click" />
                        <asp:Button runat="server" ID="btnThemCM" class="btn btn-info" type="submit" Text="Thêm chuyên mục" OnClick="btnThemCM_Click" />
                        <asp:Button runat="server" ID="btnSave" class="btn btn-primary" type="submit" Text="Save" OnClick="btnSave_Click" />
                    </div>
                    <div class="col-md-3" style="float: left">
                        <asp:Button runat="server" ID="Button1" class="btn btn-danger" type="submit" Text="Cancel" OnClick="btnCancel_Click" />

                    </div>

                </div>
            </div>
            <!-- /.card -->

            <!-- /.container-fluid -->
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <!-- Select2 -->
    <script src="../Css_Js/plugins/select2/js/select2.full.min.js"></script>

    <script>
        $(function () {
            //Initialize Select2 Elements
            $('.select2').select2()

        })

</script>
</asp:Content>
