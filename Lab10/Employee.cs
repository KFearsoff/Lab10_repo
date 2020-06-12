using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab10
{
    class Employee : Person
    {
        //ключевое слово new позволяет отделить Person.Count от Employee.Count
        public new static int Count { get; private set; } = 0;
        public string Workplace { get; private set; } = "HSE";
        private int experience = 0;
        protected int Experience
        {
            get { return experience; }
            set { if (value >= 0) experience = value; }
        }

        public Employee() : base() { Count++; }
        public Employee(string Name, int Age, bool IsMale) : base(Name, Age, IsMale) { Count++; }
        public Employee(string Name, int Age, bool IsMale, string Workplace, int Experience) : base(Name, Age, IsMale)
        {
            this.Workplace = Workplace;
            this.Experience = Experience;
        }

        //выводит на экран свойства, наследуемые от Person, и свойства Employee
        public override void Show()
        {
            base.Show();
            Console.WriteLine("Workplace: " + Workplace);
            Console.WriteLine("Experience: " + Experience);
        }
    }
}
