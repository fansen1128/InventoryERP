using System.Data;

namespace Inventory.BLL
{
    public interface IDataService<T>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Insert(T t);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        int Update(T t);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        int Delete(string no);
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="strsql"></param>
        /// <returns></returns>
        DataTable Query(string strsql);

        T GetSingleByno(string no);
    }

}
