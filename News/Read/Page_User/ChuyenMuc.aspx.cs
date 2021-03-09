using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Read.Page_User.ChuyenMuc
{
    

    public partial class ChuyenMuc : System.Web.UI.Page
{
        //public int RowCount { get; protected set; }
        static int RowCount;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                //getidchuyenmuc1();  //cai này chưa phân trang
                laytenchuyenmuc();
                string idcm = Request.QueryString["ID_ChuyenMuc"];
                FetchData(10, 0);
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
        //    NewsEntities2 db = new NewsEntities2();
        //    List<News.BaiViet> listchuyenmuc = db.BaiViet.Where(x => x.ID_ChuyenMuc == idcm).ToList();
        //    //List<News.ChuyenMuc> listchuyenmuc = db.ChuyenMuc.Where(x => x.ID_ChuyenMuc == idcm).ToList();
        //    dgvchuyenmuc1.DataSource = listchuyenmuc;
        //    //dgvchuyenmuc.DataSource = listchuyenmuc;
        //    dgvchuyenmuc1.DataBind();
        //}
        //public string laycacbaiviet(int idbaiviet)
        //{
        //    NewsEntities2 db = new NewsEntities2();
        //    return db.BaiViet.Where(x => x.ID_ChuyenMuc == idbaiviet).ToString();
        //}
        //// Featuate repeater chưa phan trang end

        //public void getidchuyenmuc()
        //{
        //    int idcm = int.Parse(Request.QueryString["ID_ChuyenMuc"]);
        //    NewsEntities2 db = new NewsEntities2();
        //    List<News.BaiViet> listchuyenmuc = db.BaiViet.Where(x => x.ID_ChuyenMuc == idcm).ToList();
        //    //List<News.ChuyenMuc> listchuyenmuc = db.ChuyenMuc.Where(x => x.ID_ChuyenMuc == idcm).ToList();
        //    dgvchuyenmuc.DataSource = listchuyenmuc;
        //    //dgvchuyenmuc.DataSource = listchuyenmuc;
        //    dgvchuyenmuc.DataBind();
        //}

        //tenchuyenmucotren
        // Lay ten chuyen muc tren cung start 
        public void laytenchuyenmuc()
        {
            int idcmtren = int.Parse(Request.QueryString["ID_ChuyenMuc"]);
            NewsEntities2 db = new NewsEntities2();
            List<News.ChuyenMuc> listcm = db.ChuyenMuc.Where(x => x.ID_ChuyenMuc == idcmtren).ToList();
            tenchuyenmucotren.DataSource = listcm;
            tenchuyenmucotren.DataBind();
        }

        public string tenchuyenmuc(int idcm)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.ChuyenMuc.First(c => c.ID_ChuyenMuc == idcm).TenChuyenMuc;
        }
        // Lay ten chuyen muc tren cung end



        // Phân trang theo chuyên mục start
        // link tham khảo: https://www.dotnetcurry.com/ShowArticle.aspx?ID=345
        public void FetchData(int take, int pagesize)
        {
            int idcm = int.Parse(Request.QueryString["ID_ChuyenMuc"]);
            using (NewsEntities2 dc = new NewsEntities2())
            {
                var query = from p in dc.BaiViet.Where(c => c.ID_ChuyenMuc == idcm).OrderBy(o => o.ID_BaiViet).Take(take).Skip(pagesize)
                            select new
                            {
                                idbaiviet = p.ID_BaiViet,
                                anhthum = p.AnhThumbnail,
                                Tenbai = p.TenBaiViet,
                                Count = dc.BaiViet.Where(x => x.ID_ChuyenMuc == idcm).Count()
                            };
                PagedDataSource pgitems = new PagedDataSource();
                pgitems.AllowCustomPaging = true;
                pgitems.AllowPaging = true;
                pgitems.DataSource = query;
                pgitems.PageSize = 10;
                dgvchuyenmuc.DataSource = pgitems;
                dgvchuyenmuc.DataBind();
                if (!IsPostBack)
                {
                    RowCount = query.First().Count;
                    CreatePagingControl();
                }
            }
        }
            public void CreatePagingControl()
        {
            
            for (int i = 0; i < (RowCount / 10) + 1; i++)
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
            public void lbl_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            int currentPage = int.Parse(lnk.Text);
            int take = currentPage * 10;
            int skip = currentPage == 1 ? 0 : take - 10;
            FetchData(take, skip);
        }
        // Phân trang theo chuyên mục end



        // Read more random start
        public void getvietrandom()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.BaiViet> num = db.BaiViet.OrderBy(x => x.ID_BaiViet).ToList();
            Random rand = new Random();
            int toskip = rand.Next(1, 10);
            List<News.BaiViet> listsport = db.BaiViet.OrderBy(x => x.TGViet).Skip(toskip).Take(10).ToList();
            dgvbairandom.DataSource = listsport;
            dgvbairandom.DataBind();
        }
        public string showbairandom(string tenbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.BaiViet.First(x => x.TenBaiViet == tenbaiviet).TenBaiViet;
        }

        protected void lblPageName_DataBinding(object sender, EventArgs e)
        {

        }
        protected void lblPageName_Load1(object sender, EventArgs e)
        {
        }
        protected void lblPageName_Click(object sender, EventArgs e)
        {

        }
        // Read more random end


        //  Lay ten chuyen muc đặt cho tiêu đề start

        //  Lay ten chuyen muc dat cho tieu de end
    }
}