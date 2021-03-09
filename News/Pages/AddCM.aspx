<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddCM.aspx.cs" Inherits="News.Pages.AddCM" %>

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
                        <h1>Chuyên mục</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Chuyên mục</li>
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
                    <div class="col-md-8">
                        <!-- general form elements -->
                        <div class="card">
                            <div class="card-header card-outline card-info ">
                                <div class="row">
                                    <div class="col-md-4">
                                        <h3 class="card-title">Danh sách chuyên mục</h3>
                                    </div>
                                    <div class="col-md-6"></div>
                                    <%--<button type="button" class="btn btn-primary float-right" id="btnthem" onclick="btnthem();">Thêm chuyên mục</button>--%>
                                    <div class="card-tools col-md-2">
                                        <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                            <i class="fas fa-minus"></i>
                                        </button>
                                    </div>
                                </div>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body table-responsive p-0" style="height: 380px;">
                                <asp:GridView runat="server" ID="dgvchuyenmuc" AutoGenerateColumns="false" class="table table-bordered table-head-fixed table-hover text-nowrap text-center">
                                    <Columns>
                                        <asp:BoundField DataField="ID_ChuyenMuc" HeaderText="ID" />
                                        <asp:BoundField DataField="TenChuyenMuc" HeaderText="Tên Chuyên Mục" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Tên Chuyên Mục Cha
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <%# getTen(int.Parse(Eval("ID_ChuyenMucCha").ToString())) %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Chức năng
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:Button runat="server" CssClass="btn btn-danger" ID="btnXoa" Text="Xóa"
                                                    OnClientClick="return valid();"
                                                    CommandArgument='<%#int.Parse(Eval("ID_ChuyenMuc").ToString()) %>'
                                                    OnCommand="btnXoa_Command" />

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <!-- /.card -->
                    </div>
                    <div class="col-md-4">
                        <div class="card card-default">
                            <div class="card-header">
                                <h3 class="card-title">Thêm chuyên mục
                                </h3>
                            </div>
                            <!-- /.card-header -->
                            <div class="card-body">
                                <div class="form-group">
                                    <label for="exampleInputEmail1">ID quảng cáo:</label>
                                    <asp:TextBox runat="server" ID="txtid" placeholder="ID tự động..." CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label for="exampleInputEmail1">Tên chuyên mục:</label>
                                    <asp:TextBox runat="server" ID="txtten" placeholder="" CssClass="form-control" ></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Chuyên mục cha:</label>
                                    <asp:DropDownList runat="server" ID="cbbchuyenmuccha" CssClass="form-control select2" style="width: 100%;" ></asp:DropDownList>
                                </div>
                                <!-- /.card-body -->
                            </div>
                            <div class="card-footer row">
                                <div class="col-sm-3"></div>
                                <div class="col-sm-3">
                                    <asp:Button runat="server" type="button" Text="Thêm chuyên mục" CssClass="btn btn-success" ID="btnadd" OnClick="btnadd_Click" />
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
<!-- Select2 -->
<script src="../Css_Js/plugins/select2/js/select2.full.min.js"></script>
    <script>
  $(function () {
    //Initialize Select2 Elements
    $('.select2').select2()

  })
    </script>
</asp:Content>
