using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SAF.Foundation.ComponentModel
{
    public static class ColorHelper
    {
        private static Brush _ReadOnlyBrush = null;
        public static Brush ReadOnlyBrush
        {
            get
            {
                if (_ReadOnlyBrush == null)
                {
                    _ReadOnlyBrush = new SolidBrush(ColorFromHex("#eeeeeeee"));
                }
                return _ReadOnlyBrush;
            }
        }

        public static Color ColorFromHex(string hex)
        {
            if (hex.Length != 9)
            {
                return default(Color);
            }
            string s = hex.Substring(1, 2);
            string s2 = hex.Substring(3, 2);
            string s3 = hex.Substring(5, 2);
            string s4 = hex.Substring(7, 2);
            Color result = default(Color);
            try
            {
                int num = int.Parse(s, NumberStyles.HexNumber);
                int num2 = int.Parse(s2, NumberStyles.HexNumber);
                int num3 = int.Parse(s3, NumberStyles.HexNumber);
                int num4 = int.Parse(s4, NumberStyles.HexNumber);
                result = Color.FromArgb(byte.Parse(num.ToString()), byte.Parse(num2.ToString()), byte.Parse(num3.ToString()), byte.Parse(num4.ToString()));
            }
            catch
            {
                return default(Color);
            }
            return result;
        }
    }
}
