using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using myPortal.IDAL;
using myPortal.Model;
using myPortal.Cache;

namespace myPortal.BLL
{
    public class saBulletinType
    {
        private static readonly IsaBulletinType dal = DALFactory.DataAccess.CreatesaBulletinType();

        #region 单例

        private saBulletinType() { }

        private static saBulletinType _curr = null;
        private static object _obj = new object();
        public static saBulletinType Current
        {
            get
            {
                if (_curr == null)
                {
                    lock (_obj)
                    {
                        if (_curr == null)
                            _curr = new saBulletinType();
                    }
                }
                return _curr;
            }
        }

        #endregion

        public IList<saBulletinTypeInfo> GetAllBulletinType()
        {
            IList<saBulletinTypeInfo> obj = CacheService.Current.RetriveObject(CacheKey.DicBulletinType) as IList<saBulletinTypeInfo>;
            if (obj == null)
            {
                obj = dal.GetAllBulletinType();
                CacheService.Current.AddObject(CacheKey.DicBulletinType, obj);
            }
            return obj;
        }
        public void DeleteBulletinType(string[] iIdens)
        {
            dal.Delete(iIdens);
            CacheService.Current.RemoveObject(CacheKey.DicBulletinType);
        }
        public saBulletinTypeInfo GetsaBulletinType(int iIden)
        {
            var obj = GetAllBulletinType();
            return obj.FirstOrDefault(p => p.iIden == iIden);
        }
        public void UpdateBulletinType(saBulletinTypeInfo bulletin)
        {
            dal.Update(bulletin);
            CacheService.Current.RemoveObject(CacheKey.DicBulletinType);
        }

        public void CreateBulletinType(saBulletinTypeInfo bulletin)
        {
            dal.Create(bulletin);
            CacheService.Current.RemoveObject(CacheKey.DicBulletinType);
        }
    }
}
