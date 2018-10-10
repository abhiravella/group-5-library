using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {

            #region userInterface
            Console.WriteLine("Try Help for available commands or Exit to quit application");
            var userInput = Console.ReadLine();
            while (true)
            {
                if (userInput.Equals("Exit"))
                {
                    break;
                }
                else
                {
                    if (userInput.Contains("Help")) {
                        if (userInput.Contains("-") && userInput.Split('-').Length == 2)
                        {
                            var userCommand = userInput.Split('-')[1];
                            if (userCommand.Equals("Search"))
                            {
                                Console.WriteLine("Command: Search");
                                Console.WriteLine("Helps user search the library based on his criteria.\n" +
                                    "The following are the options for this command\n" +
                                    "-n name of the book\n" +
                                    "-a author name of the book\n" +
                                    "-g genere of the book\n" +
                                    "-y published year of the book\n" +
                                    "-a availability of the book\n");
                            }
                            else if (userCommand.Equals("Current"))
                            {
                                Console.WriteLine("Command : Current");
                                Console.WriteLine("Retrieves the current books held by the patron. This doesn't have any options");
                            }
                            else if (userCommand.Equals("History"))
                            {
                                Console.WriteLine("Command : History");
                                Console.WriteLine("Retrieves the patrons history of borrowing books.");
                            }
                            else if (userCommand.Equals("Add"))
                            {
                                Console.WriteLine("Command :  Add");                                
                                Console.WriteLine("Adds new book to the library.\n" +
                                    "The following are the options for this command\n" +
                                    "-n name of the book\n" +
                                    "-a author name of the book\n" +
                                    "-g genere of the book\n" +
                                    "-y published year of the book\n" +
                                    "-a availability of the book\n");
                                Console.WriteLine("The command should be Add -n -a -g -y -a . If the one option doesn't have any value leave a space.");
                            }
                            else if (userCommand.Equals("Lend"))
                            {
                                Console.WriteLine("Command : Lend");
                                Console.WriteLine("Helps Admin in lending a book to Patron.\n" +
                                    "The following are the options for this command\n" +
                                    "-bi ID of the book being lent\n" +
                                    "-pi ID of the patron to whom book is being lent\n" +
                                    "The commmand should be Lend -bi -pi \n");
                            }
                            else if (userCommand.Equals("Audit"))
                            {
                                Console.WriteLine("Command : Audit");
                                Console.WriteLine("Helps Admin in pulling all the records of books that are past due.");
                            }
                            else {
                                Console.WriteLine("Couldn't find the command '{0}'.",userCommand);
                                Console.WriteLine("The commands available for Patron\n\t" +
                                    "Search [options]   ----- Searches for books with given name\n\t" +
                                    "Current [options]  ----- Returns the books currently held by the user\n\t" +
                                    "History [options]  ----- Returns the list of books borrowed by the Patron\n" +
                                    "The commands available for Admin\n\t" +
                                    "Add [options]   -----  Adds a new book to the list\n\t" +
                                    "Lend [options]  -----  Lends the given book to the Patron\n\t" +
                                    "Audit [options] -----  Audits the books lent to all Patrons\n\t" +
                                    "Search [options]   ----- Searches for books with given name");
                                Console.WriteLine("Help -command for more details");
                            }
                        }
                        else {
                            Console.WriteLine("Couldn't find the command '{0}'.", userInput);
                            Console.WriteLine("The commands available for Patron\n\t" +
                                "Search [options]   ----- Searches for books with given name\n\t" +
                                "Current [options]  ----- Returns the books currently held by the user\n\t" +
                                "History [options]  ----- Returns the list of books borrowed by the Patron\n" +
                                "The commands available for Admin\n\t" +
                                "Add [options]   -----  Adds a new book to the list\n\t" +
                                "Lend [options]  -----  Lends the given book to the Patron\n\t" +
                                "Audit [options] -----  Audits the books lent to all Patrons\n\t" +
                                "Search [options]   ----- Searches for books with given name");
                            Console.WriteLine("Help -command for more details");
                        }
                    }
                    else if (userInput.Contains("Search")) {
                    } else if (userInput.Contains("Current")) {
                    } else if (userInput.Contains("History")) {
                    } else if (userInput.Contains("Add")) {
                    } else if (userInput.Contains("Lend")) {
                    } else if (userInput.Contains("Audit")) {
                    }
                    else { 
                            Console.WriteLine("Couldn't find the command '{0}'.",userInput);
                            Console.WriteLine("The commands available for Patron\n\t" +
                                 "Search [options]   ----- Searches for books with given name\n\t" +
                                 "Current [options]  ----- Returns the books currently held by the user\n\t" +
                                 "History [options]  ----- Returns the list of books lent by the Patron\n" +
                                 "The commands available for Admin\n\t" +
                                 "Add [options]   -----  Adds a new book to the list\n\t" +
                                 "Lend [options]  -----  Lends the given book to the Patron\n\t" +
                                 "Audit [options] -----  Audits the books lent to all Patrons");                            
                    }
                    userInput = Console.ReadLine();
                }
            }
            #endregion
            Console.ReadKey();
        }
    }
}
