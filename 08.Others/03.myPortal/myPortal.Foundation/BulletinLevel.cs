using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace myPortal.Foundation
{
    public enum BulletinLevel
    {
        /// <summary>
        /// 普通
        /// </summary>
        [Display(Name = "普通")]
        Ordinary = 0,
        /// <summary>
        /// 重要
        /// </summary>
        [Display(Name = "重要")]
        Important = 1,
        /// <summary>
        /// 紧急
        /// </summary>
        [Display(Name = "紧急")]
        Emergency = 2
    }
}
