using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.Model;

namespace myPortal.IDAL
{
    /// <summary>
    /// saBulletin接口层
    /// </summary>
    public interface IsaBulletin
    {
        /// <summary>
        /// 获取所有公告
        /// </summary>
        /// <param name="iCompanyId">公司ID</param>
        /// <returns>公告列表</returns>
        IList<saBulletinInfo> GetAllBulletins();
        /// <summary>
        /// 获取所有新公告
        /// </summary>
        /// <param name="iCompanyId">公司ID</param>
        /// <returns>公告列表</returns>
        IList<saBulletinInfo> GetNewBulletins();
        /// <summary>
        /// 删除公告
        /// </summary>
        /// <param name="iBulletinIds">公告ID数据</param>
        void DeleteBulletins(string[] iBulletinIds);
        /// <summary>
        /// 获取公告
        /// </summary>
        /// <param name="iBulletinId">公告ID</param>
        /// <param name="iCompanyId">公司ID</param>
        /// <returns>公告实体</returns>
        saBulletinInfo GetBulletin(int iBulletinId);
        /// <summary>
        /// 新建公告
        /// </summary>
        /// <param name="bulletin">公告实体</param>
        void Create(saBulletinInfo bulletin);
        /// <summary>
        /// 更新公告
        /// </summary>
        /// <param name="bulletin">公告实体</param>
        void Update(saBulletinInfo bulletin);
        /// <summary>
        /// 获取所有公告
        /// </summary>
        /// <param name="iCompanyId">公告ID</param>
        /// <param name="tStar">开始时间</param>
        /// <param name="tEnd">结束时间</param>
        /// <param name="sCaption">公告标题</param>
        /// <returns></returns>
        IList<saBulletinInfo> GetAll(string tStar, string tEnd, string sCaption);
    }
}
