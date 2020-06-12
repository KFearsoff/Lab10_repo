using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class OWList<T> : ICollection<T>, IEnumerable<T>
    {
        public T data;
        public OWList<T> start;
        private OWList<T> end;
        public OWList<T> next;
        private T[] items;
        public int Count { get; private set; } = 0;
        public int Capacity { get; private set; } = 1;
        public bool IsReadOnly { get; } = false;

        public OWList() { items = new T[Capacity]; }
        public OWList(T data) { this.data = data; }
        public OWList(int capacity)
        {
            if (capacity > 0)
            {
                Capacity = capacity;
                items = new T[Capacity];
            }
        }
        public OWList(OWList<T> collection)
        {
            Capacity = collection.Capacity;
            items = new T[Capacity];
            Add(collection.items);
        }

        #region Add
        public void Add(T data)
        {
            OWList<T> list = new OWList<T>(data);
            //Если последний элемент не определен, то это значит, что список еще не сформирован, так что добавленный элемент
            //является одновременно первым и последним. Иначе он становится новым последним.
            if (end == null)
            {
                this.data = data;
                start = this;
                end = this;
            }
            else
            {
                end.next = list;
                end = list;
            }
            //Если вместимость списка достигнута, то она удваивается.
            if (Count == Capacity)
            {
                Capacity *= 2;
                T[] temp = new T[Capacity];
                Array.Copy(items, temp, Count);
                items = temp;
            }
            items[Count] = data;
            Count++;
        }

        public void Add(params T[] data)
        {
            foreach (var c in data)
                Add(c);
        }
        #endregion
        #region Remove
        public bool Remove(T data)
        {
            //Если удаляется первый элемент и он один, список становится пустым. Иначе второй элемент становится новым первым.
            if (this != null && Equals(this.data, data))
            {
                if (Count == 1)
                {
                    this.data = default(T);
                    start = null;
                    end = null;
                    RemoveFromArray(data);
                    return true;
                }
                else
                {
                    this.data = next.data;
                    next = next.next;
                    RemoveFromArray(data);
                    return true;
                }
            }
            //Если удаляется последний элемент и он является вторым, то список становится списком из одного элемента.
            else if (this != null && Equals(end.data, data))
            {
                var current = start;
                while (current.next != end) current = current.next;
                current.next = null;
                end = current;
                RemoveFromArray(data);
                return true;
            }
            //Иначе ищется первый элемент и удаляется (если найден).
            else if (this != null)
            {
                var current = start;
                while (current.next != null)
                {
                    if (Equals(current.next.data, data))
                    {
                        current.next = current.next.next;
                        RemoveFromArray(data);
                        return true;
                    }
                    current = current.next;
                }
            }
            //Если ничего из вышеперечисленного не подходит или в функцию передан null, то ничего не происходит и функция
            //возвращает false.
            return false;
        }

        //Приватный метод, осуществляющий удаление элемента из внутреннего массива private T[] items. Вызывается в методе выше.
        private void RemoveFromArray(T data)
        {
            T[] temp = new T[Capacity];
            int index = 0;
            for (int i = 0; i < Count; i++)
                if (!Equals(items[i], data))
                {
                    temp[index] = items[i];
                    index++;
                }
            items = temp;
            Count--;
        }
        #endregion
        //Очищает коллекцию, присваивая всем элементам стандартное значение.
        public void Clear()
        {
            items = new T[Capacity];
            var temp = start;
            while (temp != null)
            {
                temp.data = default(T);
                temp = temp.next;
            }
        }

        public bool Contains(T data)
        {
            return items.Contains(data);
        }

        public void CopyTo(T[] array, int index)
        {
            items.CopyTo(array, index);
        }



        public override string ToString() { return base.ToString(); }

        public void Show()
        {
            foreach (var c in this)
                Console.Write(c.ToString());
        }

        #region IEnumerable<T>
        public IEnumerator<T> GetEnumerator()
        {
            return new OWListNumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                else
                {
                    var current = start;
                    for (int i = 0; i < index; i++)
                        current = current.next;
                    return current.data;
                }
            }
            set
            {
                if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
                else
                {
                    var current = start;
                    for (int i = 0; i < index; i++)
                        current = current.next;
                    current.data = value;
                }
            }
        }
    }
}
