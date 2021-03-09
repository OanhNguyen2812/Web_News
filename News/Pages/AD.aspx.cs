using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Pages
{
    public partial class AD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
            else { 
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
        public void getData()
        {
            NewsEntities db = new NewsEntities();
            List<News.tb_QuangCao> lst = db.tb_QuangCao.OrderBy(x => x.ID_QuangCao).ToList();
            rpquangcao.DataSource = lst;
            rpquangcao.DataBind();
        }
        protected void btnnew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Detail_AD.aspx");
        }

        protected void btnXoa_Command(object sender, CommandEventArgs e)
        {
            string ID = e.CommandArgument.ToString();
            int id = int.Parse(ID);
            NewsEntities db = new NewsEntities();
            News.tb_QuangCao obj = db.tb_QuangCao.FirstOrDefault(x => x.ID_QuangCao == id);
            
            if (obj != null)
            {
                db.tb_QuangCao.Remove(obj);
                db.SaveChanges();
                getData();
            }
        }
    }
}