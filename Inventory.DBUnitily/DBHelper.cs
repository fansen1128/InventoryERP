using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Inventory.DBUnitily
{
    public class DBHelper
    {
        private static string connstr = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;//数据库连接字符串

        #region 执行带参的SQL语句
        /// <summary>
        /// 执行查询数据库中数据
        /// </summary>
        /// <param name="sql">Sql查询语句</param>
        /// <param name="ps">Sqlparameter类型的数组</param>
        /// <returns>数据库中数据</returns>
        public static DataTable GetDataTable(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            if (ps != null)
                            {
                                cmd.Parameters.AddRange(ps);
                            }
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
                catch (Exception)
                {

                    conn.Close();
                    conn.Dispose();
                    return null;
                }
            }
        }
        /// <summary>
        /// 执行增删改查并返回受影响的行数
        /// </summary>
        /// <param name="sql">Sql查询语句</param>
        /// <param name="ps">Sqlparameter类型的数组</param>
        /// <returns>受影响的行数</returns>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        {
                            conn.Open();
                            if (ps != null)
                            {
                                cmd.Parameters.AddRange(ps);
                            }
                            return cmd.ExecuteNonQuery();//返回0或大于0的数字
                        }
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    conn.Dispose();
                    return -1;
                }
            }
        }
        /// <summary>
        /// 执行查询并返回阅读器
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="ps">Sqlparameter类型的数组</param>
        /// <returns>SqlDataReader阅读器</returns>
        public static SqlDataReader ExcuteReader(string sql, params SqlParameter[] ps)
        {
            //创建连接对象和数据库命令对象
            SqlConnection conn = new SqlConnection(connstr);
            SqlCommand cmd = new SqlCommand(sql, conn);
            //打开连接
            conn.Open();
            //添加参数
            cmd.Parameters.AddRange(ps);
            //执行查询并返回阅读器
            return cmd.ExecuteReader();
        }
        /// <summary>
        /// 执行查询并返回首行首列的值
        /// </summary>
        /// <param name="sql">查询语句</param>
        /// <param name="ps">Sqlparameter类型的数组</param>
        /// <returns>返回首行首列的值</returns>
        public static Object ExcuteScalar(string sql, params SqlParameter[] ps)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddRange(ps);
                        Object obj = cmd.ExecuteScalar();
                        if (obj == null || obj == DBNull.Value)
                        {
                            return null;
                        }
                        return obj;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    conn.Dispose();
                    throw ex;
                }
            }
        }
        #endregion

        #region 执行简单的SQL语句
        /// <summary>
        /// 执行简单的SQL语句，得到首行首列的值
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static Object ExcuteScalar(string sql)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(sql, conn))
                    {
                        conn.Open();
                        Object obj = cmd.ExecuteScalar();
                        if (obj == null || obj == DBNull.Value)
                        {
                            return null;
                        }
                        return obj;
                    }
                }
                catch (Exception ex)
                {
                    conn.Close();
                    conn.Dispose();
                    throw ex;
                }
            }
        }


         /// <summary>
         /// 获取数据列表
         /// </summary>
         /// <param name="sql"></param>
         /// <returns></returns>
        public static DataTable GetDataTable(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter(sql,connstr);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            return dt;
        }
        #endregion

        #region 执行带参的存储过程
        /// <summary>
        /// 执行存储过程返回受影响行数
        /// </summary>
        /// <param name="procName">存储过程名称</param>
        /// <param name="ps">SqlParameter类型的数组</param>
        /// <returns></returns>
        public static int ExecuteProc(string procName,params SqlParameter []ps)
        {
            using (SqlConnection conn = new SqlConnection(connstr))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(procName, conn))
                    {
                        conn.Open();
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (ps != null)
                        {
                            cmd.Parameters.AddRange(ps);
                        }
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    conn.Close();
                    conn.Dispose();
                    return -1;
                }
            }
        }

        #endregion
    }
}
