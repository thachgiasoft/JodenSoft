using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace myPortal.IDAL
{
    /// <summary>
    /// iIden生成器接口
    /// </summary>
    public interface IIdenGenerator
    {
        /// <summary>
        /// 生成新的iIden
        /// </summary>
        /// <param name="sGroupName">iIden的分组名称，一般为表名</param>
        /// <returns>返回生成的iIden</returns>
        int NewIden(string sGroupName);
    }
}
