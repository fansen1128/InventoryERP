using Inventory.DBUnitily;
using Inventory.Model;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Inventory.DAL
{
    public class goodsDAL : IDataService<goods>
    {
        #region 添加
        public int Insert(goods g)
        {
            string sql = "insert into goods values(@gno, @gname, @price, @producer)";
            SqlParameter[] ps =
            {
                new SqlParameter ("@gno",SqlDbType.Char,6) {Value=g.gno },
                new SqlParameter ("@gname",SqlDbType.VarChar,10) {Value=g.gname},
                new SqlParameter ("@price",SqlDbType.Float) {Value=g.price},
                new SqlParameter ("@producer",SqlDbType.VarChar,30) {Value=g.producer},
            };
            int number = DBHelper.ExecuteNonQuery(sql, ps);
            return number;
        }
        #endregion

        #region 删除
        public int Delete(string no)
        {
            string sql = "delete from goods where gno='" + no + "'";
            int number = DBHelper.ExecuteNonQuery(sql);
            return number;
        }
        #endregion

        #region 查询
        public goods GetSingleByno(string no)
        {
            string strsql = "select top 1 * from goods where gno=@gno";
            SqlParameter ps = new SqlParameter("@gno", SqlDbType.Char, 6) { Value = no };
            SqlDataReader reader = DBHelper.ExcuteReader(strsql, ps);
            goods go = new goods();
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        go.gno= reader.GetString(0);
                        go.gname = reader.GetString(1);
                        go.price = Convert.ToDecimal(reader.GetValue(2));
                        go.producer= reader.GetString(3);
                    }
                }
                reader.Close();
                reader.Dispose();
            }
            return go;
        }

        public DataTable Query(string strsql)
        {
            string sql = "select * from goods";
            if (!string.IsNullOrEmpty(strsql))
            {
                sql += " where " + strsql;
            }
            DataTable dt = DBHelper.GetDataTable(sql);
            return dt;
        }
        #endregion
        
        #region 修改
        public int Update(goods g)
        {
            string sql = "update goods set gname=@gname, price=@price, producer=@producer  where gno=@gno";
            SqlParameter[] ps =
            {
                new SqlParameter ("@gname",SqlDbType.VarChar,30) {Value=g.gname },
                new SqlParameter ("@price",SqlDbType.Float) {Value=g.price },
                new SqlParameter ("@producer",SqlDbType.VarChar,30) {Value=g.producer },
                new SqlParameter ("@gno",SqlDbType.Char,6) {Value=g.gno }
            };
            int number = DBHelper.ExecuteNonQuery(sql, ps);
            return number;
        }
        #endregion
         
    }
}
