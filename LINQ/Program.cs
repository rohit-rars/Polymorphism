using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LINQ
{
    /*
     * LINQ (Language Integrated Query) is uniform query syntax in C# and VB.NET to retrieve data from different sources and formats. 
     * It is integrated in C# or VB, thereby eliminating the mismatch between programming languages and databases, as well as providing 
     * a single querying interface for different types of data sources.
     * 
     * LINQ is a structured query syntax built in C# and VB.NET to retrieve data from different types of data sources such as collections, 
     * ADO.Net DataSet, XML Docs, web service and MS SQL Server and other databases.
     * 
     * LINQ to Objects, LINQ to DataSet, LINQ to XML, LINQ to Entities, LINQ to SQL
     */
    class Program
    {
        public class Employee
        {
            public int ID;
            public int Salary;
            public int DEPT_ID;
            public string Name;
        }

        public class Department
        {
            public int DEPT_ID;
            public string DEPT_Name;
        }

        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                 new Employee {ID=101,   Name="Amit  "    , Salary=4000,DEPT_ID=101},
                 new Employee {ID=102,   Name="Amit  "    , Salary=3800,DEPT_ID=102},
                 new Employee {ID=103,   Name="Salman"    , Salary=7000,DEPT_ID=103},
                 new Employee {ID=104,   Name="Ram   "    , Salary=5000,DEPT_ID=101},
                 new Employee {ID=105,   Name="Shyam "    , Salary=7000,DEPT_ID=102},
                 new Employee {ID=106,   Name="Kishor"    , Salary=6000,DEPT_ID=103},
            };

            List<string> test = new List<string>();
            test.Where(x => x.Contains("Manish"));
            /*
             * Select is all about transformation.
             * Where is all about filtering
             * */
            IEnumerable<string> strings = new List<string> { "one", "two", "three", "four" };
            // Will return { 3, 3, 5, 4 }
            IEnumerable<int> result1 = strings.Select(str => str.Length);
            var temp = employees.Select(x => x.Name.ToLower().Contains("a")).ToList();
            var tempWhere = employees.Where(x => x.Name.Trim() == "Amit");

            List<Department> departments = new List<Department>()
            {
                 new Department {DEPT_ID=101,   DEPT_Name="HR        "   },
                 new Department {DEPT_ID=102,   DEPT_Name="ACCOUNTS  "   },
                 new Department {DEPT_ID=103,   DEPT_Name="SALES     "   },
            };

            var ResultQuery = (from emp in employees
                               join dept in departments
                               on emp.DEPT_ID equals dept.DEPT_ID
                               select new
                               {
                                   ID = emp.ID,
                                   Name = emp.Name,
                                   Salary = emp.Salary,
                                   DeptName = dept.DEPT_Name
                               }).ToList();

            Console.WriteLine("Employee Details: ");
            foreach (var e in ResultQuery)
            {
                Console.WriteLine("\tID: " + e.ID + ", Name: " + e.Name + ", Salary: " + e.Salary + ", Department: " + e.DeptName);
            }

            var result = employees.GroupBy(x => x.Salary).OrderByDescending(y => y.Key).Skip(1).FirstOrDefault();
            
            Console.WriteLine(string.Format("2nd Highest Salary is: {0}", result.Key));


            Console.ReadLine();
        }

        class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

        public static void LeftOuterJoinExample()
        {
            Person magnus = new Person { FirstName = "Magnus", LastName = "Hedlund" };
            Person terry = new Person { FirstName = "Terry", LastName = "Adams" };
            Person charlotte = new Person { FirstName = "Charlotte", LastName = "Weiss" };
            Person arlene = new Person { FirstName = "Arlene", LastName = "Huff" };

            Pet barley = new Pet { Name = "Barley", Owner = terry };
            Pet boots = new Pet { Name = "Boots", Owner = terry };
            Pet whiskers = new Pet { Name = "Whiskers", Owner = charlotte };
            Pet bluemoon = new Pet { Name = "Blue Moon", Owner = terry };
            Pet daisy = new Pet { Name = "Daisy", Owner = magnus };

            // Create two lists.
            List<Person> people = new List<Person> { magnus, terry, charlotte, arlene };
            List<Pet> pets = new List<Pet> { barley, boots, whiskers, bluemoon, daisy };

            var query = from person in people
                        join pet in pets on person equals pet.Owner into gj
                        from subpet in gj.DefaultIfEmpty()
                        select new { person.FirstName, PetName = subpet?.Name ?? String.Empty };

            foreach (var v in query)
            {
                Console.WriteLine($"{v.FirstName + ":",-15}{v.PetName}");
            }
        }
    }
}
