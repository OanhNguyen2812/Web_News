using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Security.Cryptography;

namespace News.Pages
{
    public partial class Detail_User : System.Web.UI.Page
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
                    getcbbltk();
                    getcbbCM();
                    getcv();
                    //if (Session["username"] == null || Session["username"].ToString() == "")
                    //{
                    //    Response.Redirect("Login.aspx");
                    //}
                    //else
                    //{
                    if (Request.QueryString["manv"] == null)
                        {
                            getDGVCM();
                            int i = int.Parse(Session["username"].ToString());
                            // sửa bên nhân viên
                            loaitk.Visible = false;
                            chuyenmuc.Visible = false;

                            loaicv.Visible = false;
                            cbbLoaicv.Visible = false;
                            btnAddcm.Visible = false;
                            cbbChuyenMuc.Visible = false;
                            txtMaNV.Enabled = false;
                            btnSave.Visible = true;
                            btnAdd.Visible = false;
                            btnAddcm.Visible = true;
                            txtMaNV.Text = i.ToString(); //Request.QueryString["manv"];
                            txtMaNV.Enabled = false;
                            txtDiaChi.Enabled = true;
                            txtEmail.Enabled = true;
                            txtGioiTinh.Enabled = true;
                            txtNgheDanh.Enabled = true;
                            txtTenNV.Enabled = true;
                            cbbChuyenMuc.Enabled = false;
                            imgAnhDaiDien.ImageUrl = "../Images/Users/" + getAnh();
                            int id = int.Parse(txtMaNV.Text);
                            txtMaNV.CssClass = txtMaNV.CssClass + " form-control";
                            // Query về db để lấy các thông tin còn lại
                            NewsEntities db = new NewsEntities();
                            News.tb_User obj = db.tb_User.FirstOrDefault(x => x.ID_User == i);
                            if (obj == null)
                            {
                                Response.Redirect("User.aspx");
                            }
                            else
                            {

                                cbbLoaicv.Enabled = true;
                                txtTenNV.Text = obj.TenUser;
                                txtNgheDanh.Text = obj.NickName;
                                txtDiaChi.Text = obj.DiaChi;
                                txtEmail.Text = obj.Email;
                                txtGioiTinh.Text = obj.GioiTinh;
                                //txtNgayDK = obj.NgayDK;

                            }
                        }
                        else if (Request.QueryString["manv"] == 1.ToString())
                        {
                            // thêm mới
                            lbhienthi.Text = "Cần thêm user trước";
                            NewsEntities db = new NewsEntities();
                            int id = 1 + int.Parse(db.tb_User.OrderByDescending(p => p.ID_User).Select(r => r.ID_User).First().ToString());
                            txtMaNV.Text = id.ToString();

                            txtMaNV.Enabled = false;
                            btnSave.Visible = false;
                            btnAdd.Visible = true;
                            txtMaNV.Enabled = false;
                            getDGVCM2();
                        }
                        else
                        {
                            getDGVCM1();
                            // Sửa bên admin

                            cbbLoaicv.Enabled = true;
                            fuUrl.Enabled = false;
                            txtMaNV.Enabled = false;
                            btnSave.Visible = true;
                            btnAdd.Visible = false;
                            btnAddcm.Visible = true;
                            txtMaNV.Text = Request.QueryString["manv"];
                            txtMaNV.Enabled = false;
                            txtDiaChi.Enabled = false;
                            txtEmail.Enabled = false;
                            txtGioiTinh.Enabled = false;
                            txtNgheDanh.Enabled = false;
                            txtTenNV.Enabled = false;
                            imgAnhDaiDien.ImageUrl = "../Images/Users/" + getAnh1();
                            int id = int.Parse(txtMaNV.Text);
                            txtMaNV.CssClass = txtMaNV.CssClass + " form-control";
                            // Query về db để lấy các thông tin còn lại
                            NewsEntities db = new NewsEntities();
                            News.tb_User obj = db.tb_User.FirstOrDefault(x => x.ID_User == id);
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
                                //txtNgayDK = obj.NgayDK;

                            }
                        //}
                    }
                }
            }
        }
        void getcbbCM()
        {
            NewsEntities db = new NewsEntities();
            List<News.tb_ChuyenMuc> lst = db.tb_ChuyenMuc.ToList();
            cbbChuyenMuc.DataSource = lst;
            cbbChuyenMuc.DataTextField = "TenChuyenMuc";
            cbbChuyenMuc.DataValueField = "ID_ChuyenMuc";
            cbbChuyenMuc.DataBind();
        }

        void getcv()
        {
            NewsEntities db = new NewsEntities();
            List<News.tb_LoaiTK> lst = db.tb_LoaiTK.Where(x => x.ID_LoaiTK != 4).ToList();
            cbbLoaicv.DataSource = lst;
            cbbLoaicv.DataTextField = "TenLoaiTK";
            cbbLoaicv.DataValueField = "ID_LoaiTK";
            cbbLoaicv.DataBind();
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


        public string getMKMH(string mkinput)
        {
            MD5 mh = MD5.Create();
            byte[] strinput = System.Text.Encoding.ASCII.GetBytes(mkinput);
            byte[] hash = mh.ComputeHash(strinput);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            string MK = sb.ToString();
            return MK;
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
                obj.Password = getMKMH(txtMaNV.Text);
                obj.ID_LoaiTK = int.Parse(cbbLoaicv.SelectedValue);

                int iduser = 1 + int.Parse(db.tb_User.OrderByDescending(p => p.ID_User).Select(r => r.ID_User).First().ToString());
                txtMaNV.Text = iduser.ToString();

                //Kiểm tra người dùng đã chọn file hay chưa
                if (fuUrl.HasFile == true)
                {
                    // Tạo file name
                    string[] file = fuUrl.FileName.Split('.');
                    string file_ext = file[file.Length - 1];
                    string file_name = iduser + "_" +
                        DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + file_ext;
                    string folder = Server.MapPath("../Images/Users/");
                    fuUrl.SaveAs(folder + file_name);
                    obj.AnhDaiDien = file_name;
                }

                db.tb_User.Add(obj);
                db.SaveChanges();
                Response.Redirect("User.aspx");
            }
            catch
            {

            }
            //try
            //{
            //    NewsEntities db = new NewsEntities();
            //    News.tb_User obj = new News.tb_User();
            //    obj.TenUser = txtTenNV.Text;
            //    obj.NickName = txtNgheDanh.Text;
            //    obj.DiaChi = txtDiaChi.Text;
            //    obj.Email = txtEmail.Text;
            //    obj.GioiTinh = txtGioiTinh.Text;
            //    obj.Password = getMKMH(txtMaNV.Text);
            //    obj.ID_LoaiTK = int.Parse(cbbLoaicv.SelectedValue);
            //    int iduser = 1 +  int.Parse(db.tb_User.OrderByDescending(p => p.ID_User).Select(r => r.ID_User).First().ToString());
            //    txtMaNV.Text = iduser.ToString();

            //    // Kiểm tra người dùng đã chọn file hay chưa
            //    if (fuUrl.HasFile == true)
            //    {
            //        // Tạo file name
            //        string[] file = fuUrl.FileName.Split('.');
            //        string file_ext = file[file.Length - 1];
            //        string file_name = iduser + "_" +
            //            DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + file_ext;
            //        string folder = Server.MapPath("../Images/Users/");
            //        fuUrl.SaveAs(folder + file_name);
            //        obj.AnhDaiDien =file_name;
            //    }
            //    db.tb_User.Add(obj);
            //    db.SaveChanges();
            //    Response.Redirect("User.aspx");
            //}
            //catch
            //{
            //    //
            //}
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            
        }
        public string getAnh()
        {
            int id = int.Parse(Session["username"].ToString());
            NewsEntities db = new NewsEntities();
            return db.tb_User.FirstOrDefault(x => x.ID_User == id).AnhDaiDien;
        }

        public string getAnh1()
        {
            int id = int.Parse(Request.QueryString["manv"].ToString());
            NewsEntities db = new NewsEntities();
            return db.tb_User.FirstOrDefault(x => x.ID_User == id).AnhDaiDien;
        }

        protected void btnAddcm_Click(object sender, EventArgs e)
        {
            NewsEntities db = new NewsEntities();
            News.tb_Role obj1 = new News.tb_Role();
           
            int cm= int.Parse(cbbChuyenMuc.SelectedValue);
            
            int tk= int.Parse(cbbLoaiTK.SelectedValue);
            if (int.Parse(cbbLoaiTK.SelectedValue) == 2)
            {
                int count = db.tb_Role.Count(x => x.ID_ChuyenMuc == cm && x.ID_LoaiTK == 2);

                if (count >= 1)
                {
                    lbhienthi1.Text = "Đã có tổng biên cho chuyên mục rồi";
                    return ;
                }
            }
                lbhienthi1.Text = "";
                obj1.ID_User = Int32.Parse(txtMaNV.Text);
                obj1.ID_LoaiTK = int.Parse(cbbLoaiTK.SelectedValue);
                obj1.ID_ChuyenMuc = int.Parse(cbbChuyenMuc.SelectedValue);

                db.tb_Role.Add(obj1);
                db.SaveChanges();
                getDGVCM2();
                getDGVCM1();
        }

        int gettest()
        {
            NewsEntities db = new NewsEntities();
            News.tb_Role obj1 = new News.tb_Role();
            int cm = int.Parse(cbbLoaiTK.SelectedValue);

            int count = db.tb_Role.Count(x => x.ID_ChuyenMuc == cm && x.ID_LoaiTK == 2);
            return count;
        }

        public void getDGVCM1()
        {
            int id = int.Parse(Request.QueryString["manv"]);

            NewsEntities db = new NewsEntities();
            List<News.tb_Role> lstSP = db.tb_Role.Where(x => x.ID_User == id).ToList();
            dgvcm.DataSource = lstSP;
            dgvcm.DataBind();
        }
        public void getDGVCM2()
        {
            int id = int.Parse(txtMaNV.Text);

            NewsEntities db = new NewsEntities();
            int id2 = int.Parse(db.tb_User.Max(x=>x.ID_User).ToString());
            int count= db.tb_Role.Count(x => x.ID_User == id);
            if (id == id2)
            {
                List<News.tb_Role> lstSP = db.tb_Role.Where(x => x.ID_User == id).ToList();
                dgvcm.DataSource = lstSP;
                dgvcm.DataBind();
            }
            else if(count == 1 )
            {
                List<News.tb_Role> lstSP = db.tb_Role.Where(x => x.ID_User == id).ToList();
                dgvcm.DataSource = lstSP;
                dgvcm.DataBind();
                
            }
            
        }
        public void getDGVCM()
        {
            int id = int.Parse(Session["username"].ToString());
            NewsEntities db = new NewsEntities();
            List<News.tb_Role> lstSP = db.tb_Role.Where(x =>x.ID_User==id).ToList();
            dgvcm.DataSource = lstSP;
            dgvcm.DataBind();
        }
        public string getTenCM(int id)
        {
            NewsEntities db = new NewsEntities();
            return db.tb_ChuyenMuc.FirstOrDefault(x => x.ID_ChuyenMuc == id).TenChuyenMuc.ToString();
        }
        public string getChucVu(int id)
        {
            NewsEntities db = new NewsEntities();
            return db.tb_LoaiTK.FirstOrDefault(x => x.ID_LoaiTK == id).TenLoaiTK.ToString();
        }

        protected void btnXoaDGV_Command(object sender, CommandEventArgs e)
        {
           
            int id = int.Parse(txtMaNV.Text);
            int idcm = int.Parse(e.CommandArgument.ToString());
            
            NewsEntities db = new NewsEntities();
            News.tb_Role objcm = db.tb_Role.FirstOrDefault(x => x.ID_User == id && x.ID_ChuyenMuc==idcm);
            if (objcm != null)
            {
                db.tb_Role.Remove(objcm);
                db.SaveChanges();

                getDGVCM();
                getDGVCM1();
                getDGVCM2();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                NewsEntities db = new NewsEntities();
                int id = int.Parse(txtMaNV.Text);

                News.tb_User obj = db.tb_User.FirstOrDefault(x => x.ID_User == id);
                if (obj == null)
                {
                    Response.Redirect("User.aspx");
                }
                else
                {
                    // Kiểm tra người dùng đã chọn file hay chưa
                    if (fuUrl.HasFile == true)
                    {
                        // Tạo file name
                        string[] file = fuUrl.FileName.Split('.');
                        string file_ext = file[file.Length - 1];
                        string file_name = txtMaNV.Text + "_" +
                            DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + file_ext;
                        string folder = Server.MapPath("../Images/Users/");
                        fuUrl.SaveAs(folder + file_name);
                        obj.AnhDaiDien = file_name;
                        db.SaveChanges();
                    }

                    obj.TenUser = txtTenNV.Text;
                    obj.NickName = txtNgheDanh.Text;
                    obj.ID_LoaiTK = int.Parse(cbbLoaicv.SelectedValue);
                    obj.GioiTinh = txtGioiTinh.Text;
                    obj.Email = txtEmail.Text;
                    obj.DiaChi = txtDiaChi.Text;

                    db.SaveChanges();
                    Response.Redirect("User.aspx");
                }
            }
            catch
            {
                // Lỗi 
            }
        }
    }
}

