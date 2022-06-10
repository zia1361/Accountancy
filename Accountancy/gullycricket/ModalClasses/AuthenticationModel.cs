using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace gullycricket.Model_Classes
{
    [Serializable]
    public class CredentialModel
    {
        public String LoginId { get; set; }
        public String Password { get; set; }

        public Constants.UserType Type { get; set; }
    }

    [Serializable]
    [DataContract]
    public class AuthenticationModel
    {
        [DataMember]
        public bool Authenticated { get; set; }

        [DataMember]
        public Constants.UserType AccountType { get; set; }


        [DataMember]
        public UserInfo oUser { get; set; }

       
    }


    
}
