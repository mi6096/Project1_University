using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {
        //public static User[] TestUsers
        public static List<User> TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        private static List<User> _testUsers;

        private static void ResetTestUserData()
        {
            string username = "Mihail";
            string password = "qwerty";
            string facNumber = "121215064";
            int roleId = 0;

            // Create new user
            _testUsers = new List<User>();
            for (int i = 0; i < 4; i++)
            {
                _testUsers.Add(new User());

                _testUsers.ElementAt(i).username = username + i;
                _testUsers.ElementAt(i).password = password + i;
                _testUsers.ElementAt(i).facNumber = facNumber + i;
                _testUsers.ElementAt(i).Created = DateTime.Now;
                _testUsers.ElementAt(i).Expired = DateTime.MaxValue;

                // set 1 Administrator
                if (i == 0)
                {
                    _testUsers.ElementAt(i).roleId = 1;
                }
                // set 2 Students
                else
                {
                    _testUsers.ElementAt(i).roleId = 4;
                }
            }
        }

        public static User IsUserPassCorrect(User user)
        {
            User searchedUser = TestUsers.FirstOrDefault(u => u.username == user.username && u.password == user.password);

            if (searchedUser != null)
            {
                return searchedUser;
            }
            return null;
        }

        public static void  SetUserActiveTo(int userId)
        {
            foreach (User checkUser in TestUsers)
            {
                User user = TestUsers.ElementAt(userId);
                if (user.username == checkUser.username)
                {
                    Console.WriteLine("Enter new date: ");
                    string strDate = Console.ReadLine();
                    DateTime d = Convert.ToDateTime(strDate);
                    DateTime newExpiredDate = (DateTime)d;
                }
                Logger.LogActivity("Change expired date on user " + user.username);
            }
        }

        public static void AssignUserRole(int userId)
        {
            foreach (User checkUser in TestUsers)
            {
                User user = TestUsers.ElementAt(userId);
                if (user.username == checkUser.username)
                {
                    Console.WriteLine("Enter new role: ");
                    string strRole = Console.ReadLine();
                    int s = Convert.ToInt16(strRole);
                    UserRoles newRole = (UserRoles)s;
                }
                Logger.LogActivity("Change role on user " + user.username);
            }
        }
        static public Dictionary<string, int> AllUsersUsernames()
        {
            Dictionary<string, int> usernames = new Dictionary<string, int>();
            for (int i = 0; i < TestUsers.Count; i++)
            {
                usernames.Add(TestUsers[i].username, i);
            }
            return usernames;
        }
    }
}
