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

        public Patron(string value,String name,int id):base(value,name,id)
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
        public void AddBook(int BookId, DateTime IssueDate)
        {
             currentbooks.Add(new currentBookDetails { bookId = BookId, issuedDay = IssueDate });
        }

          
        public bool CheckDueDate()
        {

            bool flag =true;           
            foreach (var item in currentbooks)
            {
                if (currentDate <item.issuedDay.AddDays(timePeriod))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                    break;
                }
            }
                         
            return flag&&(CurrentCount()<maxbooklimit);
        }
        public List<string> Current()
        {
            List<string> temp = new List<string>() ;
            foreach(var i in currentbooks)
            {
                temp.Add("" + i.bookId + "," + i.issuedDay);
            }
            return temp;
        }
        public bool ReturnBook(int bookId)
        {
            var index = -1;
           for(int i =0; i<currentbooks.Count;i++ )
           {
                if (currentbooks[i].bookId == bookId)
                    index = i;
           }
           if(index != -1)
            {
                currentbooks.RemoveAt(index);
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public void AddBooks(string bookDetails)
        {
            var tempVar = bookDetails.Split('|');
            AddBook(int.Parse(tempVar[0].Trim()), DateTime.Parse(tempVar[1]));            
        }
    }
}
