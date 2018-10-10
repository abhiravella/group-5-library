using System;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            //Admin class

           Admin admin=new Admin();
            admin.SetName();
            admin.SetId();
            admin.SetContactNumber();
          //  admin.AuditBooks ();
            admin.LendBooks();
            Console.WriteLine("Admin ID is: {0} " , admin.GetId);
            Console.WriteLine("Admin Name is: {0} " , admin.GetName);
            Console.WriteLine("Admin Contact Number is: {0} " , admin.GetContactNumber);

            //Patron class

            Patron patron=new Patron();
            patron.SetName();
            patron.SetId();
            patron.SetContactNumber();
            
            Console.WriteLine("Patron ID is: {0} " , patron.GetId);
            Console.WriteLine("Patron Name is: {0} " , patron.GetName);
            Console.WriteLine("Patron Contact Number is: {0} " , patron.GetContactNumber);

        }
    }
}
