using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class OWListNumerator<T> : IEnumerator<T>
    {
        OWList<T> start = new OWList<T>();
        OWList<T> current = new OWList<T>();

        public OWListNumerator(OWList<T> c)
        {
            start.next = c.start;
            current.next = c.start;
        }

        public T Current { get { return current.data; } }
        object IEnumerator.Current { get { return Current; } }


        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            if (current.next == null)
            {
                Reset();
                return false;
            }
            else
            {
                current = current.next;
                return true;
            }
        }

        public void Reset()
        {
            current = start;
        }
    }
}
