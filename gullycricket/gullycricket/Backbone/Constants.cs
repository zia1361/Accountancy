using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace gullycricket.Model_Classes
{
    [Serializable]
    public class Constants
    {
        [Serializable]
        public enum MesageType
        {
            Error = 1,
            Warning = 2,
            Info = 3,
            Success = 4
        }

        

        [Serializable]
        public enum UserType
        {
            Admin = 1,
            Individual = 2,
            Agent = 3,
            Company = 4,
            IndividualAndAgent = 5
        }

       



       

        
    }
}
