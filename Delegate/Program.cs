using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegate
{
    /*C# delegates are similar to pointers to functions, in C or C++. A delegate is a 
     * reference type variable that holds the reference to a method. The reference 
     * can be changed at runtime.
     * 
     * It is especially used for implementing events and call-back methods.
     * 
     * You can pass methods as parameters to a delegate to allow
     * the delegate to point to the method. Delegates are used to define callback methods and
     * implement event handling, and they are declared using the “delegate” keyword.
     * You can declare a delegate that can appear on its own or even nested inside a class.
     * 
     * Func, Action and Predicate are define in C# 3.0 and these are generic inbuilt delegates.
     * 
     * Type safety means that the compiler will validate types while compiling, and throw an error 
     * if you try to assign the wrong type to a variable.
     * 
     * String one = 1; //Error
     * 
     * int foo = "bar"; //Error
     
     */

    class Program
    {
        private static int AddNumbers(int param1, int param2)
        {
            return param1 + param2;
        }

        private static int resultAction;
        private static void AddNumbersAction(int param1, int param2)
        {
            resultAction = param1 + param2;
        }

        private static bool IsApple(string modelName)
        {
            if (modelName == "I Phone X")
                return true;
            else
                return false;
        }


        //Declaration
        public delegate void addnum(int a, int b);
        public delegate void subnum(int a, int b);
        static void Main(string[] args)
        {
            //Func
            /*
             * Func is generic delegate present in System namespace. It takes one or more input parameters and returns one out parameter. 
             * The last parameter is considered as a return value.
             * 
             * Func delegate type can include 0 to 16 input parameters of different types. It must have one return type. So return type 
             * is mandatory but input parameter is not.
             */
            Func<int, int, int> Addition = AddNumbers;
            int result = Addition(10, 20);

            /*
             * Action Delegate
             * Action is a generic delegate present in System namespace. It takes one or more input parameters and returns nothing.
             * 
             * So it does not return any value.
             */
            Action<int, int> AdditionAction = AddNumbersAction;
            AdditionAction(10, 20);
            Console.WriteLine(resultAction);

            /*
             * Predicate delegate
             * Syntax difference between predicate & func is that here in predicate, you don't specify a return type because it is always a bool.
             */
            Predicate<string> CheckIfApple = IsApple;
            bool resultPredicate = CheckIfApple("I Phone X");
            if (resultPredicate)
                Console.WriteLine("It's an IPhone");

            //Single Cast
            DelegateTest del = new DelegateTest();

            //Instantiation
            addnum addnumObj = new addnum(del.sum);
            //Invocation
            addnumObj(10, 20);
            //OR
            //addnumObj.Invoke(10, 20);

            subnum subnum = new subnum(del.subtract);
            subnum.Invoke(20, 10);


            //Multicast
            DelegateTest multiCast = new DelegateTest();
            addnum addnumMulti = new addnum(del.sum);
            addnumMulti += del.subtract;
            addnumMulti.Invoke(50, 30);


            PizzaOrderingSystemMethod pizzaOrdering = new PizzaOrderingSystemMethod();
            PizzaOrder pizzaOrder = new PizzaOrder();
            pizzaOrder.Pizzas = new List<Pizza>()
            {
                new Pizza(20, Crust.Stuffed),
                new Pizza(30, Crust.Stuffed),
                new Pizza(40, Crust.Stuffed)
            };

            pizzaOrdering.ComputePrice(pizzaOrder);

            Console.ReadKey();
        }
    }

    public class DelegateTest
    {
        // method "sum" 
        public void sum(int a, int b)
        {
            Console.WriteLine("{0} + {1} = {2}", a, b, a + b);
        }

        // method "subtract" 
        public void subtract(int a, int b)
        {
            Console.WriteLine("{0} - {1} = {2}", a, b, a - b);
        }
    }

    public class DiscountPoliciesMethods
    {
        public decimal BuyOneGetOneFree(PizzaOrder order)
        {
            var pizzas = order.Pizzas;
            if (pizzas.Count < 2)
            {
                return 0m;
            }
            return pizzas.Min(p => p.Price);
        }
        public decimal FivePercentOffMoreThanFiftyDollars(PizzaOrder order)
        {
            decimal nonDiscounted = order.Pizzas.Sum(p => p.Price);
            return nonDiscounted >= 50 ? nonDiscounted * 0.05m : 0M;

        }
        public decimal FiveDollarsOffStuffedCrust(PizzaOrder order)
        {
            return order.Pizzas.Sum(p => p.Crust == Crust.Stuffed ? 5m : 0m);
        }
    }

    class PizzaOrderingSystemMethod
    {
        private readonly DiscountPoliciesMethods _discountPoliciesMethods;
        public PizzaOrderingSystemMethod()
        {
            _discountPoliciesMethods = new DiscountPoliciesMethods();
        }

        public decimal ComputePrice(PizzaOrder order)
        {
            decimal total = order.Pizzas.Sum(p => p.Price);

            decimal[] discounts = new[] {
            _discountPoliciesMethods.BuyOneGetOneFree(order),
            _discountPoliciesMethods.FivePercentOffMoreThanFiftyDollars(order),
            _discountPoliciesMethods.FiveDollarsOffStuffedCrust(order),
        };

            decimal bestDiscount = discounts.Max(discount => discount);
            total = total - bestDiscount;
            return total;
        }
    }

    public class PizzaOrder
    {
        private List<Pizza> pizzas;

        public List<Pizza> Pizzas
        {
            get
            {
                return pizzas;
            }
            set
            {
                pizzas = value;
            }
        }

    }

    public class Pizza
    {
        private int price;
        private Crust crust;

        public Pizza(int _price, Crust _crust)
        {
            price = _price;
            crust = _crust;
        }

        public int Price 
        {
            get
            {
                return price;
            } 
            set
            {
                price = value;
            }
        }

        public Crust Crust 
        {
            get
            {
                return crust;
            }
            set
            {
                crust = value;
            }
        }
    }

    public enum Crust
    {
        Stuffed = 0
    }

    
}
