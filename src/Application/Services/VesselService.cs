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
        public static int counter = vessels.Count();

        //Method to create and add new vessel to the list vessels
        public void CreateVessel()
        {
            Console.Write("Enter the imo number for the new vessel: ");
            string newVesselImoNumber = Console.ReadLine();
            
            Vessel newVesselInList = new()
            {
                Id = counter + 1,
                ImoNumber = newVesselImoNumber
            };
            vessels.Add(newVesselInList);
            Console.WriteLine($"\nThe vessel with imo number {newVesselImoNumber} was saved successfully!\n" +
                                   "-----------------------------");
        }

        //Method to stamp all the vessels inside the list vessels
        public void ReadVessel()
        {
            if (vessels.Count() != 0)
            {
                Console.WriteLine("List of the vessels: \n");
                vessels.ForEach(i => Console.WriteLine("{0}\n", i));
                Console.WriteLine("-----------------------------");
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
            do
            {
                Console.WriteLine("WELCOME TO VESSEL COMPANY\n\n"+
                                   "Select an action:\n\n"+
                                   "1) Create a new vessel\n"+
                                   "2) Read list of vessels avaiable\n"+
                                   "3) Modify a vessel\n"+
                                   "4) Delete a vessel\n"+
                                   "5) Exit\n");
                string choiceSelected = Console.ReadLine();

                switch (choiceSelected)
                {
                    case "1":
                        Console.WriteLine($"Action selected {choiceSelected}\n");
                        CreateVessel();
                        break;
                    case "2":
                        Console.WriteLine($"Action selected {choiceSelected}\n");
                        ReadVessel();
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
                        break;
                    case "5":
                        return false;
                    default:
                        Console.WriteLine("\nError!! Choose an action from the menu, 1 to 5.\n");
                        break;
                }
            }
            while (true);
        }
    }
}
