using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Patron:Person
    {
            public  List<String> currentbooks = new List<String>();
            public const int maxbooklimit=6;
            private int patronbookcount;
            

            public Patron(string value)
            {
            
            }
       /*   Returns the bookcount that patron holds before   */

        public static int CurrentCount()
        {
            return patronbookcount;
        }

        
            
       
    }
}
