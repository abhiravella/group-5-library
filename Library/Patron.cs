using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Patron:Person
    {
        private  List<currentBookDetails> currentbooks = new List<currentBookDetails>();
        public const int maxbooklimit=6;
        public const int timePeriod = 15;
        public DateTime currentDate=DateTime.Now;

        public Patron(string value):base(value)
        {
            
        }
        /* For adding two parameters at a time to list.   */

        private class currentBookDetails
        {
            public int bookId { get; set; }
            public DateTime issuedDay  { get; set; }
        }

         /*   Returns the bookcount that patron holds before   */

        public int CurrentCount()
        {
            return currentbooks.Count;
        }

         // Adding books to currentbooks bookId,Issuedate
        public void AddBooks(int BookId, DateTime IssueDate)
        {
            foreach (var i in currentbooks)
            {
                currentbooks.Add(new currentBookDetails { bookId = BookId, issuedDay = IssueDate });
            }
        }
        
         /*
         *  Check return true or false
         *  current date should be less than IssueDate+15
         *  Add function in Datetime
         */

        public void CheckDueDate(DateTime IssueDate)
        {
           if( currentDate<IssueDate.AddDays(timePeriod))
           {
                Console.WriteLine("No Dues. Can choose some books.");
           }
           else
           {
                Console.WriteLine("Need to return books.");
           }
        }
    }
}
