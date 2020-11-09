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

                            //checks if registration nr is valid
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
                            int parkingNr = 0;
                            int newParkingNr = 0;

                            //checks if parking nr is valid
                            bool isValidParkingNr = false;

                            while (!isValidParkingNr)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Please enter your vehicle's parking spot number: ");
                                string strNr = Console.ReadLine();
                                int intNr = IsInputParkingNrValid(strNr);
                                if (intNr != -1)
                                {
                                    parkingNr = intNr;
                                    isValidParkingNr = true;
                                }

                            }//end of while


                            //checks if new parking nr is valid
                            bool isValidNewParkingNr = false;

                            while (!isValidNewParkingNr)
                            {
                                Console.WriteLine("");
                                Console.WriteLine("Please enter parking spot number where you want to move your vehicle to: ");
                                string strNr = Console.ReadLine();
                                int intNr = IsNewParkingNrValid(strNr);
                                if (intNr != -1)
                                {
                                    newParkingNr = intNr;
                                    isValidNewParkingNr = true;
                                }

                            }//end of while

                            //changes vehcile's parking spot
                            ChangeParkingSpot(parkingNr, newParkingNr);
;
                            break;
                        case 3:
                            Console.WriteLine("You chose to get your vehicle");
                            string regNrInput = "empty";

                            //checks if registration nr is valid
                            bool isValidRegNrInput = false;

                            while (!isValidRegNrInput)
                            {
                                Console.WriteLine("Please enter your vehicle's registration number: ");
                                string strRegNr = Console.ReadLine();
                                bool isRegnrValid = IsInputRegnrValid(strRegNr);
                                if (isRegnrValid)
                                {
                                    regNrInput = strRegNr;
                                    isValidRegNrInput = true;
                                }
                                else
                                {
                                    Console.WriteLine("Registration number is not valid");
                                }

                            }

                            //Removes vehicle from parking
                            RemoveVehicle(regNrInput);


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

                Console.WriteLine("");
                Console.WriteLine("All our parking spots");
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
                    Console.WriteLine("Registration number is too long. It should be no longer than 10 characters");
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
                    Console.WriteLine("Your vehicle is added to out parking. Your vehicle's parking spot number is: " + i);
                    break;
                }
            }//end of for

            if (!isAdded)
            {
                Console.WriteLine("Our parking has no empty slot. Please try again later.");
            }


        }//end of AddVehicle method


        //checks if input parking nr is valid
        public static int IsInputParkingNrValid(string raw)
        {
            string s = raw.Trim(); // Ignore white space on either side.
            int number = Convert.ToInt32(s);
            if (number >= 0 && number < 100) //checks nr is 0-99 which is size of parking array
            {
                if (ParkingSpots.parkingSpotsArray[number].RegNr == "empty")
                {
                    Console.WriteLine("Your parking slot number is not valid. Please enter right number");
                    return -1;
                } else
                {
                    return number;
                }
                
                
            }
            else
            {
                Console.WriteLine("Your parking slot number is not valid. Please enter number between 0-99");
                return -1;
            }
          
        }//end of IsInputVAlid method


        //checks if input parking nr is valid number
        public static int IsNewParkingNrValid(string raw)
        {
            string s = raw.Trim(); // Ignore white space on either side.
            int number = Convert.ToInt32(s);
            if (number >= 0 && number < 100) //checks nr is 0-99 which is size of parking array
            {
                if (ParkingSpots.parkingSpotsArray[number].RegNr != "empty")
                {
                    Console.WriteLine("The parking slot you entered is not free. Please enter another number");
                    return -1;
                }
                else
                {
                    return number;
                }


            }
            else
            {
                Console.WriteLine("Your parking slot number is not valid. Please enter number between 0-99");
                return -1;
            }

        }//end of IsNewParkingNrValid method


        //changes vehicle's parking spot
        public static void ChangeParkingSpot(int oldNr, int newNr)
        {
            string regNr = ParkingSpots.parkingSpotsArray[oldNr].RegNr;
            string type = ParkingSpots.parkingSpotsArray[oldNr].VehicleType;
            int nrOfVehicles = ParkingSpots.parkingSpotsArray[oldNr].NrOfVehicle;

            ParkingSpots.parkingSpotsArray[newNr].RegNr = regNr;
            ParkingSpots.parkingSpotsArray[newNr].VehicleType = type;
            ParkingSpots.parkingSpotsArray[newNr].NrOfVehicle = nrOfVehicles;

            //free the old parking spot
            ParkingSpots.parkingSpotsArray[oldNr].RegNr = "empty";
            ParkingSpots.parkingSpotsArray[oldNr].VehicleType = "empty";
            ParkingSpots.parkingSpotsArray[oldNr].NrOfVehicle = 0;

            Console.WriteLine("Your vehicle is moved into new parking spot");
            Console.WriteLine("Your vehicle's parking spot number is: " + newNr);


        }//end of AddVehicle method


        //Remove vehicle from parking
        public static void RemoveVehicle(string regNr)
        {
            bool isRemoved = false;
            //Search for vehicle by regnr and removes it from db
            for (int i = 0; i < ParkingSpots.parkingSpotsArray.Length; i++)
            {
                if (ParkingSpots.parkingSpotsArray[i].RegNr.Contains(regNr, StringComparison.OrdinalIgnoreCase))
                {
                    if (ParkingSpots.parkingSpotsArray[i].NrOfVehicle == 2)
                    {
                        string tempRegnr = ParkingSpots.parkingSpotsArray[i].RegNr;
                        int pos = tempRegnr.IndexOf(regNr); //gets position of the regnr
                        string newStr = tempRegnr.Remove(pos, regNr.Length); //removes the regnr from the string
                        string remainingRegnr = newStr.Trim(new Char[] { ' ', ',' });

                        //removes the vehicle from db

                        ParkingSpots.parkingSpotsArray[i].RegNr = remainingRegnr;
                        ParkingSpots.parkingSpotsArray[i].NrOfVehicle = 1;
                        Console.WriteLine("Your vehicle with regnr " + regNr + " is removed from parking");

                    }
                    else
                    {
                        ParkingSpots.parkingSpotsArray[i].RegNr = "empty";
                        ParkingSpots.parkingSpotsArray[i].VehicleType = "empty";
                        ParkingSpots.parkingSpotsArray[i].NrOfVehicle = 0;

                        Console.WriteLine("Your vehicle with regnr " + regNr + " is removed from parking");
                    }

                    isRemoved = true;
                    Console.WriteLine("Your vehicle is removed from parking");
                    break;
                }
            }//end of for

            if (!isRemoved)
            {
                Console.WriteLine("There is no vehicle with the registration number you provided in our parkeing");
            }


        }//end of AddVehicle method

    }//end of class
}//end of namespace
