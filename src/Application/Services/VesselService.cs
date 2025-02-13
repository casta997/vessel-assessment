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
        public void CreateVessel()
        {

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
        public void UpdateVessel()
        {

        }
        public void DeleteVessel()
        {

        }

        //Method used to show the menu and execute the action selected by the user
        public bool SelectActionOnVessel()
        {
            CreateInitialVessels();
            do
            {
                Console.WriteLine("WELCOME TO THE VESSEL CONSOLE APP\n");
                Console.WriteLine("C) Create a vessel\n" +
                                    "R) Read list of vessels\n" +
                                    "U) Update a vessel\n" +
                                    "D) Delete a vessel\n" +
                                    "E) Exit");
                ReadVessel();
                Console.Write("\nSelected action: ");
                string choiceSelected = Console.ReadLine().ToUpper();

                switch (choiceSelected)
                {
                    case "C":
                        Console.WriteLine("crea");
                        break;
                    case "R":
                        ReadVessel();
                        Console.WriteLine("\nPress any key to continue...");
                        Console.ReadLine();
                        break;
                    case "U":
                        Console.WriteLine("modifica");
                        break;
                    case "D":
                        Console.WriteLine("elimina");
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
