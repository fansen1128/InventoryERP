using Inventory.Model;
using System;
using System.Data;
using Inventory.DAL;

namespace Inventory.BLL
{
    public class StoreBLL:IDataService<store>
    {
        public readonly StoreDAL dalstore = new StoreDAL();

        #region 删除
        /// <summary>
        /// 根据仓库编号删除仓库信息
        /// </summary>
        /// <param name="no">仓库编号</param>
        /// <returns></returns>
        public int Delete(string no)
        {
            return dalstore.Delete(no);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据仓库编号查询仓库信息
        /// </summary>
        /// <param name="no">仓库编号</param>
        /// <returns></returns>
        public store GetSingleByno(string no)
        {
            return dalstore.GetSingleByno(no);
        }
        /// <summary>
        /// 查询所有仓库信息
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public DataTable GetAll()
        {
            return Query("");
        }
        public DataTable Query(string strsql)
        {
            return dalstore.Query(strsql);
        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加仓库信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert(store t)
        {
            return dalstore.Insert(t);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改仓库信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(store t)
        {
            return dalstore.Update(t);
        }
        #endregion
       
    }
}
