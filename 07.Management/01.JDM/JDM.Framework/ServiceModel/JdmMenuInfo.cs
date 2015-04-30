using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JDM.Framework.ServiceModel
{
    public class JdmMenuInfo
    {
        public string Id { get; set; }
        public string MenuHeader { get; set; }
        public string ParentId { get; set; }
        public double MenuOrder { get; set; }
        public IJdmMenuCommand Command { get; set; }
    }
}
