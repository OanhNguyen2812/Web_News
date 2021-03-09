﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Read/Master_User/User_Master_Pages.Master" AutoEventWireup="true" CodeBehind="Main_pages.aspx.cs" Inherits="News.Read.Page_User.Main_pages" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Top News Start-->
    <div class="top-news">
        <div class="container">
            <div class="row">
                <div class="col-md-8 tn-left">
                    <div class="row tn-slider">
                        <asp:Repeater runat="server" ID="dgvbaivietmoi">
                            <ItemTemplate>
                                <div class="col-md-12">
                                    <div class="tn-img" style="width:750px;height:480px">
                                        <%--<img src="../../Images/Thums/12010_Th_202012281406436302.png" />--%>
                                        <img src='<%# "../../Images/Thums/"+ layanhbaivietmoi(int.Parse(Eval("ID_BaiViet").ToString())) %>' />
                                        <div class="tn-title">
                                            <asp:HyperLink runat="server" NavigateUrl='<%# "/Read/Page_User/single_page.aspx?ID_BaiViet=" + int.Parse(Eval("ID_BaiViet").ToString())%>'><%# slidebaivietmoi(Eval("TenBaiViet").ToString()) %></asp:HyperLink>

                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="col-md-4">
                    <ul class="nav nav-pills nav-justified">
                        <li class="nav-item">
                            <a class="nav-link active" data-toggle="pill" href="#newposts">New Posts</a>
                        </li>
                    </ul>

                    <div class="tab-content" style="padding: 30px 20px 30px 20px">
                        <div id="newposts" class="container tab-pane active">
                            <asp:Repeater runat="server" ID="dgvnewposts">
                                <ItemTemplate>
                                    <div class="tn-news">
                                        <div class="tn-img" style="width:280px;height:200px">
                                            <img src='<%# "../../Images/Thums/"+ layanhthumbnailnewposts(int.Parse(Eval("ID_BaiViet").ToString())) %>' />
                                            <%--<img src="../../Images/Thums/news-350x223-1.jpg" />--%>
                                            <div class="tn-title">
                                                <asp:HyperLink runat="server" NavigateUrl='<%# "/Read/Page_User/single_page.aspx?ID_BaiViet=" + int.Parse(Eval("ID_BaiViet").ToString())%>'><%# Eval("TenBaiViet") %></asp:HyperLink>
                                            </div>
                                        </div>

                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Top News End-->


    <!-- Category News Start-->
    <div class="cat-news">
        <div class="container">
            <div class="row">
                <asp:Repeater runat="server" ID="dgvchuyenmuccha" OnItemDataBound="dgvchuyenmuccha_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-md-12">
                            <br />
                            <br />
                            <h2><%# Eval("TenChuyenMuc").ToString()%>
                                <asp:Repeater runat="server" ID="shortlinkcmcon" OnItemDataBound="shortlinkcmcon_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Label runat="server" ID="shortlinkcmcon11">
                                            <span>
                                                <%# Eval("TenChuyenMuc")%> 
                                            </span>
                                        </asp:Label>
                                        <%-- <h2> <%# Eval("TenChuyenMuc").ToString()%></h2>--%>
                                        <%-- <span>/<%# Eval("TenChuyenMuc")%></span>--%>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </h2>

                            <div class="row cn-slider">
                                <asp:Repeater runat="server" ID="dgvchuyenmuccon" OnItemDataBound="dgvchuyenmuccon_ItemDataBound">
                                    <ItemTemplate>
                                        <asp:Repeater runat="server" ID="dgvctbv">
                                            <ItemTemplate>
                                                <div class="col-md-3">
                                                    <div class="cn-img" style="width: 270px; height: 160px">
                                                        <img src='<%# "../../Images/Thums/" + Eval("AnhThumbnail")%>' />
                                                        <%--<img src="../../Images/Thums/12011_Th_202012281419201189.jpg" />--%>
                                                        <div class="cn-title">
                                                            <asp:HyperLink runat="server" NavigateUrl='<%# "/Read/Page_User/single_page.aspx?ID_BaiViet=" + int.Parse(Eval("ID_BaiViet").ToString())%>'><%# Eval("TenBaiViet") %></asp:HyperLink>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
    <!-- Category News End-->



    <!-- Tab News Start-->
    <div class="tab-news">
        <div class="container">
            <div class="row">
                <div class="col-md-6">
                    <ul class="nav nav-pills nav-justified">
                        <li class="nav-item">
                            <a class="nav-link active" data-toggle="pill" href="#featured">Featured News</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="pill" href="#popular">Popular News</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="pill" href="#latest">Latest News</a>
                        </li>
                    </ul>

                    <div class="tab-content" style="height: 450px">
                        <div id="featured" class="container tab-pane active">
                            <asp:Repeater runat="server" ID="dgvfeatured">
                                <ItemTemplate>
                                    <div class="tn-news">
                                        <div class="tn-img">

                                            <img src='<%# "../../Images/Thums/"+ layanhthumbnailfeature(int.Parse(Eval("ID_BaiViet").ToString())) %>' />
                                            <%-- <img src="../../Images/Thums/news-350x223-1.jpg" />--%>
                                        </div>
                                        <div class="tn-title">
                                            <asp:HyperLink runat="server" NavigateUrl='<%# "/Read/Page_User/single_page.aspx?ID_BaiViet=" + int.Parse(Eval("ID_BaiViet").ToString())%>'><%# Eval("TenBaiViet") %></asp:HyperLink>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>

                        </div>
                        <div id="popular" class="container tab-pane fade">
                            <asp:Repeater runat="server" ID="dgvpopular">
                                <ItemTemplate>
                                    <div class="tn-news">
                                        <div class="tn-img">
                                            <img src='<%# "../../Images/Thums/"+ layanhthumbnailpopular(int.Parse(Eval("ID_BaiViet").ToString())) %>' />
                                        </div>
                                        <div class="tn-title">
                                            <asp:HyperLink runat="server" NavigateUrl='<%# "/Read/Page_User/single_page.aspx?ID_BaiViet=" + int.Parse(Eval("ID_BaiViet").ToString())%>'><%# Eval("TenBaiViet") %></asp:HyperLink>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div id="latest" class="container tab-pane fade">
                            <asp:Repeater runat="server" ID="dgvlastest">
                                <ItemTemplate>
                                    <div class="tn-news">
                                        <div class="tn-img">
                                            <img src='<%# "../../Images/Thums/"+ layanhthumbnaillasest(int.Parse(Eval("ID_BaiViet").ToString())) %>' />
                                        </div>
                                        <div class="tn-title">
                                            <asp:HyperLink runat="server" NavigateUrl='<%# "/Read/Page_User/single_page.aspx?ID_BaiViet=" + int.Parse(Eval("ID_BaiViet").ToString())%>'><%# Eval("TenBaiViet") %></asp:HyperLink>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>

                <div class="col-md-6">
                    <ul class="nav nav-pills nav-justified">
                        <li class="nav-item">
                            <a class="nav-link active" data-toggle="pill" href="#m-viewed">Most Viewed</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="pill" href="#m-read">Most Read</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" data-toggle="pill" href="#m-recent">Most Recent</a>
                        </li>
                    </ul>

                    <div class="tab-content" style="height: 450px">
                        <div id="m-viewed" class="container tab-pane active">
                            <asp:Repeater runat="server" ID="dgvmostview">
                                <ItemTemplate>
                                    <div class="tn-news">
                                        <div class="tn-img">

                                            <img src='<%# "../../Images/Thums/"+ layanhthumbnailmostview(int.Parse(Eval("ID_BaiViet").ToString())) %>' />
                                            <%-- <img src="../../Images/Thums/news-350x223-1.jpg" />--%>
                                        </div>
                                        <div class="tn-title">
                                            <asp:HyperLink runat="server" NavigateUrl='<%# "/Read/Page_User/single_page.aspx?ID_BaiViet=" + int.Parse(Eval("ID_BaiViet").ToString())%>'><%# Eval("TenBaiViet") %></asp:HyperLink>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div id="m-read" class="container tab-pane fade">
                            <asp:Repeater runat="server" ID="dgvmostread">
                                <ItemTemplate>
                                    <div class="tn-news">
                                        <div class="tn-img">
                                            <asp:HyperLink runat="server" NavigateUrl='<%# "/Read/Page_User/single_page.aspx?ID_BaiViet=" + int.Parse(Eval("ID_BaiViet").ToString())%>'><%# Eval("TenBaiViet") %></asp:HyperLink>
                                        </div>
                                        <div class="tn-title">

                                            <a href=""><%# laytenbaivietmostread(int.Parse(Eval("ID_BaiViet").ToString())) %></a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                        <div id="m-recent" class="container tab-pane fade">
                            <asp:Repeater runat="server" ID="dgvmostrecent">
                                <ItemTemplate>
                                    <div class="tn-news">
                                        <div class="tn-img">
                                            <asp:HyperLink runat="server" NavigateUrl='<%# "/Read/Page_User/single_page.aspx?ID_BaiViet=" + int.Parse(Eval("ID_BaiViet").ToString())%>'><%# Eval("TenBaiViet") %></asp:HyperLink>
                                        </div>
                                        <div class="tn-title">

                                            <a href=""><%# laytenbaivietmostrecent(int.Parse(Eval("ID_BaiViet").ToString())) %></a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Tab News Start-->

    <!-- Main News Start-->
    <div class="main-news">
        <div class="container">
            <div class="row">
                <div class="col-lg-9">
                    <div class="row">
                        <asp:Repeater runat="server" ID="tatcabaiviet">
                            <HeaderTemplate>
                                <table>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <div class="col-md-4">
                                    <div class="mn-img" style="width:250px; height:145px">
                                        <img src='<%# "../../Images/Thums/"+ laytatcaanhthumbnail(int.Parse(Eval("idbaiviet").ToString())) %>' />
                                        <div class="mn-title">
                                            <asp:HyperLink runat="server" NavigateUrl='<%# "/Read/Read/Page_User/single_page.aspx?ID_BaiViet=" + int.Parse(Eval("idbaiviet").ToString())%>'><%# (Eval("Tenbai").ToString()) %></asp:HyperLink>

                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <table>
                            <tr>
                                <td>
                                    <asp:PlaceHolder runat="server" ID="plcPage"></asp:PlaceHolder>
                                    <br />
                                    <asp:Label runat="server" ID="lbl_Click"></asp:Label>
                                    <%--<asp:LinkButton ID="lbl_Click" runat="server" class="btn btn-primary"> </asp:LinkButton>--%>
                                         
                                </td>
                            </tr>
                        </table>

                    </div>

                </div>

                <div class="col-lg-3">
                    <div class="mn-list">
                        <h2>Read More</h2>
                        <ul>
                            <asp:Repeater runat="server" ID="dgvvietrandom">
                                <ItemTemplate>
                                    <li>
                                        <asp:HyperLink runat="server" NavigateUrl='<%# "/Read/Page_User/single_page.aspx?ID_BaiViet=" + int.Parse(Eval("ID_BaiViet").ToString())%>'><%# showvietrandom(Eval("TenBaiViet").ToString()) %></asp:HyperLink>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Main News End-->

</asp:Content>
