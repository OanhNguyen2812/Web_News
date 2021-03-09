using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Text;

namespace News.Pages
{
    public partial class Detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["username"] == null || Session["username"].ToString() == "")
                {
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    getcbbltk();
                    getcbbCM();
                    NewsEntities db = new NewsEntities();
                    int iduser = int.Parse(db.tb_User.OrderByDescending(p => p.ID_User).Select(r => r.ID_User).First().ToString());
                    int id = iduser + 1;
                    txtMaNV.Text = id.ToString();
                    // kiểm tra trường hợp sửa/thêm mới
                    // nếu url có dạng ?masp=123 => sửa, ngược lại là thêm mới
                    if (Request.QueryString["manv"] == null)
                    {
                        // thêm mới
                        txtMaNV.Enabled = false;
                        btnSave.Visible = false;
                        btnAdd.Visible = true;
                        btnThemCM.Visible = false;
                        txtMaNV.Enabled = false;
                    }
                    else
                    {
                        // Sửa
                        btnThemCM.Visible = true;
                        btnSave.Visible = true;
                        btnAdd.Visible = false;


                        txtMaNV.Text = Request.QueryString["manv"];
                        txtMaNV.Enabled = true;
                        txtDiaChi.Enabled = false;
                        txtEmail.Enabled = false;
                        txtGioiTinh.Enabled = false;
                        txtNgheDanh.Enabled = false;
                        txtTenNV.Enabled = false;
                        int idu = int.Parse(txtMaNV.Text);
                        txtMaNV.CssClass = txtMaNV.CssClass + " form-control";
                        // Query về db để lấy các thông tin còn lại
                        News.tb_User obj = db.tb_User.FirstOrDefault(x => x.ID_User == idu);
                        if (obj == null)
                        {
                            Response.Redirect("User.aspx");
                        }
                        else
                        {
                            txtTenNV.Text = obj.TenUser;
                            txtNgheDanh.Text = obj.NickName;
                            txtDiaChi.Text = obj.DiaChi;
                            txtEmail.Text = obj.Email;
                            txtGioiTinh.Text = obj.GioiTinh;

                        }
                    }
                }
            }    
            
        }

        void getcbbCM()
        {
            NewsEntities db = new NewsEntities();
            List<News.tb_ChuyenMuc> lst = db.tb_ChuyenMuc.Where(x => x.ID_ChuyenMuc != 1).ToList();
            cbbChuyenMuc.DataSource = lst;
            cbbChuyenMuc.DataTextField = "TenChuyenMuc";
            cbbChuyenMuc.DataValueField = "ID_ChuyenMuc";
            cbbChuyenMuc.DataBind();
        }
        void getcbbltk()
        {
            NewsEntities db = new NewsEntities();
            List<News.tb_LoaiTK> lst = db.tb_LoaiTK.Where(x => x.ID_LoaiTK != 1).ToList();
            cbbLoaiTK.DataSource = lst;
            cbbLoaiTK.DataTextField = "TenLoaiTK";
            cbbLoaiTK.DataValueField = "ID_LoaiTK";
            cbbLoaiTK.DataBind();
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
                CM += obj.tb_ChuyenMuc.TenChuyenMuc.ToString() + "; ";
                LstDSmaTL.Add(obj.tb_ChuyenMuc.ID_ChuyenMuc.ToString());
                foreach (ListItem item in cbbChuyenMuc.Items)
                {
                    if (item.Value == obj.tb_ChuyenMuc.ID_ChuyenMuc.ToString())
                    {
                        item.Selected = true;
                    }
                }
            }
            return CM;
        }
        [Obsolete]
        public string mahoa(string pass)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pass.Trim(), "MD5");
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                NewsEntities db = new NewsEntities();

                News.tb_User obj = new News.tb_User();
                obj.TenUser = txtTenNV.Text;
                obj.NickName = txtNgheDanh.Text;
                obj.DiaChi = txtDiaChi.Text;
                obj.Email = txtEmail.Text;
                obj.GioiTinh = txtGioiTinh.Text;
                obj.Password = mahoa(txtMaNV.Text);
                db.tb_User.Add(obj);
                db.SaveChanges();

                News.tb_Role objcm = new News.tb_Role();
                objcm.ID_User = int.Parse(txtMaNV.Text);
                objcm.ID_ChuyenMuc = int.Parse(cbbChuyenMuc.SelectedValue);
                objcm.ID_LoaiTK = int.Parse(cbbLoaiTK.SelectedValue);

                db.tb_Role.Add(objcm);
                db.SaveChanges();

                Response.Redirect("User.aspx");

            }
            catch
            {
                //
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void btnThemCM_Click(object sender, EventArgs e)
        {
            NewsEntities db = new NewsEntities();
            News.tb_Role objcm = new News.tb_Role();
            objcm.ID_User = int.Parse(txtMaNV.Text);
            objcm.ID_ChuyenMuc = int.Parse(cbbChuyenMuc.SelectedValue);
            objcm.ID_LoaiTK = int.Parse(cbbLoaiTK.SelectedValue);

            db.tb_Role.Add(objcm);
            db.SaveChanges();

        }
    }
}