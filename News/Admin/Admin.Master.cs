using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NewsEntities db = new NewsEntities();
            if (!IsPostBack)
            {
                if (Session["username"] == null || Session["username"].ToString() == "")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    int id = int.Parse(Session["username"].ToString());
                    //lbName.Text = Session["username"].ToString();
                    News.tb_User obj = db.tb_User.FirstOrDefault(x => x.ID_User == id);
                    if (obj == null)
                    {

                    }
                    else
                    {
                        lbName.Text = getRole().ToString();
                        lbName.Text = obj.TenUser;
                        imgAnhDaiDien.ImageUrl = "../Images/Users/" + getAnh();
                    }

                    if (getRole() == 1)
                    {
                        dsbvtb.Visible = false;
                        bvmoi.Visible = false;
                    }
                    else if (getRole() == 1004)
                    {
                        if (getRole2() >= 1)
                        {
                            chuyenmuc.Visible = false;
                            quangcao.Visible = false;
                            nhanvien.Visible = false;
                        }
                        else
                        {
                            chuyenmuc.Visible = false;
                            dsbvtb.Visible = false;
                            quangcao.Visible = false;
                            nhanvien.Visible = false;
                        }
                    }
                }

            }
        }
        public string getAnh()
        {
            int id = int.Parse(Session["username"].ToString());
            NewsEntities db = new NewsEntities();
            return db.tb_User.FirstOrDefault(x => x.ID_User == id).AnhDaiDien;
        }

        public int getRole()
        {
            int id = int.Parse(Session["username"].ToString());
            NewsEntities db = new NewsEntities();
            string r= db.tb_User.FirstOrDefault(x => x.ID_User == id).ID_LoaiTK.ToString();
            return int.Parse(r);
        }
        public int getRole2()
        {
            int id = int.Parse(Session["username"].ToString());
            NewsEntities db = new NewsEntities();
            int r = db.tb_Role.Count(x => x.ID_User == id && x.ID_LoaiTK==2);
           
            return r;
            
        }
    }
}