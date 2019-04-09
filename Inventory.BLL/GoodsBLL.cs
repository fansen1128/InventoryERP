using System.Data;
using Inventory.Model;
using Inventory.DAL;

namespace Inventory.BLL
{
    public class GoodsBLL : IDataService<goods>
    {
        private readonly goodsDAL dalgoods = new goodsDAL();

        #region 删除
        /// <summary>
        /// 按编号删除商品信息
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public int Delete(string no)
        {
            return dalgoods.Delete(no);
        }
        #endregion
        
        #region 查询
        /// <summary>
        /// 按编号查询商品信息
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
         public goods GetSingleByno(string no)
        {
            return dalgoods.GetSingleByno(no);
        }
        /// <summary>
        /// 查询所有商品信息
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        public DataTable Query(string strsql)
        {
            return dalgoods.Query(strsql);
        }
        public DataTable GetAll()
        {
            return Query("");
        }
        #endregion

        #region 添加
        /// <summary>
        /// 添加商品信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Insert(goods t)
        {
            return dalgoods.Insert(t);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改商品信息
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public int Update(goods t)
        {
            return dalgoods.Update(t);
        }
        #endregion
    }
}
