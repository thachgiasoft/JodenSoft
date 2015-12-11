using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

namespace myPortal.Model
{
    public partial class saUserInfo : MembershipUser
    {
        private IList<saUserRoleInfo> _UserOrgRole = new List<saUserRoleInfo>();
        public IList<saUserRoleInfo> UserOrgRole
        {
            get
            {
                return this._UserOrgRole;
            }
        }
    }
}
