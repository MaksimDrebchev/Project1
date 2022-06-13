using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConsoleApp1
{
    internal class Program
    {
        private const string StudentsTextFile = "InputJsonFile.json";
        internal static void Main(string[] args)
        {
            School uchilishte = new School("Sofia High School", "str. Sofia 1, Sofia");
            JArray jArray = JsonDataFileReader.GetJArray(StudentsTextFile);
            List<Student> students = jArray.ToObject<List<Student>>();
            uchilishte.AddStudents(students);      

            List<Student> bestStudents = uchilishte.GetExcellentStudents();

            try
            {
                foreach (Student student in bestStudents)
                {
                    student.Speak();
                }
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You are not in School anymore");
            }
        }

    }
}


