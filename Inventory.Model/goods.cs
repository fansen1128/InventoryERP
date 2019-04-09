using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    /// <summary>
    /// 商品类
    /// </summary>
    [Serializable]
    public class goods
    {
        //[gno][gname][price][producer]
        /// <summary>
        /// 商品编号
        /// </summary>
        public string gno { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string gname { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal price { get; set; }
        /// <summary>
        /// 生产商
        /// </summary>
        public string producer { get; set; }
    }
}
