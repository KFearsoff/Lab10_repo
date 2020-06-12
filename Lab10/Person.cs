using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Person : IComparable, ICloneable
    {
        public static int Count { get; private set; } = 0;
        public string Name { get; private set; } = "Mob";
        private int age = 14;
        public int Age
        {
            get { return age; }
            private set { if (value > 0) age = value; }
        }
        public bool IsMale { get; private set; } = true;

        public Person() { Count++; }
        public Person(string Name, int Age, bool IsMale)
        {
            this.Name = Name;
            this.Age = Age;
            this.IsMale = IsMale;
            Count++;
        }

        public virtual void Show()
        {
            Console.Write(ToString());
        }

        public override string ToString()
        {
            return $"Name: {Name}\nAge: {Age}\nSex: {(IsMale ? "Male" : "Female")}\n";
        }

        public override int GetHashCode()
        {
            return (Name.Length * 2 + age * 3).GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Person)) return false;
            return Name == ((Person)obj).Name && Age == ((Person)obj).Age && IsMale == ((Person)obj).IsMale;
        }

        #region Operators
        public static bool operator ==(Person person1, Person person2)
        {
            if (Equals(person1, null) || Equals(person2, null))
                return Equals(person1, person2);
            return person1.Equals(person2);
        }

        public static bool operator !=(Person person1, Person person2)
        {
            if (Equals(person1, null) || Equals(person2, null))
                return !Equals(person1, person2);
            return !person1.Equals(person2);
        }
        #endregion

        //IComparable
        public int CompareTo(object obj)
        {
            Person temp = obj as Person;
            if (Name.CompareTo(temp.Name) != 0) return Name.CompareTo(temp.Name);
            else return Age.CompareTo(temp.Age);
        }

        //ICloneable
        public object Clone()
        {
            return new Person(Name, Age, IsMale);
        }

        public Person ShallowCopy()
        {
            return (Person)MemberwiseClone();
        }
    }
}
