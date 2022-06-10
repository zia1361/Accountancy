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

        [Serializable]
        public enum ElementType
        {
            Asset = 1,
            Expense = 2,
            Liability = 3,
            Revenue = 4,
            Capital = 5
        }

        [Serializable]
        public enum DebitCreditType
        {
            Debit = 1,
            Credit = 2
        }




    }
}
