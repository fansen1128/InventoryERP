using Inventory.BLL;
using Inventory.Model;
using System;

namespace Inventory.UI
{
    public partial class ManagerAdd : System.Web.UI.Page
    {
        private readonly ManagerBLL bllman = new ManagerBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            var man = new manager();

            man.mno = Request.Form["mno"].ToString();
            man.mname = Request.Form["mname"].ToString();
            man.sex= Request.Form["sex"].ToString();
            man.stno= Request.Form["stno"].ToString();
            man.birthday = Convert.ToDateTime( Request.Form["birthday"]);
            int number = bllman.Insert(man);
            if (number > 0)
            {
                Response.Write("<script>alert('添加成功');window.location.href='ManagerList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alter('添加失败');</script>");
            }
        }
    }
}