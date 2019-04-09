using Inventory.DBUnitily;
using Inventory.Model;
using System;
using System.Data;
using System.Data.SqlClient;


namespace Inventory.DAL
{
    public class InStoreDAL
    {
        #region 添加入库信息
        public int Insert(Instore instore)
        {
            SqlParameter[] ps =
            {
                new SqlParameter("@gno",SqlDbType.Char,6) {Value=instore.gno },
                new SqlParameter ("@stno",SqlDbType.Char,3) {Value=instore.stno },
                new SqlParameter ("@number",SqlDbType.Int,4) {Value=instore.number },
                new SqlParameter("@mno",SqlDbType.Char,6) {Value=instore.mno }
            };
            int num=DBHelper.ExecuteProc("proc_InStore",ps);
            return num;
        }
        #endregion
    }
}
