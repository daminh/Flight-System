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
        private Passenger[] flightManifest;

        //Basic Constructor
        public Flight()
        {}

        //Main Flight Constructor
        public Flight(int flightNumber, string flightOrigin, string flightDestination, Passenger[] flightManifest)
        {
            this.flightNumber = flightNumber;
            this.flightDestination = flightDestination;
            this.flightOrigin = flightOrigin;
            this.flightManifest = flightManifest;
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

        public Passenger[] FlightManifest
        {
            get { return flightManifest; }
            set { flightManifest = value; }
        }

        public int PassengerCount
        {
            get 
            {
                int counter = 0;
                for (int i = 0; i < FlightManifest.Length; i++)
                {
                    if(FlightManifest[i] != null)
                    { counter++; }
                }

                return counter;
            }
        }


        /**************************/
        /*   Main Menu Option 1   */
        /**************************/
        public bool DisplayFlights(Flight[] flightList)
        {
            int counter = 0;

            //Counts how many elements in the array are filled
            for (int i = 0; i < flightList.Length; i++)
            {
                if (flightList[i] != null)
                { counter++; }
            }

            //Displays Header
            Console.Clear();
            Header();
            Console.WriteLine("\t\t\t      Current Flights      \n\n");

            //Displays Flights
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("{0,4}. {1,-8}{2,-20}-->     {3}\n", i + 1, flightList[i].FlightNumber, flightList[i].FlightOrigin, flightList[i].FlightDestination);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            //Lets the application loop back to the main menu
            return true;
        }


        /**************************/
        /*   Main Menu Option 2   */
        /**************************/
        public Flight[] CreateFlights(Flight[] flightList)
        {
            string input = "";
            int numCheck = 0;
            int counter = 0;

            //Counts how many elements in the array are filled
            for (int i = 0; i < flightList.Length; i++)
            {
                if (flightList[i] != null)
                { counter++; }
            }

            if (counter < 20)
            {
                //Create Flight at next available spot in the array
                flightList[counter] = new Flight();

                //Clear Screen and Add Header
                Console.Clear();
                Header();
                Console.WriteLine("\t\t\t        Add Flight        \n\n");

                //Flight Number
                numCheck = VerifyInputIsNum("Enter Flight Number between 1 and 999: ");
                flightList[counter].FlightNumber = numCheck;

                //Flight Origin
                Console.Write("\nEnter Origin: ");
                input = Console.ReadLine();
                flightList[counter].FlightOrigin = input;

                //Flight Destination
                Console.Write("\nEnter Destination: ");
                input = Console.ReadLine();
                flightList[counter].FlightDestination = input;

                //Create new Flight Manifest
                Passenger[] newManifest = new Passenger[20];
                flightList[counter].FlightManifest = newManifest;
            }
            else
            {
                Console.WriteLine("Flight List is full. No more flights can be added at this time.");
            }

            return flightList;
        }


        /**************************/
        /*   Main Menu Option 3   */
        /**************************/
        public int SelectFlights(Flight[] flightList)
        {
            /**************************/
            /*Taken from DisplayFlight*/
            int counter = 0;

            //Counts how many elements in the array are filled
            for (int i = 0; i < flightList.Length; i++)
            {
                if (flightList[i] != null)
                { counter++; }
            }

            //Displays Header
            Console.Clear();
            Header();
            Console.WriteLine("\t\t\t      Current Flights      \n\n");

            //Displays Flights
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("{0,4}. {1,-8}{2,-20}-->     {3}\n", i + 1, flightList[i].FlightNumber, flightList[i].FlightOrigin, flightList[i].FlightDestination);
            }
            /**************************/

            int numCheck = 0;
            bool continueLoop = true;
            
            do{
                //Ask for flight and verify number
                numCheck = VerifyInputIsNum("Enter Option Number: ");

                if (numCheck < 1 || numCheck > (counter + 1))
                { continueLoop = true; }
                else
                { continueLoop = false; }
            } while (continueLoop == true);

            //Return the number of the flight selected minus 1 to get the array index
            return numCheck - 1;
        }


        /**************************/
        /*   Main Menu Option 4   */
        /**************************/
        public bool SearchFlights(Flight[] flightList)
        {
            string fName = "";
            string lName = "";
            int counter = 0;
            bool record = false;
            bool header = false;

            //Displays Header
            Console.Clear();
            Header();
            Console.WriteLine("\t\t\t      Find Passenger      \n\n");

            Console.Write("Enter Passenger First Name: ");
            fName = Console.ReadLine();
            Console.Write("Enter Passenger Last Name: ");
            lName = Console.ReadLine();

            //Counts how many elements in the array are filled
            for (int i = 0; i < flightList.Length; i++)
            {
                if (flightList[i] != null)
                { counter++; }
            }

            for (int i = 0; i < counter; i++)
            {

                for (int j = 0; j < flightList[i].PassengerCount; j++)
                {

                    if (((flightList[i].FlightManifest[j].FirstName.ToLower()) == fName.ToLower()) && ((flightList[i].FlightManifest[j].LastName.ToLower()) == lName.ToLower()))
                    {
                        if (header == false)
                        {
                            Console.WriteLine("\nFlight   First Name     Last Name     Loyalty Number\n");
                            header = true;
                        }
                        Console.WriteLine("{0,-9}{1,-15}{2,-15}{3,-19}", flightList[i].FlightNumber, flightList[i].FlightManifest[j].FirstName, flightList[i].FlightManifest[j].LastName, flightList[i].FlightManifest[j].LoyaltyNumber);
                        record = true;
                    }                   
                }
            }

            if(record == false)
            { Console.WriteLine("\nNo Records Found."); }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            //Lets the application loop back to the main menu
            return true;
        }


        /**************************/
        /*    SubMenu Option 1    */
        /**************************/
        public bool DisplayPassenger(Flight[] flightList, int flightIndex)
        {
            int counter = 0;

            //Counts how many elements in the array are filled
            for (int i = 0; i < (flightList[flightIndex].FlightManifest).Length; i++)
            {
                if (flightList[flightIndex].FlightManifest[i] != null)
                { counter++; }
            }

            //Displays Header
            Console.Clear();
            Header();
            Console.WriteLine("\t\t\t    Current Passengers     \n\n");

            //Displays Passengers
            Console.WriteLine("Number   First Name     Last Name     Loyalty Number     Flagged\n\n");
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("{0,-9}{1,-15}{2,-15}{3,-19}{4}", i + 1, flightList[flightIndex].FlightManifest[i].FirstName, flightList[flightIndex].FlightManifest[i].LastName, flightList[flightIndex].FlightManifest[i].LoyaltyNumber, flightList[flightIndex].FlightManifest[i].SecurityFlag);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            //Lets the application loop back to the sub menu
            return true;
        }


        /**************************/
        /*    SubMenu Option 2    */
        /**************************/
        public bool EditFlight(Flight[] flightList, int flightIndex)
        {
            string input = "";
            int numCheck = 0;

            //Displays Header
            Console.Clear();
            Header();
            Console.WriteLine("\t\tEdit Flight Information - Flight {0}\n\n", flightList[flightIndex].FlightNumber);
            Console.WriteLine("\n{0,-8}{1,-20}-->     {2}\n\n", flightList[flightIndex].FlightNumber, flightList[flightIndex].FlightOrigin, flightList[flightIndex].FlightDestination);

            //Flight Number
            numCheck = VerifyInputIsNum("Enter New Flight Number between 1 and 999: ");
            flightList[flightIndex].FlightNumber = numCheck;

            //Flight Origin
            Console.Write("\nEnter New Origin: ");
            input = Console.ReadLine();
            flightList[flightIndex].FlightOrigin = input;

            //Flight Destination
            Console.Write("\nEnter New Destination: ");
            input = Console.ReadLine();
            flightList[flightIndex].FlightDestination = input;


            Console.WriteLine("Flight information updated...");

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            //Lets the application loop back to the sub menu
            return true;
        }


        /**************************/
        /*    SubMenu Option 3    */
        /**************************/
        public Passenger[] AddPassenger(Flight[] flightList, int flightIndex)
        {
            string input = "";
            int counter = 0;

            //Counts how many elements in the array are filled
            for (int i = 0; i < (flightList[flightIndex].FlightManifest).Length; i++)
            {
                if (flightList[flightIndex].FlightManifest[i] != null)
                { counter++; }
            }

            if (counter < 20)
            {
                //Create Flight at next available spot in the array
                flightList[flightIndex].FlightManifest[counter] = new Passenger();

                //Clear Screen and Add Header
                Console.Clear();
                Header();
                Console.WriteLine("\t\t\t      Add Passenger       \n\n");

                //Passenger First Name
                Console.Write("\nEnter Passenger First Name: ");
                input = Console.ReadLine();
                flightList[flightIndex].FlightManifest[counter].FirstName = input;

                //Passenger Last Name
                Console.Write("\nEnter Passenger Last Name: ");
                input = Console.ReadLine();
                flightList[flightIndex].FlightManifest[counter].LastName = input;

                //Passenger Loyalty Number
                Console.Write("\nEnter Passenger Loyalty Number: ");
                input = Console.ReadLine();
                flightList[flightIndex].FlightManifest[counter].LoyaltyNumber = input; ;
            }
            else
            {
                Console.WriteLine("Passenger List is full. No more passengers can be added at this time.");
            }

            return flightList[flightIndex].FlightManifest;
        }


        /**************************/
        /*    SubMenu Option 4    */
        /**************************/
        public bool RunSecurity(Flight[] flightList, int flightIndex)
        {
            FlaggedPassenger[] flaggedList = new FlaggedPassenger[20];
            TSA security = new TSA();
            flaggedList = security.RunSecurityCheck(flightList[flightIndex].FlightManifest, flightList[flightIndex].PassengerCount);
            
            int counter = 0;

            //Counts how many elements in the array are filled
            for (int i = 0; i < flaggedList.Length; i++)
            {
                if (flaggedList[i] != null)
                { counter++; }
            }

            //Loop through each flagged passenger, comparing their name to the flight manifest, and flagging them if equal
            for (int i = 0; i < counter; i++)
            {
                for(int j = 0; j < flightList[flightIndex].PassengerCount; j++)
                {
                    if (((flightList[flightIndex].FlightManifest[j].FirstName) == flaggedList[i].FirstName) && ((flightList[flightIndex].FlightManifest[j].LastName) == flaggedList[i].LastName))
                    {
                        flightList[flightIndex].FlightManifest[i].SecurityFlag = true;
                    }
                }
            }
            
            Console.WriteLine("\nSecurity Check Complete. Manifest updated.");
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

            //Lets the application loop back to the sub menu
            return true;
        }


        /***************************/
        /*      Header Method      */
        /***************************/
        public void Header()
        {
            Console.WriteLine("\t\t\tMartinez-Van Flight System");
            Console.WriteLine("\t\t\t       --- MVFS ---       \n");
        }

        /***************************/
        /*   Verify Input Method   */
        /***************************/
        private int VerifyInputIsNum(string question)
        {
            bool loop = true;
            string input = "";
            int numCheck = 0;

            do //Tests if User enters a numeric value
            {
                Console.Write(question);
                input = Console.ReadLine();

                try
                {
                    numCheck = Convert.ToInt32(input);
                    loop = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("You did not enter a number. Try Again\n");  
                }
            } while (loop == true);

            return numCheck;
        }//End of Verify Input Method
    }
}
