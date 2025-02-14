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
            ReadVessel();
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
            Console.WriteLine("\nID\tIMO NUMBER\n");

            //Foreach object vessel inside of the list vessels the program write their values
            foreach (Vessel vessel in VesselRepo.vessels)
            {
                Console.WriteLine(vessel);
            }
        }

        //Method that let the user modify the IMO number of a vessel
        public void UpdateVessel()
        {
            ReadVessel();

            Console.Write("\nEnter the IMO number of the vessel to update: ");
            string vesselToUpdate = Console.ReadLine();

            //Declaration of 2 local scope
            bool vesselExist = false;
            Vessel vesselFound = null;

            //For every vessel in vessels see if one has the same IMO number wrote by the user
            foreach (Vessel vessel in VesselRepo.vessels)
            {
                if (vessel.ImoNumber == vesselToUpdate)
                {
                    vesselExist = true;


                    //The object vessel is not accessible outside so it's being memorized in the variable vesselFound
                    vesselFound = vessel;
                    break;
                }
            }

            //If there is a match the method ask for the new IMO number and save it 
            if (vesselExist == true)
            {
                Console.Write("\nEnter the new IMO number: ");
                string newImoNumber = Console.ReadLine();

                //If the new IMO number has at least one character than the value is saved 
                if (newImoNumber.Length > 0)
                {
                    vesselFound.ImoNumber = newImoNumber;
                    Console.WriteLine($"\nVessel with IMO number {vesselToUpdate} updated with success into {newImoNumber}! Press any key to continue...");
                    Console.ReadLine();
                }
                //If the new IMO number length is 0 this message shows up
                else
                {
                    Console.WriteLine("\nThe IMO number must have at least one character. Press any key to continue...");
                    Console.ReadLine();
                }
            }
            //If there is no match the method show this message
            else
            {
                Console.WriteLine($"\nVessel not found with IMO number {vesselToUpdate} not found. Press any key to continue...");
                Console.ReadLine();
            }
        }

        //Method that make the user delete a vessel
        public void DeleteVessel()
        {
            ReadVessel();

            Console.Write("\nEnter the IMO number of the vessel to delete: ");
            string vesselToDelete = Console.ReadLine();

            //Declaration of 2 local scope
            bool vesselExist = false;
            Vessel vesselFound = null;

            //For every vessel in vessels check if one has the same IMO number wrote by the user
            foreach (Vessel vessel in VesselRepo.vessels)
            {
                if (vessel.ImoNumber == vesselToDelete)
                {
                    vesselExist = true;

                    //The object needs to be removed entirely and vessel is not accessible outside the foreach so now the vessel found lives inside the variable vesselFound
                    vesselFound = vessel;
                    break;
                }
            }

            //If there is a match the vessel is removed 
            if (vesselExist == true)
            {
                VesselRepo.vessels.Remove(vesselFound);
                Console.WriteLine($"\nVessel with IMO number {vesselToDelete} deleted with success! Press any key to continue...");
                Console.ReadLine();
            }
            //If there is no match than nothing is removed 
            else
            {
                Console.WriteLine($"\nVessel with IMO number {vesselToDelete} not found. Press any key to continue...");
                Console.ReadLine();
            }
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