using Application.Interfaces;
using Application.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            Console.WriteLine("\nEnter a new vessel");
            Console.Write("Imo number: ");
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
                Console.WriteLine("\nList of all the vessel: \n");
                vessels.ForEach(i => Console.WriteLine("{0}\n", i));
                Console.WriteLine("-----------------------------");
            }
            else
            {
                Console.WriteLine("\nThe vessels list is empty\n"+
                                   "-----------------------------");
            }
        }

        public void UpdateVessel() 
        {

        }

        public void DeleteVessel()
        {

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
                        Console.WriteLine($"Action selected {choiceSelected}");
                        CreateVessel();
                        break;
                    case "2":
                        Console.WriteLine($"Action selected {choiceSelected}\n");
                        ReadVessel();
                        break;
                    case "3":
                        Console.WriteLine($"Action selected {choiceSelected}\n");
                        UpdateVessel();
                        break;
                    case "4":
                        Console.WriteLine($"Action selected {choiceSelected}\n");
                        DeleteVessel();
                        break;
                    case "5":
                        return false;
                    default:
                        Console.WriteLine("Error!! Choose an action from the menu, 1 to 5.");
                        break;
                }
            }
            while (true);
        }
    }
}
