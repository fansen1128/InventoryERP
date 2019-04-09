using Inventory.BLL;
using Inventory.Model;
using System;

namespace Inventory.UI
{
    public partial class StoreEdit : System.Web.UI.Page
    {
        private readonly StoreBLL bllsto = new StoreBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string stno = Request.QueryString["stno"].ToString();
                    var store = bllsto.GetSingleByno(stno);
                    txtstno.Value = store.stno;
                    address.Value = store.address;
                    telephone.Value = store.telephone;
                    capacity.Value =store.capacity.ToString();
                }
                catch (Exception ex)
                {
                    Response.Redirect("StoreList.aspx");
                }
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var store = new store();
            store.stno = txtstno.Value;
            store.address = address.Value;
            store.telephone = telephone.Value;
            store.capacity =Convert.ToInt16( capacity.Value);
            int number = bllsto.Update(store);
            if (number > 0)
            {
                Response.Write("<script>alert('修改成功');window.location.href='StoreList.aspx';</script>");
            }
            else
            {
                Response.Write("<script>alter('修改失败');</script>");
            }
        }
    }
}