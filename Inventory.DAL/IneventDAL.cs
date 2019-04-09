using System.Data;
using System.Text;
using Inventory.Model;
using Inventory.DBUnitily;
using System.Data.SqlClient;
using System;

namespace Inventory.DAL
{
    /// <summary>
    /// 库存数据库访问操作类
    /// </summary>
    public class IneventDAL : IDataService<invent>
    {
        #region 添加
        /// <summary>
        /// 向数据库中插入数据，返回值为整形，大于0为成功，等于0为失败，小于0为异常
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert(invent t)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("insert into invent values(@stno,@gno,@number)");
            SqlParameter[] ps =
            {
                new SqlParameter ("@stno",SqlDbType.Char,6) {Value=t.stno },
                new SqlParameter ("@gno",SqlDbType.Char,6) {Value =t.gno },
                new SqlParameter ("@number",SqlDbType.Int,4) {Value=t.number }
            };
            int number=DBHelper.ExecuteNonQuery(strsql.ToString(), ps);
            return number;
        }

        #endregion

        #region 修改
        /// <summary>
        /// 修改数据，返回值为整形，返回大于0为修改成功，等于0为失败，小于0为异常
        /// </summary>
        /// <param name="t">需要修改的数据</param>
        /// <returns></returns>
        public int Update(invent t)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("update invent set number=@number where stno=@stno,gno=@gno ");
            SqlParameter[] ps =
            {
                    new SqlParameter ("@stno",SqlDbType.Char,6) {Value=t.stno },
                    new SqlParameter ("@gno",SqlDbType.Char,6) {Value =t.gno },
                    new SqlParameter ("@number",SqlDbType.Int,4) {Value=t.number }
            };
            int number = DBHelper.ExecuteNonQuery(strsql.ToString(), ps);
            return number;
        }
        #endregion

        #region 删除
        /// <summary>
        /// 删除数据 返回值为整形，大于0为成功，等于0为失败，小于0为异常
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public int Delete(string no)
        {
            string sql = "delete from invent where gno='" + no + "'";
            int number = DBHelper.ExecuteNonQuery(sql);
            return number;
        }
        public int Delete (string sno,string gno)
        {
            string sql = "delete from invent where stno=@stno and gno=@gno";
            SqlParameter[] ps =
            {
                new SqlParameter ("@stno",SqlDbType.Char,6) {Value=sno },
                new SqlParameter ("@gno",SqlDbType.Char,6) {Value=gno }      
            };
            int number = DBHelper.ExecuteNonQuery(sql);
            return number;
        }

        #endregion

        #region 查询
        
        public invent GetSingleByno(string no)
        {
            string strsql = "select top 1 * from invent where gno=@gno";
            SqlParameter ps = new SqlParameter("@gno", SqlDbType.Char, 6) { Value = no };
            var reader = DBHelper.ExcuteReader(strsql, ps);
            var inv = new invent();
            if(reader!=null)
            {
                if(reader.HasRows)
                {
                    while(reader.Read())
                    {
                        inv.stno = reader.GetString(0);
                        inv.gno = reader.GetString(1);
                        inv.number =Convert.ToInt16( reader.GetString(2));
                    }
                }
                reader.Close();
                reader.Dispose();
            }
            return inv;
        }
        public invent GetSingleByno(string no,string gno)
        {
            string strsql = "select top 1 * from invent where gno=@gno and stno=@stno";
            SqlParameter []ps =
            {
                   new SqlParameter("@gno", SqlDbType.Char, 6) { Value = no },
                   new SqlParameter ("@stno",SqlDbType.Char,6) {Value=gno }
            };
                
            var reader = DBHelper.ExcuteReader(strsql, ps);
            var inv = new invent();
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        inv.stno = reader.GetString(0);
                        inv.gno = reader.GetString(1);
                        inv.number =Convert.ToInt16( reader.GetString(2));
                    }
                }
            }
            return inv;
        }

        /// <summary>
        /// 根据条件查询库存信息，返回DataTable数据表
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public DataTable Query(string strsql)
        {
            string sql = "select * from invent";
            if(!string.IsNullOrEmpty(strsql))
            {
                sql += " where" + strsql;
            }
            DataTable dt = DBHelper.GetDataTable(sql);
            return dt;
        }
        #endregion
    }
}
