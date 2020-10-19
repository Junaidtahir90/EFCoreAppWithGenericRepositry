using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    public class Enums
    {
        // Day enum represents number of days in a week  
       public enum Days { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };
        // Month enum represents months in a year  
        public enum Months : byte { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };
        // Colors   
        public enum Colors { Yellow, Orage, Red, Green, Blue, Purple, Black };
        public enum RGB { Red = 2, Green = 4, Blue = 6 };
    }
}
