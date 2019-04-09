using Inventory.Model;
using System.Data;
using Inventory.DBUnitily;
using System.Data.SqlClient;

namespace Inventory.DAL
{
    public class StoreDAL : IDataService<store>
    {
        #region 删除
        public int Delete(string no)
        {
            string sql = "delete from store where stno='" + no + "'";
            int number = DBHelper.ExecuteNonQuery(sql);
            return number;
        }
        #endregion
      
        #region 添加
        public int Insert(store s)
        {
            string sql = "insert into store values(@stno, @address, @telephone, @capacity)";
            SqlParameter[] ps =
            {
                new SqlParameter ("@stno",SqlDbType.Char,3) {Value=s.stno },
                new SqlParameter ("@address",SqlDbType.Char,30) {Value=s.address},
                new SqlParameter ("@telephone",SqlDbType.Char,20) {Value=s.telephone},
                new SqlParameter ("@capacity",SqlDbType.SmallInt,4) {Value=s.capacity},
            };
            int number = DBHelper.ExecuteNonQuery(sql, ps);
            return number;
        }
        #endregion

        #region 查询
        public DataTable Query(string strsql)
        {
            string sql = "select * from store";
            if (!string.IsNullOrEmpty(strsql))
            {
                sql += "where" + strsql;
            }
            DataTable dt = DBHelper.GetDataTable(sql);
            return dt;
        }
        public store GetSingleByno(string no)
        {
            string strsql = "select top 1 * from store where stno=@stno";
            SqlParameter ps = new SqlParameter("@stno", SqlDbType.Char, 6) { Value = no };
            SqlDataReader reader = DBHelper.ExcuteReader(strsql, ps);
            store sto = new store();
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        sto.stno = reader.GetString(0);
                        sto.address= reader.GetString(1);
                        sto.telephone= reader.GetString(2);
                        sto.capacity = reader.GetInt16(3);
                    }
                }
                reader.Close();
                reader.Dispose();
            }
            return sto;
        }
        #endregion
       
        #region 修改
        public int Update(store s)
        {

            string sql = "update store set address=@address, telephone=@telephone, capacity=@capacity where stno=@stno";
            SqlParameter[] ps =
            {
                new SqlParameter ("@address",SqlDbType.Char,30) {Value=s.address },
                new SqlParameter ("@telephone",SqlDbType.Char,30) {Value=s.telephone },
                new SqlParameter ("@capacity",SqlDbType.SmallInt,4) {Value=s.capacity },
                new SqlParameter ("@stno",SqlDbType.Char,3) {Value=s.stno }
            };
            int number = DBHelper.ExecuteNonQuery(sql, ps);
            return number;
        }
        #endregion
        
    }
}
