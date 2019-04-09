using Inventory.BLL;
using Inventory.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Inventory.UI
{
    public partial class GoodsAdd : System.Web.UI.Page
    {
        private readonly GoodsBLL bllgo = new GoodsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            var good = new goods();

            good.gno = Request.Form["gno"].ToString();
            good.gname = Request.Form["gname"].ToString();
            good.price = decimal.Parse(Request.Form["price"].ToString());
            good.producer = Request.Form["producer"].ToString();
            int number = bllgo.Insert(good);
            if (number > 0)
            {
                Response.Write("<script>alert('添加成功');window.location.href='GoodsList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alter('添加失败');</script>");
            }
        }
    }
}