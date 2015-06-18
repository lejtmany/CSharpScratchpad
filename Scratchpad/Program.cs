using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Immutable;

namespace Scratchpad
{
    class Program
    {
        public interface IPerson
        {
            String FirstName { get; set; }
            String LastName { get; set; }
            int Age { get; set; }
            void Talk();
            String ToString();

        }
        public class Parent : IPerson
        {
            public int Age { get; set; }
            public String FirstName { get; set; }
            public String LastName { get; set; }
            public Parent(String firstName, String lastName, int age = 0, String nickName = "Sneaks")
            {
                FirstName = firstName;
                LastName = lastName;
                Age = age;
            }
            public void Talk()
            {
                Console.WriteLine("I am a Parent");
            }

            public override String ToString()
            {
                return String.Format("Name: {0} {1} Age: {2}", FirstName, LastName, Age);
            }

        }
        public class Child : Parent
        {
            public Child()
                : base("Baby", "A")
            {

            }
            public new void Talk()
            {
                Console.WriteLine("I am a Child");
            }
        }
        public class Brat : Child
        {
            public new void Talk()
            {
                Console.WriteLine("I am a Brat");
            }
        }

        public interface ISchoolClass<out TOut, in TIn>
            where TOut : IPerson
            where TIn : IPerson
        {
            IEnumerable<TOut> GetClassList();
            void AddStudent(TIn student);
        }
        public class CollegeClass<T> : ISchoolClass<T, T> where T : IPerson
        {
            List<T> students = new List<T>();
            Func<String, int> stringLength = s => s.Length;

            public IEnumerable<T> GetClassList()
            {
                return students;
            }

            public void AddStudent(T student)
            {
                Console.WriteLine("Student added first name is {0} characters", stringLength("hello"));
                students.Add(student);
            }
        }

        static void Main(string[] args)
        {
            var parent = new Parent("John", "Doe", nickName:"007");
            var child = new Child();
            Child brat1 = new Brat();
            var brat2 = new Brat();
            parent.Talk();
            child.Talk();
            brat1.Talk();
            brat2.Talk();
            var collegeClass = new CollegeClass<IPerson>();
            collegeClass.AddStudent(parent);
            collegeClass.AddStudent(child);
            collegeClass.AddStudent(brat1);
            collegeClass.AddStudent(brat2);
            Console.WriteLine(String.Join(",", collegeClass.GetClassList()));
        }
    }
}
