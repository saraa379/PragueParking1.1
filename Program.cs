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
                ParkingSpot parkingSpotInstance = new ParkingSpot("empty", "empty", 0);
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
                            string regNr = "empty";
                            string secondRegNr = "empty";
                            string type = "empty";
                            int nrOfVehicle = 0;

                            //checks if registration nr is not empty
                            bool isValidRegNr = false;

                            while (!isValidRegNr)
                            {
                                Console.WriteLine("Please enter your vehicle's registration number: ");
                                string strRegNr = Console.ReadLine();
                                bool isRegnrValid = IsInputRegnrValid(strRegNr);
                                if (isRegnrValid)
                                {
                                    regNr = strRegNr;
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
                                    type = strType;
                                    isValidType = true;
                                } else
                                {
                                    Console.WriteLine("Vehicle type is not valid. Enter car or motorcycle.");
                                }
                            }//end of while

                            //Console.WriteLine("vehicle type is: " + type);
                            if (type == "motorcycle")
                            {
                                secondRegNr = AddSecondBike();

                                if (secondRegNr != "empty")
                                {
                                    nrOfVehicle = 2;
                                    regNr = regNr + "," + secondRegNr;
                                } else
                                {
                                    nrOfVehicle = 1;
                                }
                            } else
                            {
                                nrOfVehicle = 1;
                            }

                            //Console.WriteLine("RegNr: " + regNr);
                            //Console.WriteLine("Type: " + type);
                            //Console.WriteLine("nr of vehicle: " + nrOfVehicle);
                            AddVehicle(regNr, type, nrOfVehicle);


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
                            Console.WriteLine("Please enter the right number from the menu");
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
                    return true;
                }
                else
                {
                    Console.WriteLine("Registration number is too long. It should be no longer that 10 characters");
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


        //Adds second motorcycle
        public static string AddSecondBike()
        {
            //checks if registration nr is not empty
            bool isValidInput = false;
            string strAnswer = "empty";
            string regNr = "empty";

            while (!isValidInput)
            {
                Console.WriteLine("Do you want to place another motorcycle? Please answer yes or no.");
                string answer = Console.ReadLine();
                bool isStrEmpty = String.IsNullOrEmpty(answer);
                if (!isStrEmpty) //answer is not empty
                {
                    string trimmed = answer.Trim(); // Ignore white space on either side.
                                                  //convert to lower case
                    string lowerstr = trimmed.ToLower();
                    if (lowerstr == "yes")
                    {
                        isValidInput = true;
                        strAnswer = "yes";
                    }
                    else if (lowerstr == "no") {
                        isValidInput = true;
                        strAnswer = "no";
                    }
                    else
                    {
                        Console.WriteLine("Please answer yes or no."); //answer is not valid
                    }//end of inner if

                }
                else
                {
                    Console.WriteLine("Please answer yes or no."); //answer is empty
                }//end of outer if
            } //end of while

            Console.WriteLine("Your asnwer is: " + strAnswer);

            if (strAnswer == "yes")
            {
                //checks if registration nr is not empty
                bool isValidRegNr = false;

                while (!isValidRegNr)
                {
                    Console.WriteLine("Please enter your second motorcycle's registration number: ");
                    string strRegNr = Console.ReadLine();
                    bool isRegnrValid = IsInputRegnrValid(strRegNr);
                    if (isRegnrValid)
                    {
                        regNr = strRegNr;
                        isValidRegNr = true;
                    }
                    else
                    {
                        Console.WriteLine("Registration number is not valid");
                    }

                } //end of while

                return regNr;

            } else
            {
                return "empty";
            } //end of if

        }//end of AddSecondBike method



        //add vehicle to parking
        public static void AddVehicle(string regNr, string type, int nrOfVehicle)
        {
            bool isAdded = false;
            //find the 1st empty slot for inserting the vehicle in the ParkingSlots array
            for (int i = 0; i < ParkingSpots.parkingSpotsArray.Length; i++)
            {
                if (ParkingSpots.parkingSpotsArray[i].RegNr == "empty")
                {
                    ParkingSpots.parkingSpotsArray[i].RegNr = regNr;
                    ParkingSpots.parkingSpotsArray[i].VehicleType = type;
                    ParkingSpots.parkingSpotsArray[i].NrOfVehicle = nrOfVehicle;
                    isAdded = true;
                    Console.WriteLine("Your vehicle is added to out parking. Your vehicle's spot number is: " + i);
                    break;
                }
            }//end of for

            if (!isAdded)
            {
                Console.WriteLine("Our parking has no empty slot. Please try again later.");
            }


        }//end of AddVehicle method

    }//end of class
}//end of namespace