// kiểm tra trường hợp sửa/thêm mới
// nếu url có dạng ?masp=123 => sửa, ngược lại là thêm mới
//if (Request.QueryString["manv"] == null)
//{
//    // thêm mới
//    NewsEntities db = new NewsEntities();
//    int id = 1 + int.Parse(db.User.OrderByDescending(p => p.ID_User).Select(r => r.ID_User).First().ToString());
//    txtMaNV.Text = id.ToString();

//    txtMaNV.Enabled = false;
//    btnSave.Visible = false;
//    btnAdd.Visible = true;
//    txtMaNV.Enabled = false;
//}
//else
//{
//    // Sửa
//    txtMaNV.Enabled = false;
//    btnSave.Visible = true;
//    btnAdd.Visible = false;
//    btnAddcm.Visible = true;
//    txtMaNV.Text = Request.QueryString["manv"];
//    txtMaNV.Enabled = false;
//    txtDiaChi.Enabled = false;
//    txtEmail.Enabled = false;
//    txtGioiTinh.Enabled = false;
//    txtNgheDanh.Enabled = false;
//    txtTenNV.Enabled = false;
//    int id = int.Parse(txtMaNV.Text);
//    txtMaNV.CssClass = txtMaNV.CssClass + " form-control";
//    // Query về db để lấy các thông tin còn lại
//    NewsEntities db = new NewsEntities();
//    News.User obj = db.User.FirstOrDefault(x => x.ID_User == id);
//    if (obj == null)
//    {
//        Response.Redirect("User.aspx");
//    }
//    else
//    {
//        txtTenNV.Text = obj.TenUser;
//        txtNgheDanh.Text = obj.NickName;
//        txtDiaChi.Text = obj.DiaChi;
//        txtEmail.Text = obj.Email;
//        txtGioiTinh.Text = obj.GioiTinh;
//        //txtNgayDK = obj.NgayDK;

//    }
//}


