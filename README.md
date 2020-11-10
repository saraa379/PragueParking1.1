# PragueParking1.1
Inlämning C# del1
Sarantsetseg Hedenfalk

When the program is started, it shows menu with 5 alternatives

    1. Leave a vehicle for parking
    2. Change a vehicle's parking spot by parking number
    3. Get your vehicle
    4. Search for a vehicle
    5. Change a vehicle's parking spot by registration number

Then user is asked to enter corresponding number according to menu options

When entered
    option 1 to leave a vehicle for parking

    - user is asked to enter vehicle's registration number
      the system repeats the question untill user enters string (max length 10 characters)

    - next, user is asked to enter vehicle type
      the system repeats the question untill user enters 1 of 2 options: car or motorcycle
    - if user enters car, system saves vehicle in the parkering array
    - if user enters motorcycle, then system will ask if user wants to save 1 more motorcycle
      user has to answer yes or no
    - if user answers yes, system will asks user to enter registration number of 2nd motorcycle
      then, system will save both motorcycles in same parkings spot.
    - if user enters no, then the system will save 1 motorcycle into parkerings spot
    - when vehicle is saved, the system will print its parking spot number

    option 2 to change a vehicle's parking spot by parking number
    - user is asked to enter vehicle's parking spot number
      the system repeats the question untill user enters number 0-99 which is size of array 
      that holds parking spots and parking spot that has vehicle in it
    - user is asked to enter parking spot number where user wants to move the vehicle
      the system repeats the question untill user enters number 0-99 and parking spot that has no vehicle in it
    - when right numbers are entered, vehicle will be moved into the new parking spot
      if there are 2 motorcycles in the parking, then both of them will be moved into the new parking spot

    option 3 to get your vehicle
    - user is asked to enter vehicle's registration number
      the system repeats the question untill user enters string (max length 10 characters) and
      registration number that is saved in the system
    - when user enters the valid registration number, system will remove the vehicle from the system
      if there are 2 motorcycles in the parking, then 1 of them which registration number entered will be removed


    option 4 to search for a vehicle
    - user is asked to enter vehicle's registration number
      the system repeats the question untill user enters string (max length 10 characters)
    - when user enters the valid registration number, system will prints its parking spot number
      if the vehcile is in the parking, otherwise it will say that vehicle is not in the parking


      option 5 to change a vehicle's parking spot by registration number
    - user is asked to enter vehicle's registration number
      the system repeats the question untill user enters string (max length 10 characters) and
      registration number that is saved in the system
    - user is asked to enter parking spot number where user wants to move the vehicle
      the system repeats the question untill user enters number 0-99 and parking spot that has no vehicle in it
    - when right numbers are entered, vehicle will be moved into the new parking spot
      if there are 2 motorcycles in the parking, then 1 of them which registration number entered will be moved
      into new parking spot and other motorcycle will stay in the old parking spot



- after fullfilling the user request, the system prints content of all 100 parking spots
  so that user can check the changes and the system repeats again by presenting the initial menu