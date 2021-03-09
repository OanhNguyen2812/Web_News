using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News_Users.Master_User
{
    public partial class User_Master_Pages : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getchuyenmuccha();
            }
        }

        public void getchuyenmuccha()
        {
            NewsEntities db = new NewsEntities();
            List<News_Users.ChuyenMuc> chuyenmuccha = db.ChuyenMuc.Where(x => x.ID_ChuyenMucCha == 1 && x.ID_ChuyenMuc!=101).ToList();
            cmcha.DataSource = chuyenmuccha;
            cmcha.DataBind();
        }

        public List<News_Users.ChuyenMuc> getchuyenmuccon(int id)
        {
            NewsEntities db = new NewsEntities();
            return db.ChuyenMuc.Where(x => x.ID_ChuyenMucCha == id).ToList();

        }

        protected void cmcha_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater cmcon= (Repeater)e.Item.FindControl("cmcon");
            int id = ((ChuyenMuc)e.Item.DataItem).ID_ChuyenMuc;
            cmcon.DataSource = getchuyenmuccon(id);
            cmcon.DataBind();
        }
        
    }

}