using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SAF.Foundation.ComponentModel
{
    /// <summary>
    /// �ṩ��ƹ���
    /// </summary>
    public static class ObjectCloner
    {
        /// <summary>
        /// ���һ������.���������Ϊ Serializable
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static object Clone(object obj)
        {
            if (!obj.GetType().IsSerializable)
            {
                throw new ArgumentException("����δ���[Serializable],�޷�Clone.");
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
                    throw new Exception("���ƶ���ʱ���ִ���.", ex);
                }
            }
        }
    }
}