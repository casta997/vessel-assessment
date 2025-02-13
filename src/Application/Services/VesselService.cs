using Application.Interfaces;
using Application.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static Application.Repos.DataStorage;

namespace Application.Services
{
    /*
     *  Creating the class VesselService with the method from the 
     *  interface IVesselService
    */
    public class VesselService : IVesselService
    {
        public static string choiceSelected = string.Empty;

        //Method to create and add new vessel to the list vessels
        public void CreateVessel()
        {
            Console.Write("\nEnter the IMO number for the new vessel: ");
            string newVesselImoNumber = Console.ReadLine();

            if (!string.IsNullOrEmpty(newVesselImoNumber))
            {
                Vessel lastVessel = vessels.LastOrDefault();
                int newId = (lastVessel != null) ? lastVessel.Id + 1 : 1;

                Vessel newVesselInList = new()
                {
                    Id = newId,
                    ImoNumber = newVesselImoNumber
                };
                vessels.Add(newVesselInList);
                Console.WriteLine($"\nThe vessel with IMO number {newVesselImoNumber} was saved successfully! Press any key to continue...\n" +
                                       "-----------------------------");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nInsert a valid IMO number, at least one character. Press any key to continue...\n" +
                                       "-----------------------------");
                Console.ReadLine();
            }
        }

        //Method that create 3 vessels and add them into the list
        public void CreateExampleOfVessel()
        {
            Vessel vesselGenova = new() { Id = 1, ImoNumber = "genova1"};
            Vessel vesselRoma = new() { Id = 2, ImoNumber = "roma1"};
            Vessel vesselVenezia = new() { Id = 3, ImoNumber = "venezia1"};
            vessels.Add(vesselGenova);
            vessels.Add(vesselRoma);
            vessels.Add(vesselVenezia);
        }

        //Method to stamp all the vessels inside the list vessels
        public void ReadVessel()
        {
            if (vessels.Count() != 0)
            {
                Console.WriteLine("\nList of the vessels: \n");

                string roof = new string('-', 27);
                Console.WriteLine($"{roof}");
                Console.WriteLine($"| {"Id",-5} | {"IMO Number",-15} |");
                Console.WriteLine($"| {new string('-', 5)} | {new string('-', 15)} |");

                vessels.ForEach(v => Console.WriteLine($"| {v.Id,-5} | {v.ImoNumber,-15} |\n{roof}"));
            }
            else
            {
                Console.WriteLine("\nThe vessels list is empty\n"+
                                   "-----------------------------");
            }
        }

        //Method to modify a vessel imo number
        public void UpdateVessel() 
        {
            Console.Write("\nEnter the IMO number of the vessel that you want to modify: ");
            string vesselToModify = Console.ReadLine();

            Vessel vessel = vessels.FirstOrDefault(v => v.ImoNumber == vesselToModify);
            if (vessel != null)
            {
                Console.Write("Enter the new IMO number: ");
                string imoNumberModified = Console.ReadLine();

                vessel.ImoNumber = imoNumberModified;
                Console.WriteLine($"\nThe vessel with IMO number {vesselToModify} was modified successfully into {imoNumberModified}! Press any key to continue...\n" +
                                   "-----------------------------");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nError!! This vessel was not found. Press any key to continue...\n" +
                                   "-----------------------------");
                Console.ReadLine();
            }
        }

        //Method to delete vessels
        public void DeleteVessel()
        {
            Console.Write("\nEnter the IMO number of the vessel that you want to delete: ");
            string vesselToDelete = Console.ReadLine();

            Vessel vessel = vessels.FirstOrDefault(v => v.ImoNumber == vesselToDelete);
            if (vessel != null)
            {
                vessels.Remove(vessel);
                Console.WriteLine($"\nThe vessel with IMO number {vesselToDelete}  was deleted successfully! Press any key to continue...\n" +
                                   "-----------------------------");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nError!! This vessel was not found. Press any key to continue...\n" +
                                   "-----------------------------");
                Console.ReadLine();
            }
        }

        //Method for the selection of the user
        public bool SelectActionOnVessel()
        {
            //Comment this line to see what happens when the listof vessels is empty
            CreateExampleOfVessel();
            do
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO VESSEL COMPANY\n\n"+
                                   "Select an action:\n\n"+
                                   "1.C) Create a new vessel\n"+
                                   "2.R) Read list of vessels avaiable\n"+
                                   "3.U) Modify a vessel\n"+
                                   "4.D) Delete a vessel\n"+
                                   "5.E) Exit\n");
                ReadVessel();
                Console.Write("\nSelect action: ");
                choiceSelected = Console.ReadLine().ToUpper();
                Console.Clear(); //Un comment this to clear the menu after every choice
                
                switch (choiceSelected)
                {
                    case "1":
                    case "C":
                        ReadVessel();
                        CreateVessel();
                        RepeatActionOnVessel();
                        break;
                    case "2":
                    case "R":
                        ReadVessel();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        break;
                    case "3":
                    case "U":
                        if (vessels.Count != 0)
                        {
                            ReadVessel();
                            UpdateVessel();
                        }
                        else
                        {
                            Console.WriteLine("\nThe vessel list is empty, you can't modify elements." +
                                   "-----------------------------");
                            Console.ReadLine();
                        }
                        RepeatActionOnVessel();
                        break;
                    case "4":
                    case "D":
                        if (vessels.Count != 0)
                        {
                            ReadVessel();
                            DeleteVessel();
                        }
                        else
                        {
                            Console.WriteLine("\nThe vessel list is empty, you can't delete elements." +
                                   "-----------------------------");
                            Console.ReadLine();
                        }
                        RepeatActionOnVessel();
                        break;
                    case "5":
                    case "E":
                        return false;
                    default:
                        Console.WriteLine("\nError!! Choose an action from the menu. Press any key to continue...\n");
                        Console.ReadLine();
                        break;
                }
            }
            while (true);
        }

        //Method to repeat the last action selected from the menu
        public bool RepeatActionOnVessel()
        {  
            do
            {
                //Console.Clear();
                if (vessels.Count != 0)
                {
                    Console.Clear();
                    ReadVessel();
                    Console.WriteLine("\nDo you want to repeat the action?\n\n" +
                                    "1) Yes\n" +
                                    "2) No\n");
                    Console.Write("Select action: ");
                    string repeatChoiceSelected = Console.ReadLine();

                    if (repeatChoiceSelected == "1")
                    {
                        switch (choiceSelected)
                        {
                            case "1":
                                CreateVessel();
                                break;
                            case "3":
                                UpdateVessel();
                                break;
                            case "4":
                                DeleteVessel();
                                break;
                            default:
                                Console.WriteLine("Error!!");
                                break;
                        }
                    }
                    else if (repeatChoiceSelected == "2")
                    {
                        return false;
                    }
                    else
                    {
                        Console.WriteLine("\nError!! Select a valid option, 1 or 2. Press any key to continue...\n");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("\nThe list is empty, press any key to continue...");
                    Console.ReadLine();
                    return false;
                }
            }
            while (true);
        }
    }
}
