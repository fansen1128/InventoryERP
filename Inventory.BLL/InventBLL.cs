
using Inventory.Model;
using System.Data;
using Inventory.DAL;

namespace Inventory.BLL
{
    public class InventBLL : IDataService<invent>
    {
        private readonly IneventDAL dalInvent = new IneventDAL();
        #region 删除
        public int Delete(string no)
        {
            return dalInvent.Delete(no);
        }
        #endregion

        #region 查询
        /// <summary>
        /// 根据商品编号查询单个库存信息
        /// </summary>
        /// <param name="no">库存编号</param>
        /// <returns></returns>
        public invent GetSingleByno(string no)
        {
            return dalInvent.GetSingleByno(no);
        }
        /// <summary>
        /// 查询所有库存信息
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public DataTable Query(string strsql)
        {
            return dalInvent.Query(strsql);
        }
        /// <summary>
        /// 根据仓库编号查询该仓库的商品信息
        /// </summary>
        /// <param name="stno"></param>
        /// <returns></returns>
        public DataTable getBystno(string stno)
        {
            return Query(" stno=" + stno);
        }
        public DataTable getAll()
        {
            return Query("");
        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加库存信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert(invent t)
        {
            return dalInvent.Insert(t);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改库存信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(invent t)
        {
            return dalInvent.Update(t);
        }
        #endregion
     
    }
}
