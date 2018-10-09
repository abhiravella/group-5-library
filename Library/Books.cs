using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Books : ListofBooks
    {
        public string Title
        {
            get; set;
        }
        public string Author
        {
            get; set;
        }
        public string Genre
        {
        get; set;
        }
        public int Pubyear
        {
            get; set;
        }

        public bool available = true;
        public Books(string title, string author, string category, int publishyear)
        {
            Title = title;
            Author = author;
            Genre = category;
            Pubyear = publishyear;
        }
    }
}
