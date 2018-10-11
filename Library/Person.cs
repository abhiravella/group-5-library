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
        private int contactnumber;
        private string designation;

        public Person(string value)
        {
            this.designation=value;
        }
        public string GetDesignation()
        {          
            Console.WriteLine("Current User is: {0}",designation);
            return designation;
        }

        public void SetName( string Name)
        {
            if(string.IsNullOrEmpty(name))
            {
                throw new Exception("Entered Invalid Name");
            }
                this.name=Name;
        }
        public string GetName()
        {
            if(string.IsNullOrEmpty(this.name))
            {
                  return "No Name";
            }
            return this.name;
        }

        public void SetId(int Id)
        {
            this.id=Id;
        }
        public int GetId()
        {
            return this.id;
        }
        public void SetContactNumber(int ContactNumber)
        {
            this.contactnumber = ContactNumber;
        }
        public int GetContactNumber()
        {
            return this.contactnumber ;
        }


    }

}


   

