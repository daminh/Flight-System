using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomelandSecurity;

namespace Martinez_Van_FlightTrackingSystem
{
    class Flight
    {
        //Instance Variables
        private int flightNumber;
        private string flightDestination;
        private string flightOrigin;
        Passenger[] flightManifest = new Passenger[20];

        //Basic Constructor
        public Flight()
        {}

        //Main Flight Constructor
        public Flight(int flightNumber, string flightDestination, string flightOrigin)
        {
            this.flightNumber = flightNumber;
            this.flightDestination = flightDestination;
            this.flightOrigin = flightOrigin;
        }

        //Properties
        public int FlightNumber
        {
            get { return flightNumber; }
            set { flightNumber = value; }
        }

        public string FlightDestination
        {
            get { return flightDestination; }
            set { flightDestination = value; }
        }

        public string FlightOrigin
        {
            get { return flightOrigin; }
            set { flightOrigin = value; }
        }


        /********************************/
        /*   Display Main Menu Method   */
        /********************************/
        //Alpha Ready
        public void DisplayMainMenu(Flight[] flightArray)
        {
            int input;
            bool loop = true;

            do
            {
                //Display Menu
                Console.Clear();
                Console.WriteLine("\t\t*** Weclome to the Martinez-Van Flight System ***");
                Console.WriteLine("\t\t-----------------------------------------------");
                Console.WriteLine("1) Display a list of flights");
                Console.WriteLine("2) Create new flights");
                Console.WriteLine("3) Search all flights for a particular passenger by first and last name.");
                Console.WriteLine("4) Select a flight");
                Console.WriteLine("5) Cleanly exit the application\n");
                Console.Write("Please enter a number (1 to 5): ");

                //Takes user input to Verify it is of correct type and within Range and returns the value
                input = VerifyMenuEntry(5);

                //Menu Options
                switch (input)
                {
                    case 1:
                        //Displays Flights. Takes a bool to loop back to the Main Menu
                        loop = DisplayFlights(flightArray);
                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        //Exits the program
                        loop = false;
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        break;
                }

            } while (loop == true); 
        }//End of Display Main Menu Method


        /**************************/
        /*   Main Menu Option 1   */
        /**************************/
        public bool DisplayFlights(Flight[] flightArray)
        {
            int counter = 0;

            //Counts how many elements in the array are filled
            for (int i = 0; i < flightArray.Length; i++)
            {
                if(flightArray[i] != null)
                { counter++; }
            }

            //Displays Flights
            Console.Clear();
            Console.WriteLine("\t\tCurrent Flights\n\n");

            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("{0,4}. {1,-8}{2,-20}-->     {3}\n", i + 1, flightArray[i].FlightNumber, flightArray[i].FlightOrigin, flightArray[i].FlightDestination);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            //Lets the application loop back to the main menu
            return true;
        }


        /******************************/
        /*   Display SubMenu Method   */
        /******************************/
        //Work in Progress
        public void DisplaySubMenu()
        {
            int input;

            //Display Menu
            Console.Clear();
            Console.WriteLine("\t***Weclome to the Martinez-Van Flight System Sub-Menu***");
            Console.WriteLine("\t\t------------------------------------------------------");
            Console.WriteLine("1) Display flight information for the selected flight");
            Console.WriteLine("2) Display Passenger Manifest");
            Console.WriteLine("3) Edit flight information");
            Console.WriteLine("4) Add new passengers");
            Console.WriteLine("5) Submit the passenger manifest to TSA and update the manifest based on the returned list of flagged passengers.");
            Console.WriteLine("6) Exit the sub menu.\n");
            Console.Write("Please enter a number (1 to 6): ");

            input = VerifyMenuEntry(6);

            //Menu Options
            switch(input)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    break;
            }           
        }//End of Display SubMenu Method 


        /***************************/
        /*   Verify Input Method   */
        /***************************/
        public int VerifyMenuEntry(int numOfMenuEntries)
        {
            bool loop = true;
            int input = 0;

            do //Tests if User enters a numeric value
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());

                    //Tests if user enters a non-menu value
                    if (input < 1 || input > numOfMenuEntries)
                    {
                        Console.WriteLine("Invalid number. Try Again.");
                        Console.ReadKey();
                    }
                    else { loop = false; }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You did not enter a number. Try Again.");
                    Console.ReadKey();
                }
            } while (loop == true);

            return input;
        }//End of Verify Input Method
    }
}
