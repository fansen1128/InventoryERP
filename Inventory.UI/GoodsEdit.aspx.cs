using Inventory.BLL;
using Inventory.Model;
using System;

namespace Inventory.UI
{
    public partial class GoodsEdit : System.Web.UI.Page
    {
        private readonly GoodsBLL bllgo = new GoodsBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string gno = Request.QueryString["gno"].ToString();
                    var good = bllgo.GetSingleByno(gno);
                    txtgno.Value = good.gno;
                    //txtgno.Disabled = true;

                    gname.Value = good.gname;
                    price.Value = good.price.ToString();
                    producer.Value = good.producer;
                }
                catch (Exception ex)
                {
                    Response.Redirect("GoodsList.aspx");
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var good = new goods();
            good.gno = txtgno.Value;
            good.gname = gname.Value;
            good.price = decimal.Parse(price.Value);
            good.producer = producer.Value;
            int number = bllgo.Update(good);
            if (number > 0)
            {
                Response.Write("<script>alert('修改成功');window.location.href='GoodsList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alter('修改失败');</script>");
            }
        }
    }
}