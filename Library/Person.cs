using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Person
    {
        private String name;
        private int id;
        private int contactNo;

    }

    public class Student : Person
    {


    }


    public class Admin : Person
    {
        private List<String> bookname = new List<String>();
        private List<String> studentname = new List<String>();
        private List<int> studentid = new List<int>();
        private List<DateTime> issuedate = new List<DateTime>();

        public void LendBooks(string bookName, string studentName, int studentId, DateTime date)
        {
            bookname.Add(bookName.ToUpper());
            studentname.Add(studentName.ToUpper());
            studentid.Add(studentId);
            issuedate.Add(date);

            return;
        }

        public void AuditBooks()
        {

        }

    }
}
