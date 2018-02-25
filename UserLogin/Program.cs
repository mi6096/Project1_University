using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            LoginValidation object1 = new LoginValidation(username, password);
            User user = new User();
            user.username = username;
            user.password = password;

            switch (user.roleId)
            {
                case 1:
                    Console.WriteLine(UserRoles.ADMIN);
                    break;
                case 2:
                    Console.WriteLine(UserRoles.ANONYMOUS);
                    break;
                case 3:
                    Console.WriteLine(UserRoles.INSPECTOR);
                    break;
                case 4:
                    Console.WriteLine(UserRoles.PROFESSOR);
                    break;
                case 5:
                    Console.WriteLine(UserRoles.STUDENT);
                    break;
            }
        }
    }
}
