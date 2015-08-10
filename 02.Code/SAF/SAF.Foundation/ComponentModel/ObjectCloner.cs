using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SAF.Foundation.ComponentModel
{
    /// <summary>
    /// 提供深复制功能
    /// </summary>
    public static class ObjectCloner
    {
        /// <summary>
        /// 深复制一个对象.对象必须标记为 Serializable
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object Clone(object obj)
        {
            if (!obj.GetType().IsSerializable)
            {
                throw new ArgumentException("对象未标记[Serializable],无法Clone.");
            }
            IFormatter format = new BinaryFormatter();
            using (Stream stream = new MemoryStream())
            {
                try
                {
                    format.Serialize(stream, obj);
                    stream.Seek(0, SeekOrigin.Begin);
                    return format.Deserialize(stream);
                }
                catch (Exception ex)
                {
                    throw new Exception("复制对象时出现错误.", ex);
                }
            }
        }
    }
}