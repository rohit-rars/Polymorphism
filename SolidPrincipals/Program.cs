using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrincipals
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create book
            
            // Wait for user
            Console.ReadKey();
        }


        public abstract class Users
        {
            public List<string> allUsers = new List<string>();

            public List<string> AllUsers 
            { 
                get { return allUsers; } 
                set { allUsers = value; }
            }

            public abstract void ViewUsers();
        }

        public class AdminUsers : Users
        {
            public AdminUsers(List<string> adminUsers)
            {
                allUsers = adminUsers;
            }

            public override void ViewUsers()
            {
                foreach (string item in allUsers)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public class NonAdminUsers : Users
        {
            public NonAdminUsers(List<string> nonAdminUsers)
            {
                allUsers = nonAdminUsers;
            }

            public override void ViewUsers()
            {
                foreach (string item in allUsers)
                {
                    Console.WriteLine(item);
                }
            }
        }

        public abstract class DecorateUsers : Users
        {
            public Users _users;

            public DecorateUsers(Users users)
            {
                _users = users;
            }

            public override void ViewUsers()
            {
                _users.ViewUsers();
            }
        }

        public class UpdateUsers : DecorateUsers
        {
            protected readonly List<string> allUsers = new List<string>();

            public UpdateUsers(Users users) : base(users)
            {

            }

            public void DeleteUsers(string userName)
            {
                if (allUsers.Contains(userName))
                    allUsers.Remove(userName);
            }

            public void AddUsers(string userName)
            {
                if (!allUsers.Contains(userName))
                    allUsers.Remove(userName);
            }

            public override void ViewUsers()
            {
                base.ViewUsers();
            }
        }
    }
}
