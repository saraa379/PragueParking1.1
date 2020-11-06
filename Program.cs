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

            int number;
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


                Console.ReadLine();

            }


        }
    }
}
