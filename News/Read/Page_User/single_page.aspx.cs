using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Read.Page_User
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
                laytencmpushtag();
                countbaiviet();
                getdatacommentlogin();
                getdatacommentlogout();

                int id = int.Parse(Request.QueryString["ID_Baiviet"]);
                NewsEntities db = new NewsEntities();

                int lx = int.Parse(db.tb_BaiViet.FirstOrDefault(x => x.ID_BaiViet == id).LuotXem.ToString());

                News.tb_BaiViet obj = db.tb_BaiViet.FirstOrDefault(x => x.ID_BaiViet == id);

                obj.LuotXem = lx + 1;
                db.SaveChanges();
            }
        }

        // lay ten chuyen mục hien thi ở short link start
        public void shortcm()
        {
            int idcmtren = int.Parse(Request.QueryString["ID_Baiviet"]);
            NewsEntities2 db = new NewsEntities2();
            int idcm = (int)db.BaiViet.First(x => x.ID_BaiViet == idcmtren).ID_ChuyenMuc;
            List<News.ChuyenMuc> listcm = db.ChuyenMuc.Where(x => x.ID_ChuyenMuc == idcm).ToList();
            shortlinkcm.DataSource = listcm;
            shortlinkcm.DataBind();
        }
        public string shortlink(int idchuyenmuc)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.ChuyenMuc.First(c => c.ID_ChuyenMuc == idchuyenmuc).TenChuyenMuc;
        }

        // lay ten chuyen muc hien thị ở short link end


        // Lay chi tiêt nôi dung bai viet start
        public void getbaiviet()
        {
            int idbv = int.Parse(Request.QueryString["ID_BaiViet"]);
            NewsEntities2 db = new NewsEntities2();
            List<News.BaiViet> listchitietbv = db.BaiViet.Where(x => x.ID_BaiViet == idbv).ToList();
            chitietbaiviet.DataSource = listchitietbv;
            chitietbaiviet.DataBind();
        }
        public string layidbaiviet(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_ChuyenMuc == idbaiviet).TenBaiViet;
        }
        public string getsignature(int iduser)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.User.First(x => x.ID_User == iduser).TenUser;
        }
        // Lay chi tiêt nôi dung bai viet end

        // Relates news start
        public void relatednewbaivietmoi()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.BaiViet> listbaiviet = db.BaiViet.OrderByDescending(x => x.ID_BaiViet).Take(6).ToList();
            dgvrelatedmoi.DataSource = listbaiviet;
            dgvrelatedmoi.DataBind();
        }
        public string relatednewmoi(string tenbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        }
        public string anhrelatednewmoi(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.ID_BaiViet == idbaiviet).AnhThumbnail;
        }
        // Relates new end

        // Lây bai viets trong cùng chuyen mục start
        public void getbaivietcungcm()
        {
            int idcmtren = int.Parse(Request.QueryString["ID_Baiviet"]);
            NewsEntities2 db = new NewsEntities2();
            //Random rand = new Random();
            //int toskip = rand.Next(1, 10);
            int idcm = (int)db.BaiViet.First(x => x.ID_BaiViet == idcmtren).ID_ChuyenMuc;
            //List<News.BaiViet> listcm = db.BaiViet.Where(x => x.ID_ChuyenMuc == idcm).OrderBy(x => x.TGViet).Skip(toskip).Take(5).ToList();
            List<News.BaiViet> listcm = db.BaiViet.Where(x => x.ID_ChuyenMuc == idcm).OrderBy(x => x.TGViet).Take(5).ToList();
            cungthumuc.DataSource = listcm;
            cungthumuc.DataBind();
        }
        public string getbaivitecungthumuc(int idchuyenmuc)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(c => c.ID_ChuyenMuc == idchuyenmuc).TenBaiViet;
        }
        // Lay bai viet trong cung chuyên mục end

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
        public void getdatapopular()
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
        // Lấy tên bài viết hiển thị trong tab poppular theo id_bài viêt start

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

        // Láy tên tag cloud start
        public void laytencmpushtag()
        {
            NewsEntities2 db = new NewsEntities2();
            Random ran = new Random();
            int rannum = ran.Next(1, 4);
            List<News.ChuyenMuc> listcm = db.ChuyenMuc.Where(x => x.ID_ChuyenMucCha == 1).Take(rannum).ToList();
            tagscha.DataSource = listcm;
            tagscha.DataBind();
        }
        public List<News.ChuyenMuc> tenchuyenmuc(int idcm)
        {
            NewsEntities2 db = new NewsEntities2();
            //Random rand = new Random();
            //int randnum = rand.Next(1, 10);
            return db.ChuyenMuc.Where(c => c.ID_ChuyenMucCha == idcm).OrderBy(x => x.TenChuyenMuc).ToList();
        }
        protected void tags_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

        }
        protected void tagscha_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater tagscon = (Repeater)e.Item.FindControl("tagscon");
            int id = ((News.ChuyenMuc)e.Item.DataItem).ID_ChuyenMuc;
            tagscon.DataSource = tenchuyenmuc(id);
            tagscon.DataBind();
        }
        // Lây tên tag cloud end


        // Count bài viet chuyen mục start
        public void countbaiviet()
        {
            NewsEntities2 db = new NewsEntities2();

            List<News.ChuyenMuc> listcm = db.ChuyenMuc.Where(x => x.ID_ChuyenMucCha == 1 && x.ID_ChuyenMuc != 101).ToList();
            countCategory.DataSource = listcm;
            countCategory.DataBind();
        }
        public List<News.ChuyenMuc> countbv(int idcm)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.ChuyenMuc.Where(c => c.ID_ChuyenMucCha == idcm).ToList();
        }
        protected void countCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater bv = (Repeater)e.Item.FindControl("tencate");
            int id = ((News.ChuyenMuc)e.Item.DataItem).ID_ChuyenMuc;
            bv.DataSource = countbv(id);
            bv.DataBind();
        }
        public List<News.BaiViet> getCmCoutBv(int id)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.Where(x => x.ID_ChuyenMuc == id).Take(10).ToList();
            //return db.BaiViet.Where(x => x.ID_ChuyenMuc == id).ToList();
            //List<BaiViet> query = (List<BaiViet>)(from p in db.BaiViet.Where(x => x.ID_ChuyenMuc == id)
            //                                      select new
            //                                      {
            //                                          idbaiviet = p.ID_BaiViet,
            //                                          anhthum = p.AnhThumbnail,
            //                                          Tenbai = p.TenBaiViet,
            //                                          Count = db.BaiViet.Where(x => x.ID_ChuyenMuc == id).Count()
            //                                      });
            //return query;
        }
        protected void tencate_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //Repeater tutao = (Repeater)e.Item.FindControl("numbercount");
            //int id = ((News.ChuyenMuc)e.Item.DataItem).ID_ChuyenMuc;
            //NewsEntities2 db = new NewsEntities2();
            //List<News.BaiViet> query = (List<BaiViet>)(from p in db.BaiViet.Where(x => x.ID_ChuyenMuc == id)
            //                                      select new
            //                                      {
            //                                          Count = db.BaiViet.Where(x => x.ID_ChuyenMuc == id).Count()
            //                                      });

            //tutao.DataSource = query;
            //tutao.DataBind();
        }

        public string chon10bai(string tenchuyenmuc)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.ChuyenMuc.First(x => x.TenChuyenMuc == tenchuyenmuc).TenChuyenMuc;
        }


        // Count Bài viết chuyen muc end


        //  Đăng nhập start
        protected void btncreateacount_Click(object sender, EventArgs e)
        {
            NewsEntities2 db = new NewsEntities2();
            News.LoginReader obj = db.LoginReader.FirstOrDefault(x => x.Name == Taikhoan.Text);
            if (obj != null)
            {
                // Cảnh báo mã sản phẩm đã tồn tại

            }
            else
            {
                obj = new News.LoginReader();
                obj.Name = Taikhoan.Text;
                obj.Email = email.Text;
                obj.Password = Password.Text;
                //obj.MaLoai = cmbLoaiSP.SelectedValue;
                

                db.LoginReader.Add(obj);
                db.SaveChanges();
                Response.Redirect("Content.aspx");
            }
        }

        protected void btnlogintag_Click(object sender, EventArgs e)
        {
            //NewsEntities2 db = new NewsEntities2();

            //btnlogintag.Visible = false;
            //btnlogouttag.Visible = true;

        }

        protected void btnlogouttag_Click(object sender, EventArgs e)
        {
            //NewsEntities2 db = new NewsEntities2();
            //btnlogintag.Visible = true;
            //btnlogouttag.Visible = false;
        }
        //  Đăng nhập end

        // hiển thị các comment lab login start
        public void getdatacommentlogin()
        {
            int idbaiviet = int.Parse(Request.QueryString["ID_Baiviet"]);
            NewsEntities2 db = new NewsEntities2();
            List<News.Comment> listcomment = db.Comment.Where(x => x.ID_BaiViet == idbaiviet).ToList();
            licommentlogin.DataSource = listcomment;
            licommentlogin.DataBind();
        }
        public string getidcmlogin(int idreader)
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.LoginReader> listreader = db.LoginReader.OrderBy(x => x.ID_Reader).ToList();
            return db.LoginReader.First(x => x.ID_Reader == idreader).NickName;
        }
        public string laycomdetaillogin(int idreader)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.Comment.First(x => x.ID_Reader == idreader).Comment1;
        }
        public DateTime laytimecomlogin(int idreader)
        {
            NewsEntities2 db = new NewsEntities2();
            return (DateTime)db.Comment.First(x => x.ID_Reader == idreader).Time;
        }
        // hiển thị các comment lab login end


        // hiển thị các comment lab logout start
        public void getdatacommentlogout()
        {
            int idbaiviet = int.Parse(Request.QueryString["ID_Baiviet"]);
            NewsEntities2 db = new NewsEntities2();
            List<News.Comment> listcomment = db.Comment.Where(x => x.ID_BaiViet == idbaiviet).ToList();
            licommentlogout.DataSource = listcomment;
            licommentlogout.DataBind();
        }
        public string getidcomlogout(int idreader)
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.LoginReader> listreader = db.LoginReader.OrderBy(x => x.ID_Reader).OrderBy(c => c.ID_Reader).ToList();
            return db.LoginReader.First(x => x.ID_Reader == idreader).NickName;
        }
        
        public string laycomdetaillogout(int idreader)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.Comment.First(x => x.ID_Comment == idreader).Comment1;
        }
        public DateTime laytimecomlogout(int idreader)
        {
            NewsEntities2 db = new NewsEntities2();
            return (DateTime)db.Comment.First(x => x.ID_Comment == idreader).Time;
        }
        // hiển thị các comment lab logout end


        // Thêm mới comment vào bài viết start
        protected void btnsubmitcom_Click(object sender, EventArgs e)
        {
            NewsEntities2 db = new NewsEntities2();
            int idbaiviet = int.Parse(Request.QueryString["ID_Baiviet"]);
            DateTime addtime = DateTime.Now;
            News.Comment obj = new News.Comment();
                obj.Comment1 = addComment.Text;
                obj.ID_BaiViet = int.Parse(Request.QueryString["ID_Baiviet"]);
                obj.Time = addtime;
                obj.ID_Reader = 3;
                db.Comment.Add(obj);
                db.SaveChanges();
                Response.Redirect("single_page.aspx?ID_Baiviet=" + idbaiviet);
                //loadlaitrang(idbaiviet);
          
        }
        //public void loadlaitrang(int idbv)
        //{
        //    NewsEntities2 db = new NewsEntities2();
        //    if (db.Comment.First(x => x.ID_BaiViet == idbv) != null)
        //    {
        //        List<News.Comment> lscmreload = db.Comment.Where(x => x.ID_BaiViet == idbv).OrderBy(c => c.ID_Reader).ToList();
        //        licommentlogout.DataSource = lscmreload;
        //        licommentlogout.DataBind();
        //    }
        //    else
        //    {
                
        //    }
        //}

        // Thêm mới comment vào bài viết start

        //public void login()
        //{
        //    string taikhoan = Taikhoan.Text;
        //    string matkhau = Password.Text;

        //    NewsEntities2 db = new NewsEntities2();
        //    int soluong = db.LoginReader.Count(x => x.Name == taikhoan && x.Password == matkhau);
        //    if (soluong == 1)
        //    {
        //        Session["Username"] = taikhoan;

        //        Response.Redirect("Content.aspx");
        //    }
        //    else
        //    {
        //        lbError.Text = "Tài khoản hoặc mật khẩu đúng";
        //    }
        //}
    }
}