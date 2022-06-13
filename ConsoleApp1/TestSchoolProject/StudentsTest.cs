using ConsoleApp1;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace TestSchoolProject
{
    [TestFixture]
    public class StudentsTest : BaseTests
    {

        [Test]
        public void CheckIdProperty()
        {
            bool isIdProperty = false;
            foreach (JObject jObject in Array)
            {
                if (jObject.ContainsKey("Id"))
                {
                    isIdProperty = true;
                    break;
                }  
            }
            Assert.IsFalse(isIdProperty);
        }

        [Test]
        public void UniqueIds()
        {
            List<int> studentIds = new List<int>();
            foreach (Student student in School.Students)
            {
                studentIds.Add(student.Id);
            }
            bool isUnique = studentIds.Distinct().Count() == studentIds.Count();
            Assert.IsTrue(isUnique);
        }

        [Test]
        public void ComapreSubjects()
        {
            List<string> comparedSubjects = School.Students.First().belejnik.Keys.ToList();
            foreach (Student student in School.Students)
            {
                List<string> subjects = student.belejnik.Keys.ToList();
                CollectionAssert.AreEquivalent(comparedSubjects, subjects);
            }
        }

        [Test]
        public void ValidateObjects()
        {
            for (int i = 0; i < School.Students.Count; i++)
            {
                Student student = School.Students[i];
                JObject jObject = Array[i].ToObject<JObject>();

                string expectedName = jObject["Name"].ToObject<string>();
                int expectedAge = jObject["Age"].ToObject<int>();
                Dictionary<string, int> expectedMarks = jObject["Marks"].ToObject<Dictionary<string, int>>();
                Assert.AreEqual(expectedName, student.Name);
                Assert.AreEqual(expectedAge, student.Age);

                foreach (var pair in expectedMarks)
                {
                    Assert.AreEqual(student.belejnik[pair.Key], pair.Value);
                }
            }
        }

        [Test]
        public void ValidateStudentsUnder18Years()
        {
            School.Students.RemoveAll(student => student.Age == 18);
            Assert.AreEqual(3, School.Students.Count);
        }


    }
}