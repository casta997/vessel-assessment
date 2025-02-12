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
            Console.Write("Enter the imo number for the new vessel: ");
            string newVesselImoNumber = Console.ReadLine();

            Vessel lastVessel = vessels.LastOrDefault();
            int newId = (lastVessel != null) ? lastVessel.Id + 1 : 1;

            Vessel newVesselInList = new()
            {
                Id = newId,
                ImoNumber = newVesselImoNumber
            };
            vessels.Add(newVesselInList);
            Console.WriteLine($"\nThe vessel with imo number {newVesselImoNumber} was saved successfully!\n" +
                                   "-----------------------------");
            
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
                Console.WriteLine("List of the vessels: \n");

                string roof = new string('-', 25);
                Console.WriteLine($"{roof}");
                Console.WriteLine($"| {"Id",-5} | {"IMO Number",-15} |");
                Console.WriteLine($"| {new string('-', 5)} | {new string('-', 15)} |");

                vessels.ForEach(v => Console.WriteLine($"| {v.Id,-5} | {v.ImoNumber,-15} |\n{roof}"));
            }
            else
            {
                Console.WriteLine("The vessels list is empty\n"+
                                   "-----------------------------");
            }
        }

        //Method to modify a vessel imo number
        public void UpdateVessel() 
        {
            Console.Write("Enter the imo number of the vessel that you want to modify: ");
            string vesselToModify = Console.ReadLine();

            Vessel vessel = vessels.FirstOrDefault(v => v.ImoNumber == vesselToModify);
            if (vessel != null)
            {
                Console.Write("Enter the new imo number: ");
                string imoNumberModified = Console.ReadLine();

                vessel.ImoNumber = imoNumberModified;
                Console.WriteLine($"\nThe vessel with imo number {vesselToModify} was modified successfully into {imoNumberModified}!\n" +
                                   "-----------------------------");
            }
            else
            {
                Console.WriteLine("\nError!! This vessel was not found.\n" +
                                   "-----------------------------");
            }
        }

        public void DeleteVessel()
        {
            Console.Write("Enter the imo number of the vessel that you want to delete: ");
            string vesselToDelete = Console.ReadLine();

            Vessel vessel = vessels.FirstOrDefault(v => v.ImoNumber == vesselToDelete);
            if (vessel != null)
            {
                vessels.Remove(vessel);
                Console.WriteLine($"\nThe vessel with imo number {vesselToDelete}  was deleted successfully!\n" +
                                   "-----------------------------");
            }
            else
            {
                Console.WriteLine("\nError!! This vessel was not found.\n" +
                                   "-----------------------------");
            }
        }

        //Method for the selection of the user
        public bool SelectActionOnVessel()
        {
            //Comment this line to see what happens when the listof vessels is empty
            CreateExampleOfVessel();
            do
            {
                Console.WriteLine("WELCOME TO VESSEL COMPANY\n\n"+
                                   "Select an action:\n\n"+
                                   "1) Create a new vessel\n"+
                                   "2) Read list of vessels avaiable\n"+
                                   "3) Modify a vessel\n"+
                                   "4) Delete a vessel\n"+
                                   "5) Exit\n");
                choiceSelected = Console.ReadLine();
                //Console.Clear(); Un comment this to clear the menu after every choice

                switch (choiceSelected)
                {
                    case "1":
                        Console.WriteLine($"Action selected {choiceSelected}\n");
                        CreateVessel();
                        RepeatActionOnVessel();
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine($"Action selected {choiceSelected}\n");
                        ReadVessel();
                        Console.ReadLine();
                        break;
                    case "3":
                        if (vessels.Count != 0)
                        {
                            Console.WriteLine($"Action selected {choiceSelected}\n");
                            UpdateVessel();
                        }
                        else
                        {
                            Console.WriteLine("\nThe vessel list is empty, you can't modify elements.\n"+
                                   "-----------------------------");
                        }
                        RepeatActionOnVessel();
                        Console.ReadLine();
                        break;
                    case "4":
                        if (vessels.Count != 0)
                        {
                            Console.WriteLine($"Action selected {choiceSelected}\n");
                            DeleteVessel();
                        }
                        else
                        {
                            Console.WriteLine("\nThe vessel list is empty, you can't delete elements.\n" +
                                   "-----------------------------");
                        }
                        RepeatActionOnVessel();
                        Console.ReadLine();
                        break;
                    case "5":
                        return false;
                    default:
                        Console.WriteLine("\nError!! Choose an action from the menu, 1 to 5.\n");
                        break;
                }
                Console.Clear();
            }
            while (true);
        }

        //Method to repeat the last action selected from the menu
        public bool RepeatActionOnVessel()
        {
            do
            {
                Console.WriteLine("Do you want to repeat the action?\n\n" +
                                "1) Yes\n" +
                                "2) No\n");
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
                    Console.WriteLine("Error!! Select a valid option.");
                }
            }
            while(true);
        }
    }
}
