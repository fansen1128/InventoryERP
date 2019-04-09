using Inventory.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventory.UI
{
    public partial class Login : System.Web.UI.Page
    {
        private readonly ManagerBLL bllman = new ManagerBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Onclick(object sender, EventArgs e)
        {
            string mno = Request.Form["mno"].ToString();
            string mname = Request.Form["mname"].ToString();
            if(bllman.Login(mno,mname))
            {
                Session["mno"] = mno;
                HttpCookie cookie = new HttpCookie("mname", mname);
                Response.Redirect("Index.aspx");
            }
            else
            {
                Response.Write("账号或密码错误！");
            }
        }
    }
}