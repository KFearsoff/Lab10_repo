using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    delegate void CollectionHandler(object source, CHEventArgs args);
    class PersonList : List<Person>
    {
        //Два события и методы для их вызова, проверяющие события на null.
        public event CollectionHandler CountChanged;
        public void OnCountChanged(object source, CHEventArgs args) { CountChanged?.Invoke(source, args); }
        public event CollectionHandler ReferenceChanged;
        public void OnReferenceChanged(object source, CHEventArgs args) { ReferenceChanged?.Invoke(source, args); }

        public string Name { get; set; }

        //Конструктор, принимающий в качестве аргумента имя коллекции и создающий список из 5 элементов типа Person.
        public PersonList(string Name)
        {
            this.Name = Name;
            Random rand = new Random();
            for (int i = 0; i < 5; i++)
                base.Add(new Person("Mob", rand.Next(10, 81), true));
        }

        #region Вызывают CountChanged
        public new void Add(Person item)
        {
            OnCountChanged(this, new CHEventArgs(Name, "Add", item));
            base.Add(item);
        }

        public new bool Remove(Person item)
        {
            var temp = base.Remove(item);
            if (temp) OnCountChanged(this, new CHEventArgs(Name, "Remove", item));
            return temp;
        }

        public new void RemoveAt(int index)
        {
            OnCountChanged(this, new CHEventArgs(Name, "RemoveAt", this[index]));
            base.RemoveAt(index);
        }
        #endregion

        public override string ToString()
        {
            string temp = "";
            foreach (var c in this) temp += c.ToString();
            return temp;
        }

        //Вызывает ReferenceChanged.
        public new Person this[int index]
        {
            get { return base[index]; }
            set
            {
                OnReferenceChanged(this, new CHEventArgs(Name, "Change", this[index]));
                base[index] = value;
            }
        }
    }
}
