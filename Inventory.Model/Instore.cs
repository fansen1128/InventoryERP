using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    /// <summary>
    /// 商品入库类
    /// </summary>
    [Serializable]
    public class Instore
    {
        //intoID, gno, stno, number, intoTime
        /// <summary>
        /// 入库编号
        /// </summary>
        public int intoID { get; set; }
        /// <summary>
        /// 入库商品编号
        /// </summary>
        public string gno { get; set; }
        /// <summary>
        /// 仓库编号
        /// </summary>
        public string stno { get; set; }
        /// <summary>
        /// 入库数量
        /// </summary>
        public int number { get; set; }
        /// <summary>
        /// 入库时间
        /// </summary>
        public string intoTime { get; set; }
        /// <summary>
        /// 此操作的管理员编号
        /// </summary>
        public string mno { get; set; }
    }
}
