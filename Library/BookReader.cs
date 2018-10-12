﻿using System;
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
        public static void Add(int bookId,string bookName, string bookAuthor, string bookGenere, int bookYear, int bookavailable)
        {
            //Created a line to capture all book info delimited by commas
            string line = Environment.NewLine +bookId+","+ bookName + "," + bookAuthor + "," + bookGenere + "," + bookYear + "," + bookavailable;
            //Used the StreamWriter to find and write to the file not delete "append "true"
            using (System.IO.StreamWriter file =
             new System.IO.StreamWriter(@"Resources/Books.txt", true))
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
            int bookId = 0;
            foreach (var line in lines) 
            {
                //Create an Array to read the string in the line of the file
                string[] _b = new string[6];
                //Split to give text on each side of comma
                _b = line.Split(',');
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
    }
}