using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpWasher
{
    class Garage : ICollection<Car>
    {
        ICollection<Car> items;
        public Garage()
        {
            items = new List<Car>();
        }

        public int Count => items.Count;

        public bool IsReadOnly => items.IsReadOnly;

        public void Add(Car item)
        {
            items.Add(item);
        }

        public void Clear()
        {
            items.Clear();
        }

        public bool Contains(Car item)
        {
            return items.Contains(item);
        }

        public void CopyTo(Car[] array, int arrayIndex)
        {
            items.CopyTo(array, arrayIndex);
        }

        public IEnumerator<Car> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public bool Remove(Car item)
        {
            return items.Remove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return items.GetEnumerator();
        }
    }
}
