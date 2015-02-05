﻿using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SAF.Framework.Controls
{
    [ToolboxItem(false)]
    public class BaseUserControl : XtraUserControl, IBaseUserControl
    {

        public void Init()
        {
            OnInit();
        }

        public void RefreshUI()
        {
            OnRefreshUI();
        }

        protected virtual void OnInit()
        {
           
        }

        protected virtual void OnRefreshUI()
        {
           
        }
    }
}
