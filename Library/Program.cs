using System;
using System.Collections.Generic;

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
            List<String> username = new List<String> {"abhiravilla","kim","Robert","smith","swapna"};
            List<String> password = new List<String> { "AZaz09$$", "AZaz09$$", "AZaz09$$", "AZaz09$$", "AZaz09$$" };
            List<String> designation = new List<String> { "Admin", "Patron", "Patron", "Admin", "Patron" };
            Books bk = new Books();
            Console.WriteLine("Enter your username and password");
            var usernameInput = Console.ReadLine();
            var passwordInput = Console.ReadLine();
            if (username.Contains(usernameInput))
            {
                if (password[username.IndexOf(usernameInput)].Equals(passwordInput))
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
                            if (userInput.Contains("Help"))
                            {
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
                                            "-v availability of the book\n");
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
                                            "The following are the required paramters for this command\n" +
                                            "-n name of the book\n" +
                                            "-a author name of the book\n" +
                                            "-g genere of the book\n" +
                                            "-y published year of the book\n" +
                                            "-v availability of the book\n");
                                        Console.WriteLine("The command should be Add -n -a -g -y -a . If the one option doesn't have any value leave a space.");
                                    }
                                    else if (userCommand.Equals("Lend"))
                                    {
                                        Console.WriteLine("Command : Lend");
                                        Console.WriteLine("Helps Admin in lending a book to Patron.\n" +
                                            "The following are the required paramters for this command\n" +
                                            "-bi ID of the book being lent\n" +
                                            "-pi ID of the patron to whom book is being lent\n" +
                                            "The commmand should be Lend -bi -pi \n");
                                    }
                                    else if (userCommand.Equals("Audit"))
                                    {
                                        Console.WriteLine("Command : Audit");
                                        Console.WriteLine("Helps Admin in pulling all the records of books that are past due.");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Couldn't find the command '{0}'.", userCommand);
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
                                else
                                {
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
                            else if (userInput.Contains("Search"))
                            {
                                if (usernameInput.Split('-').Length == 2)
                                {
                                    int sepCount = 2;
                                    string option = userInput.Split('-')[1];
                                    string[] optionValue = option.Split(new char[] { ' ' }, sepCount);
                                    switch (optionValue[0])
                                    {
                                        case "n":
                                            Console.WriteLine("Calling Search function with value {0} and code 1.",optionValue[1].Trim());
                                            //bk.SearchBooks(optionValue[1].Trim(),1);
                                            break;
                                        case "g":
                                            Console.WriteLine("Calling Search function with value {0} and code 3.", optionValue[1].Trim());
                                            //bk.SearchBooks(optionValue[1].Trim(),3);
                                            break;
                                        case "a":
                                            Console.WriteLine("Calling Search function with value {0} and code 2.", optionValue[1].Trim());
                                            //bk.SearchBooks(optionValue[1].Trim(),2);
                                            break;
                                        case "y":
                                            Console.WriteLine("Calling Search function with value {0} and code 4.", optionValue[1].Trim());
                                            //bk.SearchBooks(optionValue[1].Trim(),4);
                                            break;
                                        case "v":
                                            Console.WriteLine("Calling Search function with value {0} and code 5.", optionValue[1].Trim());
                                            //bk.SearchBooks(optionValue[1].Trim(),5);
                                            break;
                                        default:
                                            Console.WriteLine("Invalid Option. Try Help -Search for more information");
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Invalid number of options for command Search. Try Help -Search for more information");
                                }
                            }
                            else if (userInput.Contains("Current"))
                            {
                                if (designation[username.IndexOf(usernameInput)] == "Patron")
                                {
                                    Console.WriteLine("Calls the List of patron class and prints info of the books held by Patron");
                                }
                                else
                                {
                                    Console.WriteLine("Your account doesn't support this command");
                                }
                            }
                            else if (userInput.Contains("History"))
                            {
                                if (designation[username.IndexOf(usernameInput)] == "Patron")
                                {
                                    Console.WriteLine("Calls the History of Patron class and prints info of the books held by Patron");
                                }
                                else
                                {
                                    Console.WriteLine("Your account doesn't support this command");
                                }
                            }
                            else if (userInput.Contains("Add"))
                            {
                                if (designation[username.IndexOf(usernameInput)] == "Admin")
                                {
                                    if(userInput.Split('-').Length == 6)
                                    {
                                        var bookName = "";
                                        var bookAuthor = "";
                                        var bookGenere = "";
                                        var bookYear = "";
                                        var bookAvailable = "";
                                        var userInputOptions = userInput.Split('-');
                                        for (int i = 1; i < 6; i++)
                                        {
                                            switch (userInputOptions[i].Split(new char[] { ' ' }, 2)[0])
                                            {
                                                case "n":
                                                    bookName = userInputOptions[i].Split(new char[] { ' ' }, 2)[1].Trim();                                                    
                                                    break;
                                                case "g":
                                                    bookGenere = userInputOptions[i].Split(new char[] { ' ' }, 2)[1].Trim();
                                                    break;
                                                case "a":
                                                    bookAuthor = userInputOptions[i].Split(new char[] { ' ' }, 2)[1].Trim();
                                                    break;
                                                case "y":
                                                    bookYear = userInputOptions[i].Split(new char[] { ' ' }, 2)[1].Trim();
                                                    break;
                                                case "v":
                                                    bookAvailable = userInputOptions[i].Split(new char[] { ' ' }, 2)[1].Trim();
                                                    break;
                                                default:
                                                    break;
                                            }                                            
                                        }
                                        if(String.IsNullOrEmpty(bookName)|| String.IsNullOrEmpty(bookGenere) || String.IsNullOrEmpty(bookAuthor) || String.IsNullOrEmpty(bookYear) || String.IsNullOrEmpty(bookAvailable))
                                        {
                                            Console.WriteLine("Invalid options or command. Try Help -Add for more information");
                                        }
                                        else
                                        {
                                            Console.WriteLine("calling add function with values {0},{1},{2},{3},{4}",bookName,bookAuthor,bookGenere,bookYear,bookAvailable);
                                            //bk.AddBook(bookName,bookAuthor,bookGenere,bookYear,bookAvailable);
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid options or command. Try Help -Add for more information");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Your account doesn't support this command");
                                }
                            }
                            else if (userInput.Contains("Lend"))
                            {

                            }
                            else if (userInput.Contains("Audit"))
                            {
                                Console.WriteLine("Calling audit function of Admin class");
                            }
                            else
                            {
                                Console.WriteLine("Couldn't find the command '{0}'.", userInput);
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
                }
                else
                {
                    Console.WriteLine("Incorrect Username or Password");
                }
            }
            else
            {
                Console.WriteLine("Incorrect Username or Password");
            }
            Console.ReadKey();
        }
    }
}
