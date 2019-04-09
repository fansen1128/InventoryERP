using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Model
{
    /// <summary>
    /// 管理员类
    /// </summary>
    [Serializable]
    public class manager
    {
        //mno, mname, sex, stno, birthday
        /// <summary>
        /// 管理员编号
        /// </summary>
        public string mno { get; set; }
        /// <summary>
        /// 管理员姓名
        /// </summary>
        public string mname { get; set; }
        /// <summary>
        /// 管理员性别
        /// </summary>
        public string sex { get; set; }
        /// <summary>
        /// 仓库编号
        /// </summary>
        public string stno { get; set; }
        /// <summary>
        /// 管理员生日
        /// </summary>
        public DateTime birthday { get; set; }
    }
}
