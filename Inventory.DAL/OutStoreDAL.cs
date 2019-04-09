using Inventory.DBUnitily;
using Inventory.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Inventory.DAL
{
    public  class OutStoreDAL
    {
        #region 添加出库信息
        /// <summary>
        /// 添加出库信息
        /// </summary>
        /// <param name="instore">出库类型的商品</param>
        /// <returns></returns>
        public int Insert(Outstore instore)
        {
            SqlParameter[] ps =
            {
                new SqlParameter("@gno",SqlDbType.Char,6) {Value=instore.gno },
                new SqlParameter ("@stno",SqlDbType.Char,3) {Value=instore.stno },
                new SqlParameter ("@number",SqlDbType.Int,4) {Value=instore.number },
                new SqlParameter("@mno",SqlDbType.Char,6) {Value=instore.mno }
            };
            int num = DBHelper.ExecuteProc("proc_OutStore", ps);
            return num;
        }
        #endregion
    }
}
