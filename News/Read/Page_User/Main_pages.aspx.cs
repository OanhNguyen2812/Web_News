using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace News.Read.Page_User
{
    public partial class Main_pages : System.Web.UI.Page
    {
        static int RowCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                slidetenbaivietmoi();
                //getbaivietrandom();
                //getChuyenMucport();

                getdgvchuyenmuccha();
                //getdgvchuyenmuccha1();
                getdatanewposts();
                getdatafeature();
                getdatapopuler();
                getdatalastest();
                getdatamostviews();
                getdatamostread();
                getdatamostrecent();
                //getallbaiviet();
                getvietrandom();
                FetchData(15, 0);
            }
            else
            {
                plcPage.Controls.Clear();
                CreatePagingControl();
            }

        }

        //Slide bài viet mới theo id bài viêt start
        public void slidetenbaivietmoi()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.BaiViet> listbaiviet = db.BaiViet.OrderByDescending(x => x.ID_BaiViet).Take(6).ToList();
            dgvbaivietmoi.DataSource = listbaiviet;
            dgvbaivietmoi.DataBind();
        }
        public string slidebaivietmoi(string tenbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        }
        public string layanhbaivietmoi(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        //Slide bài viet mới theo id bài viêt end


        ////Hien thi 3 bài viets random Start
        //public void getbaivietrandom()
        //{
        //    NewsEntities2 db = new NewsEntities2();
        //    List<News.BaiViet> num = db.BaiViet.OrderBy(x => x.ID_BaiViet).ToList();
        //    Random rand = new Random();
        //    int toskip = rand.Next(1, 10);
        //    List<News.BaiViet> listsport = db.BaiViet.OrderBy(x => x.TGViet).Skip(toskip).Take(3).ToList();
        //    dgvbaivietrandom.DataSource = listsport;
        //    dgvbaivietrandom.DataBind();
        //}
        //public string showbaivietrandom(string tenbaiviet)
        //{
        //    NewsEntities2 db = new NewsEntities2();
        //    return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        //}
        //public string layanhanhtheoidbai(int idbaiviet)
        //{
        //    NewsEntities2 db = new NewsEntities2();
        //    return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        //}
        //// Hiện thị 3 bài viết randon END





        // lấy tên các chuyên mục cha và con hiên thị trong repeater start
        public void getdgvchuyenmuccha()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.ChuyenMuc> listcha = db.ChuyenMuc.Where(x => x.ID_ChuyenMucCha == 1 && x.ID_ChuyenMuc!=101).ToList();
            dgvchuyenmuccha.DataSource = listcha;
            dgvchuyenmuccha.DataBind();
        }

        public string listcmcon(int cmcha)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.ChuyenMuc.First(x => x.ID_ChuyenMucCha == cmcha).TenChuyenMuc;
        }
        public List<News.ChuyenMuc> getdgvchuyenmuccon(int id)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.ChuyenMuc.Where(x => x.ID_ChuyenMucCha == id).ToList();
        }

        protected void dgvchuyenmuccha_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater dgvchuyenmuccon = (Repeater)e.Item.FindControl("dgvchuyenmuccon");
            int id = ((News.ChuyenMuc)e.Item.DataItem).ID_ChuyenMuc;
            dgvchuyenmuccon.DataSource = getdgvchuyenmuccon(id);
            dgvchuyenmuccon.DataBind();
        }
        public List<News.BaiViet> getdgvctbv(int id)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.Where(x => x.ID_ChuyenMuc == id).ToList();
        }
        protected void dgvchuyenmuccon_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater dgvctbv = (Repeater)e.Item.FindControl("dgvctbv");
            int id = (int)((News.ChuyenMuc)e.Item.DataItem).ID_ChuyenMuc;
            dgvctbv.DataSource = getdgvctbv(id);
            dgvctbv.DataBind();
        }

      
        public List<News.ChuyenMuc> getdgvshortlink(int id)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.ChuyenMuc.Where(x => x.ID_ChuyenMucCha == id).ToList();
        }
        protected void shortlinkcmcon_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater shortlinkcmcon = (Repeater)e.Item.FindControl("shortlinkcmcon11");
            int id = ((News.ChuyenMuc)e.Item.DataItem).ID_ChuyenMuc;
            shortlinkcmcon.DataSource = getdgvshortlink(id);
            shortlinkcmcon.DataBind();
        }

        // Lay tên và anh cho bài viết new posts start
        public void getdatanewposts()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.BaiViet> listhotposts= db.BaiViet.OrderByDescending(x => x.ID_BaiViet).Take(2).ToList();
            dgvnewposts.DataSource = listhotposts;
            dgvnewposts.DataBind();
        }
        public string laytenbaivietnewposts(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).TenBaiViet;
        }
        public string layanhthumbnailnewposts(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // Lây tên và ảnh cho bài viết new posts end


        //public List<News.BaiViet> getdgvctbv(int id)
        //{
        //    NewsEntities2 db = new NewsEntities2();
        //    return db.BaiViet.Where(x => x.ID_ChuyenMuc == id).ToList();
        //}
        //protected void dgvchuyenmuccon_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    Repeater dgvctbv = (Repeater)e.Item.FindControl("dgvctbv");
        //    int id = (int)((News.BaiViet)e.Item.DataItem).ID_ChuyenMuc;
        //    //NewsEntities2 db = new NewsEntities2();
        //    //List<News.BaiViet> listbv = db.BaiViet.Where(x => x.ID_ChuyenMuc == id).ToList();
        //    dgvctbv.DataSource = getdgvctbv(id);
        //    dgvctbv.DataBind();
        //}


        // lấy tên các chuyên mục cha và con hiên thị trong repeater end

        // Lây ảnh thumbnail theo id_bài viết start


        // Lây ảnh thumnail theo id_bài viết end

        // Lấy tên bài viết hiển thị trong tab feature theo id_bài viêt start
        public void getdatafeature()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.BaiViet> listfeature = db.BaiViet.OrderBy(x => x.ID_BaiViet).Skip(2).Take(4).ToList();
            dgvfeatured.DataSource = listfeature;
            dgvfeatured.DataBind();
        }
        public string laytenbaivietfeature(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).TenBaiViet;
        }
        public string layanhthumbnailfeature(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // Lấy tên bài viết hiển thị trong tab feature theo id_bài viêt end

        // Lấy tên bài viết hiển thị trong tab poppular theo id_bài viêt start
        public void getdatapopuler()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.BaiViet> listfeature = db.BaiViet.OrderBy(x => x.ID_BaiViet).Skip(5).Take(4).ToList();
            dgvpopular.DataSource = listfeature;
            dgvpopular.DataBind();
        }
        public string laytenbaivietpopular(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).TenBaiViet;
        }
        public string layanhthumbnailpopular(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // Lấy tên bài viết hiển thị trong tab poppular theo id_bài viêt end

        // Lấy tên bài viết hiển thị trong tab lasest theo id_bài viêt start
        public void getdatalastest()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.BaiViet> listfeature = db.BaiViet.OrderByDescending(x => x.TGViet).Take(4).ToList();
            dgvlastest.DataSource = listfeature;
            dgvlastest.DataBind();
        }
        public string laytenbaivietlastest(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).TenBaiViet;
        }
        public string layanhthumbnaillasest(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // Lấy tên bài viết hiển thị trong tab lastest theo id_bài viêt start

        // Lấy tên bài viết hiển thị trong tab mostviews theo id_bài viêt start
        public void getdatamostviews()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.BaiViet> listmostviews = db.BaiViet.OrderBy(x => x.TGViet).Take(4).ToList();
            dgvmostview.DataSource = listmostviews;
            dgvmostview.DataBind();
        }
        public string laytenbaivietmostview(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).TenBaiViet;
        }
        public string layanhthumbnailmostview(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // Lấy tên bài viết hiển thị trong tab mostviews theo id_bài viêt start


        // Lây tên bài viết hiện thị trong tab mostread theo id_bài viết start
        public void getdatamostread()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.BaiViet> listmostread = db.BaiViet.OrderBy(x => x.ID_BaiViet).Skip(6).Take(4).ToList();
            dgvmostread.DataSource = listmostread;
            dgvmostread.DataBind();
        }
        public string laytenbaivietmostread(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).TenBaiViet;
        }
        public string layanhthumbnailmostread(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // láy ten bài viết hiện thị trong tab mostread theo id_baiviet end 


        // Lây tên bài viết hiện thị trong tab mostrecent theo id_bài viết start
        public void getdatamostrecent()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.BaiViet> listmostread = db.BaiViet.OrderBy(x => x.ID_BaiViet).Skip(8).Take(4).ToList();
            dgvmostrecent.DataSource = listmostread;
            dgvmostrecent.DataBind();
        }
        public string laytenbaivietmostrecent(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).TenBaiViet;
        }
        public string layanhthumbnailmostrecent(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // lấy ten bài viết hiện thị trong tab mostrecent theo id_baiviet end 


        // lay tat cả bài viet start
        public void getallbaiviet()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.BaiViet> listall = db.BaiViet.OrderBy(x => x.ID_BaiViet).ToList();
            tatcabaiviet.DataSource = listall;
            tatcabaiviet.DataBind();
        }

        //public string laytatcabaiviet(string tenbaiviet)
        //{
        //    NewsEntities2 db = new NewsEntities2();
        //    return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        //}

        public string laytatcaanhthumbnail(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.FirstOrDefault(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // lay tat cả bai viet end


        // Read more random start
        public void getvietrandom()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.BaiViet> num = db.BaiViet.OrderBy(x => x.ID_BaiViet).ToList();
            Random rand = new Random();
            int toskip = rand.Next(1, 10);
            List<News.BaiViet> listsport = db.BaiViet.OrderBy(x => x.TGViet).Skip(toskip).Take(10).ToList();
            dgvvietrandom.DataSource = listsport;
            dgvvietrandom.DataBind();
        }
        public string showvietrandom(string tenbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        }
        // Read more random end


        //code phân trang các bài viet
        public void FetchData(int take, int pagesize)
        {
            //int idcm = int.Parse(Request.QueryString["ID_ChuyenMuc"]);
            using (NewsEntities2 dc = new NewsEntities2())
            {
                var query = from p in dc.BaiViet.OrderBy(o => o.ID_BaiViet).Take(take).Skip(pagesize)
                            select new
                            {
                                idbaiviet = p.ID_BaiViet,
                                anhthum = p.AnhThumbnail,
                                Tenbai = p.TenBaiViet,
                                Count = dc.BaiViet.OrderBy(x => x.ID_BaiViet).Count()
                            };
                PagedDataSource pgitems = new PagedDataSource();
                pgitems.AllowCustomPaging = true;
                pgitems.AllowPaging = true;
                pgitems.DataSource = query;
                pgitems.PageSize = 15;
                tatcabaiviet.DataSource = pgitems;
                tatcabaiviet.DataBind();
                if (!IsPostBack)
                {
                    RowCount = query.First().Count;
                    CreatePagingControl();
                }
            }
        }
        public void CreatePagingControl()
        {

            for (int i = 0; i < (RowCount / 15) + 1; i++)
            {
                LinkButton lnk = new LinkButton();
                lnk.Click += new EventHandler(lbl_Clickee);
                lnk.ID = "lnkPage" + (i + 1).ToString();
                lnk.Text = (i + 1).ToString();
                
                plcPage.Controls.Add(lnk);
                Label spacer = new Label();
                spacer.Text = "&nbsp;";
                plcPage.Controls.Add(spacer);
            }
        }
        public void lbl_Clickee(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int currentPage = int.Parse(lnk.Text);
            int take = currentPage * 15;
            int skip = currentPage == 1 ? 0 : take - 15;
            FetchData(take, skip);
        }
    }
}

