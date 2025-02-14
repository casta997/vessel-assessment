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
    //Creation of the service VessselService that use the interface IVesselService
    public class VesselService : IVesselService
    {
        
        //Method used to create bew vessels
        public void CreateVessel()
        {
            
            ReadVessel();
            Console.Write("\nEnter the IMO number for the new vessel: ");
            string newVessel = Console.ReadLine();
            
            int maxId = 0;
            foreach (Vessel vessel in VesselRepo.vessels)
            {
                if (vessel.Id > maxId)
                {
                    maxId = vessel.Id;
                }
            }
            int newId = maxId + 1;

            bool imoExists = false;
            foreach (Vessel vessel in VesselRepo.vessels)
            {
                if (vessel.ImoNumber == newVessel)
                {
                    imoExists = true;
                    break;
                }
            }

            if (!imoExists)
            {

                Vessel newVesselInList = new Vessel(newId, newVessel);
                VesselRepo.vessels.Add(newVesselInList);
                Console.WriteLine("\nVessel created with success! Press any key to continue...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("\nA vessel with this IMO number already exist! Press any key to continue...");
                Console.ReadLine();
            }
        }

        //Method used to create and insert 3 vessels into the list "vessels"
        public void CreateInitialVessels()
        {
            Vessel vesselRoma = new Vessel(1, "roma1");
            Vessel vesselRio = new Vessel(2, "rio1");
            Vessel vesselLivorno = new Vessel(3, "livorno1");
            VesselRepo.vessels.Add(vesselRoma);
            VesselRepo.vessels.Add(vesselRio);
            VesselRepo.vessels.Add(vesselLivorno);
        }

        //Method used to stamp the list "vessels"
        public void ReadVessel()
        {
            Console.WriteLine("\nList of vessels:\n" +
                            "\nID\tIMO NUMBER\n");

            foreach (Vessel vessel in VesselRepo.vessels)
            {
                Console.WriteLine($"{vessel}");
            }
        }

        //Method used to change the IMO number of a specific vessel
        public void UpdateVessel()
        {
            ReadVessel();
            Console.Write("\nEnter the IMO number of the vessel to update: ");
            string vesselToUpdate = Console.ReadLine();

            foreach (Vessel vessel in VesselRepo.vessels)
            {
                if (vessel.ImoNumber == vesselToUpdate)
                {
                    Console.Write("\nEnter the new IMO number: ");
                    string newImoNumber = Console.ReadLine();

                    vessel.ImoNumber = newImoNumber;
                    Console.WriteLine($"\nVessel with IMO number {vesselToUpdate} changed into {newImoNumber} with success! Press any key to continue...");
                    Console.ReadLine();
                    break;
                }
            }
        }

        //Method used to delete a vessel by his IMO number
        public void DeleteVessel()
        {
            ReadVessel();
            Console.Write("\nEnter the IMO number of the vessel to delete: ");
            string vesselToDelete = Console.ReadLine();

            foreach (Vessel vessel in VesselRepo.vessels)
            {
                if (vessel.ImoNumber == vesselToDelete)
                {
                    VesselRepo.vessels.Remove(vessel);
                    Console.WriteLine($"\nVessel with IMO number {vesselToDelete} deleted with success! Press any key to continue...");
                    Console.ReadLine();
                    break;
                }
            }
        }

        //Method used to show the menu and execute the action selected by the user
        public bool SelectActionOnVessel()
        {
            CreateInitialVessels();
            do
            {
                Console.Clear();
                Console.WriteLine("WELCOME TO THE VESSEL CONSOLE APP\n");
                Console.WriteLine("C) Create a vessel\n" +
                                    "R) Read list of vessels\n" +
                                    "U) Update a vessel\n" +
                                    "D) Delete a vessel\n" +
                                    "E) Exit");
                ReadVessel();
                Console.Write("\nSelected action: ");
                string choiceSelected = Console.ReadLine().ToUpper();
                Console.Clear();
                switch (choiceSelected)
                {
                    case "C":
                        Console.WriteLine($"Selected action: {choiceSelected}");
                        CreateVessel();
                        break;
                    case "R":
                        Console.WriteLine($"Selected action: {choiceSelected}");
                        ReadVessel();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        break;
                    case "U":
                        Console.WriteLine($"Selected action: {choiceSelected}");
                        UpdateVessel();
                        break;
                    case "D":
                        Console.WriteLine($"Selected action: {choiceSelected}");
                        DeleteVessel();
                        break;
                    case "E":
                        return false;
                    default: 
                        Console.WriteLine("\nSelect a valid option from the menu! Press any key to continue...");
                        Console.ReadLine();
                        break;
                }
            }
            while (true);
        }
    }
}
