using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Admin:Person 
    {
        private List<String> bookid = new List<String>();
        private List<int> patrontid = new List<int>();
        private List<DateTime> datetime = new List<DateTime>();
        private int bookcount;

        public Admin(string value):base(value)
        {
            
        }        

         /*    Updates count of books after lending books to patron    */             
        public string LendBooks(int bookId, int patronId)
        {

            // calling check method in patron class
            // calling checkBookAvailability in Books class

            bool checkBook = true;
            if (checkBook)
            {
                string currentRecord = "";
                currentRecord += "" + bookId;
                //    bookid.Add(bookId);
                currentRecord += "" + patronId;
                //patrontid.Add(patronId);
                currentRecord += "" + DateTime.Today.ToString("D");
                //datetime.Add(DateTime.Today);
                // Call Add method in patron class
                // Calling method in books to update the count
                Console.WriteLine("Calling update method in books");
                return currentRecord;
            }
            else
            {
                return " ";
            }
        }        
                
    }
}
