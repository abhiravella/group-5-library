using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add Books to file
            BookReader.Add("bookName", "bookAuthor", "bookGenere", 1997, 1);
            //Read Books and save to variable books
            Books books = BookReader.Read("Books.txt");

        }
    }
}
