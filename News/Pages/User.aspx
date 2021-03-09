<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="News.Pages.User" %>

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
                        <h1>Nhân Viên</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Nhân Viên</li>
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
                        <div class="row">
                            <div class="col-md-2">
                                <asp:Button runat="server" ID="btnadd" Text="thêm mới" CssClass="btn btn-primary" OnClick="btnadd_Click" />
                            </div>
                            <div class="col-md-9">
                            </div>
                            <div class="card-tools col-md-1">
                                <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                    <i class="fas fa-minus"></i>
                                </button>
                            </div>
                        </div>
                    </div>
                    <!-- /.card-header -->
                    <div class="card-body">

                            <asp:GridView runat="server" ID="dgvuser" class="table table-bordered table-hover text-center" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="ID_User" HeaderText="ID" />
                                    <asp:BoundField DataField="TenUser" HeaderText="Tên Nhân Viên" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Ảnh Đại Diện
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <img width="80px" src='<%# "../Images/Users/" + Eval("AnhDaiDien") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Loại Tài Khoản
                                        </HeaderTemplate>   
                                        <ItemTemplate>
                                            <div>
                                                <%# getTenLoaiTK(int.Parse(Eval("ID_User").ToString())) %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Chuyên Mục
                                        </HeaderTemplate>   
                                        <ItemTemplate>
                                            <div style="width: 400px">
                                                <%# getCM(int.Parse(Eval("ID_User").ToString())) %>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Chức năng
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <button class="btn btn-outline-success">
                                                <asp:HyperLink runat="server" ID="btnchitiet" Text="Chi Tiết" NavigateUrl='<%# "Detail-User.aspx?manv=" + Eval("ID_User").ToString() %>' />
                                            </button>
                                            <br />
                                            <br />
                                            <button class="btn btn-warning">
                                                <asp:LinkButton runat="server" ID="btnXoa" Text="Xóa"
                                                    OnClientClick="return valid();"
                                                    CommandArgument='<%# int.Parse(Eval("ID_User").ToString()) %>'
                                                    OnCommand="btnXoa_Command" />
                                            </button>

                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <!-- /.row -->
                </div>
                <!-- /.card-body -->
            </div>
            <!-- /.container-fluid -->
        </section>
        <!-- /.content -->
    </div>
    <!-- /.content-wrapper -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
