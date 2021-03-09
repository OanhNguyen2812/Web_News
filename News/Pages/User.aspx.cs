using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Pages
{
    public partial class User : System.Web.UI.Page
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
                    int count = db.tb_User.Count(x => x.ID_User == id && x.ID_LoaiTK == 1);
                    if (count == 1)
                    {
                        getData();
                    }
                    else
                    {
                        Session.Clear();

                    }
                }
            }
        }
        public void getData()
        {
            NewsEntities db = new NewsEntities();
            List<News.tb_User> lstSP = db.tb_User.Where(x=> x.ID_LoaiTK!=4 && x.ID_User!=1).ToList();
            dgvuser.DataSource = lstSP;
            dgvuser.DataBind();
        }

        public string getTenCM(int ID)
        {
            NewsEntities db = new NewsEntities();
            int cm = (int)db.tb_Role.FirstOrDefault(x => x.ID_User == ID).ID_ChuyenMuc;
            return db.tb_ChuyenMuc.FirstOrDefault(x => x.ID_ChuyenMuc == cm).TenChuyenMuc;
        }
        public string getTenLoaiTK(int ID)
        {
            NewsEntities db = new NewsEntities();
            int tk = (int)db.tb_User.FirstOrDefault(x => x.ID_User == ID).ID_LoaiTK;
            return db.tb_LoaiTK.FirstOrDefault(x => x.ID_LoaiTK == tk).TenLoaiTK;
        }

        public string getCM(int ma)
        {
            List<string> LstDSmaTL = new List<string>();
            NewsEntities db = new NewsEntities();
            string CM = "";
            List<tb_Role> lstCM = db.tb_Role.Where(x => x.ID_User == ma).ToList();
            int sl = lstCM.Count();
            for (int i = 0; i < sl; i++)
            {
                tb_Role obj = lstCM.ElementAt(i);
                CM += obj.tb_ChuyenMuc.TenChuyenMuc.ToString() + " || ";
                LstDSmaTL.Add(obj.tb_ChuyenMuc.ID_ChuyenMuc.ToString());
            }
            return CM;
        }
        protected void btnXoa_Command(object sender, CommandEventArgs e)
        {
            string IDuser = e.CommandArgument.ToString();
            int id = int.Parse(IDuser);
            NewsEntities db = new NewsEntities();
            News.tb_User obj = db.tb_User.FirstOrDefault(x => x.ID_User == id);
            List<tb_Role> objcm= db.tb_Role.Where(x => x.ID_User == id).ToList();
            if (objcm!=null )
            {
                db.tb_Role.RemoveRange(objcm);
                db.SaveChanges();
            }
            if (obj != null)
            {
                db.tb_User.Remove(obj);
                db.SaveChanges();
                getData();
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            Response.Redirect("Detail-User.aspx?manv=1");
        }
    }
}