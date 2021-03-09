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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
        [Obsolete]
        protected void btnlogin_Click(object sender, EventArgs e)
        {
            string matkhau = getMKMH(txtpass.Text);
            int taikhoan = int.Parse(txtid.Text);
            NewsEntities db = new NewsEntities();
            int soluong = db.tb_User.Count(x => x.ID_User == taikhoan && x.Password == matkhau);
            if (soluong == 1)
            {
                // Dang nhap thanh cong
                Session["username"] = taikhoan;
                Response.Redirect("Index.aspx");
            }
            else
            {
                lbError.Text = "Tài khoản hoặc mật khẩu không đúng!";
            }

        }



        [Obsolete]
        protected void btnsingin_Click(object sender, EventArgs e)
        {
            /*byte[] hs = new byte[50];
            string pass = txtpassword.Text;
            MD5 md5 = MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
            byte[] hash = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                hs[i] = hash[i];
                sb.Append(hs[i].ToString("x2"));
            }
            var hash_pass = sb.ToString();

            string taikhoan = txtusername.Text;
            QLBHEntities db = new QLBHEntities();
            int soluong = db.User.Count(x => x.Username == taikhoan && x.Password == hash_pass);
            if (soluong == 1)
            {
                // Dang nhap thanh cong
                Session["username"] = taikhoan;
                Response.Redirect("Home.aspx");
            }
            else
            {
                lbError.Text = "Tài khoản hoặc mật khẩu không đúng!";
            }
            /*string taikhoan = txtusername.Text;
            string matkhau = txtpassword.Text;
            string passmahoa = mahoa(txtpassword.Text);

            QLBHEntities db = new QLBHEntities();
            int soluong = db.User.Count(x => x.Username == taikhoan && x.Password == passmahoa);
            if (soluong == 1)
            {
                // Dang nhap thanh cong
                Session["username"] = taikhoan;
                Response.Redirect("Home.aspx");
            }
            else
            {
                lbError.Text = "Tài khoản hoặc mật khẩu không đúng!";
            }*/
        }
    }
}