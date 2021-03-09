using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Pages
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["username"] != null )
            //{
            //    //Session.Clear();
            //    //Session.Remove("username");
            //    //Session.Abandon();
            //    Session["username"] = "";
            //    //HttpContext.Current.Session.Remove("userName");
            //    Response.Redirect("Login.aspx");

            //}
            Session.Clear();
            Session.Abandon();
            Session.RemoveAll();
            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Response.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["ASP.NET_SessionId"].Value = string.Empty;
                Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", string.Empty));
            }
            Response.Redirect("Login.aspx");
        }
    }
}