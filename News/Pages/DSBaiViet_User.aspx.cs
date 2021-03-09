using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Pages
{
    public partial class DSBaiViet_User : System.Web.UI.Page
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
                    int count = db.tb_User.Count(x => x.ID_User == id && x.ID_LoaiTK == 3);
                    if (count == 1)
                    {
                        getdata();
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
            NewsEntities db = new NewsEntities();
            int id = int.Parse(Session["username"].ToString());
            List<News.tb_BaiViet> lst = db.tb_BaiViet.Where(x=>x.ID_User==id).ToList();
            dgvbaiviet.DataSource = lst;
            dgvbaiviet.DataBind();
        }
        public string getCM(int id)
        {
            NewsEntities db = new NewsEntities();
            return db.tb_ChuyenMuc.FirstOrDefault(x => x.ID_ChuyenMuc == id).TenChuyenMuc.ToString();
        }
        public string getcm(int id)
        {
            NewsEntities db = new NewsEntities();
            return db.tb_ChuyenMuc.FirstOrDefault(x => x.ID_ChuyenMuc == id).TenChuyenMuc.ToString();
        }
        public string gettrangthai(bool id)
        {
            NewsEntities db = new NewsEntities();
            if (id == true)
            {
                return "Đã được duyệt";
            }
            else
            {
                return "Chờ xét duyệt";
            }
        }
        protected void btnXoa_Command(object sender, CommandEventArgs e)
        {
            string IDuser = e.CommandArgument.ToString();
            int id = int.Parse(IDuser);
            NewsEntities db = new NewsEntities();
            News.tb_BaiViet obj = db.tb_BaiViet.FirstOrDefault(x => x.ID_BaiViet == id);
            if (obj != null)
            {
                db.tb_BaiViet.Remove(obj);
                db.SaveChanges();
                getdata();
            }
        }

        protected void btnnew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Detail_Page.aspx");
        }
    }
}