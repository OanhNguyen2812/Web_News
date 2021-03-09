using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Pages
{
    public partial class AddCM : System.Web.UI.Page
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
                        getcbbcm();
                        getdata();
                        txtid.Enabled = false;
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
            
            List<News.tb_ChuyenMuc> listsp = db.tb_ChuyenMuc.ToList();
            dgvchuyenmuc.DataSource = listsp;
            dgvchuyenmuc.DataBind();
        }
        public string getTenCM(int ID)
        {
            NewsEntities db = new NewsEntities();
                return db.tb_ChuyenMuc.First(x => x.ID_ChuyenMuc == ID && x.ID_ChuyenMuc !=101).TenChuyenMuc;
            
            //return db.ChuyenMucCha.First(x=> x.ID_ChuyenMucCha == ID).TenChuyenMucCha;
        }
        public string getTen(int ID)
        {
            NewsEntities db = new NewsEntities();
            if (ID == 1)
            {
                return " ";
            }
            else
            {
                return db.tb_ChuyenMuc.First(x => x.ID_ChuyenMuc == ID).TenChuyenMuc;
            }
            //return db.ChuyenMucCha.First(x=> x.ID_ChuyenMucCha == ID).TenChuyenMucCha;
        }
        public void getcbbcm()
        {
            NewsEntities db = new NewsEntities();
            List<News.tb_ChuyenMuc> lst = db.tb_ChuyenMuc.Where(x => x.ID_ChuyenMucCha == 1).ToList();
            cbbchuyenmuccha.DataSource = lst;
            cbbchuyenmuccha.DataTextField = "TenChuyenMuc";
            cbbchuyenmuccha.DataValueField = "ID_ChuyenMuc";
            cbbchuyenmuccha.DataBind();

        }
        protected void btnadd_Click(object sender, EventArgs e)
        {
            NewsEntities db = new NewsEntities();
            News.tb_ChuyenMuc obj = new News.tb_ChuyenMuc();

            if (int.Parse(cbbchuyenmuccha.SelectedValue) == 101)
            {
                obj.TenChuyenMuc = txtten.Text;
                obj.ID_ChuyenMucCha = 1;

                db.tb_ChuyenMuc.Add(obj);
                db.SaveChanges();

                getdata();
                getcbbcm();
            }
            else
            {
                obj.TenChuyenMuc = txtten.Text;
                obj.ID_ChuyenMucCha = int.Parse(cbbchuyenmuccha.SelectedValue);

                db.tb_ChuyenMuc.Add(obj);
                db.SaveChanges();
                getdata();
                getcbbcm();
            }
        }

        protected void btnXoa_Command(object sender, CommandEventArgs e)
        {
            int IDCM = int.Parse(e.CommandArgument.ToString());
            NewsEntities db = new NewsEntities();
            News.tb_ChuyenMuc obj = db.tb_ChuyenMuc.FirstOrDefault(x => x.ID_ChuyenMuc == IDCM);
            if (obj != null)
            {
                db.tb_ChuyenMuc.Remove(obj);
                db.SaveChanges();
                getdata();
                getcbbcm();
            }
        }
    }
}