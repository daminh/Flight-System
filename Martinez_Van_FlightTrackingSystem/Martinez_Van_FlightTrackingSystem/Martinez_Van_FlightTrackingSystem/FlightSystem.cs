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
            FlightSystem.LoadTempData();
        }

        private static void LoadTempData()
        {
            //Create Flight to Display Menu
            Flight temp = new Flight();

            //Create Flight Array to hold Flights. Given 20 elements to hold new entries.
            Flight[] flightList = new Flight[20];

            //Premade Flights
            Flight flight1 = new Flight(578, "Tokyo", "Phoenix");
            Flight flight2 = new Flight(430, "New York", "San Diego");
            Flight flight3 = new Flight(724, "Phoenix", "Seattle");

            //Store Flights in Fligt List
            flightList[0] = flight1;
            flightList[1] = flight2;
            flightList[2] = flight3;

            //Display Main Menu
            temp.DisplayMainMenu(flightList);
        }
    }
}
