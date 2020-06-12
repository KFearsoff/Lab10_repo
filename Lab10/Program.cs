using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Примечание: в этом проекте собраны результаты 5 лабораторных работ, которые помечены номерами. Все лабораторные
             * работы, кроме первой, сделаны на основе иерархии классов из первой работы.
             * Задание: 
             * 1. Реализовать иерархию классов:
             * Person -> Employee -> Teacher
             * Person -> Student
             * Реализовать для каждого класса статическое поле Count, которое ведет подсчет количества объектов данного класса.
             * Для класса Person реализовать интерфейсы IComparable, ICloneable. 
             * 2. Создать класс TestCollections, который содержит поля List<T>, List<string>, Dictionary<T, K>, Dictionary<string, K>,
             * где string - это результат применения метода ToString() к T, K - производный класс в иерархии классов, а T -
             * базовый класс, поля которого соответствуют полям класса K.
             * 3. Реализовать для класса Person коллекции: двунаправленный список и бинарное дерево. Реализовать методы:
             * добавление в двунаправленный список элемента по номеру и превращение идеально сбалансированного дерева в дерево
             * поиска. 
             * Реализовать однонаправленный обобщенный список с конструкторами: OWList(), OWList(int capacity), OWList(OWList e).
             * Реализовать в нем методы для добавления одного или нескольких элементов, удаления элемента, поиска элемента,
             * клонирования коллекции, поверхностного копирования коллекции, удаления коллекции. Реализовать поле, 
             * позволяющее получить текущее количество элементов. Реализовать интерфейсы IEnumerable и IEnumerator и перегрузить
             * индексатор.
             * 4. Создать класс PersonList, производный от класса List<Person>. Добавить в него методы для добавления и удаления
             * элементов и перегрузить индексатор. Добавить событие CountChanged, которое вызывается при изменении количества
             * элементов, и событие ReferenceChanged, которое вызывается при замене элемента коллекции. Для событий определить
             * делегат CollectionHandler(object source, CHEventArgs args), где CHEventArgs - класс, наследуемый от EventArgs,
             * содержащий сведения о имени коллекции, типе изменения и ссылку на элемент, с которым связаны изменения.
             * Создать класс JournalEntry, в который можно помещать данные из CHEventArgs, и класс Journal, который хранит
             * список элементов типа JournalEntry. Обеспечить возможность добавления в класс Journal элементов каждый раз, когда
             * вызывается событие класса PersonList.
             * 5. Заполнить обобщенную коллекцию из задания 3 элементами иерархии классов из задания 1. Выполнить запросы с
             * помощью LINQ: на выборку данных, на количество объектов с заданным условием, на аггрегацию данных.
             * Это задание выполнено ниже.
             */
            OWList<Person> list = new OWList<Person>(15);
            Random rand = new Random();
            for (int i = 0; i < 15; i++)
                list.Add(new Person($"Mob{i + 1}", rand.Next(10, 81), (rand.Next(2) == 0) ? true : false));
            list.Show();
            Console.WriteLine();
            var youngsters = from person in list where person.Age < 40 select person;
            foreach (var c in youngsters) Console.Write(c.ToString());
            Console.WriteLine("Amount of geezers: " + (from person in list where person.Age >= 60 select person).Count());
            var gentlemen = from person in list where person.IsMale == true select person;
            var grandfathers = from person in list where person.Age >= 40 && person.IsMale == true select person;
            foreach (var c in grandfathers) Console.Write(c.ToString());
            Console.WriteLine("Total age: " + (from person in list select person.Age).Aggregate((a, b) => a + b));
        }
    }
}
