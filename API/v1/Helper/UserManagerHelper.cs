using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Helper
{
    public class UserManagerHelper
    {

        public static string GetUserToken()
        {
            return HttpContext.Current.User.PrimarySid();
        }
    }
}