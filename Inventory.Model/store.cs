using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    /// <summary>
    /// 仓库类
    /// </summary>
    [Serializable]
    public  class store
    {
        //  stno, address, telephone, capacity
        /// <summary>
        /// 仓库编号
        /// </summary>
        public string stno { get; set; }
        /// <summary>
        /// 仓库地址
        /// </summary>
        public string address { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string telephone { get; set; }
        /// <summary>
        /// 容量
        /// </summary>
        public int capacity { get; set; }
    }
}
