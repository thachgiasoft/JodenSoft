using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace SAF.Foundation.ComponentModel
{
    public static class XmlSerializerHelper
    {
        public static string Serialize<T>(T obj)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer xz = new XmlSerializer(obj.GetType());
                xz.Serialize(sw, obj);
                return sw.ToString();
            }
        }

        public static T Deserialize<T>(string s)
        {
            if (s.IsEmpty()) return default(T);

            using (StringReader sr = new StringReader(s))
            {
                XmlSerializer xz = new XmlSerializer(typeof(T));
                try
                {
                    var obj = xz.Deserialize(sr);
                    if (obj is T)
                        return (T)obj;
                    return default(T);
                }
                catch
                {
                    return default(T);
                }
            }
        }
    }
}
