using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Pages
{
    public partial class DSBaiViet : System.Web.UI.Page
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
                    int count = db.tb_User.Count(x => x.ID_User == id && x.ID_LoaiTK == 2);
                    if (count >= 1)
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
            int id= int.Parse(Session["username"].ToString());
            int cm = int.Parse(db.tb_Role.FirstOrDefault(x => x.ID_User == id && x.ID_LoaiTK == 2).ID_ChuyenMuc.ToString());
            List <News.tb_ChuyenMuc> lstcm = db.tb_ChuyenMuc.Where(x => x.ID_ChuyenMucCha == cm).ToList();
            List<News.tb_BaiViet> lst = new List<tb_BaiViet>();
            for(int i=0; i<lstcm.Count(); i++)
            {
                int cm1 = lstcm[i].ID_ChuyenMuc;
                List<News.tb_BaiViet> obj = db.tb_BaiViet.Where(x => x.ID_ChuyenMuc == cm1).ToList();
                if (obj != null)
                {
                    lst.AddRange(obj);
                }
                
            }
            dgvbaiviet.DataSource = lst;
            dgvbaiviet.DataBind();
        }

        public string getTen(int id)
        {
            NewsEntities db = new NewsEntities();
            return db.tb_User.FirstOrDefault (x => x.ID_User == id).TenUser.ToString();
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
            string ID = e.CommandArgument.ToString();
            int id = int.Parse(ID);
            NewsEntities db = new NewsEntities();
            News.tb_BaiViet obj = db.tb_BaiViet.FirstOrDefault(x => x.ID_BaiViet == id);

            if (obj != null)
            {
                db.tb_BaiViet.Remove(obj);
                db.SaveChanges();
                getdata();
            }
        }

        protected void btnXoa_Command1(CommandEventArgs e)
        {

        }
    }
}