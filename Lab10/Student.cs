using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Student : Person
    {
        //ключевое слово new позволяет отделить Person.Count от Student.Count
        public new static int Count { get; private set; } = 0;
        private int year = 1;
        private int Year
        {
            get { return year; }
            set { if (value > 0 || value < 6) year = value; }
        }
        private string Course { get; set; } = "Software Engineering";


        public Student() : base() { Count++; }
        public Student(string Name, int Age, bool IsMale) : base(Name, Age, IsMale) { Count++; }
        public Student(string Name, int Age, bool IsMale, string Course, int Year) : base(Name, Age, IsMale)
        {
            this.Course = Course;
            this.Year = Year;
            Count++;
        }

        //выводит на экран свойства, наследуемые от Person, и свойства Student
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Course: " + Course);
            Console.WriteLine("Year: " + Year);
        }

        public override string ToString()
        {
            return base.ToString() + "Course: " + Course + "\nYear: " + Year + "\n";
        }
    }
}
