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
    public partial class InventList : System.Web.UI.Page
    {
        private readonly InventBLL bllin = new InventBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable dt = bllin.getAll();
                Repeater1.DataSource = dt;
                Repeater1.DataBind();
            }
        }
    }
}