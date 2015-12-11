using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.Model;

namespace myPortal.IDAL
{
    /// <summary>
    /// saBulletinType接口
    /// </summary>
    public interface IsaBulletinType
    {
        /// <summary>
        /// 获取所有公告类型
        /// </summary>
        /// <returns>公告类型列表</returns>
        IList<saBulletinTypeInfo> GetAllBulletinType();
        /// <summary>
        /// 增加一条数据
        /// </summary>
        /// <param name="saBulletinType">公告类型实体</param>
        void Create(saBulletinTypeInfo saBulletinType);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="saBulletinType">公告类型实体</param>
        void Update(saBulletinTypeInfo saBulletinType);
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="saBulletinType">公告类型ID数组</param>
        void Delete(string[] iIdens);
    }
}
