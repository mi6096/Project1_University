using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    static class UserData
    {
        public static User[] TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }
        private static User[] _testUsers;
        private static void ResetTestUserData()
        {
            string username = "Mihail";
            string password = "12345";
            string facNumber = "121215064";
            int roleId = 0;

            
            for (int i=0; i<_testUsers.Length; i++)
            {
                _testUsers = new User[3];
                _testUsers[i].username = username + i;
                _testUsers[i].password = password + i;
                _testUsers[i].facNumber = facNumber + i;
                if(i == 0)
                {
                    _testUsers[i].roleId = 1;
                }
                else
                {
                    _testUsers[i].roleId = 5;
                }
            }
        }
        
        public static User IsUserPassCorrect(User u)
        {
            for(int i=0; i<_testUsers.Length; i++)
            {
                if(u.username == _testUsers[i].username && u.password == _testUsers[i].password)
                {
                    return _testUsers[i];
                }
            }
            return null;
        }
       
    }
}
