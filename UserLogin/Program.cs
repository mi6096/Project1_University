using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            Console.Write("Enter date: ");
            string strdate = Console.ReadLine();
            DateTime date = Convert.ToDateTime(strdate);

            LoginValidation validator = new LoginValidation(username, password, ActionOnError);

            User user = new User();
            user.username = username;
            user.password = password;

            if (validator.ValidateUserInput(ref user))
            {
                Console.WriteLine("Data for user: Username - {0}, Password - {1}, Fac. Number: {2}, role: {3}, time: {4}, expired: {5}",
                    user.username, user.password, user.facNumber, LoginValidation.currentUserRoles, user.Created, user.Expired);
                if(user.roleId == 1){
                    AdminOptions(user);
                }
            }
            else
            {
                Console.WriteLine("ERROR: {0}", validator.errorException);
                Console.WriteLine("User role: {0}", LoginValidation.currentUserRoles);
            }
        }

        public static void AdminOptions(User user)
        {
                Console.WriteLine("Choose option:");
                Console.WriteLine("0: Exit");
                Console.WriteLine("1: Change the role of user");
                Console.WriteLine("2: Change expired date of user");
                Console.WriteLine("3: Show all users");
                Console.WriteLine("4: Show activity log");
                string userinput = Console.ReadLine();
                int option = Convert.ToInt32(userinput);
                string UserName = user.username;
                Dictionary<string, int> allusers = UserData.AllUsersUsernames();
                switch (option)
                {
                    case 0:
                        break;
                    case 1:
                        UserData.AssignUserRole(allusers[UserName]);
                        break;
                    case 2:
                        UserData.SetUserActiveTo(allusers[UserName]);
                        break;
                    case 3:
                        UserData.AllUsersUsernames();
                        break;
                    case 4:
                        GetUserActivitiesWithFilter();
                        break;
                    default:
                        Console.WriteLine("No such method");
                        break;
                }
        }
        private static void ShowAllUserNames()
        {
            Dictionary<string, int> usernames = UserData.AllUsersUsernames();

            foreach (KeyValuePair<string, int> userName in usernames)
            {
                Console.WriteLine("Username: {0} with id: {1}", userName.Key, userName.Value);
            }
        }

        public static void ActionOnError(string errorMessage)
        {
            Console.WriteLine("!!! " + errorMessage + " !!!");
        }

        private static void GetUserActivitiesWithFilter()
        {
            Console.Write("Enter filter word: ");
            string filter = Console.ReadLine();
            Logger.GetCurrentSessionActivies(filter);
        }

    }
}
