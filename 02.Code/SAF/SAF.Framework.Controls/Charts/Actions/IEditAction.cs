using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAF.Framework.Controls.Charts.Actions
{
    /// <summary>
    /// m_To define a new key for the drawArea, you must write a class which
    /// implements this interface.
    /// </summary>
    public interface IEditAction
    {
        /// <value>
        /// An array of keys on which this edit action occurs.
        /// </value>
        Keys[] Keys
        {
            get;
            set;
        }

        void m_Execute(DrawArea drawArea);
    }

    /// <summary>
    /// m_To define a new key for the drawArea, you must write a class which
    /// implements this interface.
    /// </summary>
    public abstract class AbstractEditAction : IEditAction
    {
        Keys[] keys = null;

        /// <value>
        /// An array of keys on which this edit action occurs.
        /// </value>
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

        /// <remarks>
        /// When the key which is defined per XML is pressed, this method will be launched.
        /// </remarks>
        public abstract void m_Execute(DrawArea drawArea);
    }		
}
