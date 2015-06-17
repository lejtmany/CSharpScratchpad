using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scratchpad
{
    class Program
    {
        public interface IPerson
        {
            void Talk();
        }
        public class Parent : IPerson
        {

            public void Talk()
            {
                Console.WriteLine("I am a Parent");
            }
        }
        public class Child : IPerson
        {
            public virtual void Talk()
            {
                Console.WriteLine("I am a Child");
            }
        }
        public class Brat : Child
        {
            public override void Talk()
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

            public IEnumerable<T> GetClassList()
            {
                return students;
            }

            public void AddStudent(T student)
            {
                students.Add(student);
            }
        }

        static void Main(string[] args)
        {
            var parent = new Parent();
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
            Console.WriteLine(String.Join("," , collegeClass.GetClassList()));
        }
    }
}
