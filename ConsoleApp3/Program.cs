using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Post
            {
                name = "test",
                straat = "sdfds",
                email = "dfds@sdf.be"
            };
            Repositrory<Post>.GetInstance().DataBase = "db";
            Repositrory<Post>.GetInstance().Add(p);
            ;
            foreach (var item in Repositrory<Post>.GetInstance().All())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("-----------------------------");

            Repositrory<Student>.GetInstance().Add(CreateNewStudents());
            
            foreach (var item in Repositrory<Student>.GetInstance().All())
            {
                Console.WriteLine(item);
            }
        


            for (int i = 0; i < 100000; i++)
            {
                Repositrory<Student>.GetInstance().Add(new Student
                {
                    FirstName = "Gregor "+i,
                    LastName = "Felix "+i,
                    Subjects = new List<string>() { "English", "Mathematics", "Physics", "Biology" },
                    Class = "JSS 3"+i,
                    Age = 23+i
                });
            }
            Console.WriteLine(Repositrory<Student>.GetInstance().Count());
            Repositrory<Student>.GetInstance().DeleteAll();
            Console.WriteLine(Repositrory<Student>.GetInstance().Count());
            Console.ReadLine();
        }
  


    private static IList<Student> CreateNewStudents()
    {
        var student1 = new Student
        {
            FirstName = "Gregor",
            LastName = "Felix",
            Subjects = new List<string>() { "English", "Mathematics", "Physics", "Biology" },
            Class = "JSS 3",
            Age = 23
        };

        var student2 = new Student
        {
            FirstName = "Machiko",
            LastName = "Elkberg",
            Subjects = new List<string> { "English", "Mathematics", "Spanish" },
            Class = "JSS 3",
            Age = 23
        };

        var student3 = new Student
        {
            FirstName = "Julie",
            LastName = "Sandal",
            Subjects = new List<string> { "English", "Mathematics", "Physics", "Chemistry" },
            Class = "JSS 1",
            Age = 25
        };

        var newStudents = new List<Student> { student1, student2, student3 };

        return newStudents;
    }
}
}