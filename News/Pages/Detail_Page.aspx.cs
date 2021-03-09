using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Pages
{
    public partial class Detail_Page : System.Web.UI.Page
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
                    int idu = int.Parse(Session["username"].ToString());
                    int count = db.tb_User.Count(x => x.ID_User == idu && x.ID_LoaiTK == 1004);
                    if (count == 1)
                    {
                        getcbbChuyenMuc();
                        if (Request.QueryString["mabv"] == null)
                        {
                            btnAdd.Visible = true;
                            btnSave.Visible = false;
                        }
                        else
                        {
                            btnAdd.Visible = false;
                            btnSave.Visible = true;
                            int id = int.Parse(Request.QueryString["mabv"]);
                            News.tb_BaiViet obj = db.tb_BaiViet.FirstOrDefault(x => x.ID_BaiViet == id);
                            if (obj == null)
                            {
                                Response.Redirect("User.aspx");
                            }
                            else
                            {
                                txttieude.Text = obj.TenBaiViet;
                                txttomtat.Text = obj.TomTat;
                                txtnoidung.Text = obj.NoiDung;

                            }
                        }
                    }
                    else
                    {
                        Session.Clear();
                    }
                    
                }
            }
        }

        public void getcbbChuyenMuc()
        {
            //NewsEntities db = new NewsEntities();
            ////List<News.ChuyenMuc> lst = db.ChuyenMuc.Where(x => x.ID_ChuyenMuc != 1).ToList();
            //List<News.Role> lst = db.Role.Where(x => x.ID_ChuyenMuc != 1).ToList();
            //cbbChuyenMuc.DataSource = lst;
            //cbbChuyenMuc.DataTextField = "TenChuyenMuc";
            //cbbChuyenMuc.DataValueField = "ID_ChuyenMuc";
            //cbbChuyenMuc.DataBind();


            NewsEntities db = new NewsEntities();
            int id = int.Parse(Session["username"].ToString());
            List<News.tb_Role> lstr = db.tb_Role.Where(x => x.ID_User == id ).ToList();
            List<News.tb_ChuyenMuc> lst = new List<tb_ChuyenMuc>();
            for (int i = 0; i < lstr.Count(); i++)
            {
                int role = int.Parse(lstr[i].ID_ChuyenMuc.ToString());
                int q= int.Parse(lstr[i].ID_LoaiTK.ToString());
                if (role != 2)
                {
                    List<News.tb_ChuyenMuc> obj = db.tb_ChuyenMuc.Where(x => x.ID_ChuyenMuc == role).ToList();
                    if (obj != null)
                    {
                        lst.AddRange(obj);
                    }
                }
                if (role != 2 && q==2)
                {
                    List<News.tb_ChuyenMuc> obj1 = db.tb_ChuyenMuc.Where(x => x.ID_ChuyenMucCha == role).ToList();
                    if (obj1 != null)
                    {
                        lst.AddRange(obj1);
                    }
                }
            }
            cbbChuyenMuc.DataSource = lst;
            cbbChuyenMuc.DataTextField = "TenChuyenMuc";
            cbbChuyenMuc.DataValueField = "ID_ChuyenMuc";
            cbbChuyenMuc.DataBind();

        }

        public int getidbv()
        {
            return int.Parse(Request.QueryString["mabv"]);
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime aDateTime = DateTime.Now;
                NewsEntities db = new NewsEntities();
                News.tb_BaiViet obj = new News.tb_BaiViet();
                obj.TenBaiViet = txttieude.Text;
                obj.TomTat = txttomtat.Text;
                obj.NoiDung = txtnoidung.Text;
                obj.ID_ChuyenMuc = int.Parse(cbbChuyenMuc.SelectedValue);
                obj.TGViet = aDateTime;
                obj.TrangThai = false;
                obj.ID_User = int.Parse(Session["username"].ToString());
                obj.LuotXem = 0;
                int idbv = 1 + int.Parse(db.tb_BaiViet.OrderByDescending(p => p.ID_BaiViet).Select(r => r.ID_BaiViet).First().ToString());
                // Kiểm tra người dùng đã chọn file hay chưa

                if (fumain.HasFile == true)
                {
                    // Tạo file name
                    string[] file = fumain.FileName.Split('.');
                    string file_ext = file[file.Length - 1];
                    string file_name = idbv + "_" + "Th" + "_" +
                        DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + file_ext;
                    string folder = Server.MapPath("../Images/Thums/");
                    fumain.SaveAs(folder + file_name);
                    obj.AnhDaiDien = file_name;
                }
                db.tb_BaiViet.Add(obj);
                db.SaveChanges();

                Response.Redirect("DSBaiViet_User.aspx");

            }
            catch
            {
                //
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            DateTime aDateTime = DateTime.Now;
            NewsEntities db = new NewsEntities();
            int id = int.Parse(Request.QueryString["mabv"]);
            News.tb_BaiViet obj = db.tb_BaiViet.FirstOrDefault(x => x.ID_BaiViet == id);
            if (obj == null)
            {
                //
            }
            else
            {
                obj.TenBaiViet = txttieude.Text;
                obj.TomTat = txttomtat.Text;
                obj.NoiDung = txtnoidung.Text;
                obj.ID_ChuyenMuc = int.Parse(cbbChuyenMuc.SelectedValue);
                obj.TGViet = aDateTime;
                obj.TrangThai = false;
                int idbv = int.Parse(Request.QueryString["mabv"]);
                // Kiểm tra người dùng đã chọn file hay chưa
                if (fumain.HasFile == true)
                {
                    // Tạo file name
                    string[] file = fumain.FileName.Split('.');
                    string file_ext = file[file.Length - 1];
                    string file_name = idbv + "_" +
                        DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + file_ext;
                    string folder = Server.MapPath("../Images/Thums/");
                    fumain.SaveAs(folder + file_name);
                    obj.AnhDaiDien = file_name;
                }
                db.SaveChanges();
            }

            Response.Redirect("DSBaiViet_User.aspx");
        }

        protected void btnpre_Click(object sender, EventArgs e)
        {
            Response.Redirect("Preview_Page_Comment.aspx?mabv=" + getidbv());
        }
    }
}