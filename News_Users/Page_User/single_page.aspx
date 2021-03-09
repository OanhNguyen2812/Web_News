<%@ Page Title="" Language="C#" MasterPageFile="~/Master_User/User_Master_Pages.Master" AutoEventWireup="true" CodeBehind="single_page.aspx.cs" Inherits="News_Users.Page_User.single_page" %>

<%--<%@ Register Src="~/Page_User/comment.ascx" TagPrefix="uc1" TagName="comment" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Breadcrumb Start -->
    <div class="breadcrumb-wrap">
        <div class="container">
            <ul class="breadcrumb">
                <li class="breadcrumb-item"><a href="Main_pages.aspx">Home</a></li>
                <asp:Repeater runat="server" ID="shortlinkcm">
                    <ItemTemplate>
                        <li class="breadcrumb-item">
                            <asp:HyperLink runat="server" NavigateUrl='<%# "/Page_User/ChuyenMuc.aspx?ID_ChuyenMuc=" + Eval("ID_ChuyenMuc")%>'><%# Eval("TenChuyenMuc") %></asp:HyperLink>

                        </li>
                    </ItemTemplate>
                </asp:Repeater>

            </ul>
        </div>
    </div>
    <!-- Breadcrumb End -->

    <!-- Single News Start-->
    <div class="single-news">
        <div class="container">
            <div class="row">
                <div class="col-lg-8">
                    <div class="sn-container">
                        <asp:Repeater runat="server" ID="chitietbaiviet">
                            <ItemTemplate>
                                <div class="sn-header" style="text-align: right">
                                    <p>Time: <%# Eval("TGViet") %></p>
                                    <%--<img src='<%# "../css_js/img/"+ Eval("AnhThumbnail") %>' />--%>
                                </div>
                                <div class="sn-content">

                                    <h1 class="sn-title"><%#  Eval("TenBaiViet") %></h1>
                                    <h4 class="sn-title"><%#  Eval("TomTat") %></h4>
                                    <p>
                                        <%# Eval("NoiDung") %>
                                    </p>

                                </div>
                                <div class="sn-sinature" style="text-align: right">
                                    <p>Author: <%#  getsignature(int.Parse(Eval("ID_User").ToString())) %></p>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                    <div class="sn-related">
                        <h2>Related News</h2>
                        <div class="row sn-slider">

                            <asp:Repeater runat="server" ID="dgvrelatedmoi">
                                <ItemTemplate>

                                    <div class="col-md-4">
                                        <div class="sn-img">

                                            <%-- <img src='<%# "../css_js/img/"+ anhrelatednewmoi(int.Parse(Eval("ID_BaiViet").ToString())) %>'/>--%>
                                            <img src="../Css_Js/img/12011_Th_202012281419201189.jpg" />
                                            <div class="sn-title">
                                                <asp:HyperLink runat="server" NavigateUrl='<%# "/Page_User/single_page.aspx?ID_BaiViet=" + int.Parse(Eval("ID_BaiViet").ToString())%>'><%# relatednewmoi(Eval("TenBaiViet").ToString()) %></asp:HyperLink>

                                            </div>
                                        </div>
                                    </div>


                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>

                <div class="col-lg-4">
                    <div class="sidebar">
                        <div class="sidebar-widget">
                            <h2 class="sw-title">In This Category</h2>
                            <div class="news-list">
                                <asp:Repeater ID="cungthumuc" runat="server">
                                    <ItemTemplate>
                                        <div class="nl-item">
                                            <div class="nl-img">
                                                <img src='<%# "../css_js/img/"+Eval("AnhThumbnail")%>' />
                                            </div>
                                            <div class="nl-title">
                                                <asp:HyperLink runat="server" NavigateUrl='<%# "/Page_User/single_page.aspx?ID_BaiViet=" + Eval("ID_BaiViet")%>'><%# Eval("TenBaiViet") %></asp:HyperLink>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="sidebar-widget">
                            <div class="image">
                                <a href="https://htmlcodex.com">
                                    <img src="/Css_Js/img/ads-3.jpg" alt="Image"></a>
                            </div>
                        </div>

                        <div class="sidebar-widget">
                            <div class="tab-news">
                                <ul class="nav nav-pills nav-justified">
                                    <li class="nav-item">
                                        <a class="nav-link active" data-toggle="pill" href="#featured">Featured</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-toggle="pill" href="#popular">Popular</a>
                                    </li>
                                    <li class="nav-item">
                                        <a class="nav-link" data-toggle="pill" href="#latest">Latest</a>
                                    </li>
                                </ul>

                                <div class="tab-content">
                                    <div id="featured" class="container tab-pane active">
                            <asp:Repeater runat="server" ID="dgvfeatured">
                                <ItemTemplate>
                                    <div class="tn-news">
                                        <div class="tn-img">

                                            <img src='<%# "../css_js/img/"+ layanhthumbnailfeature(int.Parse(Eval("ID_BaiViet").ToString())) %>' />
                                            <%-- <img src="../Css_Js/img/news-350x223-1.jpg" />--%>
                                        </div>
                                        <div class="tn-title">

                                            <a href=""><%# laytenbaivietfeature(int.Parse(Eval("ID_BaiViet").ToString())) %></a>
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
                                            <img src='<%# "../css_js/img/"+ layanhthumbnailpopular(int.Parse(Eval("ID_BaiViet").ToString())) %>' />
                                        </div>
                                        <div class="tn-title">

                                            <a href=""><%# laytenbaivietpopular(int.Parse(Eval("ID_BaiViet").ToString())) %></a>
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
                                            <img src='<%# "../css_js/img/"+ layanhthumbnaillasest(int.Parse(Eval("ID_BaiViet").ToString())) %>' />
                                        </div>
                                        <div class="tn-title">

                                            <a href=""><%# laytenbaivietlastest(int.Parse(Eval("ID_BaiViet").ToString())) %></a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                                </div>
                            </div>
                        </div>

                        <div class="sidebar-widget">
                            <div class="image">

                                <a href="#">
                                    <img src="../Css_Js/img/quangcao.png" alt="Image"></a>
                            </div>
                        </div>

                        <div class="sidebar-widget">
                            <h2 class="sw-title">News Category</h2>
                            <div class="category">
                                <ul>
                                    <li><a href="">National</a><span>(98)</span></li>
                                    <li><a href="">International</a><span>(87)</span></li>
                                    <li><a href="">Economics</a><span>(76)</span></li>
                                    <li><a href="">Politics</a><span>(65)</span></li>
                                    <li><a href="">Lifestyle</a><span>(54)</span></li>
                                    <li><a href="">Technology</a><span>(43)</span></li>
                                    <li><a href="">Trades</a><span>(32)</span></li>
                                </ul>
                            </div>
                        </div>

                        <div class="sidebar-widget">
                            <div class="image">
                                <a href="https://htmlcodex.com">
                                    <img src="/Css_Js/img/ads-3.jpg" alt="Image"></a>

                            </div>
                        </div>

                        <div class="sidebar-widget">
                            <h2 class="sw-title">Tags Cloud</h2>
                            <div class="tags">
                                <a href="">National</a>
                                <a href="">International</a>
                                <a href="">Economics</a>
                                <a href="">Politics</a>
                                <a href="">Lifestyle</a>
                                <a href="">Technology</a>
                                <a href="">Trades</a>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Single News End-->




    <%--Comment Start--%>

    <div class="container">
        <div class="row">
            <div class="col-md-10 offset-sm-1" id="logout">
                <div class="page-header">
                    <h3 class="reviews">Leave your comment</h3>
                    <div class="logout">
                        <button class="btn btn-secondary btn-circle text-uppercase" type="button"
                            onclick="$(&apos;#logout&apos;).hide(); $(&apos;#login&apos;).show()">
                            <span class="glyphicon glyphicon-off"></span>Logout</button>
                    </div>
                </div>
                <div class="comment-tabs">
                    <ul class="nav nav-tabs" role="tablist">
                        <li class="active nav-item"><a href="#comments-logout" role="tab" data-toggle="tab" class="nav-link">

                            <h4 class="reviews text-capitalize">Comments</h4>

                        </a>
                        </li>
                        <li class="nav-item"><a href="#add-comment" role="tab" data-toggle="tab" class="nav-link">

                            <h4 class="reviews text-capitalize">Add comment</h4>

                        </a>
                        </li>
                        <li class="nav-item"><a href="#account-settings" role="tab" data-toggle="tab" class="nav-link">

                            <h4 class="reviews text-capitalize">Account settings</h4>

                        </a>
                        </li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="comments-logout">
                            <ul class="media-list">
                                <li class="media"><a class="float-left" href="#">

                                    <img class="media-object rounded-circle" src="https://s3.amazonaws.com/uifaces/faces/twitter/dancounsell/128.jpg" alt="profile">
                                </a>
                                    <div class="media-body">
                                        <div class="card bg-light card-body mb-3 well-lg">
                                            <h4 class="media-heading text-uppercase reviews">Marco </h4>
                                            <ul class="media-date text-uppercase reviews list-inline">
                                                <li class="dd list-inline-item">22</li>
                                                <li class="mm list-inline-item">09</li>
                                                <li class="aaaa list-inline-item">2014</li>
                                            </ul>
                                            <p class="media-comment">Great snippet! Thanks for sharing.</p>
                                            <a class="btn btn-info btn-circle text-uppercase"
                                                href="#" id="reply"><span class="glyphicon glyphicon-share-alt"></span>Reply</a>
                                            <a
                                                class="btn btn-warning btn-circle text-uppercase" data-toggle="collapse"
                                                href="#replyOne"><span class="glyphicon glyphicon-comment"></span>2 comments</a>
                                        </div>
                                    </div>
                                    <div class="collapse" id="replyOne">
                                        <ul class="media-list">
                                            <li class="media media-replied"><a class="float-left" href="#">

                                                <img class="media-object rounded-circle" src="https://s3.amazonaws.com/uifaces/faces/twitter/ManikRathee/128.jpg" alt="profile">
                                            </a>
                                                <div class="media-body">
                                                    <div class="card bg-light card-body mb-3 well-lg">
                                                        <h4 class="media-heading text-uppercase reviews"><span class="glyphicon glyphicon-share-alt"></span>The Hipster</h4>
                                                        <ul class="media-date text-uppercase reviews list-inline">
                                                            <li class="dd list-inline-item">22</li>
                                                            <li class="mm list-inline-item">09</li>
                                                            <li class="aaaa list-inline-item">2014</li>
                                                        </ul>
                                                        <p class="media-comment">Nice job Maria.</p>
                                                        <a class="btn btn-info btn-circle text-uppercase" href="#"
                                                            id="reply"><span class="glyphicon glyphicon-share-alt"></span>Reply</a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="media media-replied" id="replied"><a class="float-left" href="#">

                                                <img class="media-object rounded-circle" src="https://pbs.twimg.com/profile_images/442656111636668417/Q_9oP8iZ.jpeg" alt="profile">
                                            </a>
                                                <div class="media-body">
                                                    <div class="card bg-light card-body mb-3 well-lg">
                                                        <h4 class="media-heading text-uppercase reviews"><span class="glyphicon glyphicon-share-alt"></span>Mary</h4>
                                                        <ul class="media-date text-uppercase reviews list-inline">
                                                            <li class="dd list-inline-item">22</li>
                                                            <li class="mm list-inline-item">09</li>
                                                            <li class="aaaa list-inline-item">2014</li>
                                                        </ul>
                                                        <p class="media-comment">Thank you Guys!</p>
                                                        <a class="btn btn-info btn-circle text-uppercase" href="#"
                                                            id="reply"><span class="glyphicon glyphicon-share-alt"></span>Reply</a>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                </li>
                                <li class="media"><a class="float-left" href="#">

                                    <img class="media-object rounded-circle" src="https://s3.amazonaws.com/uifaces/faces/twitter/kurafire/128.jpg" alt="profile">
                                </a>
                                    <div class="media-body">
                                        <div class="card bg-light card-body mb-3 well-lg">
                                            <h4 class="media-heading text-uppercase reviews">Nico</h4>
                                            <ul class="media-date text-uppercase reviews list-inline">
                                                <li class="dd list-inline-item">22</li>
                                                <li class="mm list-inline-item">09</li>
                                                <li class="aaaa list-inline-item">2014</li>
                                            </ul>
                                            <p class="media-comment">I&apos;m looking for that. Thanks!</p>
                                            <div class="embed-responsive embed-responsive-16by9">
                                                <iframe class="embed-responsive-item" src="//www.youtube.com/embed/80lNjkcp6gI"
                                                    allowfullscreen></iframe>
                                            </div>
                                            <a class="btn btn-info btn-circle text-uppercase" href="#" id="reply"><span class="glyphicon glyphicon-share-alt"></span>Reply</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="media"><a class="float-left" href="#">

                                    <img class="media-object rounded-circle" src="https://s3.amazonaws.com/uifaces/faces/twitter/lady_katherine/128.jpg" alt="profile">
                                </a>
                                    <div class="media-body">
                                        <div class="card bg-light card-body mb-3 well-lg">
                                            <h4 class="media-heading text-uppercase reviews">Kriztine</h4>
                                            <ul class="media-date text-uppercase reviews list-inline">
                                                <li class="dd list-inline-item">22</li>
                                                <li class="mm list-inline-item">09</li>
                                                <li class="aaaa list-inline-item">2014</li>
                                            </ul>
                                            <p class="media-comment">Yehhhh... Thanks for sharing.</p>
                                            <a class="btn btn-info btn-circle text-uppercase"
                                                href="#" id="reply"><span class="glyphicon glyphicon-share-alt"></span>Reply</a>
                                            <a
                                                class="btn btn-warning btn-circle text-uppercase" data-toggle="collapse"
                                                href="#replyTwo"><span class="glyphicon glyphicon-comment"></span>1 comment</a>
                                        </div>
                                    </div>
                                    <div class="collapse" id="replyTwo">
                                        <ul class="media-list">
                                            <li class="media media-replied"><a class="float-left" href="#">

                                                <img class="media-object rounded-circle" src="https://s3.amazonaws.com/uifaces/faces/twitter/jackiesaik/128.jpg" alt="profile">
                                            </a>
                                                <div class="media-body">
                                                    <div class="card bg-light card-body mb-3 well-lg">
                                                        <h4 class="media-heading text-uppercase reviews"><span class="glyphicon glyphicon-share-alt"></span>Lizz</h4>
                                                        <ul class="media-date text-uppercase reviews list-inline">
                                                            <li class="dd list-inline-item">22</li>
                                                            <li class="mm list-inline-item">09</li>
                                                            <li class="aaaa list-inline-item">2014</li>
                                                        </ul>
                                                        <p class="media-comment">Classy!</p>
                                                        <a class="btn btn-info btn-circle text-uppercase" href="#"
                                                            id="reply"><span class="glyphicon glyphicon-share-alt"></span>Reply</a>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <div class="tab-pane" id="add-comment">
                            <form action="#" method="post" class="" id="commentForm" role="form">
                                <div class="form-group">
                                    <label for="email" class="col-md-2 col-form-label">Comment</label>
                                    <div class="col-md-10">
                                        <textarea class="form-control" name="addComment" id="addComment" rows="5"></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="uploadMedia" class="col-md-2 col-form-label">Upload media</label>
                                    <div class="col-md-10">
                                        <div class="input-group">
                                            <div class="input-group-addon">http://</div>
                                            <input type="text" class="form-control" name="uploadMedia"
                                                id="uploadMedia">
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="offset-sm-2 col-md-10">
                                        <button class="btn btn-success btn-circle text-uppercase" type="submit"
                                            id="submitComment">
                                            <span class="glyphicon glyphicon-send"></span>Summit comment</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <div class="tab-pane" id="account-settings">
                            <form action="#" method="post" class="" id="accountSetForm" role="form">
                                <div class="form-group">
                                    <label for="avatar" class="col-md-2 col-form-label">Avatar</label>
                                    <div class="col-md-10">
                                        <div class="custom-input-file">
                                            <label class="uploadPhoto">
                                                Edit
                                            <input type="file" class="change-avatar" name="avatar" id="avatar">
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="name" class="col-md-2 col-form-label">Name</label>
                                    <div class="col-md-10">
                                        <input type="text" class="form-control" name="name" id="name" placeholder="Vilma palma">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="nickName" class="col-md-2 col-form-label">Nick name</label>
                                    <div class="col-md-10">
                                        <input type="text" class="form-control" name="nickName" id="nickName"
                                            placeholder="Vilma">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="email" class="col-md-2 col-form-label">Email</label>
                                    <div class="col-md-10">
                                        <input type="email" class="form-control" name="email" id="email" placeholder="vilma@mail.com">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="newPassword" class="col-md-2 col-form-label">New password</label>
                                    <div class="col-md-10">
                                        <input type="password" class="form-control" name="newPassword" id="newPassword">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="confirmPassword" class="col-md-2 col-form-label">Confirm password</label>
                                    <div class="col-md-10">
                                        <input type="password" class="form-control" name="confirmPassword" id="confirmPassword">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="offset-sm-2 col-md-10">
                                        <button class="btn btn-primary btn-circle text-uppercase" type="submit"
                                            id="submit">
                                            Save changes</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-10 offset-sm-1" id="login">
                <div class="page-header">
                    <h3 class="reviews">Leave your comment</h3>
                    <div class="logout">
                        <button class="btn btn-secondary btn-circle text-uppercase" type="button"
                            onclick="$(&apos;#login&apos;).hide(); $(&apos;#logout&apos;).show()">
                            <span class="glyphicon glyphicon-off"></span>Login</button>
                    </div>
                </div>
                <div class="comment-tabs">
                    <ul class="nav nav-tabs" role="tablist">
                        <li class="active nav-item"><a href="#comments-login" role="tab" data-toggle="tab" class="nav-link">

                            <h4 class="reviews text-capitalize">Comments</h4>

                        </a>
                        </li>
                        <li class="nav-item"><a href="#add-comment-disabled" role="tab" data-toggle="tab" class="nav-link">

                            <h4 class="reviews text-capitalize">Add comment</h4>

                        </a>
                        </li>
                        <li class="nav-item"><a href="#new-account" role="tab" data-toggle="tab" class="nav-link">

                            <h4 class="reviews text-capitalize">Create an account</h4>

                        </a>
                        </li>
                    </ul>
                    <div class="tab-content">
                        <div class="tab-pane active" id="comments-login">
                            <ul class="media-list">
                                <li class="media"><a class="float-left" href="#">

                                    <img class="media-object rounded-circle" src="https://s3.amazonaws.com/uifaces/faces/twitter/dancounsell/128.jpg" alt="profile">
                                </a>
                                    <div class="media-body">
                                        <div class="card bg-light card-body mb-3 well-lg">
                                            <h4 class="media-heading text-uppercase reviews">Marco</h4>
                                            <ul class="media-date text-uppercase reviews list-inline">
                                                <li class="dd list-inline-item">22</li>
                                                <li class="mm list-inline-item">09</li>
                                                <li class="aaaa list-inline-item">2014</li>
                                            </ul>
                                            <p class="media-comment">Great snippet! Thanks for sharing.</p>
                                            <a class="btn btn-info btn-circle text-uppercase"
                                                href="#" id="reply"><span class="glyphicon glyphicon-share-alt"></span>Reply</a>
                                            <a
                                                class="btn btn-warning btn-circle text-uppercase" data-toggle="collapse"
                                                href="#replyThree"><span class="glyphicon glyphicon-comment"></span>2 comments</a>
                                        </div>
                                    </div>
                                    <div class="collapse" id="replyThree">
                                        <ul class="media-list">
                                            <li class="media media-replied"><a class="float-left" href="#">

                                                <img class="media-object rounded-circle" src="https://s3.amazonaws.com/uifaces/faces/twitter/ManikRathee/128.jpg" alt="profile">
                                            </a>
                                                <div class="media-body">
                                                    <div class="card bg-light card-body mb-3 well-lg">
                                                        <h4 class="media-heading text-uppercase reviews"><span class="glyphicon glyphicon-share-alt"></span>The Hipster</h4>
                                                        <ul class="media-date text-uppercase reviews list-inline">
                                                            <li class="dd list-inline-item">22</li>
                                                            <li class="mm list-inline-item">09</li>
                                                            <li class="aaaa list-inline-item">2014</li>
                                                        </ul>
                                                        <p class="media-comment">Nice job Maria.</p>
                                                        <a class="btn btn-info btn-circle text-uppercase" href="#"
                                                            id="reply"><span class="glyphicon glyphicon-share-alt"></span>Reply</a>
                                                    </div>
                                                </div>
                                            </li>
                                            <li class="media media-replied" id="replied"><a class="float-left" href="#">

                                                <img class="media-object rounded-circle" src="https://pbs.twimg.com/profile_images/442656111636668417/Q_9oP8iZ.jpeg" alt="profile">
                                            </a>
                                                <div class="media-body">
                                                    <div class="card bg-light card-body mb-3 well-lg">
                                                        <h4 class="media-heading text-uppercase reviews"><span class="glyphicon glyphicon-share-alt"></span>Mary</h4>
                                                        <ul class="media-date text-uppercase reviews list-inline">
                                                            <li class="dd list-inline-item">22</li>
                                                            <li class="mm list-inline-item">09</li>
                                                            <li class="aaaa list-inline-item">2014</li>
                                                        </ul>
                                                        <p class="media-comment">Thank you Guys!</p>
                                                        <a class="btn btn-info btn-circle text-uppercase" href="#"
                                                            id="reply"><span class="glyphicon glyphicon-share-alt"></span>Reply</a>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                </li>
                                <li class="media"><a class="float-left" href="#">

                                    <img class="media-object rounded-circle" src="https://s3.amazonaws.com/uifaces/faces/twitter/kurafire/128.jpg" alt="profile">
                                </a>
                                    <div class="media-body">
                                        <div class="card bg-light card-body mb-3 well-lg">
                                            <h4 class="media-heading text-uppercase reviews">Nico</h4>
                                            <ul class="media-date text-uppercase reviews list-inline">
                                                <li class="dd list-inline-item">22</li>
                                                <li class="mm list-inline-item">09</li>
                                                <li class="aaaa list-inline-item">2014</li>
                                            </ul>
                                            <p class="media-comment">I&apos;m looking for that. Thanks!</p>
                                            <div class="embed-responsive embed-responsive-16by9">
                                                <iframe class="embed-responsive-item" src="//www.youtube.com/embed/80lNjkcp6gI"
                                                    allowfullscreen></iframe>
                                            </div>
                                            <a class="btn btn-info btn-circle text-uppercase" href="#" id="reply"><span class="glyphicon glyphicon-share-alt"></span>Reply</a>
                                        </div>
                                    </div>
                                </li>
                                <li class="media"><a class="float-left" href="#">

                                    <img class="media-object rounded-circle" src="https://s3.amazonaws.com/uifaces/faces/twitter/lady_katherine/128.jpg" alt="profile">
                                </a>
                                    <div class="media-body">
                                        <div class="card bg-light card-body mb-3 well-lg">
                                            <h4 class="media-heading text-uppercase reviews">Kriztine</h4>
                                            <ul class="media-date text-uppercase reviews list-inline">
                                                <li class="dd list-inline-item">22</li>
                                                <li class="mm list-inline-item">09</li>
                                                <li class="aaaa list-inline-item">2014</li>
                                            </ul>
                                            <p class="media-comment">Yehhhh... Thanks for sharing.</p>
                                            <a class="btn btn-info btn-circle text-uppercase"
                                                href="#" id="reply"><span class="glyphicon glyphicon-share-alt"></span>Reply</a>
                                            <a
                                                class="btn btn-warning btn-circle text-uppercase" data-toggle="collapse"
                                                href="#replyFour"><span class="glyphicon glyphicon-comment"></span>1 comment</a>
                                        </div>
                                    </div>
                                    <div class="collapse" id="replyFour">
                                        <ul class="media-list">
                                            <li class="media media-replied"><a class="float-left" href="#">

                                                <img class="media-object rounded-circle" src="https://s3.amazonaws.com/uifaces/faces/twitter/jackiesaik/128.jpg" alt="profile">
                                            </a>
                                                <div class="media-body">
                                                    <div class="card bg-light card-body mb-3 well-lg">
                                                        <h4 class="media-heading text-uppercase reviews"><span class="glyphicon glyphicon-share-alt"></span>Lizz</h4>
                                                        <ul class="media-date text-uppercase reviews list-inline">
                                                            <li class="dd list-inline-item">22</li>
                                                            <li class="mm list-inline-item">09</li>
                                                            <li class="aaaa list-inline-item">2014</li>
                                                        </ul>
                                                        <p class="media-comment">Classy!</p>
                                                        <a class="btn btn-info btn-circle text-uppercase" href="#"
                                                            id="reply"><span class="glyphicon glyphicon-share-alt"></span>Reply</a>
                                                    </div>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                </li>
                            </ul>
                        </div>
                        <div class="tab-pane" id="add-comment-disabled">
                            <div class="alert alert-info alert-dismissible" role="alert">
                                <button type="button" class="close" data-dismiss="alert">
                                    <span aria-hidden="true">&#xD7;</span><span class="sr-only">Close</span>
                                </button>
                                <strong>Hey!</strong> If you already have an account <a href="#" class="alert-link">Login</a> now
                            to make the comments you want. If you do not have an account yet you&apos;re
                            welcome to <a href="#" class="alert-link">create an account.</a>
                            </div>
                            <form action="#" method="post" class="" id="commentForm" role="form">
                                <div class="form-group">
                                    <label for="email" class="col-md-2 col-form-label">Comment</label>
                                    <div class="col-md-10">
                                        <textarea class="form-control" name="addComment" id="addComment" rows="5"
                                            disabled></textarea>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="uploadMedia" class="col-md-2 col-form-label">Upload media</label>
                                    <div class="col-md-10">
                                        <div class="input-group">
                                            <div class="input-group-addon">http://</div>
                                            <input type="text" class="form-control" name="uploadMedia"
                                                id="uploadMedia" disabled>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="offset-sm-2 col-md-10">
                                        <button class="btn btn-success btn-circle text-uppercase disabled" type="submit"
                                            id="submitComment">
                                            <span class="glyphicon glyphicon-send"></span>Summit comment</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                        <div class="tab-pane" id="new-account">
                            <form action="#" method="post" class="" id="commentForm" role="form">
                                <div class="form-group">
                                    <label for="name" class="col-md-2 col-form-label">Name</label>
                                    <div class="col-md-10">
                                        <input type="text" class="form-control" name="name" id="name">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="email" class="col-md-2 col-form-label">Email</label>
                                    <div class="col-md-10">
                                        <input type="email" class="form-control" name="email" id="email" required>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="password" class="col-md-2 col-form-label">Password</label>
                                    <div class="col-md-10">
                                        <input type="password" class="form-control" name="password" id="password">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="form-check">
                                        <label for="agreeTerms" class="offset-sm-2 col-md-10">
                                            <input type="checkbox" name="agreeTerms" id="agreeTerms">I agree all <a href="#">Terms &amp; Conditions</a>
                                        </label>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="offset-sm-2 col-md-10">
                                        <asp:Button runat="server" 
                                            ID="btncreateacount" 
                                            class="btn btn-primary btn-circle text-uppercase" 
                                            OnClick="btncreateacount_Click" 
                                            Text="Create an account" />

                                        <button class="btn btn-primary btn-circle text-uppercase" type="submit"
                                            id="submit">
                                            Create an account</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <%--Comment end--%>

    <link href="../Css_Js/css/Comment.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
