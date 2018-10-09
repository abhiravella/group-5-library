using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {

            #region booksDebug
            //Books bk = new Books();
            //bk.AddBook("Clash of Kings", "George R.R Martin", "Fantasy", 2005, 6);
            //bk.AddBook("Dance of Ice and Fire", "George R.R Martin", "Fantasy", 2011, 5);
            //bk.AddBook("Game of Thrones", "George R.R Martin", "Fantasy", 1994, 11);
            //bk.AddBook("Winds of Winter", "George R.R Martin", "Fantasy", 2019, 25);
            //bk.AddBook("Half Blood Prince", "J.K Rowling", "Fantasy", 2004, 8);
            //bk.AddBook("Deathly Hallows", "J.K Rowling", "Fantasy", 2007, 4);
            //bk.AddBook("Prisoner Of Askabahen", "J.K Rowling", "Fantasy", 2005, 8);
            //bk.AddBook("Goblet Of Fire", "J.K Rowling", "Fantasy", 20011, 5);
            //Console.WriteLine("Search for Name");
            //bk.SearchBooks("of", 1);
            //Console.WriteLine("Search for Author");
            //bk.SearchBooks("Martin", 2);
            //Console.WriteLine("Search for Year");
            //bk.SearchBooks("2005", 4);
            //Console.WriteLine("Search for Genere");
            //bk.SearchBooks("Fantasy", 3);
            #endregion
            #region userInterface
            var userInput = Console.ReadLine();
            switch (userInput)
            {
                case "Help":
                    if (userInput.Contains("-") && userInput.Split('-').Length > 1)
                    {
                        var userCommand = userInput[1];
                        switch (userCommand)
                        {
                            case ""
                        }
                    }
                    else
                    {
                        Console.WriteLine("The commands available for Patron\n\t" +
                        "Search [options]   ----- Searches for books with given name\n\tCurrent [options]  ----- Returns the books currently held by the user\n\tHistory [options]  ----- Returns the list of books lent by the Patron\n" +
                        "The commands available for Admin\n\t" +
                        "Add [options]   -----  Adds a new book to the list\n\tLend [options]  -----  Lends the given book to the Patron\n\tAudit [options] -----  Audits the books lent to all Patrons");
                        Console.WriteLine("Help -command for more details");
                    }
                    break;
                case "Search":
                    break;
                case "Current":
                    break;
                case "History":
                    break;
                case "Add":
                    break;
                case "Lend":
                    break;
                case "Audit":
                    break;
                default:
                    Console.WriteLine("The command doesn't exist");
                    Console.WriteLine("The commands available for Patron\n\t" +
                         "Search [options]   ----- Searches for books with given name\n\tCurrent [options]  ----- Returns the books currently held by the user\n\tHistory [options]  ----- Returns the list of books lent by the Patron\n" +
                         "The commands available for Admin\n\t" +
                         "Add [options]   -----  Adds a new book to the list\n\tLend [options]  -----  Lends the given book to the Patron\n\tAudit [options] -----  Audits the books lent to all Patrons");
                    break;
            }
                #endregion

            Console.ReadKey();
        }
    }
}
