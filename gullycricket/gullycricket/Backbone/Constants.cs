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
            Player = 1,
            Organizer = 2
        }

       



       

        
    }
}
