/* Sarantsetseg Hedenfalk
 * Inlämnings uppgift C# del 1
 * Prague Parking 1.1
 */


using System;

namespace PragueParking1._1
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Prague parking!");

            //initiate array with objects of ParkingSlot
            for (int i = 0; i < ParkingSpots.parkingSpotsArray.Length; i++)
            {
                ParkingSpot parkingSpotInstance = new ParkingSpot("empty", "empty");
                ParkingSpots.parkingSpotsArray[i] = parkingSpotInstance;
            }//end of for

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

                    //if the input is valid, program continues here
                    switch (number)
                    {
                        case 1:
                            Console.WriteLine("You chose to leave your vehicle");

                            //checks if registration nr is not empty
                            bool isValidRegNr = false;

                            while (!isValidRegNr)
                            {
                                Console.WriteLine("Please enter your vehicle's registration number: ");
                                string strRegNr = Console.ReadLine();
                                bool isRegnrValid = IsInputRegnrValid(strRegNr);
                                if (isRegnrValid)
                                {
                                    isValidRegNr = true;
                                } else
                                {
                                    Console.WriteLine("Registration number is not valid");
                                }
                               
                            }

                            //checks if vehicle type is valid. Input must be car or motorcycle
                            bool isValidType = false;
                            while (!isValidType)
                            {
                                Console.WriteLine("Please enter your vehicle's type (car, motorcycle): ");
                                string strType = Console.ReadLine();
                                bool isStrTypeValid = IsInputTypeValid(strType);
                                if (isStrTypeValid)
                                {
                                    isValidType = true;
                                } else
                                {
                                    Console.WriteLine("Vehicle type is not valid. Enter car or motorcycle.");
                                }

                            }

                            break;
                        case 2:
                            Console.WriteLine("You chose to change your vehicle's parking spot");
                            break;
                        case 3:
                            Console.WriteLine("You chose to get your vehicle");
                            break;
                        case 4:
                            Console.WriteLine("You chose to search for a vehicle");
                            break;
                        case 5:
                            Console.WriteLine("You chose to exit the system");
                            break;
                        default:
                            Console.WriteLine("Please enter the right number");
                            break;
                    }


                } else
                {
                    Console.WriteLine("Please enter a valid number from the menu");
                }

                //prints content of the parking spots array
                foreach (ParkingSpot obj in ParkingSpots.parkingSpotsArray)
                {
                    Console.WriteLine(obj.RegNr);
                }


            }//end of while


        }//end of main

        //checks if input is valid number between 1-5
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
        }//end of IsInputVAlid method


        //checks if input for regnr is valid
        public static bool IsInputRegnrValid(string regnr)
        {
            bool isStrEmpty = String.IsNullOrEmpty(regnr);
            if (!isStrEmpty)
            {
                string trimmed = regnr.Trim(); // Ignore white space on either side.
                //convert to lower case
                if (trimmed.Length < 10)
                {
                    Console.WriteLine("Registration number is too long. It should be no longer that 10 characters");
                    return true;
                }
                else
                {
                    return false;
                }//end of inner if

            }
            else
            {
                return false; //input is empty string
            }//end of outer if

        }//end of IsInputTypeValid method



        //checks if input for vehicle type is car or motorcycle
        public static bool IsInputTypeValid(string type)
        {
            bool isStrEmpty = String.IsNullOrEmpty(type);
            if (!isStrEmpty)
            {
                string trimmed = type.Trim(); // Ignore white space on either side.
                //convert to lower case
                string lowerstr = trimmed.ToLower();
                if (lowerstr == "car" || lowerstr == "motorcycle")
                {
                    return true;
                } else { 
                    return false;  
                }//end of inner if

            } else
            {
                return false; //input is empty string
            }//end of outer if

        }//end of IsInputTypeValid method





    }//end of class
}//end of namespace
