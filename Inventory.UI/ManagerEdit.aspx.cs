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
    public partial class ManagerEdit : System.Web.UI.Page
    {
        private readonly ManagerBLL bllman = new ManagerBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string mno = Request.QueryString["mno"].ToString();
                    var man = bllman.GetSingleByno(mno);
                    txtmno.Value = man.mno;
                    mname.Value = man.mname;
                    sex.Value = man.sex;
                    stno.Value = man.stno;
                    birthday.Value =man.birthday.ToString("yyyy-MM-dd");
                }
                catch (Exception ex)
                {
                    Response.Redirect("ManagerList.aspx");
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var man = new manager();
            man.mno = txtmno.Value;
            man.mname = mname.Value;
            man.sex = sex.Value;
            man.stno = stno.Value;
            man.birthday =Convert.ToDateTime( birthday.Value);
            int number = bllman.Update(man);
            if (number > 0)
            {
                Response.Write("<script>alert('修改成功');window.location.href='ManagerList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alter('修改失败');</script>");
            }
        }
    }
}