using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Admin : Person
    {
        private List<String> bookid = new List<String>();
        private List<int> patrontid = new List<int>();
        private List<DateTime> datetime = new List<DateTime>();

        public Admin(string value) : base(value)
        {

        }
        /*    Updates count of books after lending books to patron    */
        public string LendBooks(int bookId, ref Patron patronObject,ref Books book)
        {
            if (patronObject.CheckDueDate() == true)
            {
                if(book.CheckBookAvailability(bookId))              
                {
                    string currentRecord = "";
                    currentRecord += "" + bookId;
                    currentRecord += "" + patronObject.GetId();                    
                    currentRecord += "" + DateTime.Today.ToString("D");
                    patronObject.AddBooks(bookId, DateTime.Today);
                    book.UpdateAvailability(bookId);
                    return currentRecord;
                }
                else
                {
                    Console.WriteLine("Requested Book is not available.");
                    return " ";
                }
            }
            else
            {
                Console.WriteLine("There books that are Due.");
                return " ";
            }
            
        }

    }
}