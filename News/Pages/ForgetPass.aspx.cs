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
    public partial class ForgetPass : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null || Session["username"].ToString() == "")
            {
                Response.Redirect("Login.aspx");
            }
            else
            { 
            }
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

        protected void btnrepass_Click(object sender, EventArgs e)
        {
            NewsEntities db = new NewsEntities();
            int id = int.Parse(Session["username"].ToString());

            string oldpass = db.tb_User.FirstOrDefault(x => x.ID_User == id).Password.ToString();
            if (oldpass == getMKMH(txtoldpass.Text))
            {
                if (txtpass.Text == txtrepass.Text)
                {
                    News.tb_User obj = db.tb_User.FirstOrDefault(x => x.ID_User == id);
                    if (obj == null)
                    {
                        Response.Redirect("Index.aspx");
                    }
                    else
                    {
                        obj.Password = getMKMH(txtrepass.Text);
                        db.SaveChanges();
                        Response.Redirect("Login.aspx");
                    }
                }
            }
            else
            {

            }


        }
    }
}