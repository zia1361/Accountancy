using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gullycricket.Model_Classes
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int UserTypeId { get; set; }
        public string UserTypeName { get; set; }
        public string ProfileImageURL { get; set; }
        public DateTime RegisteredOnDate { get; set; }
        public string RegisteredOnDateString { get; set; }
        public bool IsVerified { get; set; }
        public string PlayerId { get; set; }
        public int PlayerTypeId { get; set; }
        public string PlayerTypeName { get; set; }
    }
}