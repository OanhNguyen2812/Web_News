<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/NhanVien/Master_User.Master" AutoEventWireup="true" CodeBehind="DSBaiViet_User.aspx.cs" Inherits="News.Pages.NhanVien.DSBaiViet_User" %>
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
                        <h1>Text Editors</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Text Editors</li>
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
                            <h3 class="card-title">Summernote </h3>
                        </div>
                        <!-- /.card-header -->
                        <div class="card-body row">
                            <div class="row">
                                <asp:GridView runat="server" ID="dgvbaiviet" CssClass="table table-bordered table-hover" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField DataField="ID_BaiViet" HeaderText="ID" />
                                        <asp:BoundField DataField="TenBaiViet" HeaderText="Tên Bài Viết" />
                                        <asp:TemplateField>
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
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                Chức Năng
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:HyperLink runat="server" ID="btnchitiet" Text="Chi Tiết" NavigateUrl='<%# "BaiViet.aspx?mabv=" + Eval("ID_BaiViet").ToString() %>' />
                                                <asp:LinkButton runat="server" ID="btnXoa" Text="Xóa"
                                                    OnClientClick="return valid();"
                                                    CommandArgument='<%# int.Parse(Eval("ID_BaiViet").ToString()) %>'
                                                    OnCommand="btnXoa_Command" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                        <div class="card-footer row">
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
