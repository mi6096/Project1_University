using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class LoginValidation
    {
        private string username;
        private string password;
        private string errorLog;
        public static UserRoles currentUserRole
        {
            get; private set;
        }
        public LoginValidation(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public bool ValidateUserInput(ref User u)
        {
            currentUserRole = (UserRoles)u.roleId;
            
            bool isEmptyUserName = this.username.Equals(String.Empty);
            if(isEmptyUserName || this.username.Length < 5)
            {
                this.errorLog = "The username must be at least 5 symbols long.";
                return false;
            }
            bool isEmptyPassword = this.password.Equals(String.Empty);
            if(isEmptyPassword || this.password.Length < 5)
            {
                this.errorLog = "The password must be at least 5 symbols long.";
                return false;
            }

            u = UserData.IsUserPassCorrect(u);
            if(u == null)
            {
                this.errorLog = "The username and password are different.";
                currentUserRole = UserRoles.ANONYMOUS;
                return false;
            }
            currentUserRole = (UserRoles)u.roleId;
            return true;
        }
    }
}
