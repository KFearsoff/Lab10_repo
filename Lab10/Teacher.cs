using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Teacher : Employee
    {
        //ключевое слово new позволяет отделить Teacher.Count от Employee.Count и Person.Count
        public new static int Count { get; private set; } = 0;
        public string Subject { get; private set; } = "Programming";

        public Teacher() : base() { Count++; }
        public Teacher(string Name, int Age, bool IsMale) : base(Name, Age, IsMale) { Count++; }
        public Teacher(string Name, int Age, bool IsMale, string Workplace, int Experience)
            : base(Name, Age, IsMale, Workplace, Experience) { Count++; }
        public Teacher(string Name, int Age, bool IsMale, string Workplace, int Experience, string Subject)
            : base(Name, Age, IsMale, Workplace, Experience)
        {
            this.Subject = Subject;
            Count++;
        }

        //выводит на экран все свойства, наследуемые от Employee, и свойства класса Teacher
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Subject: " + Subject);
        }
    }
}
