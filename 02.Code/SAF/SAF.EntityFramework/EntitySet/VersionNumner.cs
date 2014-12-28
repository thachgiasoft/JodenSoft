using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace SAF.EntityFramework
{
    [DataContract]
    [Serializable]
    public sealed class VersionNumber : IEquatable<VersionNumber>
    {
        [DataMember(Name = "Bytes")]
        private byte[] bytes;
        private int? hashCode;

        public int Length
        {
            get
            {
                return this.bytes.Length;
            }
        }

        public VersionNumber(byte[] value)
        {
            if (value == null)
            {
                this.bytes = new byte[0];
            }
            else
            {
                this.bytes = new byte[value.Length];
                Array.Copy(value, this.bytes, value.Length);
            }
            this.ComputeHash();
        }

        public byte[] ToArray()
        {
            byte[] array = new byte[this.bytes.Length];
            Array.Copy(this.bytes, array, array.Length);
            return array;
        }

        public static implicit operator VersionNumber(byte[] value)
        {
            return new VersionNumber(value);
        }

        public bool Equals(VersionNumber other)
        {
            return this.EqualsTo(other);
        }

        public static bool operator ==(VersionNumber versionNumner1, VersionNumber versionNumner2)
        {
            return versionNumner1 == versionNumner2 || (versionNumner1 == null && versionNumner2 == null) || (versionNumner1 != null && versionNumner2 != null && versionNumner1.EqualsTo(versionNumner2));
        }

        public static bool operator !=(VersionNumber binary1, VersionNumber binary2)
        {
            return binary1 != binary2 && (binary1 != null || binary2 != null) && (binary1 == null || binary2 == null || !binary1.EqualsTo(binary2));
        }

        public override bool Equals(object obj)
        {
            return this.EqualsTo(obj as VersionNumber);
        }

        public override int GetHashCode()
        {
            if (!this.hashCode.HasValue)
            {
                this.ComputeHash();
            }
            return this.hashCode.Value;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("\"");
            stringBuilder.Append(Convert.ToBase64String(this.bytes, 0, this.bytes.Length));
            stringBuilder.Append("\"");
            return stringBuilder.ToString();
        }

        private bool EqualsTo(VersionNumber versionNumner)
        {
            if (this == versionNumner)
            {
                return true;
            }
            if (versionNumner == null)
            {
                return false;
            }
            if (this.bytes.Length != versionNumner.bytes.Length)
            {
                return false;
            }
            if (this.GetHashCode() != versionNumner.GetHashCode())
            {
                return false;
            }
            int i = 0;
            int num = this.bytes.Length;
            while (i < num)
            {
                if (this.bytes[i] != versionNumner.bytes[i])
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        private void ComputeHash()
        {
            int num = 314;
            int num2 = 159;
            this.hashCode = 0;
            for (int i = 0; i < this.bytes.Length; i++)
            {
                this.hashCode = this.hashCode * num + (int)this.bytes[i];
                num *= num2;
            }
        }
    }

}
