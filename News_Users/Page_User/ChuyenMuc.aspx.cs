using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News_Users.Page_User.ChuyenMuc
{
    
    
public partial class ChuyenMuc : System.Web.UI.Page
{
        private int RowCount;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //getidchuyenmuc1();  //cai này chưa phân trang
                laytenchuyenmuc();
                string idcm = Request.QueryString["ID_ChuyenMuc"];
                FetchData(3, 0);
                getvietrandom();
            }
            else
            {
                plcPaging.Controls.Clear();
                CreatePagingControl();
            }
        }

        //// Featuate repeater chưa phan trang start 
        //public void getidchuyenmuc1()
        //{
        //    int idcm = int.Parse(Request.QueryString["ID_ChuyenMuc"]);
        //    NewsEntities db = new NewsEntities();
        //    List<News_Users.BaiViet> listchuyenmuc = db.BaiViet.Where(x => x.ID_ChuyenMuc == idcm).ToList();
        //    //List<News_Users.ChuyenMuc> listchuyenmuc = db.ChuyenMuc.Where(x => x.ID_ChuyenMuc == idcm).ToList();
        //    dgvchuyenmuc1.DataSource = listchuyenmuc;
        //    //dgvchuyenmuc.DataSource = listchuyenmuc;
        //    dgvchuyenmuc1.DataBind();
        //}
        //public string laycacbaiviet(int idbaiviet)
        //{
        //    NewsEntities db = new NewsEntities();
        //    return db.BaiViet.Where(x => x.ID_ChuyenMuc == idbaiviet).ToString();
        //}
        //// Featuate repeater chưa phan trang end

        //public void getidchuyenmuc()
        //{
        //    int idcm = int.Parse(Request.QueryString["ID_ChuyenMuc"]);
        //    NewsEntities db = new NewsEntities();
        //    List<News_Users.BaiViet> listchuyenmuc = db.BaiViet.Where(x => x.ID_ChuyenMuc == idcm).ToList();
        //    //List<News_Users.ChuyenMuc> listchuyenmuc = db.ChuyenMuc.Where(x => x.ID_ChuyenMuc == idcm).ToList();
        //    dgvchuyenmuc.DataSource = listchuyenmuc;
        //    //dgvchuyenmuc.DataSource = listchuyenmuc;
        //    dgvchuyenmuc.DataBind();
        //}

        //tenchuyenmucotren
        // Lay ten chuyen muc tren cung start 
        public void laytenchuyenmuc()
        {
            int idcmtren = int.Parse(Request.QueryString["ID_ChuyenMuc"]);
            NewsEntities db = new NewsEntities();
            List<News_Users.ChuyenMuc> listcm = db.ChuyenMuc.Where(x => x.ID_ChuyenMuc == idcmtren).ToList();
            tenchuyenmucotren.DataSource = listcm;
            tenchuyenmucotren.DataBind();
        }

        public string tenchuyenmuc(int idcm)
        {
            NewsEntities db = new NewsEntities();
            return db.ChuyenMuc.First(c => c.ID_ChuyenMuc == idcm).TenChuyenMuc;
        }
        // Lay ten chuyen muc tren cung end



        // Phân trang theo chuyên mục start
        // link tham khảo: https://www.dotnetcurry.com/ShowArticle.aspx?ID=345
        public void FetchData(int take, int pagesize)
        {
            int idcm = int.Parse(Request.QueryString["ID_ChuyenMuc"]);
            using (NewsEntities dc = new NewsEntities())
            {
                var query = from p in dc.BaiViet.Where(x => x.ID_ChuyenMuc == idcm).OrderBy(o => o.ID_BaiViet).Take(take).Skip(pagesize)
                            select new
                            {
                                idbaiviet = p.ID_BaiViet,
                                anhthum = p.AnhThumbnail,
                                Tenbai = p.TenBaiViet,
                                Count = dc.BaiViet.Where(x => x.ID_ChuyenMuc == idcm).Count()
                            };
               
                NewsEntities db = new NewsEntities();
                PagedDataSource pgitems = new PagedDataSource();
                pgitems.AllowCustomPaging = true;
                pgitems.AllowPaging = true;
                pgitems.DataSource = query;
                pgitems.PageSize = 3;
                dgvchuyenmuc.DataSource = pgitems;
                dgvchuyenmuc.DataBind();
                if (!IsPostBack)
                {
                    RowCount = query.First().Count;
                    CreatePagingControl();
                }
            }
        }
        private void CreatePagingControl()
        {
            for (int i = 0; i < (RowCount / 3) + 1; i++)
            {
                LinkButton lnk = new LinkButton();
                lnk.Click += new EventHandler(lbl_Click);
                lnk.ID = "lnkPage" + (i + 1).ToString();
                lnk.Text = (i + 1).ToString();
                plcPaging.Controls.Add(lnk);
                Label spacer = new Label();
                spacer.Text = "&nbsp;";
                plcPaging.Controls.Add(spacer);
            }
        }
        void lbl_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int currentPage = int.Parse(lnk.Text);
            int take = currentPage * 3;
            int skip = currentPage == 1 ? 0 : take - 3;
            FetchData(take, skip);
        }
        // Phân trang theo chuyên mục end



        // Read more random start
        public void getvietrandom()
        {
            NewsEntities db = new NewsEntities();
            List<News_Users.BaiViet> num = db.BaiViet.OrderBy(x => x.ID_BaiViet).ToList();
            Random rand = new Random();
            int toskip = rand.Next(1, 10);
            List<News_Users.BaiViet> listsport = db.BaiViet.OrderBy(x => x.TGViet).Skip(toskip).Take(10).ToList();
            dgvbairandom.DataSource = listsport;
            dgvbairandom.DataBind();
        }
        public string showbairandom(string tenbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        }

        public string showbaird(string tenbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        }

        public string getrd(string tenbaiviet)
        {
            NewsEntities db = new NewsEntities();
            return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        }
        // Read more random end


        //  Lay ten chuyen muc đặt cho tiêu đề start

        //  Lay ten chuyen muc dat cho tieu de end
    }
}