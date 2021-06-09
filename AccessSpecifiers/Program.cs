using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessSpecifiers
{
    class Program
    {
        /*
         private: limits the accessibility of a member to within the defined type, for example if a 
         variable or a functions is being created in a ClassA and declared as private then 
         another ClassB can't access that.
         
         public: has no limits, any members or types defined as public can be accessed within the class, 
         assembly even outside the assembly. Most DLLs are known to be produced by public class and members
         written in a .cs file.
         
         internal: internal plays an important role when you want your class members to be accessible within the
         assembly. An assembly is the produced .dll or .exe from your .NET Language code (C#). Hence, if you 
         have a C# project that has ClassA, ClassB and ClassC then any internal type and members will become 
         accessible across the classes with in the assembly.
         
         protected: plays a role only when inheritance is used. In other words any protected type or member 
         becomes accessible when a child is inherited by the parent. In other cases (when no inheritance) protected
         members and types are not visible.

         Protected methods can be called from derived classes. Private methods can't.
         
         Protected internal: is a combination of protected and internal both. A protected internal will be accessible
         within the assembly due to its internal flavor and also via inheritance due to its protected flavor.

        */

        class Test
        {
            protected void TestProtected()
            {
                Console.WriteLine("in protected method");
            }
        }

        class Test1 : Test
        {
            public void TestPublic()
            {
                TestProtected();
            }
        }

        static void Main(string[] args)
        {
            Test t1 = new Test();
            // t1.TestProtected(); Complier error: inaccessible due to protection level.
            Test1 t2 = new Test1();
            t2.TestPublic();
            // t2.TestProtected(); Complier error: inaccessible due to protection level.
            Console.ReadKey();
        }
    }
}
