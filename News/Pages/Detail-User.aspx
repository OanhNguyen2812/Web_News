<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Detail-User.aspx.cs" Inherits="News.Pages.Detail_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Select2 -->
    <link rel="stylesheet" href="../Css_Js/plugins/select2/css/select2.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="../Css_Js/dist/css/adminlte.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Thông tin nhân viên</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Thông tin nhân viên  </li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>

        <!-- Main content -->

        <section class="content row">
            <div class="container-fluid col-md-8">
                <!-- SELECT2 EXAMPLE -->
                <div class="card card-default">
                    <div class="card-header">
                        <h3 class="card-title">Thông tin nhân viên</h3>

                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
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
                                    <asp:TextBox runat="server" ID="txtTenNV" placeholder="" CssClass="form-control" required=""></asp:TextBox>
                                </div>
                                <!-- /.form-group -->
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Nghệ danh:</label>
                                    <asp:TextBox runat="server" ID="txtNgheDanh" placeholder="" CssClass="form-control" required=""></asp:TextBox>
                                </div>
                                <!-- /.form-group -->

                                <div class="form-group" runat="server" id="loaicv">
                                    <label>Loại tài khoản:</label>
                                    <asp:DropDownList runat="server" ID="cbbLoaicv" CssClass="form-control select2" ></asp:DropDownList>
                                </div>

                                <div class="form-group">
                                    <label for="exampleInputEmail1">Giới tính:</label>
                                    <asp:TextBox runat="server" ID="txtGioiTinh" placeholder="" CssClass="form-control" ></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Email:</label>
                                    <asp:TextBox runat="server" ID="txtEmail" placeholder="" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Địa chỉ:</label>
                                    <asp:TextBox runat="server" ID="txtDiaChi" placeholder="" CssClass="form-control" ></asp:TextBox>
                                </div>
                            </div>
                            <!-- /.col -->
                            <div class="col-md-6">
                                <div class="form-group ">
                                    <label for="exampleInputEmail1">Ảnh đại diện:</label>
                                    <div class="input-group">
                                        <div class="custom-file">
                                            <asp:FileUpload runat="server" type="file" class="custom-file-input" ID="fuUrl" />
                                            <label class="custom-file-label" for="exampleInputFile">Choose file</label>
                                        </div>
                                    </div>
                                    <br />
                                    <div style="width: 350px; height: 350px">
                                        <div class="image" style="width: 200px; height: 200px; margin: 10px 70px 10px 70px">
                                            <asp:Image runat="server" ID="imgAnhDaiDien" CssClass="brand-image img-circle elevation-3" Style="width: 200px; height: 200px" />
                                        </div>
                                    </div>
                                </div>

                            </div>
                            <!-- /.col -->
                        </div>
                        <!-- /.row -->
                    </div>
                    <!-- /.card-body -->
                    <div class="card-footer">
                        <div class="row">
                            <div class="col-sm-8">
                                <p></p>
                            </div>
                            <div class="col-sm-2">
                                <asp:Button runat="server" ID="btnAdd" class="btn btn-primary" type="submit" Text="Thêm mới" OnClick="btnAdd_Click" />
                                <asp:Button runat="server" ID="btnSave" class="btn btn-primary" type="submit" Text="Sửa" OnClick="btnSave_Click" />
                                <%--<asp:Button runat="server" ID="btnAddcm" class="btn btn-success" type="submit" Text="Add Chuyen Muc" OnClick="btnAddcm_Click" />--%>
                            </div>
                            <div class="col-sm-2">
                                <asp:Button runat="server" ID="btnCancel" class="btn btn-danger" type="submit" Text="Hủy" OnClick="btnCancel_Click" />

                            </div>
                        </div>
                    </div>
                </div>
                <!-- /.card -->
            </div>
            <!-- /.container-fluid -->
            <div class="container-fluid col-md-4" runat="server" id="chuyenmuc">
                <!-- SELECT2 EXAMPLE -->
                <div class="card card-default">
                    <div class="card-header">
                        <h3 class="card-title">Chuyên mục</h3>

                        <div class="card-tools">
                            <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                <i class="fas fa-minus"></i>
                            </button>
                        </div>
                    </div>
                    <!-- /.card-header -->
                    <div class="card-body">
                        <div style="color:red; text-align:center">
                            <asp:Label runat="server" ID="lbhienthi" />
                        <asp:Label runat="server" ID="lbhienthi1" />
                        </div>
                        
                        <div class="form-group">
                            <label>Chuyên mục:</label>
                            <asp:DropDownList runat="server" ID="cbbChuyenMuc" CssClass="form-control select2" Style="width: 100%;"></asp:DropDownList>
                        </div>
                        <div class="form-group" runat="server" id="loaitk">
                            <label>Loại tài khoản:</label>
                            <asp:DropDownList runat="server" ID="cbbLoaiTK" CssClass="form-control select2"></asp:DropDownList>
                        </div>
                        <asp:GridView runat="server" ID="dgvcm" class="table table-bordered table-hover" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Tên Chuyên mục
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# getTenCM(int.Parse(Eval("ID_ChuyenMuc").ToString()))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Chức vụ
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <%# getChucVu(int.Parse(Eval("ID_LoaiTK").ToString()))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                        Chức năng
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" ID="btnXoaDGV" Text="Xóa"
                                            OnClientClick="return valid();"
                                            CommandArgument='<%# int.Parse(Eval("ID_ChuyenMuc").ToString()) %>'
                                            OnCommand="btnXoaDGV_Command" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <!-- /.row -->
                    </div>
                    <!-- /.card-body -->
                    <div class="card-footer">
                        <div class="">
                            <asp:Button runat="server" ID="btnAddcm" class="btn btn-success" type="submit" Text="Thêm chuyên mục" OnClick="btnAddcm_Click" />
                        </div>
                    </div>
                </div>
                <!-- /.card -->
            </div>
            <!-- /.container-fluid -->
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <!-- Select2 -->
    <script src="../Css_Js/plugins/select2/js/select2.full.min.js"></script>

    <!-- bs-custom-file-input -->
    <script src="../Css_Js/plugins/bs-custom-file-input/bs-custom-file-input.min.js"></script>
    <!-- Page specific script -->
    <script>
        $(function () {
            bsCustomFileInput.init();
        });
    </script>
    <script>
        $(function () {
            //Initialize Select2 Elements
            $('.select2').select2()

        })
    </script>
</asp:Content>
