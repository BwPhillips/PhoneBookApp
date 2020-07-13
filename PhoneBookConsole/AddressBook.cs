using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace PhoneBookConsole
{
    public class AddressBook
    {
        private WriteToFile wtf;

        public List<Person> AddressBookList { get; set; } = new List<Person>();


        public AddressBook()
        {
            AddressBookList = new List<Person>();
            wtf = new WriteToFile();
        }

        public void CreateUser()
        {
            Console.Clear();
            Console.WriteLine("Enter First Name:");
            string firstName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter Last Name:");
            string lastName = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter Address:");
            string address = Console.ReadLine();

            Console.Clear();
            Console.WriteLine("Enter Phone Number:");
            string phoneNumber = Console.ReadLine();

            Console.Clear();
            Person person = new Person(firstName, lastName, address, phoneNumber);
            AddPersonToList(person);

        }

        private void AddPersonToList(Person person) => AddressBookList.Add(person);

        public void RemovePersonFromList()
        {
            Console.Clear();
            Console.WriteLine("Enter firstName of the user you want to remove");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter lastname of the user you want to remove");
            string lastName = Console.ReadLine();

            AddressBookList.RemoveAll(item => item.FirstName == firstName && item.LastName == lastName);
            wtf.UpdateUserOnFile(AddressBookList);
        }

        public void ShowAllPersonsInList()
        {
            Console.Clear();
            Console.WriteLine("Retrieving Records . . . . .");
            Thread.Sleep(1000);
            foreach (var person in AddressBookList)
            {
                Console.WriteLine("FirstName: {0}, LastName: {1}, Address: {2}, Phone Number: {3}", person.FirstName, person.LastName, person.Address, person.PhoneNumber);
            }
        }

        public void UpdateUserInformation()
        {
            Console.Clear();
            Console.WriteLine("Which information do you want to update?");
            Console.WriteLine("#1: First name, #2: Last name, 3# Address, 4# Phone Number");
            var userOption = Console.ReadLine();

            Console.WriteLine("Enter firstname on existing user to be updated");
            var oldFirstName = Console.ReadLine();
            UpdateUserFunction(userOption, oldFirstName);
        }

        private void UpdateUserFunction(string userOption, string oldFirstName)
        {
            var personsWithMatchingFirstName = AddressBookList.Where(person => person.FirstName == oldFirstName);
            string newValue;

            if (userOption == "1")
            {
                Console.WriteLine("Enter a new First Name");
                newValue = Console.ReadLine();

                foreach (var person in personsWithMatchingFirstName)
                {
                    person.FirstName = newValue;
                    wtf.UpdateUserOnFile(AddressBookList);


                }
            }
            else if (userOption == "2")
            {
                Console.WriteLine("Enter a new Last Name");
                newValue = Console.ReadLine();

                foreach (var person in personsWithMatchingFirstName)
                {
                    person.LastName = newValue;
                    wtf.UpdateUserOnFile(AddressBookList);
                }
            }
            else if (userOption == "3")
            {
                Console.WriteLine("Enter a New Address");
                newValue = Console.ReadLine();

                foreach (var person in personsWithMatchingFirstName)
                {
                    person.Address = newValue;
                    wtf.UpdateUserOnFile(AddressBookList);
                }
            }
            else if (userOption == "4")
            {
                Console.WriteLine("Enter a Phone Number");
                newValue = Console.ReadLine();

                foreach (var person in personsWithMatchingFirstName)
                {
                    person.PhoneNumber = newValue;
                    wtf.UpdateUserOnFile(AddressBookList);
                }
            }

        }
    }
}
