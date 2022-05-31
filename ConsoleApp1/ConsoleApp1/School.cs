using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class School
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public List<Student> Students { get; private set; }

        public School(string name, string address)
        {
            Name = name;
            Address = address;
            Students = new List<Student>();
        }

        public void AddStudent(Student student)
        {
            Students.Add(student);
        }

        public void AddStudents(List<Student> students) => Students.AddRange(students);

        public void RemoveStudent(int id)
        {
            foreach (Student student in Students)
            {
                if (student.Id == id)
                {
                    Students.Remove(student);
                }
            }
        }

        public List<Student> GetExcellentStudents()
        {
            List<Student> otlichnici = new List<Student>();
            foreach (var student in Students)
            {
                int lowerScore = 6;
                foreach (int item in student.belejnik.Values)
                {
                    if (item < 6)
                    {
                        lowerScore = item;
                    }
                }
                if (lowerScore == 6)
                {
                    student.isExcellent = true;
                    otlichnici.Add(student);
                }
            }
            return otlichnici;
        }
    }
}
