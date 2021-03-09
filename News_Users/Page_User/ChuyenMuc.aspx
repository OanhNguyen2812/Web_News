<%@ Page Title="" Language="C#" MasterPageFile="~/Master_User/User_Master_Pages.Master" AutoEventWireup="true" CodeBehind="ChuyenMuc.aspx.cs" Inherits="News_Users.Page_User.ChuyenMuc.ChuyenMuc" EnableEventValidation="true" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Top News Start-->
    <%-- <div class="top-news">
            <div class="container">
                <div class="row">
                    <div class="col-md-6 tn-left">
                        <div class="row tn-slider">
                            
                                <asp:Repeater runat="server" ID="dgvchuyenmuc">
                                <ItemTemplate>
                                    <div class="col-md-6">
                                        <div class="tn-img">
                                            <img src="../../Css_Js/img/news-350x223-2.jpg" />
                                            <div class="tn-title">
                                                
                                                <a href="single_page.aspx"><%# idchuyenmuc(int.Parse(Eval("ID_ChuyenMuc").ToString())) %></a>
                                            </div>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            
                            
                        </div>
                    </div>
                   
                </div>
            </div>
        </div>--%>
    <!-- Top News End-->

    <div class="tab-news">
        <div class="container">
            <div class="row">
                <div class="col-lg-9">
                    <ul class="nav nav-pills nav-justified">
                        <div class="breadcrumb-wrap">
                            <div class="container">
                                <ul class="breadcrumb">
                                    <li class="breadcrumb-item"><a href="Main_pages.aspx">Home</a></li>
                                    <asp:Repeater runat="server" ID="tenchuyenmucotren">
                                        <ItemTemplate>
                                            <li class="breadcrumb-item">
                                                <asp:HyperLink runat="server" NavigateUrl='<%# "/Page_User/ChuyenMuc.aspx?ID_ChuyenMuc=" + Eval("ID_ChuyenMuc")%>'><%# Eval("TenChuyenMuc") %></asp:HyperLink>
                                                <%--<a href="#"><%# Eval("TenChuyenMuc") %></a>--%></li>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                    
                                </ul>
                            </div>
                        </div>
                       <%-- <li class="nav-item">
                            
                            <asp:Repeater runat="server" ID="tenchuyenmucotren">
                                <ItemTemplate>
                                    <a class="nav-link active" data-toggle="pill" href="#featured"><%# Eval("TenChuyenMuc") %></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </li>--%>
                    </ul>

                    <div class="tab-content">


                        <div id="featured" class="container tab-pane active">

                            <asp:Repeater ID="dgvchuyenmuc" runat="server">
                                <ItemTemplate>
                                    <div class="tn-news">
                                        <div class="tn-img">
                                            <%--<img src="../Css_Js/img/12011_Th_202012281419201188.png" />--%>
                                            <img src='<%# "../css_js/img/"+Eval("anhthum")%>' />
                                            <%--<a href="single_page.aspx"><%#  %></a>--%>
                                        </div>
                                        <div class="tn-title">
                                            <%--<asp:Label runat="server" ID="lblContactName" Text='<%# Eval("Tenbai") %>' />--%>
                                            <asp:HyperLink runat="server" NavigateUrl='<%# "/Page_User/single_page.aspx?ID_BaiViet=" + Eval("idbaiviet")%>'><%# Eval("Tenbai") %></asp:HyperLink>

                                            <%--<a href="single_page.aspx"><%# Eval("Tenbai") %></a>--%>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                            <table>
                                <tr>
                                    <td>
                                        <asp:PlaceHolder ID="plcPaging" runat="server" />
                                        <br />
                                        <asp:Label runat="server" ID="lblPageName" />
                                    </td>
                                </tr>
                            </table>


                        </div>

                    </div>
                    
                </div>
                <div class="col-lg-3">
                    <div class="mn-list">
                        <h2>Read More</h2>
                        <ul>
                            <asp:Repeater runat="server" ID="dgvbairandom">
                                <ItemTemplate>
                                    <li>
                                        <asp:HyperLink runat="server" NavigateUrl='<%# "/Page_User/single_page.aspx?ID_BaiViet=" + int.Parse(Eval("ID_BaiViet").ToString())%>'><%# getrd(Eval("TenBaiViet").ToString())%></asp:HyperLink>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
