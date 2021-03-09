using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News_Users.Page_User
{
    public partial class single_page : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //string idbv = Request.QueryString["ID_BaiViet"];
                getbaiviet();
                shortcm();
                relatednewbaivietmoi();
                getbaivietcungcm();
                getdatafeature();
                getdatapopular();
                getdatalastest();
            }
        }

        // lay ten chuyen mục hien thi ở short link start
        public void shortcm()
        {
            int idcmtren = int.Parse(Request.QueryString["ID_Baiviet"]);
            NewsEntities db = new NewsEntities();
            int idcm = (int)db.BaiViet.First(x => x.ID_BaiViet == idcmtren).ID_ChuyenMuc;
            List<News_Users.ChuyenMuc> listcm = db.ChuyenMuc.Where(x => x.ID_ChuyenMuc == idcm).ToList();
            shortlinkcm.DataSource = listcm;
            shortlinkcm.DataBind();
        }
        public string shortlink(int idchuyenmuc)
        {
            NewsEntities db = new NewsEntities();
            return db.ChuyenMuc.First(c => c.ID_ChuyenMuc == idchuyenmuc).TenChuyenMuc;
        }
        
        // lay ten chuyen muc hien thị ở short link end


        // Lay chi tiêt nôi dung bai viet start
        public void getbaiviet()
        {
            int idbv = int.Parse(Request.QueryString["ID_BaiViet"]);
            NewsEntities db = new NewsEntities();
            List<News_Users.BaiViet> listchitietbv = db.BaiViet.Where(x => x.ID_BaiViet == idbv).ToList();
            chitietbaiviet.DataSource = listchitietbv;
            chitietbaiviet.DataBind();
        }
        public string layidbaiviet(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_ChuyenMuc == idbaiviet).TenBaiViet;
        }

        public string getsignature(int iduser)
        {
            NewsEntities db = new NewsEntities();
            return db.User.First(x => x.ID_User == iduser).NgheDanh;
        }
        // Lay chi tiêt nôi dung bai viet end



        // Relates news start
        //Slide bài viet mới theo id bài viêt start
        public void relatednewbaivietmoi()
        {
            NewsEntities db = new NewsEntities();
            List<News_Users.BaiViet> listbaiviet = db.BaiViet.OrderByDescending(x => x.ID_BaiViet).Take(6).ToList();
            dgvrelatedmoi.DataSource = listbaiviet;
            dgvrelatedmoi.DataBind();
        }
        public string relatednewmoi(string tenbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        }
        public string anhrelatednewmoi(int idbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }

        // Relates new end

        // Lây bai viets trong cùng chuyen mục
        public void getbaivietcungcm()
        {
            int idcmtren = int.Parse(Request.QueryString["ID_Baiviet"]);
            NewsEntities db = new NewsEntities();
            Random rand = new Random();
            int toskip = rand.Next(1, 10);
            int idcm = (int)db.BaiViet.First(x => x.ID_BaiViet == idcmtren).ID_ChuyenMuc;
            List<News_Users.BaiViet> listcm = db.BaiViet.Where(x => x.ID_ChuyenMuc == idcm).OrderBy(x => x.TGViet).Skip(toskip).Take(5).ToList();
            cungthumuc.DataSource = listcm;
            cungthumuc.DataBind();
        }
        public string getbaivitecungthumuc(int idchuyenmuc)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(c => c.ID_ChuyenMuc == idchuyenmuc).TenBaiViet;
        }
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
        public void getdatapopular()
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
    }
}