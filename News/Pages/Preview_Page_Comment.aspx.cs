using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Pages
{
    public partial class Preview_Page_Comment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] == null || Session["username"].ToString() == "")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    NewsEntities db = new NewsEntities();
                    int id = int.Parse(Session["username"].ToString());
                    int count = db.tb_User.Count(x => x.ID_User == id && (x.ID_LoaiTK == 1 || x.ID_LoaiTK == 3));
                    if (count == 1)
                    {
                        if (Request.QueryString["mabv"] == null)
                        {

                        }
                        else
                        {
                            getdata();
                            lbten.Text = getTen();
                            lbmo.Text = getMo();
                        }
                    }
                    else
                    {
                        Session.Clear();
                    }
                    
                }
            }

        }
        public void getdata()
        {
            int id = int.Parse(Request.QueryString["mabv"]);
            NewsEntities db = new NewsEntities();
            List<News.tb_LSBaiViet> lst = db.tb_LSBaiViet.Where(x=>x.ID_BaiViet==id).ToList();
            rpLS.DataSource = lst;
            rpLS.DataBind();
        }

        public string getTen()
        {
            int id = int.Parse(Request.QueryString["mabv"]);
            NewsEntities db = new NewsEntities();
            return db.tb_BaiViet.FirstOrDefault(x => x.ID_BaiViet == id).TenBaiViet;
        }
        public string getMo()
        {
            int id = int.Parse(Request.QueryString["mabv"]);
            NewsEntities db = new NewsEntities();
            return db.tb_BaiViet.FirstOrDefault(x => x.ID_BaiViet == id).NoiDung;
        }
        public string getTenNV(int id)
        {
            NewsEntities db = new NewsEntities();
            return db.tb_User.FirstOrDefault(x => x.ID_User == id).TenUser;
        }
        public string getANV(int id)
        {
            NewsEntities db = new NewsEntities();
            return db.tb_User.FirstOrDefault(x => x.ID_User == id).AnhDaiDien;
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            try
            {

                DateTime aDateTime = DateTime.Now;
                NewsEntities db = new NewsEntities();
                int id = int.Parse(Request.QueryString["mabv"]);
                News.tb_BaiViet obj = db.tb_BaiViet.FirstOrDefault(x => x.ID_BaiViet == id);

                News.tb_LSBaiViet obj1 =new News.tb_LSBaiViet();
                
                obj1.ID_BaiViet = id;
                obj1.GhiChu = txtghichu.Text;
                obj1.ID_User= int.Parse(Session["username"].ToString());
                obj1.ThoiGian = aDateTime;
                db.tb_LSBaiViet.Add(obj1);
                db.SaveChanges();
                getdata();
                txtghichu.Text = "";
            }
            catch
            {
                // Lỗi 
            }
        }

        protected void btnduyet_Click(object sender, EventArgs e)
        {
            NewsEntities db = new NewsEntities();
            int id = int.Parse(Request.QueryString["mabv"]);
            News.tb_BaiViet obj = db.tb_BaiViet.FirstOrDefault(x => x.ID_BaiViet == id);
            if (obj == null)
            {
                //
            }
            else
            {

                obj.TrangThai = true;

                db.SaveChanges();
                Response.Redirect("DSBaiViet.aspx");
            }

            
        }
    }
}