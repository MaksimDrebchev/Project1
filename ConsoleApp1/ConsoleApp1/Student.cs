using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Student
    {
        public string Name { get; set; }
        public int Id { get; private set; }
        private int _age;
        public Dictionary<string, int> belejnik = new Dictionary<string, int>();
        public bool isExcellent = false;

        public int Age
        {
            get { return _age; }
            set
            {
                if (value >= 7)
                {
                    _age = value;
                }  
                else
                {
                    throw new ArgumentException("Student age is less than 7");
                }    
            }
        }

        public Student (string name, int age, Dictionary<string, int> marks)
        {
            Name = name;
            Age = age;
            belejnik = marks;
            Random random = new Random();
            int randomNumber = random.Next();
            Id = randomNumber;
        }

        public void Speak() => Console.WriteLine(Message);

        private int YearsLeft => 18 - Age;
        private string Message
        {
            get
            {
                string message;
                if (Age < 18)
                {
                    message = $"Hello I'm {Name} and I've got {YearsLeft} years to graduate.";
                }
                else
                {
                    message = $"Hello I’m {Name} and I'll graduate this year.";
                }
                return message;
            }
        }

        public object Marks { get; set; }
    }
}
