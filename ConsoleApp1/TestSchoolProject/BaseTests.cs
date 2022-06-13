using ConsoleApp1;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSchoolProject
{
    public abstract class BaseTests
    {
        protected School School { get; set; }
        protected JArray Array { get; set; }

        [OneTimeSetUp]
        public void SetUpSchool()
        {
            School = new School("Sofia High School", "str. Sofia 1, Sofia");
            string studentsJsonFile = "InputJsonFile.json";
            Array = JsonDataFileReader.GetJArray(studentsJsonFile);
            List<Student> students = Array.ToObject<List<Student>>();
            School.AddStudents(students);
        }

    }
}
