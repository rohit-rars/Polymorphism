using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Liskov
{
    /*
     * The Liskov substitution principle (LSP) is a specific definition of a subtyping relation created by Barbara Liskov and Jeannette Wing. 
     * The principle says that any class must be directly replaceable by any of its subclasses without error.
     * 
     * In other words, each subclass must maintain all behavior from the base class along with any new behaviors unique to the subclass. 
     * The child class must be able to process all the same requests and complete all the same tasks as its parent class
     */
    class Program
    {
        static void Main(string[] args)
        {
            var managerEmp = new Manager();
            managerEmp.Name = "John Doe";
            managerEmp.GetPay();

            var programmerEmp = new Employee();
            programmerEmp.Name = "Roel Doel";
            programmerEmp.GetPay();
            programmerEmp.AssignManager(managerEmp);

            var manager = new Manager();
            manager.Name = "John Doe";
            manager.GetPay();

            var programmer = new Manager();
            programmer.Name = "Roel Doel";
            programmer.GetPay();
            programmer.AssignManager(manager);

            var managerCeo = new Manager();
            managerCeo.Name = "John Doe";
            managerCeo.GetPay();

            var programmerCeo = new CEO();
            programmerCeo.Name = "Roel Doel";
            programmerCeo.GetPay();
            //programmerCeo.AssignManager(managerCeo);--Error
            Console.ReadKey();
        }
    }

    public interface IBaseEmployee
    {
        string Name { get; set; }

        double GetPay();
    }

    public abstract class BaseEmployee : IBaseEmployee
    {
        public string Name { get; set; }

        public virtual double GetPay() { return 0; }
    }

    public interface IHasManager
    {
        IBaseEmployee AssignedManager { get; set; }

        void AssignManager(IBaseEmployee manager);
    }

    public class Employee : BaseEmployee, IHasManager
    {
        public IBaseEmployee AssignedManager { get; set; }

        public override double GetPay()
        {
            var currentSalary = 500;
            Console.WriteLine($"Current Pay {currentSalary}");
            return currentSalary;
        }

        public virtual void AssignManager(IBaseEmployee manager)
        {
            Console.WriteLine("Manager Assigned");
            AssignedManager = manager;
        }

    }

    public class Manager : BaseEmployee, IHasManager
    {
        public IBaseEmployee AssignedManager { get; set; }
        public override double GetPay()
        {
            var currentSalary = 750;
            Console.WriteLine($"Current Pay {currentSalary}");
            return currentSalary;
        }

        public void AssignManager(IBaseEmployee manager)
        {
            Console.WriteLine("Manager Assigned");
            AssignedManager = manager;
        }
    }

    public class CEO : BaseEmployee
    {

        public override double GetPay()
        {
            var currentSalary = 750;
            Console.WriteLine($"Current Pay {currentSalary}");
            return currentSalary;
        }

    }
}
