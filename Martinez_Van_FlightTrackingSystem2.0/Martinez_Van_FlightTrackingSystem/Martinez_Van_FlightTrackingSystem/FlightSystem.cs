// Project Alpha, Devin Martinez, CIS 345, Tuesday 1:30 PM
// Project Alpha, David Van, CIS 345, Tuesday 1:30 PM
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HomelandSecurity;

namespace Martinez_Van_FlightTrackingSystem
{
    class FlightSystem
    {
        static void Main(string[] args)
        {
            //Start Application
            DisplayMainMenu();
        }


        /********************************/
        /*   Display Main Menu Method   */
        /********************************/
        static private void DisplayMainMenu()
        {
            //Variables
            int input = 0;
            bool loop = true;
            int selectedFlight = 0;

            //Create basic temp flight to call methods if needed
            Flight temp = new Flight();

            //Create Flight Array to hold Flights. Given 20 elements to hold new entries.
            Flight[] flightList = new Flight[20];

            //Premade Flight Manifests
            Passenger[] flightManifest1 = new Passenger[20];
            Passenger[] flightManifest2 = new Passenger[20];
            Passenger[] flightManifest3 = new Passenger[20];

            //Premade Passengers
            Passenger passenger1 = new Passenger("Souma", "Yukihira", "111111");
            Passenger passenger2 = new Passenger("Erina", "Nakiri", "131313");
            Passenger passenger3 = new Passenger("Megumi", "Katou", "630274");
            Passenger passenger4 = new Passenger("Utaha", "Kasumigaoka", "172037");
            Passenger passenger5 = new Passenger("Eriri", "Sawamura", "936104");
            Passenger passenger6 = new Passenger("Yukino", "Yukinoshita", "777777");
            Passenger passenger7 = new Passenger("Yui", "Yuigahama", "190273");
            Passenger passenger8 = new Passenger("Tony", "Calzone", "854920");
            Passenger passenger9 = new Passenger("Ricki", "Stars", "131313");
            Passenger passenger10 = new Passenger("Devin", "Martinez", "666666");
            Passenger passenger11 = new Passenger("David", "Van", "999999");

            //Premade Flights
            Flight flight1 = new Flight(578, "Phoenix", "Tokyo", flightManifest1);
            Flight flight2 = new Flight(430, "San Diego", "New York", flightManifest2);
            Flight flight3 = new Flight(724, "Seattle", "Phoenix", flightManifest3);

            //Store Passengers in Flight 1
            flightManifest1[0] = passenger8;    //Tony C.
            flightManifest1[1] = passenger9;    //Ricki S.
            flightManifest1[2] = passenger10;   //Devin M.
            flightManifest1[3] = passenger11;   //David V.
            flightManifest1[4] = passenger3;    //Megumi K.
            flightManifest1[5] = passenger4;    //Utaha K.
            flightManifest1[6] = passenger5;    //Eriri S.

            //Store Passengers in Flight 2
            flightManifest2[0] = passenger3;    //Megumi K.
            flightManifest2[1] = passenger4;    //Utaha K.
            flightManifest2[2] = passenger5;    //Eriri S.
            flightManifest2[3] = passenger1;    //Souma Y.
            flightManifest2[4] = passenger2;    //Erina N.
            flightManifest2[5] = passenger6;    //Yukino Y.
            flightManifest2[6] = passenger7;    //Yui Y.

            //Store Passengers in Flight 3
            flightManifest3[0] = passenger1;    //Souma Y.
            flightManifest3[1] = passenger2;    //Erina N.
            flightManifest3[2] = passenger6;    //Yukino Y.
            flightManifest3[3] = passenger7;    //Yui Y.
            flightManifest3[4] = passenger8;    //Tony C.
            flightManifest3[5] = passenger9;    //Ricki S.
            flightManifest3[6] = passenger10;   //Devin M.
            flightManifest3[7] = passenger11;   //David V.

            //Store Flights in Flight List
            flightList[0] = flight1;    //Phoenix to Tokyo
            flightList[1] = flight2;    //San Diego to NY
            flightList[2] = flight3;    //Seattle to Phoenix


            /******************************/
            /*          Main Menu         */
            /******************************/
            do
            {
                //Display Menu
                Console.Clear();
                Console.WriteLine("\t\t*** Weclome to the Martinez-Van Flight System ***");
                Console.WriteLine("\t\t-------------------------------------------------\n\n");
                Console.WriteLine("1) Display a List of Flights");
                Console.WriteLine("2) Create New Flights");
                Console.WriteLine("3) Select a Flight");
                Console.WriteLine("4) Search by Passenger");
                Console.WriteLine("5) Exit\n");

                //Takes user input to Verify it is of correct type and within Range and returns the value
                input = VerifyMenuEntry();

                //Menu Options
                switch (input)
                {
                    case 1:
                        //Displays Flights. Takes a bool to loop back to the Main Menu
                        loop = temp.DisplayFlights(flightList);
                        break;
                    case 2:
                        //Create new flights
                        flightList = temp.CreateFlights(flightList);
                        break;
                    case 3:
                        //Select a flight
                        selectedFlight = temp.SelectFlights(flightList);
                        DisplaySubMenu(flightList, selectedFlight, temp);
                        break;
                    case 4:
                        //Search all flights for a particular passenger by first and last name
                        loop = temp.SearchFlights(flightList);
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

        /******************************/
        /*   Display SubMenu Method   */
        /******************************/
        static private void DisplaySubMenu(Flight[] flightList, int flightIndex, Flight temp)
        {
            //Variables
            int input;
            bool loop = true;

            do
            {
                //Display Menu
                Console.Clear();
                Console.WriteLine("\t***Weclome to the Martinez-Van Flight System Sub-Menu***");
                Console.WriteLine("\t--------------------------------------------------------");
                Console.WriteLine("\n\t\t        Flight Menu - Flight {0}", flightList[flightIndex].FlightNumber);
                Console.WriteLine("\n\t      {0,-8}{1,-20}-->     {2}\n\n", flightList[flightIndex].FlightNumber, flightList[flightIndex].FlightOrigin, flightList[flightIndex].FlightDestination);
                Console.WriteLine("1) Display Passenger Manifest");
                Console.WriteLine("2) Edit Flight Information");
                Console.WriteLine("3) Add New Passengers");
                Console.WriteLine("4) Run Passenger Security Check");
                Console.WriteLine("5) Exit to Main Menu.\n");

                input = VerifyMenuEntry();

                //Menu Options
                switch (input)
                {
                    case 1:
                        //Display Passenger list
                        loop = temp.DisplayPassenger(flightList, flightIndex);
                        break;
                    case 2:
                        //Edit flight info
                        loop = temp.EditFlight(flightList, flightIndex);
                        break;
                    case 3:
                        //Add new passengers
                        flightList[flightIndex].FlightManifest = temp.AddPassenger(flightList, flightIndex);
                        break;
                    case 4:
                        //Run Security Check
                        loop = temp.RunSecurity(flightList, flightIndex);
                        break;
                    case 5:
                        loop = false;
                        Console.WriteLine("Press any key to exit...");
                        Console.ReadKey();
                        break;
                }
            } while (loop == true);
        }//End of Display SubMenu Method 


        /***************************/
        /*   Verify Input Method   */
        /***************************/
        static private int VerifyMenuEntry()
        {
            bool loop = true;
            string input = "";
            int numCheck = 0;

            do //Tests if User enters a numeric value
            {
                Console.Write("Please enter a number (1 to 5): ");
                input = Console.ReadLine();

                try
                {
                    numCheck = Convert.ToInt32(input);

                    //Tests if user enters a non-menu value
                    if (numCheck < 1 || numCheck > 5)
                    {
                        Console.WriteLine("Invalid number. Try Again.\n");
                    }
                    else { loop = false; }
                }
                catch (FormatException)
                {
                    Console.WriteLine("You did not enter a number. Try Again.\n");
                }
            } while (loop == true);

            return numCheck;
        }//End of Verify Input Method
    }
}
