﻿using System;

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
            Console.WriteLine("");
            //Admin class

            Admin admin=new Admin("Admin");
            Console.WriteLine(admin.GetDesignation());
            //  admin.SetName();
            //  admin.SetId();
            //  admin.SetContactNumber();
            //  admin.LendBooks();
            
            //  Console.WriteLine("Admin ID is: {0} " , admin.GetId);
            //  Console.WriteLine("Admin Name is: {0} " , admin.GetName);
            //  Console.WriteLine("Admin Contact Number is: {0} " , admin.GetContactNumber);

            //  //Patron class

            //   Patron patron=new Patron("Patron");
           //  Console.WriteLine(admin.GetDesignation());
            //    patron.SetName();
            //  patron.SetId();
            //  patron.SetContactNumber();

            //  Console.WriteLine("Patron ID is: {0} " , patron.GetId);
            //  Console.WriteLine("Patron Name is: {0} " , patron.GetName);
            //  Console.WriteLine("Patron Contact Number is: {0} " , patron.GetContactNumber);


            Console.ReadKey();
        }
    }
}
