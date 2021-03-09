<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Detail_Page.aspx.cs" Inherits="News.Pages.Detail_Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <title>AdminLTE 3 | Editors</title>
    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback" />
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../Css_Js/plugins/fontawesome-free/css/all.min.css" />
    <!-- Theme style -->
    <link rel="stylesheet" href="../Css_Js/dist/css/adminlte.min.css" />
    <!-- Select2 -->
    <link rel="stylesheet" href="../Css_Js/plugins/select2/css/select2.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">
    <!-- Content Wrapper. Contains page content -->
    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <section class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1>Bài viết</h1>
                    </div>
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Bài viết</li>
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
                            <div class="row">
                                <div class="col-md-4">
                                    <h3 class="card-title">Chi tiết bài viết
                                </h3>
                                </div>
                                <div class="col-md-6"></div>
                                <div class="col-md-2">
                                    <%--<asp:Button runat="server" ID="btnpre" CssClass="btn btn-success" OnClick="btnpre_Click" Text="Xem trước" />--%>
                                </div>
                            </div>

                        </div>
                        <!-- /.card-header -->
                        <div class="card-body row">
                            <div class="col-md-1 ">
                            </div>
                            <div class="col-md-10">
                                <div class="form-group row">
                                    <label for="" class="col-sm-2 col-form-label">Tiêu đề bài viết:</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" type="text" CssClass="form-control" ID="txttieude" placeholder="" required=""></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="" class="col-sm-2 col-form-label">Tóm tắt:</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" TextMode="MultiLine" Rows="2" Columns="50" type="text" CssClass="form-control" ID="txttomtat" required=""></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Chuyên mục:</label>
                                    <div class="col-sm-7">
                                        <asp:DropDownList runat="server" CssClass=" form-control select2 m-b" ID="cbbChuyenMuc" data-placeholder="Select a State" Style="width: 100%;">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label class="col-sm-2 col-form-label">Ảnh thumbnail</label>
                                    <div class="col-sm-5">
                                        <div class="input-group">
                                            <div class="custom-file">
                                                <asp:FileUpload runat="server" type="file" CssClass="custom-file-input" ID="fumain" />
                                                <label class="custom-file-label" for="exampleInputFile">Choose file</label>
                                            </div>
                                        </div>
                                        <asp:Image runat="server" />
                                    </div>
                                </div>
                                <div class="form-group row">
                                    <label for="" class="col-sm-2 col-form-label">Nội dung bài viết:</label>
                                    <div class="col-sm-10">
                                        <asp:TextBox runat="server" TextMode="MultiLine" Rows="5" ID="txtnoidung" required=""></asp:TextBox>
                                    </div>
                                </div>

                            </div>

                        </div>
                        <%--<div class="card-footer row">
                            <div class="col-md-9">
                                
                            </div>
                            <div class="col-md-2">
                                <asp:Button runat="server" ID="btnAdd" class="btn btn-success " type="submit" Text="Thêm bài viết" OnClick="btnAdd_Click" />
                                <asp:Button runat="server" ID="btnSave" class="btn btn-success " type="submit" Text="Sửa bài viết" OnClick="btnSave_Click" />
                            </div>
                            <div class="col-md-1">
                                <asp:Button runat="server" ID="btnCancel" class="btn btn-danger " type="submit" Text="   Hủy   " />
                            </div>
                        </div>--%>
                    </div>
                </div>
                <!-- /.col-->
                <div class="col-md-4">
                    <div class="card">
                        <div class="card-header">
                            <div class="row">
                                <div class="col-sm-6">
                                    <h3 class="card-title">Chi tiết bài viết
                                    </h3>
                                </div>

                                <div class="col-sm-2">
                                    <%--<asp:Button runat="server" ID="btnpre" CssClass="btn btn-success" OnClick="btnpre_Click" Text="Xem trước" />--%>
                                </div>
                            </div>

                        </div>
                        <!-- /.card-header -->

                        <div class="card-body">
                        </div>
                        <div class="card-footer">
                            <div class="row">
                                <div class="col-sm-4">
                                </div>
                                <div class="col-sm-5">
                                    <asp:Button runat="server" ID="btnAdd" class="btn btn-success " type="submit" Text="Thêm bài viết" OnClick="btnAdd_Click" />
                                    <asp:Button runat="server" ID="btnSave" class="btn btn-success " type="submit" Text="Sửa bài viết" OnClick="btnSave_Click" />
                                </div>
                                <div class="col-sm-1">
                                    <asp:Button runat="server" ID="btnCancel" class="btn btn-danger " type="submit" Text="   Hủy   " />
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
                <!-- /.col-->
            </div>
            <!-- ./row -->
        </section>
        <!-- /.content -->
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">

    <!-- jQuery -->
    <script src="../Css_Js/plugins/jquery/jquery.min.js"></script>
    <!-- Bootstrap 4 -->
    <script src="../Css_Js/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../Css_Js/dist/js/adminlte.min.js"></script>
    <!-- bs-custom-file-input -->
    <script src="../Css_Js/plugins/bs-custom-file-input/bs-custom-file-input.min.js"></script>
    <!-- Select2 -->
    <script src="../Css_Js/plugins/select2/js/select2.full.min.js"></script>

    <script src="../Admin/Tools/ckeditor/ckeditor.js"></script>
    <script src="../Admin/Tools/ckfinder/ckfinder.js"></script>
    <script>

        $(document).ready(function () {
            CKEDITOR.config.language = "vi";
            CKEDITOR.config.htmlEncodeOutput = false;
            CKEDITOR.config.ProcessHTMLEntities = false;
            CKEDITOR.config.entities = false;
            CKEDITOR.config.entities_latin = false;
            CKEDITOR.replace('Content_txtnoidung',
                {
                    filebrowserBrowseUrl: '../Admin/Tools/ckfinder/ckfinder.html',
                    filebrowserImageBrowseUrl: '../Admin/Tools/ckfinder/ckfinder.html?type=Images',
                    filebrowserUploadUrl: '../Admin/Tools/ckfinder/connector?command=QuickUpload&type=Files&currentFolder=/archive/',
                    filebrowserImageUploadUrl: '../Admin/Tools/ckfinder/connector?command=QuickUpload&type=Files&currentFolder=/Posts/'
                });
        });
</script>

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
    <script>
        $(function () {
            bsCustomFileInput.init();
        });
  </script>
</asp:Content>
