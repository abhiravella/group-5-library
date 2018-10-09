using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    //A list to store the books
    class ListofBooks
    {
        private List<ListofBooks> books = new List<ListofBooks>();
        public void AddBook(string booktitle, string bookauthor, string bookcategory, int bookpublishyear)
        {
            books.Add(new Books(booktitle, bookauthor, bookcategory, bookpublishyear));
        }
        public string BookName { get; set; }
        public string Name { get; set; }
    }
}

    
