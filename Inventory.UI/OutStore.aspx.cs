using Inventory.BLL;
using Inventory.Model;
using System;
using System.Data;

namespace Inventory.UI
{
    public partial class OutStore : System.Web.UI.Page
    {
        private readonly InStoreBLL bllinstore = new InStoreBLL();
        private readonly GoodsBLL bllgo = new GoodsBLL();
        private readonly StoreBLL bllsto = new StoreBLL();
        private readonly InventBLL bllinvent = new InventBLL();
        private readonly OutStoreBLL blloutstore = new OutStoreBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                //获取所有仓库列表
                DataTable storeTable = bllsto.GetAll();
                stno.DataSource = storeTable;
                stno.DataTextField = "stno";
                stno.DataValueField = "stno";
                stno.DataBind();                

                DataTable goodsTable = bllinvent.getBystno(stno.SelectedValue.ToString());
                gno.DataSource = goodsTable;
                gno.DataTextField = "gno";
                gno.DataValueField = "gno";
                gno.DataBind();
            }
        }
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            var outstore = new Outstore();
            outstore.gno = this.gno.SelectedValue.ToString();
            outstore.stno = this.stno.SelectedValue;
            outstore.number = Convert.ToInt16(txtNumber.Text.Trim());
            outstore.mno = Session["mno"].ToString();
            int num = blloutstore.Insert(outstore);
            if (num > 0)
            {
                Response.Write("<script>alert('出库成功');window.location.href='InventList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alter('库存不足，出库失败！');</script>");
            }
        }
        //添加selectedchange事件
        protected void stno_SelectedIndexChanged(object sender, EventArgs e)
        {
            //获取该仓库的商品列表

            DataTable goodsTable = bllinvent.getBystno(stno.SelectedValue.ToString());
            gno.DataSource = goodsTable;
            gno.DataTextField = "gno";
            gno.DataValueField = "gno";
            gno.DataBind();
        }
    }
}