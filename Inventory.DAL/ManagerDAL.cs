using Inventory.DBUnitily;
using System.Data;
using Inventory.Model;
using System.Data.SqlClient;

namespace Inventory.DAL
{
    public class ManagerDAL : IDataService<manager>
    {
        #region 添加
        /// <summary>
        /// 向数据库中插入数据，返回值为整形，大于0为成功，等于0为失败，小于0为异常
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert(manager t)
        {
            string sql = "insert into manager values(@mno, @mname, @sex, @stno, @birthday)";
            SqlParameter[] ps =
            {
                new SqlParameter ("@mno",SqlDbType.Char,3) {Value=t.mno },
                new SqlParameter ("@mname",SqlDbType.Char,10) {Value=t.mname},
                new SqlParameter ("@sex",SqlDbType.Char,2) {Value=t.sex},
                new SqlParameter ("@stno",SqlDbType.Char,3) {Value=t.stno},
                new SqlParameter ("@birthday",SqlDbType.DateTime) {Value=t.birthday}
            };
            int number = DBHelper.ExecuteNonQuery(sql, ps);
            return number;
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改数据，返回值为整形，返回大于0为修改成功，等于0为失败，小于0为异常
        /// </summary>
        /// <param name="t">需要修改的数据</param>
        /// <returns></returns>
        public int Update(manager t)
        {
            string sql = "update manager set mname=@mname, sex=@sex, stno=@stno, birthday=@birthday where mno=@mno";
            SqlParameter[] ps =
            {
                new SqlParameter ("@mname",SqlDbType.Char,3) {Value=t.mname },
                new SqlParameter ("@sex",SqlDbType.Char,3) {Value=t.sex },
                new SqlParameter ("@stno",SqlDbType.Char,3) {Value=t.stno },
                new SqlParameter ("@birthday",SqlDbType.DateTime,20) {Value=t.birthday },
                new SqlParameter ("@mno",SqlDbType.Char,3) {Value=t.mno },
            };
            int number = DBHelper.ExecuteNonQuery(sql, ps);
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
            string sql = "delete from manager where mno='" + no + "'";
            int number = DBHelper.ExecuteNonQuery(sql);
            return number;
        }
        #endregion

        #region 查询
        public manager GetSingleByno(string no)
        {
            string strsql = "select top 1 * from manager where mno=@mno";
            SqlParameter ps = new SqlParameter("@mno", SqlDbType.Char, 6) { Value = no };
            SqlDataReader reader = DBHelper.ExcuteReader(strsql, ps);
            manager man = new manager();
            if (reader != null)
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        man.mno = reader.GetString(0); 
                        man.mname= reader.GetString(1);
                        man.sex = reader.GetString(2);
                        man.stno= reader.GetString(3);
                        man.birthday= reader.GetDateTime(4);
                    }
                }
                reader.Close();
                reader.Dispose();
            }
            return man;
        }
        public DataTable Query(string strsql)
        {
            string sql = "select * from manager";
            if (!string.IsNullOrEmpty(strsql))
            {
                sql += " where " + strsql;
            }
            DataTable dt = DBHelper.GetDataTable(sql);
            return dt;
        }    
        #endregion 
    }
}
