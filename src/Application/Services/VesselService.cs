using Application.Interfaces;
using Application.Models;
using Application.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    //Vessel service 
    public class VesselService : IVesselService
    {
        public void CreateVessel()
        {

        }

        //Method that create some vessels to add in the list
        public void CreateSomeVessel()
        {
            Vessel genovaVessel = new Vessel(1, "genova1");
            Vessel rioVessel = new Vessel(2, "rio1");
            Vessel livornoVessel = new Vessel(3, "livorno1");
            VesselRepo.vessels.Add(genovaVessel);
            VesselRepo.vessels.Add(rioVessel);
            VesselRepo.vessels.Add(livornoVessel);
        }

        //Method that display the "vessels" list
        public void ReadVessel()
        {
            Console.WriteLine("\nList of the vessels: ");
            Console.WriteLine("\nID\tIMO NUMBER");

            //Foreach object vessel inside of the list vessels the program write their values
            foreach (Vessel vessel in VesselRepo.vessels)
            {
                Console.WriteLine(vessel);
            }
        }

        public void UpdateVessel()
        {

        }

        public void DeleteVessel()
        {

        }


        //Method that display the menu and handle the user selection
        public bool SelectActionOnVessel()
        {
            //Call the method that create some new vessels, this way from the beginning there are some vessels 
            CreateSomeVessel();

            do
            {
                //Clear the console after a cycle
                Console.Clear();

                //Use of escape characters to display the menu more nicely
                Console.WriteLine("WELCOME TO THE VESSEL CONSOLE APP");
                Console.WriteLine("\nC.) Create a vessel" +
                                    "\nR.) Read list of vessels" +
                                    "\nU.) Update a vessel" +
                                    "\nD.) Delete a vessel" +
                                    "\nE.) Exit");

                //Show the list of vessels as soon as the application starts
                ReadVessel();

                //Ask and read the input provided by the user
                Console.Write("\nSelect an option: ");
                string selectedAction = Console.ReadLine().ToUpper();

                //Clear the console after an option is selected
                Console.Clear();

                //Switch case that use the input provided by the user previously saved in the variable selectedAction (string)
                switch (selectedAction)
                {
                    case "C":

                        //Show witch option was selected
                        Console.WriteLine($"\nOption selected: {selectedAction}");

                        //Call the method that create a new vessel
                        CreateVessel();
                        break;

                    case "R":

                        //Show witch option was selected
                        Console.WriteLine($"\nOption selected: {selectedAction}");

                        //Call the method that display the list of vessels
                        ReadVessel();

                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        break;

                    case "U":

                        //Show witch option was selected
                        Console.WriteLine($"\nOption selected: {selectedAction}");

                        //Call the method that update the IMO number of a specific vessel
                        UpdateVessel();
                        break;

                    case "D":

                        //Show witch option was selected
                        Console.WriteLine($"\nOption selected: {selectedAction}");

                        //Call the method that delete a specific vessel
                        DeleteVessel();
                        break;

                    case "E":

                        //Return false so the user can get out from the do while cycle and close the program
                        return false;

                    default:

                        //Show which option was selected
                        Console.WriteLine($"\nOption selected: {selectedAction}");

                        //Message for a wrong input
                        Console.WriteLine("\nError!! Select a valid option from the menu. Press any key to continue...");

                        //Stop the application and wait for an input, this way the user can read the message before the console clear
                        Console.ReadLine();
                        break;
                }
            }
            while (true);
        }
    }
}