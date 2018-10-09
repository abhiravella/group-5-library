using System;
using System.Collections.Generic;

namespace Library
{
    class Books
    {
        #region variable declaration
        private static int bookCount;
        private List<String> name = new List<String>();
        private List<String> author = new List<String>();
        private List<String> genere = new List<String>();
        private List<int> year = new List<int>();
        private List<int> id = new List<int>();
        private List<int> available = new List<int>();
        #endregion
        #region methods
        /*
         *  Returns number of Books in the Library
         */
        public static int getCount()
        {
            return bookCount;
        }
        /*
         *  Updates number of books when adding a new book
         */
        private static void updateCount()
        {
            bookCount++;
        }
        /*
         *  Adds a new book to the library. If one of the field is null pass it as empty string or null
         */
        public void AddBook(string bookName, string bookAuthor, string bookGenere, int bookYear, int bookavailable)
        {
            name.Add(bookName.ToUpper());
            author.Add(bookAuthor.ToUpper());
            genere.Add(bookGenere.ToUpper());
            year.Add(bookYear);
            Books.updateCount();
            id.Add(Books.bookCount);
            available.Add(bookavailable);
            return;
        }
        /*
         *  Searches the library based on the value given and field user wants. The values for field are given below
         *  Field value 
         *  1 = Name
         *  2 = Author
         *  3 = Genere
         *  4 = year
         *  5 = id   
         */
        public void SearchBooks(string searchValue, int field)
        {
            List<int> indexes = new List<int>();
            switch (field)
            {
                case 1:
                    indexes = SearchResult(searchValue.ToUpper(), name);
                    Display(indexes);
                    break;
                case 2:
                    indexes = SearchResult(searchValue.ToUpper(), author);
                    Display(indexes);
                    break;
                case 3:
                    indexes = SearchResult(searchValue.ToUpper(), genere);
                    Display(indexes);
                    break;
                case 4:
                    if (String.IsNullOrEmpty(searchValue) || String.IsNullOrWhiteSpace(searchValue))
                        return;
                    indexes = SearchResult(Convert.ToInt32(searchValue), year);
                    Display(indexes);
                    break;
                case 5:
                    if (String.IsNullOrEmpty(searchValue) || String.IsNullOrWhiteSpace(searchValue))
                        return;
                    indexes = SearchResult(Convert.ToInt32(searchValue), year);
                    Display(indexes);
                    break;
                default:
                    return;
            }
            return;
        }
        /*
         * SearchResult --- Overloaded method. It will search based on userinputs. If year or availability are search parameters then method with Integer parameters is used.
         */
        private List<int> SearchResult(string value, List<String> searchList)
        {
            List<int> resultIndex = new List<int>();
            for (int i = 0; i < searchList.Count; i++)
            {
                if (searchList[i].Contains(value))
                {
                    resultIndex.Add(i);
                }
            }
            return resultIndex;
        }
        private List<int> SearchResult(int value, List<int> searchList)
        {
            List<int> resultIndex = new List<int>();
            for (int i = 0; i < searchList.Count; i++)
            {
                if (searchList[i] == value)
                {
                    resultIndex.Add(i);
                }
            }
            return resultIndex;
        }
        /*
         *  Displays all the details of the book based on return value of SearchResult
         */
        private void Display(List<int> indexes)
        {
            if (indexes.Count == 0)
            {
                Console.WriteLine("Search didn't return anything");
            }
            else
            {
                var iterator = 1;
                foreach (var item in indexes)
                {
                    Console.WriteLine("Book {0}", iterator);
                    Console.WriteLine("ID:{4}\nName : {0}\nAuthor: {1}\nGenere: {2}\nYear: {3}\nAvailable Copies:{5}", name[item], genere[item], author[item], year[item], id[item], available[item]);
                    iterator++;
                }
            }
            return;
        }
        #endregion
    }
}
