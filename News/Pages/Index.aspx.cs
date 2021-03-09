using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;

namespace News.Pages
{
    public partial class Home : System.Web.UI.Page
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
                    lbcm.Text = getcm();
                    lbnv.Text = getnv();
                    lbqc.Text = getqc();
                    txttext1.Text = getdata1();
                    txttext2.Text = getdata2();
                    getNV();

                    NewsEntities db = new NewsEntities();
                    int id = int.Parse(Session["username"].ToString());
                    int cm = int.Parse(db.tb_User.FirstOrDefault(x => x.ID_User == id).ID_LoaiTK.ToString());
                    if (cm == 3)
                    {
                        lbbvduyet.Text = getbvduyet();
                        lbbvcd.Text = getbvcd();

                        tongbien.Visible = true;
                        admin.Visible = false;
                    }
                    else
                    {
                        admin.Visible = true;
                        tongbien.Visible = false;
                    }

                }
            }
            
        }

        string getbvcd()
        {
            NewsEntities db = new NewsEntities();
            int id = int.Parse(Session["username"].ToString());
            int cm = int.Parse(db.tb_Role.FirstOrDefault(x => x.ID_User == id && x.ID_LoaiTK == 2).ID_ChuyenMuc.ToString());
            List<News.tb_ChuyenMuc> lstcm = db.tb_ChuyenMuc.Where(x => x.ID_ChuyenMucCha == cm).ToList();
            List<News.tb_BaiViet> lst = new List<tb_BaiViet>();
            for (int i = 0; i < lstcm.Count(); i++)
            {
                int cm1 = lstcm[i].ID_ChuyenMuc;
                List<News.tb_BaiViet> obj = db.tb_BaiViet.Where(x => x.ID_ChuyenMuc == cm1 && x.TrangThai==false).ToList();
                if (obj != null)
                {
                    lst.AddRange(obj);
                }

            }
            return lst.Count.ToString();
        }
        string getbvduyet()
        {
            NewsEntities db = new NewsEntities();
            int id = int.Parse(Session["username"].ToString());
            int cm = int.Parse(db.tb_Role.FirstOrDefault(x => x.ID_User == id && x.ID_LoaiTK == 2).ID_ChuyenMuc.ToString());
            List<News.tb_ChuyenMuc> lstcm = db.tb_ChuyenMuc.Where(x => x.ID_ChuyenMucCha == cm).ToList();
            List<News.tb_BaiViet> lst = new List<tb_BaiViet>();
            for (int i = 0; i < lstcm.Count(); i++)
            {
                int cm1 = lstcm[i].ID_ChuyenMuc;
                List<News.tb_BaiViet> obj = db.tb_BaiViet.Where(x => x.ID_ChuyenMuc == cm1 && x.TrangThai == true).ToList();
                if (obj != null)
                {
                    lst.AddRange(obj);
                }

            }
            return lst.Count.ToString();
        }

        string getnv()
        {
            NewsEntities db = new NewsEntities();
            return db.tb_User.Count(x => x.ID_User != 0).ToString();
        }

        string getqc()
        {
            NewsEntities db = new NewsEntities();
            return db.tb_QuangCao.Count(x => x.ID_QuangCao != 0).ToString();
        }
        
        string getcm()
        {
            NewsEntities db = new NewsEntities();
            return db.tb_ChuyenMuc.Count(x => x.ID_ChuyenMuc != 0).ToString();
        }
        //biểu đồ
        public string getdata1()
        {
            NewsEntities db = new NewsEntities();
            DateTime aDateTime = DateTime.Now;

            int month1 = int.Parse(aDateTime.Month.ToString());

            int year = int.Parse(aDateTime.Year.ToString());

            List<News.ThongKe> monthdata = db.ThongKe.Where(x => x.ThoiGian.Month == month1 && x.ThoiGian.Year == year).ToList();
            string tk1 = "";
            for (int i = 0; i < monthdata.Count(); i++)
            {
                tk1 += monthdata[i].SoTruyCap.ToString() + "/";
            }
            tk1 = tk1.Substring(0, tk1.Length - 1);
            return tk1;
        }
        public string getdata2()
        {
            NewsEntities db = new NewsEntities();
            DateTime aDateTime = DateTime.Now;

            int month1 = int.Parse(aDateTime.Month.ToString());

            int year = int.Parse(aDateTime.Year.ToString());

            int month2 = 0;
            int year2 = 0;

            int t = int.Parse(aDateTime.AddMonths(-1).Month.ToString());

            if (t == 12)
            {
                month2 = 12;
                year2 = year - 1;
            }
            else
            {
                month2 = month1;
                year2 = year;
            }

            List<News.ThongKe> monthdata2 = db.ThongKe.Where(x => x.ThoiGian.Month == month2 && x.ThoiGian.Year == year2).ToList();
            string tk2 = "";
            for (int i = 0; i < monthdata2.Count(); i++)
            {
                tk2 += monthdata2[i].SoTruyCap.ToString() + "/";
            }
            tk2 = tk2.Substring(0, tk2.Length - 1);
            return tk2;
        }

        // top 3 bài viết có lượt xem nhiều nhất
        public void getBVmaxmonth()
        {
            NewsEntities db = new NewsEntities();
            DateTime aDateTime = DateTime.Now;
            int month = int.Parse(aDateTime.Month.ToString());

            List<News.tb_BaiViet> lstSP = db.tb_BaiViet.Where(x =>x.TGViet.Value.Month == month).OrderBy(x => x.LuotXem).Take(3).ToList();
            dgvbaivietmaxmonth.DataSource = lstSP;
            dgvbaivietmaxmonth.DataBind();
        }


        // nhân viên có nhiều bài đăng trong tháng nhất
        //SELECT TOP 2 WITH TIES tb_BaiViet.ID_User, tb_User.TenUser,count(TenBaiViet) AS SoLuong
            //FROM tb_BaiViet
            //INNER JOIN tb_User ON tb_User.ID_User = tb_BaiViet.ID_User
            //where tb_User.ID_User = tb_BaiViet.ID_User
            //GROUP BY tb_BaiViet.ID_User, tb_User.TenUser
            //ORDER BY SoLuong DESC
        public void getNV()
        {
            NewsEntities db = new NewsEntities();
            SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-I53O5MR\SQLEXPRESS;Initial Catalog=News;Integrated Security=True");

            cnn.Open();
            string sql = "SELECT TOP 2 WITH TIES tb_BaiViet.ID_User, tb_User.TenUser,count(TenBaiViet) AS SoLuong " +
                        "FROM tb_BaiViet INNER JOIN tb_User ON tb_User.ID_User = tb_BaiViet.ID_User " +
                        "Where tb_User.ID_User = tb_BaiViet.ID_User " +
                        "GROUP BY tb_BaiViet.ID_User, tb_User.TenUser " +
                        "ORDER BY SoLuong DESC";  // lay het du lieu trong bang sinh vien
            SqlCommand com = new SqlCommand(sql, cnn); //bat dau truy van
            com.CommandType = CommandType.Text;
            SqlDataAdapter da = new SqlDataAdapter(com); //chuyen du lieu ve
            DataTable dt = new DataTable(); //tạo một kho ảo để lưu trữ dữ liệu
            da.Fill(dt);  // đổ dữ liệu vào kho
            cnn.Close();  // đóng kết nối
            dgvbaivietmaxmonth.DataSource = dt;//đổ dữ liệu vào datagridview
            dgvbaivietmaxmonth.DataBind();
        }

    }
}