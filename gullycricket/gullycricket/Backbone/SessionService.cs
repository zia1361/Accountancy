using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace gullycricket.Model_Classes
{
    public static class SessionService
    {
        public enum Keys
        {
            AuthenticationInfo ,
            ApplicationMessage
        }


        public static AuthenticationModel GetCurrentUser()
        {
            var authenticationModel = SessionService.Get<AuthenticationModel>(SessionService.Keys.AuthenticationInfo);

            // we donot want to return null object here,
            return authenticationModel ?? new AuthenticationModel();
        }



        public static T Get<T>(Keys key)
        {
            var context = HttpContext.Current;
            if (context != null)
            {
                var session = context.Session;
                if (session != null)
                {
                    return (T)session[key.ToString()];
                }
            }

            return default(T);
        }

        public static bool Save(Keys key, object item)
        {
            return Save<object>(key, item);
        }

        public static bool Save<T>(Keys key, T item)
        {
            var done = false;
            var context = HttpContext.Current;
            if (context != null)
            {
                var session = context.Session;
                if (session != null)
                {
                    session[key.ToString()] = item;
                    done = true;
                }
            }

            return done;
        }

        public static bool Remove(Keys key)
        {
            return SessionService.Save<object>(key, null);
        }
    }
}
