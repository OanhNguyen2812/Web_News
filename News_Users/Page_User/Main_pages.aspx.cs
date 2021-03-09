using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace News_Users.Page_User
{
    public partial class Main_pages : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                slidetenbaivietmoi();
                //getbaivietrandom();
                //getChuyenMucport();

                getdgvchuyenmuccha();
                //getdgvchuyenmuccha1();
                getdatafeature();
                getdatapopuler();
                getdatalastest();
                getdatamostviews();
                getdatamostread();
                getdatamostrecent();
                getallbaiviet();
                getvietrandom();
            }

        }

        //Slide bài viet mới theo id bài viêt start
        public void slidetenbaivietmoi()
        {
            NewsEntities db = new NewsEntities();
            List<News_Users.BaiViet> listbaiviet = db.BaiViet.OrderByDescending(x => x.ID_BaiViet).Take(6).ToList();
            dgvbaivietmoi.DataSource = listbaiviet;
            dgvbaivietmoi.DataBind();
        }
        public string slidebaivietmoi(string tenbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        }
        public string layanhbaivietmoi(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        //Slide bài viet mới theo id bài viêt end


        ////Hien thi 3 bài viets random Start
        //public void getbaivietrandom()
        //{
        //    NewsEntities db = new NewsEntities();
        //    List<News_Users.BaiViet> num = db.BaiViet.OrderBy(x => x.ID_BaiViet).ToList();
        //    Random rand = new Random();
        //    int toskip = rand.Next(1, 10);
        //    List<News_Users.BaiViet> listsport = db.BaiViet.OrderBy(x => x.TGViet).Skip(toskip).Take(3).ToList();
        //    dgvbaivietrandom.DataSource = listsport;
        //    dgvbaivietrandom.DataBind();
        //}
        //public string showbaivietrandom(string tenbaiviet)
        //{
        //    NewsEntities db = new NewsEntities();
        //    return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        //}
        //public string layanhanhtheoidbai(int idbaiviet)
        //{
        //    NewsEntities db = new NewsEntities();
        //    return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        //}
        //// Hiện thị 3 bài viết randon END





        // lấy tên các chuyên mục cha và con hiên thị trong repeater start
        public void getdgvchuyenmuccha()
        {
            NewsEntities db = new NewsEntities();
            List<News_Users.ChuyenMuc> listcha = db.ChuyenMuc.Where(x => x.ID_ChuyenMucCha == 1 && x.ID_ChuyenMuc!=101).ToList();
            dgvchuyenmuccha.DataSource = listcha;
            dgvchuyenmuccha.DataBind();
        }

        public string listcmcon(int cmcha)
        {
            NewsEntities db = new NewsEntities();
            return db.ChuyenMuc.First(x => x.ID_ChuyenMucCha == cmcha).TenChuyenMuc;
        }
        public List<News_Users.ChuyenMuc> getdgvchuyenmuccon(int id)
        {
            NewsEntities db = new NewsEntities();
            return db.ChuyenMuc.Where(x => x.ID_ChuyenMucCha == id).ToList();
        }

        protected void dgvchuyenmuccha_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater dgvchuyenmuccon = (Repeater)e.Item.FindControl("dgvchuyenmuccon");
            int id = ((News_Users.ChuyenMuc)e.Item.DataItem).ID_ChuyenMuc;
            dgvchuyenmuccon.DataSource = getdgvchuyenmuccon(id);
            dgvchuyenmuccon.DataBind();
        }
        public List<News_Users.BaiViet> getdgvctbv(int id)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.Where(x => x.ID_ChuyenMuc == id).ToList();
        }
        protected void dgvchuyenmuccon_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater dgvctbv = (Repeater)e.Item.FindControl("dgvctbv");
            int id = (int)((News_Users.ChuyenMuc)e.Item.DataItem).ID_ChuyenMuc;
            dgvctbv.DataSource = getdgvctbv(id);
            dgvctbv.DataBind();
        }

      
        public List<News_Users.ChuyenMuc> getdgvshortlink(int id)
        {
            NewsEntities db = new NewsEntities();
            return db.ChuyenMuc.Where(x => x.ID_ChuyenMucCha == id).ToList();
        }
        protected void shortlinkcmcon_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater shortlinkcmcon = (Repeater)e.Item.FindControl("shortlinkcmcon");
            int id = ((News_Users.ChuyenMuc)e.Item.DataItem).ID_ChuyenMuc;
            shortlinkcmcon.DataSource = getdgvshortlink(id);
            shortlinkcmcon.DataBind();
        }

        //public List<News_Users.BaiViet> getdgvctbv(int id)
        //{
        //    NewsEntities db = new NewsEntities();
        //    return db.BaiViet.Where(x => x.ID_ChuyenMuc == id).ToList();
        //}
        //protected void dgvchuyenmuccon_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    Repeater dgvctbv = (Repeater)e.Item.FindControl("dgvctbv");
        //    int id = (int)((News_Users.BaiViet)e.Item.DataItem).ID_ChuyenMuc;
        //    //NewsEntities db = new NewsEntities();
        //    //List<News_Users.BaiViet> listbv = db.BaiViet.Where(x => x.ID_ChuyenMuc == id).ToList();
        //    dgvctbv.DataSource = getdgvctbv(id);
        //    dgvctbv.DataBind();
        //}


        // lấy tên các chuyên mục cha và con hiên thị trong repeater end

        // Lây ảnh thumbnail theo id_bài viết start


        // Lây ảnh thumnail theo id_bài viết end

        // Lấy tên bài viết hiển thị trong tab feature theo id_bài viêt start
        public void getdatafeature()
        {
            NewsEntities db = new NewsEntities();
            List<News_Users.BaiViet> listfeature = db.BaiViet.OrderBy(x => x.ID_BaiViet).Skip(2).Take(4).ToList();
            dgvfeatured.DataSource = listfeature;
            dgvfeatured.DataBind();
        }
        public string laytenbaivietfeature(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).TenBaiViet;
        }
        public string layanhthumbnailfeature(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // Lấy tên bài viết hiển thị trong tab feature theo id_bài viêt end

        // Lấy tên bài viết hiển thị trong tab poppular theo id_bài viêt start
        public void getdatapopuler()
        {
            NewsEntities db = new NewsEntities();
            List<News_Users.BaiViet> listfeature = db.BaiViet.OrderBy(x => x.ID_BaiViet).Skip(5).Take(4).ToList();
            dgvpopular.DataSource = listfeature;
            dgvpopular.DataBind();
        }
        public string laytenbaivietpopular(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).TenBaiViet;
        }
        public string layanhthumbnailpopular(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // Lấy tên bài viết hiển thị trong tab poppular theo id_bài viêt start

        // Lấy tên bài viết hiển thị trong tab lasest theo id_bài viêt start
        public void getdatalastest()
        {
            NewsEntities db = new NewsEntities();
            List<News_Users.BaiViet> listfeature = db.BaiViet.OrderByDescending(x => x.TGViet).Take(4).ToList();
            dgvlastest.DataSource = listfeature;
            dgvlastest.DataBind();
        }
        public string laytenbaivietlastest(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).TenBaiViet;
        }
        public string layanhthumbnaillasest(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // Lấy tên bài viết hiển thị trong tab lastest theo id_bài viêt start

        // Lấy tên bài viết hiển thị trong tab mostviews theo id_bài viêt start
        public void getdatamostviews()
        {
            NewsEntities db = new NewsEntities();
            List<News_Users.BaiViet> listmostviews = db.BaiViet.OrderBy(x => x.TGViet).Take(4).ToList();
            dgvmostview.DataSource = listmostviews;
            dgvmostview.DataBind();
        }
        public string laytenbaivietmostview(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).TenBaiViet;
        }
        public string layanhthumbnailmostview(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // Lấy tên bài viết hiển thị trong tab mostviews theo id_bài viêt start


        // Lây tên bài viết hiện thị trong tab mostread theo id_bài viết start
        public void getdatamostread()
        {
            NewsEntities db = new NewsEntities();
            List<News_Users.BaiViet> listmostread = db.BaiViet.OrderBy(x => x.ID_BaiViet).Skip(6).Take(4).ToList();
            dgvmostread.DataSource = listmostread;
            dgvmostread.DataBind();
        }
        public string laytenbaivietmostread(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).TenBaiViet;
        }
        public string layanhthumbnailmostread(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // láy ten bài viết hiện thị trong tab mostread theo id_baiviet end 


        // Lây tên bài viết hiện thị trong tab mostrecent theo id_bài viết start
        public void getdatamostrecent()
        {
            NewsEntities db = new NewsEntities();
            List<News_Users.BaiViet> listmostread = db.BaiViet.OrderBy(x => x.ID_BaiViet).Skip(8).Take(4).ToList();
            dgvmostrecent.DataSource = listmostread;
            dgvmostrecent.DataBind();
        }
        public string laytenbaivietmostrecent(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).TenBaiViet;
        }
        public string layanhthumbnailmostrecent(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // lấy ten bài viết hiện thị trong tab mostrecent theo id_baiviet end 


        // lay tat cả bài viet start
        public void getallbaiviet()
        {
            NewsEntities db = new NewsEntities();
            List<News_Users.BaiViet> listall = db.BaiViet.OrderBy(x => x.ID_BaiViet).ToList();
            tatcabaiviet.DataSource = listall;
            tatcabaiviet.DataBind();
        }

        public string laytatcabaiviet(string tenbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        }

        public string laytatcaanhthumbnail(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // lay tat cả bai viet end


        // Read more random start
        public void getvietrandom()
        {
            NewsEntities db = new NewsEntities();
            List<News_Users.BaiViet> num = db.BaiViet.OrderBy(x => x.ID_BaiViet).ToList();
            Random rand = new Random();
            int toskip = rand.Next(1, 10);
            List<News_Users.BaiViet> listsport = db.BaiViet.OrderBy(x => x.TGViet).Skip(toskip).Take(10).ToList();
            dgvvietrandom.DataSource = listsport;
            dgvvietrandom.DataBind();
        }
        public string showvietrandom(string tenbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        }
        // Read more random end
    }
}

