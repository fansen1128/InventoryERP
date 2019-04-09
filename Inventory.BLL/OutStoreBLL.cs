using Inventory.Model;
using System.Data;
using Inventory.DAL;

namespace Inventory.BLL
{
    public class OutStoreBLL
    {
        private readonly OutStoreDAL blloutstore = new OutStoreDAL();

        #region 添加
        /// <summary>
        /// 添加入库信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert(Outstore outstore)
        {
            int num= blloutstore.Insert(outstore);
            return num;
        }
        #endregion
    }
}
