using gullycricket.Model_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gullycricket.Backbone
{
    public class BasePage : System.Web.UI.Page
    {
        private AuthenticationModel _loginInfo = null;
        protected AuthenticationModel LoginInfo
        {
            get
            {
                if (_loginInfo == null)
                {
                    _loginInfo = SessionService.GetCurrentUser();
                }

                return _loginInfo;
            }
        }
        public BasePage()
        {
            this.PreInit += BasePage_PreInit;
            this.Init += BasePage_Init;
        }

        void BasePage_Init(object sender, EventArgs e)
        {
            // authentication checks if user is logged in or not
            var isLoggedIn = false;


            var loginInfo = this.LoginInfo;

            if (loginInfo.oUser != null)
            {
                isLoggedIn = true;
            }
            else
            {
                isLoggedIn = false;
            }


            if (isLoggedIn == false)
            {
                Response.Redirect("~/Signin.aspx");
            }
            else
            {
               
            }
        }



        void BasePage_PreInit(object sender, EventArgs e)
        {

        }
    }
}