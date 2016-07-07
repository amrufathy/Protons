using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Phonebook
{
    class Program
    {

        /*
         * Amr Fathy's Solution to the phonebook project
         * Please note that this is merely how I thought about the problem
         * 
         * The searching algorithm is linear search which takes O(n) time
         * The sorting algorithm is selection sort which takes O(n^2) time
         */

        #region application declarations

        private struct Subscriber
        {
            public string firstName;
            public string lastName;
            public string mobileNumber;
            public string email;
            public Address address;
            public List<string> groups;
        }

        private struct Address
        {
            public string buildingNumber;
            public string streetName;
            public string city;
            public string country;
        }

        private static List<Subscriber> allSubscribers = new List<Subscriber>();
        private static bool sortByFirstName = true;

        #endregion

        public static void Main(string[] args)
        {
            run();
        }

        #region application logic

        private static void run()
        {
            int response = 0;
            while (response != 10)
            {
                Console.Clear();

                Console.Write("\t    _____  _                      ____              _\n" +
                "\t   |  __ \\| |                    |  _ \\            | |         \n" +
                "\t   | |__| | |__   ___  _ __   ___| |_| | ___   ___ | | __        \n" +
                "\t   |  ___/| '_ \\ / _ \\| '_ \\ / _ \\  _ < / _ \\ / _ \\| |/ /  \n" +
                "\t   | |    | | | | |_| | | | |  __/ |_| | |_| | |_| |   <         \n" +
                "\t   |_|    |_| |_|\\___/|_| |_|\\___|____/ \\___/ \\___/|_|\\_\\  \n" +
                "\t\t                           _                   \n" +
                "\t\t   |\\/|  /\\  | |\\ |  |\\/| |_  |\\ | | |    \n" +
                "\t\t   |  | /--\\ | | \\|  |  | |_  | \\| |_|      \n\n" +
                "\t   (1) Add subscriber.     |\t(2) Modify subscriber.\n" +
                "\t   (3) Delete subscriber.  |\t(4) Print subscribers.\n" +
                "\t   (5) Search by name.     |\t(6) Search by group.\n" +
                "\t   (7) Save.\t\t   |\t(8) Load.\n" +
                "\t   (9) Sort.\t\t   |\t(10) Exit.\n\n" +
                "\t   >>>> ");

                response = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (response)
                {
                    case 1: addSubscriber(); break;
                    case 2: editSubscriber(); break;
                    case 3: deleteSubscriber(); break;
                    case 4: printAllSubscribers(); break;
                    case 5: search(false); break;
                    case 6: search(true); break;
                    case 7: Save(); break;
                    case 8: Load(); break;
                    case 9: sortHelper(); break;
                    case 10: exit(); break;
                    default: Console.WriteLine("Invalid input"); break;
                }
            }

            Console.ReadKey();
        }

        private static void addSubscriber()
        {
            // read subscriber from the user
            Subscriber subscriber = readSubscriber();

            // check is subscriber is not empty
            // extra layer of error handling
            if (!subscriber.Equals(default(Subscriber)))
            {
                // add to the list then sort
                allSubscribers.Add(subscriber);
                sort(sortByFirstName);

                Console.WriteLine("Subscriber added sucessfully !");
                wait();
            }
        }

        private static Subscriber readSubscriber()
        {
            /* this function reads a subscriber from the user,
             * validates the input then returns a valid subscriber
             */
            Subscriber subscriber = new Subscriber();
            subscriber.groups = new List<string>();

            Console.WriteLine("Please enter first name:");
            subscriber.firstName = validateString(Console.ReadLine());

            Console.WriteLine("\nPlease enter last name:");
            subscriber.lastName = validateString(Console.ReadLine());

            Console.WriteLine("\nPlease enter mobile number:");
            subscriber.mobileNumber = validateNumber(Console.ReadLine());

            Console.WriteLine("\nPlease enter email:");
            subscriber.email = validateString(Console.ReadLine());

            Console.WriteLine("\nPlease enter address:\n[Building Number] [Street Name], [City], [Country]");
            subscriber.address = readAddress(validateString(Console.ReadLine()));

            Console.WriteLine("\nAdd the user to groups ? (y/n)");
            while (char.Parse(Console.ReadLine()) == 'y')
            {
                Console.WriteLine("Please enter group name:");
                subscriber.groups.Add(validateString(Console.ReadLine()));

                Console.WriteLine("Add another group ? (y/n)");
            }

            if (subscriber.firstName == null || subscriber.lastName == null ||
                subscriber.mobileNumber == null || subscriber.email == null ||
                subscriber.address.Equals(default(Address)))
            {
                Console.WriteLine("This subscriber is invalid !\nCannot Add it !");
                wait();
                return default(Subscriber);
            }

            return subscriber;
        }

        private static Address readAddress(string input)
        {
            /* this function reads the address from the user
             * the input string is parsed and each field is populated
             * accordingly.
             */ 
            if (input == null || input.Length == 0)
            {
                return new Address();
            }

            Address address = new Address();

            int index1 = input.IndexOf(' ');
            int index2 = input.IndexOf(',', index1);
            int index3 = input.IndexOf(',', index2 + 1);

            int length = input.Length;

            // please note the usage of substring is Substring(startIndex, length)
            // Trim delete the specified character from the start and end of string
            address.buildingNumber = input.Substring(0, index1).Trim(' ');
            address.streetName = input.Substring(index1 + 1, index2 - index1 - 1).Trim(' ');
            address.city = input.Substring(index2 + 1, index3 - index2 - 1).Trim(' ');
            address.country = input.Substring(index3 + 1).Trim(' ');

            return address;
        }

        private static string validateString(string input)
        {
            // check if field is not empty
            if (input.Length == 0)
            {
                Console.WriteLine("Field left empty !");
                return null;
            }

            Regex rg = new Regex(@"^[a-zA-z0-9,.@\s]*$");

            // check if input has alphanumeric digits only using regular expressions
            if (!rg.IsMatch(input))
            {
                Console.WriteLine("Only Alphanumeric input is allowed !");
                return null;
            }

            return input;
        }

        public static string validateNumber(string input)
        {
            // validate mobile number input, must contain only numbers
            if (input.Length == 0)
            {
                Console.WriteLine("Field left empty !");
                return null;
            }

            Regex rg = new Regex(@"^[0-9]*$");

            if (!rg.IsMatch(input))
            {
                Console.WriteLine("Only Numeric input is allowed !");
                return null;
            }

            return input;
        }

        private static void search(bool group)
        {
            List<int> indecies = new List<int>();

            /* check if search by name or by group
             * getIndecies return the index of subscriber that
             * matches the search query
             */
            if (group)
            {
                Console.WriteLine("Please enter group:");
                string str = Console.ReadLine();
                indecies = getIndeciesByGroup(str);
            }
            else
            {
                Console.WriteLine("Please enter first or last name:");
                string str = Console.ReadLine();
                indecies = getIndecies(str);
            }

            // no subscribers found
            if (indecies.Count == 0)
            {
                Console.WriteLine("No subscribers with these info !");

                Console.WriteLine("\nPress enter to continue");
                Console.ReadKey();
                return;
            }

            Console.WriteLine();
            foreach (int index in indecies)
            {
                printSubscriber(allSubscribers[index], index);
            }

            Console.WriteLine("\nPress enter to continue");
            Console.ReadKey();
        }

        private static void deleteSubscriber()
        {
            // apply search algorithm
            Console.WriteLine("Please enter first or last name:");
            string name = Console.ReadLine();

            List<int> indecies = getIndecies(name);

            if (indecies.Count == 0)
            {
                Console.WriteLine("No subscribers with these info !");
                wait();
                return;
            }

            Console.WriteLine();
            foreach (int index in indecies)
            {
                printSubscriber(allSubscribers[index], index + 1);
            }

            // pick subscriber to delete
            Console.WriteLine("Which contact do you want to delete?\nIf you don't want to delete enter '-1'.\n");
            int choice = int.Parse(Console.ReadLine()) - 1;

            if (choice == -1) return;

            if (choice < 0 || choice > allSubscribers.Count - 1 || !indecies.Contains(choice))
            {
                Console.WriteLine("Index out of range !");
                wait();
                return;
            }

            allSubscribers.RemoveAt(choice);

            Console.WriteLine("Subscriber deleted successfully.");
            wait();
        }

        private static void editSubscriber()
        {
            // apply search algorithm
            Console.WriteLine("Please enter first or last name:");
            string name = Console.ReadLine();

            List<int> indecies = getIndecies(name);

            if (indecies.Count == 0)
            {
                Console.WriteLine("No subscribers with these info !");
                wait();
                return;
            }

            Console.WriteLine();
            foreach (int index in indecies)
            {
                printSubscriber(allSubscribers[index], index + 1);
            }

            // pick subscriber to modify
            Console.WriteLine("Which contact do you want to modify?\nIf you don't want to edit enter '-1'.\n");
            int choice = int.Parse(Console.ReadLine()) - 1;

            if (choice == -1) return;

            if (choice < 0 || choice > allSubscribers.Count - 1 || !indecies.Contains(choice))
            {
                Console.WriteLine("Index out of range !");
                wait();
                return;
            }

            // modify algorithm is done by re-reading the subscriber and replacing the old subscriber
            // with the new one
            Subscriber subscriber = readSubscriber();

            // check if subscriber was modified or not
            if (!allSubscribers[choice].Equals(subscriber))
            {
                allSubscribers[choice] = subscriber;
                Console.WriteLine("Subscriber modified successfully !");
            }
            else
            {
                Console.WriteLine("Subscriber didn't change !");
            }

            wait();
        }

        private static void printSubscriber(Subscriber subscriber, int index)
        {
            Console.WriteLine("Subscriber #" + index);
            Console.WriteLine("First Name: " + subscriber.firstName);
            Console.WriteLine("Last Name: " + subscriber.lastName);
            Console.WriteLine("Mobile Number: " + subscriber.mobileNumber);
            Console.WriteLine("Email: " + subscriber.email);
            Console.WriteLine("Address: " + subscriber.address.buildingNumber + ", " +
                subscriber.address.streetName + ", " + subscriber.address.city + ", " +
                subscriber.address.country);

            if (subscriber.groups.Count > 0)
            {
                Console.Write("Groups: ");
                foreach (string group in subscriber.groups)
                {
                    Console.Write(group + " ");
                }
            }
            Console.WriteLine("\n");
        }

        private static void printAllSubscribers()
        {
            if (allSubscribers.Count == 0)
            {
                Console.WriteLine("No Subscribers to print !");
            }
            else
            {
                int i = 0;
                foreach (Subscriber subscriber in allSubscribers)
                {
                    printSubscriber(subscriber, ++i);
                }
            }

            wait();
        }

        private static List<int> getIndecies(string name)
        {
            List<int> indecies = new List<int>();

            for (int i = 0; i < allSubscribers.Count; i++)
            {
                // search algorithm is not case sensitive
                if (name.ToLower() == allSubscribers[i].firstName.ToLower() ||
                    name.ToLower() == allSubscribers[i].lastName.ToLower())
                {
                    indecies.Add(i);
                }
            }

            return indecies;
        }

        private static List<int> getIndeciesByGroup(string str)
        {
            List<int> indecies = new List<int>();

            for (int i = 0; i < allSubscribers.Count; i++)
            {
                foreach (string group in allSubscribers[i].groups)
                {
                    // search algorithm is not case sensitive
                    if (str.ToLower() == group.ToLower())
                    {
                        indecies.Add(i);
                    }
                }
            }

            return indecies;
        }

        private static void sortHelper()
        {
            Console.WriteLine("Please enter the corresponding number:\n" +
                "1) Sort by first name.\n2) Sort by last name.\nDefault is by first name.");
            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                sortByFirstName = true;
            }
            else
            {
                sortByFirstName = false;
            }
            sort(sortByFirstName);
        }

        private static void sort(bool byFirstName)
        {
            // Selection Sort O(n^2)

            int min;
            for (int i = 0; i < allSubscribers.Count; i++)
            {
                min = i;
                for (int j = i; j < allSubscribers.Count; j++)
                {
                    if (sortByFirstName)
                    {
                        // allSubscribers[j].firstName < allSubscribers[min].firstName
                        if (allSubscribers[j].firstName.CompareTo(allSubscribers[min].firstName) < 0)
                        {
                            min = j;
                        }
                    }
                    else
                    {
                        // allSubscribers[j].lastName < allSubscribers[min].lastName
                        if (allSubscribers[j].lastName.CompareTo(allSubscribers[min].lastName) < 0)
                        {
                            min = j;
                        }
                    }
                }

                if (min != i)
                {
                    // swap i with new min
                    Subscriber temp = allSubscribers[i];
                    allSubscribers[i] = allSubscribers[min];
                    allSubscribers[min] = temp;
                }
            }
        }

        private static void Save()
        {
            Console.WriteLine("Please enter file name:");
            string fileName = validateString(Console.ReadLine());

            if (!fileName.EndsWith(".txt"))
            {
                fileName += ".txt";
            }

            StreamWriter writer = new StreamWriter(fileName);

            // write each subscriber as a line in file
            // each field is separated by a comma
            foreach (Subscriber subscriber in allSubscribers)
            {
                string line = subscriber.firstName + ", " +
                    subscriber.lastName + ", " + subscriber.mobileNumber + ", " +
                    subscriber.email + ", ";

                line += subscriber.address.buildingNumber + ", " +
                    subscriber.address.streetName + ", " +
                    subscriber.address.city + ", " + subscriber.address.country;

                if (subscriber.groups.Count > 0)
                {
                    foreach (string group in subscriber.groups)
                    {
                        line += ", " + group;
                    }
                }

                writer.WriteLine(line);
            }

            writer.Close();
            Console.WriteLine("Directory saved successfully !");
            wait();
        }

        private static void Load()
        {
            Console.WriteLine("Please enter file name:");
            string fileName = validateString(Console.ReadLine());

            if (!fileName.EndsWith(".txt"))
            {
                fileName += ".txt";
            }

            StreamReader reader = new StreamReader(fileName);

            allSubscribers.Clear();

            string line;
            // keep reading untill reaching an empty line
            while ((line = reader.ReadLine()) != null)
            {
                // remember each field is separated by a comma
                string[] parts = line.Split(',');

                Subscriber subscriber = new Subscriber();
                int i = 0;

                subscriber.firstName = parts[i++].Trim(' ');
                subscriber.lastName = parts[i++].Trim(' ');
                subscriber.mobileNumber = parts[i++].Trim(' ');
                subscriber.email = parts[i++].Trim(' ');

                subscriber.address.buildingNumber = parts[i++].Trim(' ');
                subscriber.address.streetName = parts[i++].Trim(' ');
                subscriber.address.city = parts[i++].Trim(' ');
                subscriber.address.country = parts[i++].Trim(' ');

                subscriber.groups = new List<string>();

                while (i < parts.Length)
                {
                    subscriber.groups.Add(parts[i++].Trim(' '));
                }

                allSubscribers.Add(subscriber);
            }

            reader.Close();
            Console.WriteLine("Directory loaded successfully !");
            wait();
        }

        private static void wait()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        private static void exit()
        {
            Console.WriteLine("Would you like to save your current directory ?(y/n)");
            if (char.Parse(Console.ReadLine()) == 'y')
            {
                Save();
            }
            Environment.Exit(0);
        }

        #endregion
    }
}
