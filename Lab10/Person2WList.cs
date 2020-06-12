using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Person2WList
    {
        public static Person2WList StartingPoint;
        public Person person;
        public Person2WList next;
        public Person2WList previous;

        public Person2WList() { }
        public Person2WList(Person person) { this.person = person; }
        public override string ToString() { return person.ToString(); }

        static Person2WList Add(Person person)
        {
            return new Person2WList(person);
        }

        //Создает список с заданным размером из мужчин с именем Mob возраста от 10 до 80 лет.
        public static void MakeList(int size)
        {
            Random rand = new Random();
            Person2WList currentElement, nextElement;
            StartingPoint = Add(new Person("Mob", rand.Next(10, 81), true));
            nextElement = Add(new Person("Mob", rand.Next(10, 81), true));
            StartingPoint.next = nextElement;
            nextElement.previous = StartingPoint;
            for (int i = 1; i < size - 1; i++)
            {
                currentElement = nextElement;
                nextElement = Add(new Person("Mob", rand.Next(10, 81), true));
                currentElement.next = nextElement;
                nextElement.previous = currentElement;
            }
        }

        public static void Show()
        {
            if (StartingPoint == null) Console.WriteLine("Collection is empty!");
            else
            {
                var numerator = StartingPoint;
                while (numerator != null)
                {
                    numerator.person.Show();
                    numerator = numerator.next;
                }
            }
        }

        public static void AddAt(Person person, int index)
        {
            var numerator = StartingPoint;
            for (int i = 0; i < index; i++)
            {
                if (numerator.next == null)
                {
                    Console.WriteLine("Index out of range!");
                    break;
                }
                else if (i == index - 1)
                {
                    var temp = numerator.next;
                    numerator.next = new Person2WList(person);
                    numerator.next.previous = numerator;
                    numerator.next.next = temp;
                }
                else numerator = numerator.next;
            }
        }
    }
}
