using Inventory.Model;
using System.Data;
using Inventory.DAL;

namespace Inventory.BLL
{
    public class ManagerBLL : IDataService<manager>
    {
        private readonly ManagerDAL dalman = new ManagerDAL();
        #region 删除
        /// <summary>
        /// 根据编号删除管理员信息
        /// </summary>
        /// <param name="no">管理员编号</param>
        /// <returns></returns>
        public int Delete(string no)
        {
            return dalman.Delete(no);
        }
        #endregion
    
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="mno">用户名</param>
        /// <param name="mname">密码</param>
        /// <returns></returns>
        public bool Login(string mno,string mname)
        {
            var manager = GetSingleByno(mno);
            if(manager==null)
            {
                return false;
            }
            else
            {
                if(manager.mname==mname)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
       
        #region 添加
        /// <summary>
        /// 添加仓库管理员信息
        /// </summary>
        /// <param name="t">管理员信息</param>
        /// <returns></returns>
        public int Insert(manager t)
        {
            return dalman.Insert(t);
        }
        #endregion

        #region 查询
        public DataTable Query(string strsql)
        {
            return dalman.Query(strsql);
        }
        public DataTable GetAll()
        {
            return Query("");
        }
        /// <summary>
        /// 根据条件查询管理员
        /// </summary>
        /// <param name="no">查询条件</param>
        /// <returns></returns>
        public manager GetSingleByno(string no)
        {
            return dalman.GetSingleByno(no);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改管理员信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(manager t)
        {
            return dalman.Update(t);
        }
        #endregion
       
    }
}
