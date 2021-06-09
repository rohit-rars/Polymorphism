using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefandOut
{
    /*
     * Ref and out keywords in C# are used to pass arguments within a method or function.
     * Both indicate that an argument/parameter is passed by reference. By default
     * parameters are passed to a method by value. By using these keywords (ref and out)
     * we can pass a parameter by reference.
     * 
     * When we use REF, data can be passed bi-directionally.
     * When we use OUT data is passed only in a unidirectional way (from the called method to the caller method).
     * 
     * The parameter or argument must be initialized first before it is passed to ref.
     * It is not compulsory to initialize a parameter or argument before it is passed to an out.
     * 
     * It is not required to assign or initialize the value of a parameter (which is passed by ref) 
          before returning to the calling method.
     * A called method is required to assign or initialize a value of a parameter (which is
           passed to an out) before returning to the calling method.
     */
    class Program
    {
        static void Main(string[] args)
        {
        }

        public int CheckOut(out int test)
        {
            test = 0;

            return 0;
        }
    }
}
