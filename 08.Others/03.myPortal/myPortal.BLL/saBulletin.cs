using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.Model;
using myPortal.IDAL;

namespace myPortal.BLL
{
    public class saBulletin
    {
        private static readonly IsaBulletin dal = DALFactory.DataAccess.CreatesaBulletin();

        #region 单例

        private saBulletin() { }

        private static saBulletin _curr = null;
        private static object _obj = new object();
        public static saBulletin Current
        {
            get
            {
                if (_curr == null)
                {
                    lock (_obj)
                    {
                        if (_curr == null)
                            _curr = new saBulletin();
                    }
                }
                return _curr;
            }
        }

        #endregion

        public IList<saBulletinInfo> GetAllBulletins()
        {
            return dal.GetAllBulletins();
        }

        public IList<saBulletinInfo> GetNewBulletins()
        {
            return dal.GetNewBulletins();
        }

        public void DeleteBulletins(string[] iBulletinIds)
        {
            dal.DeleteBulletins(iBulletinIds);
        }

        public saBulletinInfo GetBulletin(int iBulletinId)
        {
            return dal.GetBulletin(iBulletinId);
        }


        public void CreateBulletin(saBulletinInfo bulletin)
        {
            dal.Create(bulletin);
        }

        public void UpdateBulletin(saBulletinInfo bulletin)
        {
            dal.Update(bulletin);
        }
        public IList<saBulletinInfo> GetAll( string tStar, string tEnd, string sCaption)
        {
            return dal.GetAll(tStar, tEnd, sCaption);
        }
    }
}
