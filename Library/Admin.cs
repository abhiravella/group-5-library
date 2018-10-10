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

        public Admin(string value)
            {
            
            }

        private GetDesignation(string value)
            {
            
            }

         /*    Updates count of books after lending books to patron    */

        private static void updateCount()
        {
            bookCount--;
        }

      
        public void LendBooks(string bookId, int patronId)
        {
                        
            bookid.Add(bookId);
            patrontid.Add(patronId);
            dateTime=DateTime.Now();
            datetime.Add(dateTime);

            return;
        }
        

        public void AuditBooks()
        {
            DueDate();
        }
        public void DueDate(DateTime dateTime )
        {

        return;      
        }

        string var=new string();
        var=Books.AddBooks(string bookname, string author,string bookgenere);




        
    }
}
