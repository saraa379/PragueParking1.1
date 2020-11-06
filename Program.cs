/*Sarantsetseg Hedenfalk
 * Inlämnings uppgift C# del 1
 */


using System;

namespace PragueParking1._1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Prague parking!");

            bool isOpen = true;

            while (isOpen)
            {
                //Menu
                Console.WriteLine("");
                Console.WriteLine("Please enter the corresponding number from the menu below");
                Console.WriteLine("");
                Console.WriteLine("---------------------------------------------------------");
                Console.WriteLine("1. Leave a vehicle for parking");
                Console.WriteLine("2. Change a vehicle's parking spot");
                Console.WriteLine("3. Get your vehicle");
                Console.WriteLine("4. Search for a vehicle");
                Console.WriteLine("5. Exit the system");


                string s = Console.ReadLine();
                //checks if input is valid
                bool isInputValidNumber = IsInputValid(s);
                if (isInputValidNumber)
                {
                    int number = Convert.ToInt32(s);
                    Console.WriteLine("Your choice is: " + number);
                } else
                {
                    Console.WriteLine("Please enter a valid number from the menu");
                }
                

            }//end of while


        }//end of main

        //checks if input is valid number between 
        public static bool IsInputValid(string raw)
        {
            string s = raw.Trim(); // Ignore white space on either side.
            int number = Convert.ToInt32(s);
            if (s.Length == 0 || s.Length > 1)
            {
                return false;
            }
            else if (Char.IsDigit(s[0]) == false)
            {
                return false;
            }
            else if (number == 0 || number > 5)
            {
                return false;
            }
            else
            {
                return true;
            }
        }//end of IsInputVAlid
    }
}
