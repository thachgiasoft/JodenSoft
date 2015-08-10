using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.Foundation.ComponentModel
{
    public static class Equality<T>
    {
        public static IEqualityComparer<T> CreateComparer<V>(Func<T, V> keySelector)
        {
            return new CommonEqualityComparer<V>(keySelector);
        }

        public static IEqualityComparer<T> CreateComparer<V>(Func<T, V> keySelector, IEqualityComparer<V> comparer)
        {
            return new CommonEqualityComparer<V>(keySelector, comparer);
        }

        class CommonEqualityComparer<V> : IEqualityComparer<T>
        {
            private Func<T, V> keySelector;
            private IEqualityComparer<V> comparer;

            public CommonEqualityComparer(Func<T, V> keySelector, IEqualityComparer<V> comparer)
            {
                this.keySelector = keySelector;
                this.comparer = comparer;
            }
            public CommonEqualityComparer(Func<T, V> keySelector)
                : this(keySelector, EqualityComparer<V>.Default)
            { }

            public bool Equals(T x, T y)
            {
                if (x == null || y == null) return false;
                return comparer.Equals(keySelector(x), keySelector(y));
            }
            public int GetHashCode(T obj)
            {
                if (obj == null) return 0; 

                return comparer.GetHashCode(keySelector(obj));
            }
        }
    }
}
