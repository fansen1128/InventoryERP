using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    /// <summary>
    /// 仓储信息类
    /// </summary>
    [Serializable]//可序列化
    public class invent
    {
        /// <summary>
        /// 仓库编号
        /// </summary>
        public string stno { get; set; }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string gno { get; set; }
        /// <summary>
        /// 仓储数量
        /// </summary>
        public int number { get; set; }
    }
}
