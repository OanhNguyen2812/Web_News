<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="News.Pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">

    <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="../Css_Js/plugins/fontawesome-free/css/all.min.css">
    <!-- Ionicons -->
    <link rel="stylesheet" href="https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css">
    <!-- Tempusdominus Bootstrap 4 -->
    <link rel="stylesheet" href="../Css_Js/plugins/tempusdominus-bootstrap-4/css/tempusdominus-bootstrap-4.min.css">
    <!-- iCheck -->
    <link rel="stylesheet" href="../Css_Js/plugins/icheck-bootstrap/icheck-bootstrap.min.css">
    <!-- JQVMap -->
    <link rel="stylesheet" href="../Css_Js/plugins/jqvmap/jqvmap.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="dist/css/adminlte.min.css">
    <!-- overlayScrollbars -->
    <link rel="stylesheet" href="../Css_Js/plugins/overlayScrollbars/css/OverlayScrollbars.min.css">
    <!-- Daterange picker -->
    <link rel="stylesheet" href="../Css_Js/plugins/daterangepicker/daterangepicker.css">
    <!-- summernote -->
    <link rel="stylesheet" href="../Css_Js/plugins/summernote/summernote-bs4.min.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Content" runat="server">

    <div class="content-wrapper">
        <!-- Content Header (Page header) -->
        <div class="content-header">
            <div class="container-fluid">
                <div class="row mb-2">
                    <div class="col-sm-6">
                        <h1 class="m-0">Trang chủ</h1>
                    </div>
                    <!-- /.col -->
                    <div class="col-sm-6">
                        <ol class="breadcrumb float-sm-right">
                            <li class="breadcrumb-item"><a href="#">Home</a></li>
                            <li class="breadcrumb-item active">Trang chủ</li>
                        </ol>
                    </div>
                    <!-- /.col -->
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </div>
        <!-- /.content-header -->
        <!-- Main content -->
        <section class="content">
            <div class="container-fluid">
                <!-- Small boxes (Stat box) -->
                <div class="row" runat="server" id="admin">
                    <div class="col-lg-3 col-6">
                        <!-- small box -->
                        <div class="small-box bg-info">
                            <div class="inner">
                                <h3>
                                    <asp:Label runat="server" ID="lbcm"></asp:Label></h3>

                                <p>Tổng số chuyên mục</p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-paperclip"></i>
                            </div>
                            <a href="#" class="small-box-footer"><%--<i class="fas fa-arrow-circle-right"></i>--%></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-6">
                        <!-- small box -->
                        <div class="small-box bg-success">
                            <div class="inner">

                                <h3>
                                    <asp:Label runat="server" ID="lbnv"></asp:Label></h3>

                                <p>Tổng số nhân viên</p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-person"></i>
                            </div>
                            <a href="#" class="small-box-footer"><%--<i class="fas fa-arrow-circle-right"></i>--%></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-6">
                        <!-- small box -->
                        <div class="small-box bg-warning">
                            <div class="inner">

                                <h3>
                                    <asp:Label runat="server" ID="lbqc"></asp:Label></h3>

                                <p>Tổng số quảng cáo</p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-person-add"></i>
                            </div>
                            <a href="#" class="small-box-footer"><%--<%--<i class="fas fa-arrow-circle-right"></i>--%></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-6">
                        <!-- small box -->
                        <div class="small-box bg-danger">
                            <div class="inner">
                                <h3><% =Application["TatCa"].ToString()%></h3>
                                <p>Tổng số lượt truy cập website</p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-pie-graph"></i>
                            </div>
                            <a href="#" class="small-box-footer"><%--<i class="fas fa-arrow-circle-right"></i>--%></a>
                        </div>
                    </div>
                    <!-- ./col -->
                </div>
                <!-- /.row -->

                <!-- Small boxes (Stat box) -->
                <div class="row" runat="server" id="tongbien">
                    <div class="col-lg-3 col-6">
                        <!-- small box -->
                        <div class="small-box bg-info">
                            <div class="inner">
                                <h3>
                                    <asp:Label runat="server" ID="lbbvduyet"></asp:Label></h3>

                                <p>Số bài viết đã duyệt</p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-paperclip"></i>
                            </div>
                            <a href="#" class="small-box-footer"><%--<i class="fas fa-arrow-circle-right"></i>--%></a>
                        </div>
                    </div>
                    <!-- ./col -->
                    <div class="col-lg-3 col-6">
                        <!-- small box -->
                        <div class="small-box bg-success">
                            <div class="inner">

                                <h3>
                                    <asp:Label runat="server" ID="lbbvcd"></asp:Label></h3>

                                <p>Số bài viết chưa duyệt</p>
                            </div>
                            <div class="icon">
                                <i class="ion ion-person"></i>
                            </div>
                            <a href="#" class="small-box-footer"><%--<i class="fas fa-arrow-circle-right"></i>--%></a>
                        </div>
                    </div>
                    <!-- ./col -->
                </div>
                <!-- /.row -->

                <!-- CHART -->
                <div class="row">
                    <div class="col-md-6">
                        <!-- AREA CHART -->
                        <div>
                            <div class="card card-primary">
                                <div class="card-header">
                                    <h3 class="card-title">Lượt truy cập trong tháng</h3>

                                    <div class="card-tools">
                                        <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                            <i class="fas fa-minus"></i>
                                        </button>
                                    </div>
                                </div>
                                <div class="card-body">
                                    <div class="chart">
                                        <canvas id="areaChart" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>
                                    </div>
                                </div>
                                <!-- /.card-body -->
                                <div class="card-footer">
                                    <div class="row">
                                        <label style="width: 50px; height: 20px;"></label>
                                        <label style="width: 100px; height: 20px; background-color: rgba(60,141,188,0.9)"></label>
                                        <label style="width: 10px; height: 20px;"></label>
                                        <label style="color: #071019">Tháng này</label>
                                        <label style="width: 100px; height: 20px;"></label>
                                        <label style="width: 100px; height: 20px; background-color: rgba(210, 214, 222, 1)"></label>
                                        <label style="width: 10px; height: 20px;"></label>
                                        <label style="color: #071019">Tháng Trước</label>
                                    </div>
                                </div>
                            </div>
                            <!-- /.card -->
                            <!-- /.col (LEFT) -->
                        </div>
                        <!-- BAR CHART -->
                        <div class="card card-success">
                            <div class="card-header">
                                <h3 class="card-title">Bar Chart</h3>

                                <div class="card-tools">
                                    <button type="button" class="btn btn-tool" data-card-widget="collapse">
                                        <i class="fas fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="card-body">
                                <div class="chart">
                                    <canvas id="barChart" style="min-height: 250px; height: 250px; max-height: 250px; max-width: 100%;"></canvas>
                                </div>
                            </div>
                            <!-- /.card-body -->
                        </div>
                        <!-- /.card -->

                    </div>
                    <div class="col-md-6 ">
                        <div class="card-body table-responsive p-0" style="height: 380px;">
                            <asp:GridView runat="server" ID="dgvbaivietmaxmonth" AutoGenerateColumns="false" class="table table-bordered table-head-fixed table-hover text-nowrap text-center">
                                <Columns>
                                    <asp:TemplateField HeaderText="STT">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ID_User" HeaderText="id" />
                                    <asp:BoundField DataField="TenUser" HeaderText="Ten" />
                                    <asp:BoundField DataField="SoLuong" HeaderText="Soluong" />
                                    
                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                    <!-- /.col (RIGHT) -->
                </div>
                <div class="row">
                    <div>
                        <asp:TextBox runat="server" ID="txttext1">
                        </asp:TextBox>
                    </div>
                    <div>
                        <asp:TextBox runat="server" ID="txttext2">
                        </asp:TextBox>
                    </div>
                </div>
                <!-- /.row -->
            </div>
            <!-- /.container-fluid -->
        </section>
        <!-- /.content -->

    </div>
    <!-- /.content-wrapper -->

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Script" runat="server">
    <!-- jQuery -->
    <script src="../Css_Js/plugins/jquery/jquery.min.js"></script>
    <script src="../Css_Js/../Css_Js/plugins/jquery/jquery.min.js"></script>
    <!-- jQuery UI 1.11.4 -->
    <script src="../Css_Js/plugins/jquery-ui/jquery-ui.min.js"></script>
    <!-- Resolve conflict in jQuery UI tooltip with Bootstrap tooltip -->
    <script>
        $.widget.bridge('uibutton', $.ui.button)
    </script>
    <!-- Bootstrap 4 -->
    <script src="../Css_Js/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
    <!-- ChartJS -->
    <script src="../Css_Js/plugins/chart.js/Chart.min.js"></script>
    <!-- Sparkline -->
    <script src="../Css_Js/plugins/sparklines/sparkline.js"></script>
    <!-- JQVMap -->
    <script src="../Css_Js/plugins/jqvmap/jquery.vmap.min.js"></script>
    <script src="../Css_Js/plugins/jqvmap/maps/jquery.vmap.usa.js"></script>
    <!-- jQuery Knob Chart -->
    <script src="../Css_Js/plugins/jquery-knob/jquery.knob.min.js"></script>
    <!-- daterangepicker -->
    <script src="../Css_Js/plugins/moment/moment.min.js"></script>
    <script src="../Css_Js/plugins/daterangepicker/daterangepicker.js"></script>
    <!-- Tempusdominus Bootstrap 4 -->
    <script src="../Css_Js/plugins/tempusdominus-bootstrap-4/js/tempusdominus-bootstrap-4.min.js"></script>
    <!-- Summernote -->
    <script src="../Css_Js/plugins/summernote/summernote-bs4.min.js"></script>
    <!-- overlayScrollbars -->
    <script src="../Css_Js/plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js"></script>
    <!-- AdminLTE for demo purposes -->
    <script src="../Css_Js/dist/js/demo.js"></script>
    <!-- AdminLTE dashboard demo (This is only for demo purposes) -->
    <script src="../Css_Js/dist/js/pages/dashboard.js"></script>
    <!-- jQuery -->
    <script src="../Css_Js/plugins/jquery/jquery.min.js"></script>
    <!-- AdminLTE App -->
    <script src="../Css_Js/dist/js/adminlte.min.js"></script>
    <!-- Page specific script -->
    <script>
        $(function () {

            var dataTest = document.getElementById('Content_txttext1').value;
            var arrData = dataTest.split("/");
            var arrData1 = [];
            for (var i = 0; i < arrData.length; i++) {
                arrData1.push(parseInt(arrData[i]));
            }
            console.log(arrData1);

            var dataTest2 = document.getElementById('Content_txttext2').value;
            var arrData2 = dataTest2.split("/");
            var arrData3 = [];
            for (var i = 0; i < arrData2.length; i++) {
                arrData3.push(parseInt(arrData2[i]));
            }
            console.log(arrData3);

            var areaChartCanvas = $('#areaChart').get(0).getContext('2d')

            var areaChartData = {
                labels: ['1', '2', '3', '4', '5', '6', '7', '8', '9', '10', '11', '12', '13', '14', '15', '16', '17', '18', '19', '20', '21', '22', '23', '24', '25', '26', '27', '28', '29', '30', '31'],
                datasets: [
                    {
                        label: 'ThisMonth',
                        backgroundColor: 'rgba(60,141,188,0.9)',
                        borderColor: 'rgba(60,141,188,0.8)',
                        pointRadius: false,
                        pointColor: '#3b8bba',
                        pointStrokeColor: 'rgba(60,141,188,1)',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(60,141,188,1)',
                        data: arrData1
                    },
                    {
                        label: 'LastMonth',
                        backgroundColor: 'rgba(210, 214, 222, 1)',
                        borderColor: 'rgba(210, 214, 222, 1)',
                        pointRadius: false,
                        pointColor: 'rgba(210, 214, 222, 1)',
                        pointStrokeColor: '#c1c7d1',
                        pointHighlightFill: '#fff',
                        pointHighlightStroke: 'rgba(220,220,220,1)',
                        data: arrData3
                    },
                ]
            }

            var areaChartOptions = {
                maintainAspectRatio: false,
                responsive: true,
                legend: {
                    display: false
                },
                scales: {
                    xAxes: [{
                        gridLines: {
                            display: false,
                        }
                    }],
                    yAxes: [{
                        gridLines: {
                            display: false,
                        }
                    }]
                }
            }


            // This will get the first returned node in the jQuery collection.
            var areaChart = new Chart(areaChartCanvas, {
                type: 'line',
                data: areaChartData,
                options: areaChartOptions
            })

            //-------------
            //- BAR CHART -
            //-------------
            var barChartCanvas = $('#barChart').get(0).getContext('2d')
            var barChartData = $.extend(true, {}, areaChartData)
            var temp0 = areaChartData.datasets[0]
            var temp1 = areaChartData.datasets[1]
            barChartData.datasets[0] = temp1
            barChartData.datasets[1] = temp0

            var barChartOptions = {
                responsive: true,
                maintainAspectRatio: false,
                datasetFill: false
            }

            var barChart = new Chart(barChartCanvas, {
                type: 'bar',
                data: barChartData,
                options: barChartOptions
            })

        })
</script>
</asp:Content>
