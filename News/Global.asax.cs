using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.SessionState;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using System.Data;


namespace News
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            Application["LuotTruyCap"] = 0;
            Application["LuotOnline"] = 0;

            Application["HomNay"] = 0;
            Application["HomQua"] = 0;
            Application["TuanNay"] = 0;
            Application["TuanTruoc"] = 0;
            Application["ThangNay"] = 0;
            Application["ThangTruoc"] = 0;
            Application["TatCa"] = 0;
            Application["visitors_online"] = 0;
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            //khi bat dau 1 phien lam viec moi tuc la có 1 người dùng truy cập website
            // hệ thống sẽ gọi hàm này để thực hiện

            //tăng lượt truy cập

            Session.Timeout = 150;
            if (Application["LuotTruyCap"] != null)
            {
                Application.Lock();
                Application["LuotTruyCap"] = (int.Parse(Application["LuotTruyCap"].ToString()) + 1).ToString();

                //Tăng lượt đăng online lên 1
                Application["LuotOnline"] = (int.Parse(Application["LuotOnline"].ToString()) + 1).ToString();

                Application.UnLock();

            }

            Application.Lock();
            Application["visitors_online"] = Convert.ToInt32(Application["visitors_online"]) + 1;
            Application.UnLock();
            try
            {
                DataBindSQL mThongKe = new DataBindSQL();
                DataTable dtb = mThongKe.TableThongKe();
                if (dtb.Rows.Count > 0)
                {
                    Application["HomNay"] = long.Parse("0" + dtb.Rows[0]["HomNay"]).ToString("#,###");
                    Application["HomQua"] = long.Parse("0" + dtb.Rows[0]["HomQua"]).ToString("#,###");
                    Application["TuanNay"] = long.Parse("0" + dtb.Rows[0]["TuanNay"]).ToString("#,###");
                    Application["TuanTruoc"] = long.Parse("0" + dtb.Rows[0]["TuanTruoc"]).ToString("#,###");
                    Application["ThangNay"] = long.Parse("0" + dtb.Rows[0]["ThangNay"]).ToString("#,###");
                    Application["ThangTruoc"] = long.Parse("0" + dtb.Rows[0]["ThangTruoc"]).ToString("#,###");
                    Application["TatCa"] = long.Parse("0" + dtb.Rows[0]["TatCa"]).ToString("#,###");
                }
                dtb.Dispose();
                mThongKe = null;
            }
            catch { }

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {
            // khi một phiên làm việc kết thúc --> tức là khi có 1 người dùng thoát khỏi website
            //hệ thống sẽ gọi hàm này để thực hiện
            Application.Lock();
            Application["LuotOnline"] = (int.Parse(Application["LuotOnline"].ToString()) - 1).ToString();

            Application.UnLock();

            Application.Lock();
            Application["visitors_online"] = Convert.ToUInt32(Application["visitors_online"]) - 1;
            Application.UnLock();
            // giảm lượt online xuống 1

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}