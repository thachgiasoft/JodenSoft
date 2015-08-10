using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAF.EntityFramework
{
    public class EntitySetBaseCollection : IList<IEntitySetBase>
    {
        private List<IEntitySetBase> innerList = new List<IEntitySetBase>();

        public int IndexOf(IEntitySetBase item)
        {
            return innerList.IndexOf(item);
        }

        public void Insert(int index, IEntitySetBase item)
        {
            innerList.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            innerList.RemoveAt(index);
        }

        public IEntitySetBase this[int index]
        {
            get
            {
                return innerList[index];
            }
            set
            {
                innerList[index] = value;
            }
        }

        public void Add(IEntitySetBase item)
        {
            if (item == null)
                throw new ArgumentNullException("item");
            this.innerList.Add(item);
        }

        public void Clear()
        {
            innerList.Clear();
        }

        public bool Contains(IEntitySetBase item)
        {
            return innerList.Contains(item);
        }

        public void CopyTo(IEntitySetBase[] array, int arrayIndex)
        {
            innerList.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return this.innerList.Count; }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(IEntitySetBase item)
        {
            return innerList.Remove(item);
        }

        public IEnumerator<IEntitySetBase> GetEnumerator()
        {
            return innerList.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return innerList.GetEnumerator();
        }
    }
}
