using System;
using Inventory.Model;
using Inventory.BLL;
using System.Data;

namespace Inventory.UI
{
    public partial class InStore : System.Web.UI.Page
    {
        private readonly  InStoreBLL bllinstore = new InStoreBLL();
        private readonly GoodsBLL bllgo = new GoodsBLL();
        private readonly StoreBLL bllsto = new StoreBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //获取所有仓库列表
                DataTable storeTable = bllsto.GetAll();
                stno.DataSource = storeTable;
                stno.DataTextField = "stno";
                stno.DataValueField = "stno";
                stno.DataBind();

                //获取所有商品编号
                DataTable goodTable = bllgo.GetAll();
                gno.DataSource = goodTable;
                gno.DataTextField = "gno";
                gno.DataValueField = "gno";
                gno.DataBind();
            }
        }
        protected void btnAdd_OnClick(object sender, EventArgs e)
        {
            var instore = new Instore();
            instore.gno = this.gno.SelectedValue.ToString();
            instore.stno = this.stno.SelectedValue;
            instore.number =Convert.ToInt16( txtNumber.Text.Trim());
            instore.mno = Session["mno"].ToString();
            DateTime nowTime = DateTime.Now;
            int num = bllinstore.Insert(instore);
            if (num > 0)
            {
                Response.Write("<script>alert('入库成功');window.location.href='InventList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alter('入库失败');</script>");
            }
            //string mno = // 缺登录功能，在登录成功时候保存当前登录者信息
            //往入库表中插入入库记录 缺入库表的模型层、数据访问层（添加、修改（权限） 删除不能开、查询需要些）、业务逻辑层
            //入库成功需要往库存表中写输入数据
        }
    }
}