using Inventory.Model;
using System.Data;
using Inventory.DAL;

namespace Inventory.BLL
{
    public class InStoreBLL
    {
        private readonly  InStoreDAL bllinstore = new InStoreDAL();

        #region 添加
        /// <summary>
        /// 添加入库信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert(Instore instore)
        {
            return bllinstore.Insert(instore);
        }
        #endregion
    }
}
