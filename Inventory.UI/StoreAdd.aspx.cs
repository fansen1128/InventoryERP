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
    public partial class StoreAdd : System.Web.UI.Page
    {
        private readonly StoreBLL bllsto = new StoreBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            var sto = new store();

            sto.stno = Request.Form["stno"].ToString();
            sto.address = Request.Form["address"].ToString();
            sto.telephone = Request.Form["telephone"].ToString();
            sto.capacity =Convert.ToInt16( Request.Form["capacity"]);
            int number = bllsto.Insert(sto);
            if (number > 0)
            {
                Response.Write("<script>alert('添加成功');window.location.href='StoreList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alter('添加失败');</script>");
            }
        }
    }
}