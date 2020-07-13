using System;
using System.Threading;

namespace PhoneBookConsole
{
    public static class Selection
    {
        public static void StartUp()
        {
            Console.Clear();
            bool ProgramIsRunning = true;
            AddressBook ab = new AddressBook();

            Console.WriteLine("Processing. . . . .");
            Thread.Sleep(1000);

            Console.Clear();
            while (ProgramIsRunning)
            {
                PrintUserOptions();
                var userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        ab.CreateUser();
                        break;
                    case "2":
                        ab.UpdateUserInformation();
                        break;
                    case "3":
                        ab.RemovePersonFromList();
                        break;
                    case "4":
                        ab.ShowAllPersonsInList();
                        break;
                    case "5":
                        Console.WriteLine("Have a Wonderful Day!");
                        Thread.Sleep(1000);
                        Environment.Exit(0);
                        break;
                }
            }


        }
        private static void PrintUserOptions()
        {
            Console.WriteLine("Choose one of the following options: ");
            Console.WriteLine("#1 Create new user");
            Console.WriteLine("#2 Edit user information");
            Console.WriteLine("#3 Delete existing user");
            Console.WriteLine("#4 Show all users in Address Book");
            Console.WriteLine("#5 Exit Program");
        }


    }
}
