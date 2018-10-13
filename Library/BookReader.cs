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
        // Updates the books list to reflect current application state.
        public static void Add(Books book, string filename)
        {        
                var CurrentBook = book.GetAll();            
                //Created a line to capture all book info delimited by commas
                string line = CurrentBook;
                //Used the StreamWriter to find and write to the file not delete "append "true"
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(filename, false))
                {
                    //Write the line to the file
                    file.WriteLine(line);
                }            
        }
        // Saves the current patrons state 
        public static void Add(string addString, string filename)
        {
            //Created a line to capture all book info delimited by commas
            string line = addString;
            //Used the StreamWriter to find and write to the file not delete "append "true"
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(filename, false))
            {
                //Write the line to the file
                file.WriteLine(line);
            }
        }
        // Return Books object updated with list of books
        public static Books BooksRead(string filename)
        {
            //Go look at Book Class and create a new book Object
            Books books = new Books();
            //declaring the variable lines and reading the Books.txt file
            var lines = File.ReadLines(filename);
            //Each time you read a line....
            int bookId = 0;
            foreach (var line in lines) 
            {
                if (String.IsNullOrEmpty(line) || String.IsNullOrWhiteSpace(line))
                    continue;
                //Create an Array to read the string in the line of the file
                string[] _b = new string[6];
                //Split to give text on each side of comma
                _b = line.Split('|');
                //Parsing bookyear and bookavailabe into intergers
                bookId = int.Parse(_b[0]);
                int bookyear = int.Parse(_b[4]);
                int bookavailable = int.Parse(_b[5]);
                //Adding the book information to book Object
                books.PrepareBooks(bookId, _b[1], _b[2], _b[3], bookyear, bookavailable);
            }
            books.bookCount = bookId;
            //Returns all the lines in file in correct format
            return books;
        }
        // Reads the Users details from the file
        public static PersonsRead PersonsRead(string filename)
        {
            //Go look at PatronRead Class and create a new PatronRead Object
            PersonsRead pread = new PersonsRead();
            //declaring the variable lines and reading the Creds.txt file
            var lines = File.ReadLines(filename);
            //Each time you read a line....            
            foreach (var line in lines)
            {
                if (String.IsNullOrEmpty(line) || String.IsNullOrWhiteSpace(line))
                    continue;
                //Create an Array to read the string in the line of the file
                string[] _b = new string[4];
                //Split to give text on each side of comma
                _b = line.Split(',');
                // Depending on designations the objects are stored in PatronRead
                if (_b[3].Equals("Admin"))
                {
                    pread.adminList.Add(new Admin("Admin",_b[2],int.Parse(_b[0])));
                    pread.userId.Add(_b[0]);
                    pread.password.Add(_b[1]);
                    pread.designation.Add(_b[3]);
                }else if (_b[3].Equals("Patron"))
                {
                    pread.patronList.Add(new Patron("Patron", _b[2], int.Parse(_b[0])));
                    pread.userId.Add(_b[0]);
                    pread.password.Add(_b[1]);
                    pread.designation.Add(_b[3]);
                }
            }
            //Returns all the lines in file in correct format
            return pread;
        }
        // Reads the current patrons state from the file
        public static List<String> PatronData(string filename)
        {
            //Go look at PatronRead Class and create a new PatronRead Object
            List<String> patronData = new List<string>();
            //declaring the variable lines and reading the Creds.txt file
            var lines = File.ReadLines(filename);
            //Each time you read a line....            
            foreach (var line in lines)
            {
                if (String.IsNullOrEmpty(line) || String.IsNullOrWhiteSpace(line))
                    continue;
                patronData.Add(line);                
            }
            return patronData;
        }
    }
}
