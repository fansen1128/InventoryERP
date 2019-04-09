using Inventory.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventory.UI
{
    public partial class GoodsList : System.Web.UI.Page
    {
        private readonly GoodsBLL bllgo = new GoodsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                DataTable dt = bllgo.GetAll();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }
        protected void LinkButton1_OnClick(object sender, EventArgs e)
        {
            LinkButton link = (LinkButton)sender;
            var gno = link.CommandArgument.ToString();
            int number = bllgo.Delete(gno);
            if (number > 0)
            {
                Response.Write("<script>alert('删除成功');window.location.href='GoodsList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alter('删除失败');</script>");
            }

        }
    }
}