using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts.ChartControlActions
{
    public interface IChartControlEditAction
    {

        Keys[] Keys
        {
            get;
            set;
        }

        void m_Execute(IChartControl chartControl);
    }


    public abstract class AbstractChartControlEditAction : IChartControlEditAction
    {
        Keys[] keys = null;

        public Keys[] Keys
        {
            get
            {
                return keys;
            }
            set
            {
                keys = value;
            }
        }

        public abstract void m_Execute(IChartControl chartControl);
    }		
}
