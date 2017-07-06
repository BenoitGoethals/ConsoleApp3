using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Drawing;

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
          //  Repositrory<Post>.GetInstance().DataBase = "db";
            Repositrory<Post>.GetInstance().Add(p);
            ;
            foreach (var item in Repositrory<Post>.GetInstance().All().Result)
            {
                Console.WriteLine(item.name);
            }

            Console.WriteLine("-----------------------------");

            Repositrory<Student>.GetInstance().Add(CreateNewStudents());

            //  foreach (var item in Repositrory<Student>.GetInstance().All())
            // {
            //   Console.WriteLine(item);
            // }

            String newFileName = "my-image";

            Image imageCircle = 


            var tasks=new Task[10];
            for (var i2 = 0; i2 < 10; i2++)
            {
                var i1 = i2;
                var i3 = i2;
               tasks[i2]= Task.Factory.StartNew(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {

                        Repositrory<Student>.GetInstance().Add(new Student
                        {
                            FirstName = "Gregor " + i1+i3,
                            LastName = "Felix " + i1,
                            Subjects = new List<string>() {"English", "Mathematics", "Physics", "Biology"},
                            Class = "JSS 3" + i1,
                            Age = 23 + i1
                        });

                    }
                    ;
                    Console.WriteLine("einde task"+i3);
                });
            }
            Task.WaitAll(tasks);
            Console.WriteLine("einde+"+Repositrory<Student>.GetInstance().Count().Result);
          
          //  Console.WriteLine(Repositrory<Student>.GetInstance().Count().Result);
          //  Repositrory<Post>.GetInstance().RemoveAll();
         
            Console.ReadLine();
            Repositrory<Student>.GetInstance().RemoveAll();
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