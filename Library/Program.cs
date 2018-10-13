using System;
using System.Collections.Generic;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Books books = BookReader.BooksRead(@"Resources/Books.txt");
            // Reads the userIds, passwords and details of every user
            PersonsRead pread = BookReader.PersonsRead(@"Resources/Creds.txt");
            List<String> username = pread.userId;
            List<String> password = pread.password;
            List<String> designation = pread.designation;
            List<Patron> Patrons = pread.patronList;
            List<Admin> Admins = pread.adminList;
            List<String> patronData = BookReader.PatronData(@"Resources/patronsLend.txt");
            // Prepares the data for patrons to reflect previous application state
            foreach(var item in patronData)
            {
                var details = item.Split(new char[] { '|' }, 2);
                foreach(var patron in Patrons)
                {
                    if (patron.GetId() == int.Parse(details[0])){
                        patron.AddBooks(details[1]);
                    }
                }
            }
            // Current Patron or Admins position on object Lists
            var currentPatron = 0;
            var currentAdmin = 0;            
            var usernameInput = "";
            var passwordInput = "";
            var loginsuccessful = false;
            var tries = 0;

            while (loginsuccessful == false && tries < 3)
            {
                Console.WriteLine("Username:");
                usernameInput = Console.ReadLine();
                Console.WriteLine("Password:");
                passwordInput = Console.ReadLine();
                //Check to see if username in list
                if (username.Contains(usernameInput))
                {
                    //Check to see if password is correct for usename
                    if (password[username.IndexOf(usernameInput)].Equals(passwordInput))
                    {
                        loginsuccessful = true;

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
                //Incrementing tries
                tries++;
            }
            if (loginsuccessful == false)
            {
                Console.WriteLine("\nLogin Unsuccessful, Close Program and Retry!");
                Console.ReadLine();
            }

            // Checks if userId's and password match
            while (loginsuccessful)
            {
                // Finding the position of Patron or Admin
                if (designation[username.IndexOf(usernameInput)] == "Patron")
                    {
                        for(int i = 0; i < Patrons.Count; i++)
                        {
                            if (Patrons[i].GetId() == int.Parse(usernameInput))
                                currentPatron = i;
                        }
                    }else if (designation[username.IndexOf(usernameInput)] == "Admin")
                    {

                        for (int i = 0; i < Admins.Count; i++)
                        {
                            if (Admins[i].GetId() == int.Parse(usernameInput))
                                currentPatron = i;
                        }
                    }
                #region userInterface
                Console.WriteLine("\nType the word Help for available commands or Exit to leave the library");
                var userInput = Console.ReadLine();
                if (userInput.Equals("Exit"))
                {
                    // If Exiting Application saves the current state of all objects
                    BookReader.Add(books, @"Resources/Books.txt");
                    var patronLend = "";
                    for (int i = 0; i < Patrons.Count; i++)
                    {
                        if (i == Patrons.Count)
                        {
                            List<String> patronCurrent = Patrons[i].Current();
                            foreach (var item in patronCurrent)
                            {
                                patronLend += "" + Patrons[i].GetId() + "|" + item.Replace(',', '|');
                            }
                        }
                        else
                        {
                            List<String> patronCurrent = Patrons[i].Current();
                            foreach (var item in patronCurrent)
                            {
                                patronLend += "" + Patrons[i].GetId() + "|" + item.Replace(',', '|') + System.Environment.NewLine;
                            }
                        }
                        BookReader.Add(patronLend, @"Resources/patronsLend.txt");

                    }
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
                                Console.WriteLine("\nCommand: Search");
                                Console.WriteLine("Use any of the criteria below to search the library (ex: Search -a J.K Rowling).\n\t" +
                                    "-n name of the book\n\t" +
                                    "-a author name of the book\n\t" +
                                    "-g genere of the book\n\t" +
                                    "-y published year of the book\n\t" +
                                    "-i id of the book\n");
                            }
                            else if (userCommand.Equals("Current"))
                            {
                                Console.WriteLine("Command : Current");
                                Console.WriteLine("Retrieves the current books held by the Patron. No other criteria exist for this command.");
                            }
                            else if (userCommand.Equals("History"))
                            {
                                Console.WriteLine("Command : History");
                                Console.WriteLine("Retrieves the Patron's history of borrowing books. No other criteria exist for this command.");
                            }
                            else if (userCommand.Equals("Add"))
                            {
                                Console.WriteLine("Command :  Add");
                                Console.WriteLine("Use any of the criteria below to add a new book to the library (ex: Add -a J.K Rowling).\n\t" +                                                                        
                                    "-n name of the book\n\t" +
                                    "-a author name of the book\n\t" +
                                    "-g genere of the book\n\t" +
                                    "-y published year of the book\n\t" +
                                    "-v availability of the book\n");
                                Console.WriteLine("The command should be Add -n -a -g -y -a . If the one option doesn't have any value leave a space.");
                            }
                            else if (userCommand.Equals("Lend"))
                            {
                                Console.WriteLine("Command : Lend");
                                Console.WriteLine("Admin enters book ID and Patron ID when lending a book.\n\t" +
                                    "The following are the required paramters for this command\n\t" +
                                    "-bi ID of the book being lent\n\t" +
                                    "-pi ID of the patron to whom book is being lent\n\t" +
                                    "Enter the commmand as (ex: Lend -pi 1 -bi 5).\n");
                            }
                            else if (userCommand.Equals("Return"))
                            {
                                Console.WriteLine("Command : Return");
                                Console.WriteLine("Admin enters book ID and Patron ID when Patron is retuning a book.\n\t" +
                                    "The following are the required paramters for this command\n\t" +
                                    "-bi ID of the book being returned\n\t" +
                                    "-pi ID of the patron to who is returning a book\n\t" +
                                    "Enter the commmand as (ex: Return -pi 2 -bi 5).\n");
                            }
                            else if (userCommand.Equals("Audit"))
                            {
                                Console.WriteLine("Command : Audit");
                                Console.WriteLine("Allows Admin to pull a record of books that are past due.");
                            }
                            else
                            {
                                Console.WriteLine("Couldn't find the command '{0}'.", userCommand);
                                Console.WriteLine("\nThe commands available for Patron\n\t" +
                                    "Command Definitions:\n\t" +
                                    "Search  ----- Searches for books using given criteria\n\t" +
                                    "Current ----- Returns the books currently held by the user\n\t" +
                                    "History ----- Returns the list of books borrowed by the Patron\n" +
                                    "\nThe commands available for Admin\n\t" +
                                    "Add    -----  Adds a new book to the list\n\t" +
                                    "Lend   -----  Lends the given book to the Patron\n\t" +
                                    "Return -----  Return the given book to the Library\n\t" +
                                    "Audit  -----  Audits the books lent to all Patrons\n\t" +
                                    "Search -----  Searches for books using given criteria\n");
                                Console.WriteLine("Help -command for more details");
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nThe commands available for Patron's are:\n\t" +
                                "Command & Definitions:\n\t" +
                                "Search   ----- Searches for books using given criteria\n\t" +
                                "Current  ----- Returns the books currently held by the user\n\t" +
                                "History  ----- Returns the list of books borrowed by the Patron\n" +
                                "\nThe commands available for Admin's are:\n\t" +
                                "Add    -----  Adds a new book to the list\n\t" +
                                "Lend   -----  Lends the given book to the Patron\n\t" +
                                "Audit  -----  Audits the books lent to all Patrons\n\t" +
                                "Search ----- Searches for books using given criteria\n");
                            Console.WriteLine("Type the word Help -command (ex: Help -Search) for more details");
                        }
                    }
                    else if (userInput.Contains("Search"))
                    {
                        if (userInput.Split('-').Length == 2)
                        {
                            var sepCount = 2;
                            var option = userInput.Split('-')[1];
                            var optionValue = option.Split(new char[] { ' ' }, sepCount);
                            var tempVar = 0;
                            switch (optionValue[0])
                            {
                                case "n":
                                    books.SearchBooks(optionValue[1].Trim(), 1);
                                    break;
                                case "g":
                                    books.SearchBooks(optionValue[1].Trim(), 3);
                                    break;
                                case "a":
                                    books.SearchBooks(optionValue[1].Trim(), 2);
                                    break;
                                case "y":
                                    if (int.TryParse(optionValue[1].Trim(), out tempVar))
                                    {
                                        books.SearchBooks(tempVar, 4);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid value for the option. The value should be integer");
                                    }
                                    break;
                                case "i":
                                    if (int.TryParse(optionValue[1].Trim(), out tempVar))
                                    {
                                        books.SearchBooks(tempVar, 5);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid value for the option. The value should be integer");
                                    }
                                    break;
                                default:
                                    Console.WriteLine("Invalid option for the Command. Try Help -Search for more information");
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid number of options for command Search. Try typing Help -Search for more information");
                        }
                    }
                    else if (userInput.Contains("Current"))
                    {
                            // Checks if current user can execute the command
                            if (designation[username.IndexOf(usernameInput)] == "Patron")
                            {
                                Console.WriteLine("Id: {0}\nName: {1}\n", Patrons[currentPatron].GetId(), Patrons[currentPatron].GetName());
                                if (Patrons[currentPatron].CurrentCount() == 0)
                                    Console.WriteLine("Currently you do not hold any of the books");
                                else
                                {
                                    List<String> currentBooks = Patrons[currentPatron].Current();
                                    foreach (var item in currentBooks)
                                    {
                                        var bookdetails = books.GetDetails(int.Parse(item.Split(',')[0])).Split('|');
                                        Console.WriteLine("Book ID: {5}\nBook Name : {0}\nBook Author: {1}\nBook Genere: {2}\nBook Published Year: {3}\nIssued Date: {4}",
                                            bookdetails[1], bookdetails[3], bookdetails[2], bookdetails[3], DateTime.Parse(item.Split(',')[1]).Date.ToString(), int.Parse(item.Split(',')[0]));
                                    }
                                }
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
                            // Checks if command Add is valid or not
                            if (userInput.Split('-').Length == 6)
                            {
                                var bookName = "";
                                var bookAuthor = "";
                                var bookGenere = "";
                                var bookYear = 0;
                                var bookAvailable = 1;
                                var tempVar = 0;
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
                                            if (int.TryParse(userInputOptions[i].Split(new char[] { ' ' }, 2)[1].Trim(), out tempVar))
                                            {
                                                bookYear = tempVar;
                                            }

                                            break;
                                        case "v":
                                            if (int.TryParse(userInputOptions[i].Split(new char[] { ' ' }, 2)[1].Trim(), out tempVar))
                                            {
                                                bookAvailable = tempVar;
                                            }
                                            break;
                                        default:
                                            break;
                                    }
                                }
                                if (String.IsNullOrEmpty(bookName) || String.IsNullOrEmpty(bookGenere) || String.IsNullOrEmpty(bookAuthor) || bookYear == 0 || bookAvailable == 0)
                                {
                                    Console.WriteLine("Invalid options or command. Try Help -Add for more information");
                                }
                                else
                                {
                                    //Console.WriteLine("calling add function with values {0},{1},{2},{3},{4}",bookName,bookAuthor,bookGenere,bookYear,bookAvailable);
                                    books.AddBook(bookName, bookAuthor, bookGenere, Convert.ToInt32(bookYear), Convert.ToInt32(bookAvailable));
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
                        if (designation[username.IndexOf(usernameInput)] == "Admin")
                        {
                            if (userInput.Split('-').Length == 3)
                            {
                                var bookId = 0;
                                var PatronId = 0;
                                var tempVar = 0;
                                var userInputOptions = userInput.Split('-');
                                for (int i = 1; i < 3; i++)
                                {
                                    switch (userInputOptions[i].Split(new char[] { ' ' }, 2)[0])
                                    {
                                        case "bi":
                                            if (int.TryParse(userInputOptions[i].Split(new char[] { ' ' }, 2)[1].Trim(), out tempVar))
                                            {
                                                bookId = tempVar;
                                            }
                                            break;
                                        case "pi":
                                            if (int.TryParse(userInputOptions[i].Split(new char[] { ' ' }, 2)[1].Trim(), out tempVar))
                                            {
                                                PatronId = tempVar;
                                            }

                                            break;
                                        default:
                                            break;
                                    }
                                }
                                if (bookId == 0 || PatronId == 0)
                                {
                                    Console.WriteLine("Invalid options or command. Try Help -Lend for more information");
                                }
                                else
                                {
                                    for (int i = 0; i < Patrons.Count; i++)
                                    {
                                        if (Patrons[i].GetId() == PatronId)
                                            currentPatron = i;
                                    }
                                    Patron tempPatron = Patrons[currentPatron];
                                    Admins[currentAdmin].LendBooks(bookId, ref tempPatron, ref books);
                                }
                            }

                            else
                            {
                                Console.WriteLine("Invalid number of options for command Lend. Try Help -Lend for more information");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Your account doesn't have privilages to execute this command");
                        }
                    }
                    else if (userInput.Contains("Return"))
                    {
                        if (designation[username.IndexOf(usernameInput)] == "Admin")
                        {
                            if (userInput.Split('-').Length == 3)
                            {
                                var bookId = 0;
                                var PatronId = 0;
                                var tempVar = 0;
                                var userInputOptions = userInput.Split('-');
                                for (int i = 1; i < 3; i++)
                                {
                                    switch (userInputOptions[i].Split(new char[] { ' ' }, 2)[0])
                                    {
                                        case "bi":
                                            if (int.TryParse(userInputOptions[i].Split(new char[] { ' ' }, 2)[1].Trim(), out tempVar))
                                            {
                                                bookId = tempVar;
                                            }
                                            break;
                                        case "pi":
                                            if (int.TryParse(userInputOptions[i].Split(new char[] { ' ' }, 2)[1].Trim(), out tempVar))
                                            {
                                                PatronId = tempVar;
                                            }

                                            break;
                                        default:
                                            break;
                                    }
                                }
                                if (bookId == 0 || PatronId == 0)
                                {
                                    Console.WriteLine("Invalid options or command. Try Help -Return  for more information");
                                }
                                else
                                {
                                    for (int i = 0; i < Patrons.Count; i++)
                                    {
                                        if (Patrons[i].GetId() == PatronId)
                                            currentPatron = i;
                                    }
                                    Patron tempPatron = Patrons[currentPatron];
                                    Admins[currentAdmin].Return(bookId, ref tempPatron, ref books);
                                }
                            }

                            else
                            {
                                Console.WriteLine("Invalid number of options for command Lend. Try Help -Lend for more information");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Your account doesn't have privilages to execute this command");
                        }
                    }
                    else if (userInput.Contains("Audit"))
                    {
                        Console.WriteLine("Calling audit function of Admin class");
                    }
                    else
                    {
                        Console.WriteLine("Couldn't find the command '{0}'.", userInput);
                        Console.WriteLine("The commands available for Patron's are:\n\t" +
                             "Search  ----- Searches for books using given criteria\n\t" +
                             "Current ----- Returns the books currently held by the user\n\t" +
                             "History ----- Returns the list of books lent by the Patron\n" +
                             "The commands available for Admin's are:\n\t" +
                             "Add   -----  Adds a new book to the list\n\t" +
                             "Lend  -----  Lends the given book to the Patron\n\t" +
                             "Audit -----  Audits the books lent to all Patrons");
                    }
                }
            }
            #endregion

            Console.ReadKey();
        }

    }
}                         
