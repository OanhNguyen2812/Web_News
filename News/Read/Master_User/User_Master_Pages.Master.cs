using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Read.Master_User
{
    public partial class User_Master_Pages : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getchuyenmuccha();
                getdataquickly();
                getdatauserfull();
            }
        }

        public void getchuyenmuccha()
        {
            NewsEntities2 db = new NewsEntities2();
            List<News.ChuyenMuc> chuyenmuccha = db.ChuyenMuc.Where(x => x.ID_ChuyenMucCha == 1 && x.ID_ChuyenMuc!=101).Take(10).ToList();
            cmcha.DataSource = chuyenmuccha;
            cmcha.DataBind();
        }

        public List<News.ChuyenMuc> getchuyenmuccon(int id)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.ChuyenMuc.Where(x => x.ID_ChuyenMucCha == id).ToList();

        }

        protected void cmcha_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater cmcon= (Repeater)e.Item.FindControl("cmcon");
            int id = ((ChuyenMuc)e.Item.DataItem).ID_ChuyenMuc;
            cmcon.DataSource = getchuyenmuccon(id);
            cmcon.DataBind();
        }

        // Lấy tên bài viết hiển thị trong tab quick link theo id_bài viêt start
        public void getdataquickly()
        {
            NewsEntities2 db = new NewsEntities2();
            Random ran = new Random();
            int rand = ran.Next(1, 5);
            List<News.ChuyenMuc> listquickly = db.ChuyenMuc.OrderBy(x => x.ID_ChuyenMuc).Skip(rand).Take(5).ToList();
            dgvquicklink.DataSource = listquickly;
            dgvquicklink.DataBind();
        }
        public string laytenquickly(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.ChuyenMuc.First(x => x.ID_ChuyenMuc == idbaiviet).TenChuyenMuc;
        }

        // Lấy tên bài viết hiển thị trong tab  quick link theo id_bài viêt end
        // Lấy tên bài viết hiển thị trong tab quick link theo id_bài viêt start
        public void getdatauserfull()
        {
            NewsEntities2 db = new NewsEntities2();
            Random ran = new Random();
            int rand = ran.Next(5, 10);
            List<News.ChuyenMuc> listusefull = db.ChuyenMuc.OrderBy(x => x.ID_ChuyenMuc).Skip(rand).Take(5).ToList();
            dgvusefull.DataSource = listusefull;
            dgvusefull.DataBind();
        }
        public string laytenusefull(int idbaiviet)
        {
            NewsEntities2 db = new NewsEntities2();
            return db.ChuyenMuc.First(x => x.ID_ChuyenMuc == idbaiviet).TenChuyenMuc;
        }

        // Lấy tên bài viết hiển thị trong tab  quick link theo id_bài viêt end

    }

}