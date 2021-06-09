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
     * Type safety means that the compiler will validate types while compiling, and throw an error 
     * if you try to assign the wrong type to a variable.
     * 
     * String one = 1; //Error
     * 
     * int foo = "bar"; //Error
     
     */
    class Program
    {
        //Declaration
        public delegate void addnum(int a, int b);
        public delegate void subnum(int a, int b);
        static void Main(string[] args)
        {
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
