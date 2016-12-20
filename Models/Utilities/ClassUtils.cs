using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITC.SeedBank.Tool.Utilities
{
    public static class ClassUtils
    {
       

        internal static bool ValidateLoginFields(string userName, string password)
        {
            if (ValidateUserName(userName))
            {
                if (ValidatePassword(password))
                {
                    return true;
                }
            }
            return false;
        }


        internal static bool ValidateUserName(string userName)
        {
            //do logic
            if (userName.Length > 0)
            {
                return true;
            }
         
            return false;
        }

        internal static bool ValidatePassword(string password)
        {
            //do logic
            if (password.Length > 0)
            {
                return true;
            }
            return false;
        }
    }
}
