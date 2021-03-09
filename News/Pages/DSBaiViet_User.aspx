<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="DSBaiViet_User.aspx.cs" Inherits="News.Pages.DSBaiViet_User" %>

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
                        <h1>Danh sách bài viết cá nhân</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Danh sách bài viết cá nhân</li>
                        </ol>
                    </div>
                </div>
            </div>
            <!-- /.container-fluid -->
        </section>

        <!-- Main content -->
        <section class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="card card-outline card-info">
                        <div class="card-header">
                            <asp:Button runat="server" ID="btnnew" class="btn btn-success" Text="Thêm mới bài viết" OnClick="btnnew_Click" />
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body">
                            <asp:GridView runat="server" ID="dgvbaiviet" CssClass="table table-bordered table-hover text-center " AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField DataField="ID_BaiViet" HeaderText="ID" />
                                    <asp:BoundField DataField="TenBaiViet" HeaderText="Tên Bài Viết" />
                                    <asp:TemplateField ControlStyle-CssClass="text-center">
                                        <HeaderTemplate>
                                            Chuyên Mục
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# getCM((int)Eval("ID_ChuyenMuc")) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                            Trạng Thái
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <%# gettrangthai(bool.Parse(Eval("TrangThai").ToString())) %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TGViet" HeaderText="Thời Gian Viết" />
                                    <asp:TemplateField ControlStyle-CssClass="text-center">
                                        <HeaderTemplate>
                                            Chức Năng
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <button class="btn btn-warning">
                                                <asp:HyperLink runat="server" ID="btnchitiet" Text="Sửa bài" NavigateUrl='<%# "Detail_Page.aspx?mabv=" + Eval("ID_BaiViet").ToString() %>' />
                                            </button>
                                            <br />
                                            <br />
                                            <button class="btn btn-danger">
                                                <asp:LinkButton runat="server" ID="btnXoa" Text="Xóa"
                                                    OnClientClick="return valid();"
                                                    CommandArgument='<%# int.Parse(Eval("ID_BaiViet").ToString()) %>'
                                                    OnCommand="btnXoa_Command" />
                                            </button>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div class="card-footer ">
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col-->
        </section>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
</asp:Content>
