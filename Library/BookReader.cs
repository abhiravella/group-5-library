using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class BookReader
    {
        //Static to be accessed to Add book info
        public static void Add(string bookName, string bookAuthor, string bookGenere, int bookYear, int bookavailable)
        {
            //Created a line to capture all book info delimited by commas
            string line = Environment.NewLine + bookName + "," + bookAuthor + "," + bookGenere + "," + bookYear + "," + bookavailable;
            //Used the StreamWriter to find and write to the file not delete "append "true"
            using (System.IO.StreamWriter file =
             new System.IO.StreamWriter(@"Books.txt", true))
            {
                //Write the line to the file
                file.WriteLine(line);
            }
        }
        //Return list of books from file
        public static Books Read(string filename)
        {
            //Go look at Book Class and create a new book Object
            Books books = new Books();
            //declaring the variable lines and reading the Books.txt file
            var lines = File.ReadLines(filename);
            //Each time you read a line....
            foreach (var line in lines) 
            {
                //Create an Array to read the string in the line of the file
                string[] _b = new string[5];
                //Split to give text on each side of comma
                _b = line.Split(',');
                //Parsing bookyear and bookavailabe into intergers
                int bookyear = int.Parse(_b[3]);
                int bookavailable = int.Parse(_b[4]);
                //Adding the book information to book Object
                books.AddBook(_b[0], _b[1], _b[2], bookyear, bookavailable);
            }
            //Returns all the lines in file in correct format
            return books;
        }
    }
}
