using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Lab10
{
    class TestCollections
    {
        //Person имеет те же поля, что и наследуемая от Person часть класса Student. string здесь - это Person.ToString().
        public List<Person> List1 = new List<Person>();
        public List<string> List2 = new List<string>();
        public Dictionary<Person, Student> Dictionary1 = new Dictionary<Person, Student>();
        public Dictionary<string, Student> Dictionary2 = new Dictionary<string, Student>();

        public TestCollections(int length, [Optional] bool IsTest)
        {
            Random rand = new Random();
            for (int i = 0; i < length; i++)
            {
                string name = "Mob";
                bool isMale = true;
                int age = 10;
                int year = 1;
                //Если IsTest==true, то пол, возраст, курс и имя выбираются случайно (имя будет иметь вид строки из 8 цифр).
                //Иначе передаются стандартные значения сверху.
                if (!IsTest)
                {
                    for (int j = 0; j < 8; j++)
                        name += rand.Next(0, 10);
                    isMale = (rand.Next(0, 2) == 0) ? true : false;
                    age = rand.Next(10, 81);
                    year = rand.Next(1, 6);
                }
                else name += i;
                Student student = new Student(name, age, isMale, "Software Engineering", year);
                Person person = new Person(name, age, isMale);
                List1.Add(person);
                List2.Add(person.ToString());
                Dictionary1.Add(person, student);
                Dictionary2.Add(person.ToString(), student);
            }
        }
    }
}
