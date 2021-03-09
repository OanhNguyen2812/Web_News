using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace News.Pages
{
    public partial class Detail_AD : System.Web.UI.Page
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

                    NewsEntities db = new NewsEntities();
                    int idu = int.Parse(Session["username"].ToString());
                    int count = db.tb_User.Count(x => x.ID_User == idu && x.ID_LoaiTK == 1);
                    if (count == 1)
                    {

                        if (Request.QueryString["maqc"] == null)
                        {
                            btnAdd.Visible = true;
                            btnSave.Visible = false;
                            txtid.Enabled = false;
                        }
                        else
                        {
                            txtid.Enabled = false;
                            btnAdd.Visible = false;
                            btnSave.Visible = true;
                            int id = int.Parse(Request.QueryString["maqc"]);
                            News.tb_QuangCao obj = db.tb_QuangCao.FirstOrDefault(x => x.ID_QuangCao == id);
                            if (obj == null)
                            {
                                Response.Redirect("User.aspx");
                            }
                            else
                            {
                                txtid.Text = obj.ID_QuangCao.ToString();
                                txtcongty.Text = obj.CongTy;
                                txtmota.Text = obj.MoTa;
                                datebd.Text = obj.NgayDang.ToString();
                                datekt.Text = obj.NgayKetThuc.ToString();
                                imgQC.ImageUrl = "../Images/Advertise/" + obj.URL;
                            }

                        }
                    }
                    else
                    {
                        Response.Redirect("Login.aspx");
                    }
                }
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //lbthongbao.Text = "Ngày đăng với ngày kết thúc trùng với quảng cáo nào đó rồi!";
                NewsEntities db = new NewsEntities();
                News.tb_QuangCao obj = new News.tb_QuangCao();
                

                int id = 1 + int.Parse(db.tb_QuangCao.OrderByDescending(p => p.ID_QuangCao).Select(r => r.ID_QuangCao).First().ToString());

                List<News.tb_QuangCao> lstcm = db.tb_QuangCao.ToList();

                for (int i = 0; i < lstcm.Count(); i++)
                {
                    DateTime nd = DateTime.Parse(lstcm[i].NgayDang.ToString());
                    DateTime nkt = DateTime.Parse(lstcm[i].NgayKetThuc.ToString());

                    DateTime bd = DateTime.Parse(datebd.Text);
                    DateTime kt = DateTime.Parse(datekt.Text);

                    int compare1 = DateTime.Compare(bd, nd);
                    int compare2 = DateTime.Compare(bd, nkt);
                    if ((compare1 > 0 && compare2 < 0) || compare1 == 0 || compare2 == 0)
                    {
                        txtngay.Text = "1";
                        break;
                    }
                    int compare3 = DateTime.Compare(kt, nd);
                    int compare4 = DateTime.Compare(kt, nkt);
                    if ((compare3 > 0 && compare4 < 0) || compare3 == 0 || compare4 == 0)
                    {
                        txtngay2.Text = "1";
                        break;
                    }

                }

                if (txtngay.Text == "1" && txtngay2.Text == "1")
                {
                    lbthongbao.Text = "Ngày đăng với ngày kết thúc trùng với quảng cáo nào đó rồi!";
                }
                else if (txtngay.Text == "1" || txtngay.Text=="0")
                {
                    lbthongbao.Text = "Ngày đăng trùng với quảng cáo nào đó rồi!";

                }
                else if (txtngay2.Text == "1" || txtngay.Text == "0")
                {
                    lbthongbao.Text = "Ngày kết thúc trùng với quảng cáo nào đó rồi!";

                }
                else
                {
                    obj.CongTy = txtcongty.Text;
                    obj.MoTa = txtmota.Text;
                    obj.NgayDang = DateTime.Parse(datebd.Text);
                    obj.NgayKetThuc = DateTime.Parse(datekt.Text);
                    if (fuqc.HasFile == true)
                    {
                        string[] file = fuqc.FileName.Split('.');
                        string file_ext = file[file.Length - 1];
                        string file_name = id + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + file_ext;
                        string folder = Server.MapPath("../Images/Advertise/");
                        fuqc.SaveAs(folder + file_name);
                        obj.URL = file_name;
                    }
                    db.tb_QuangCao.Add(obj);
                    db.SaveChanges();

                }


            }
            catch
            {

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                NewsEntities db = new NewsEntities();
                int id = int.Parse(Request.QueryString["maqc"]);
                News.tb_QuangCao obj = db.tb_QuangCao.FirstOrDefault(x => x.ID_QuangCao == id);

                if (obj == null)
                {
                    //
                }
                else
                {
                    obj.CongTy = txtcongty.Text;
                    obj.MoTa = txtmota.Text;
                    obj.NgayDang = DateTime.Parse(datebd.Text);
                    obj.NgayKetThuc = DateTime.Parse(datekt.Text);
                    int idqc = int.Parse(Request.QueryString["maqc"]);

                    if (fuqc.HasFile == true)
                    {
                        string[] file = fuqc.FileName.Split('.');
                        string file_ext = file[file.Length - 1];
                        string file_name = idqc + "_" + DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + file_ext;
                        string folder = Server.MapPath("../Images/Advertise/");
                        fuqc.SaveAs(folder + file_name);
                        obj.URL = file_name;
                    }
                    db.SaveChanges();
                    Response.Redirect("AD.aspx");
                }
            }
            catch
            {

            }
        }

        protected void btnhuy_Click(object sender, EventArgs e)
        {
            Response.Redirect("AD.aspx");
        }
    }
}