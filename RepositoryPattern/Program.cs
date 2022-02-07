using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    /*
     * The repository and unit of work patterns are intended to create an abstraction layer between the data access layer and the 
     * business logic layer of an application. Implementing these patterns can help insulate your application from changes in the 
     * data store and can facilitate automated unit testing or test-driven development (TDD).
     * 
     * The Repository pattern is often used when an application performs data access operations. These operations can be on a database, 
     * Web Service or file storage. The repository encapsulates These operations so that it doesn’t matter to the business logic where 
     * the operations are performed. For example, the business logic performs the method GetAllCustomers() and expects to get all 
     * available customers. The application doesn’t care whether they are loaded from a database or web service.
     * 
     * Unit of Work is referred to as a single transaction that involves multiple operations of insert/update/delete and so on kinds. 
     * To say it in simple words, it means that for a specific user action (say registration on a website), all the transactions like 
     * insert/update/delete and so on are done in one single transaction, rather then doing multiple database transactions. This means,
     * one unit of work here involves insert/update/delete operations, all in one single transaction.
     * 
     */
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
