using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Pages.NhanVien
{
    public partial class DSBaiViet_User : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getdata();
            }
        }
        public void getdata()
        {
            NewsEntities db = new NewsEntities();
            List<News.tb_BaiViet> lst = db.tb_BaiViet.ToList();
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

        }
    }
}