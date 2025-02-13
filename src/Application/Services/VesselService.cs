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
            Console.WriteLine("\nList of vessels:\n");
            Console.WriteLine(VesselRepo.vessels.Count());
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
                Console.WriteLine("1.C) Create a vessel\n" +
                                    "2.R) Read list of vessels\n" +
                                    "3.U) Update a vessel\n" +
                                    "4.D) Delete a vessel\n" +
                                    "5.E) Exit\n");
                Console.Write("Selected action: ");
                string choiceSelected = Console.ReadLine().ToUpper();

                switch (choiceSelected)
                {
                    case "1":
                    case "C":
                        Console.WriteLine("crea");
                        break;
                    case "2":
                    case "R":
                        Console.WriteLine("leggi");
                        ReadVessel();
                        break;
                    case "3":
                    case "U":
                        Console.WriteLine("modifica");
                        break;
                    case "4":
                    case "D":
                        Console.WriteLine("elimina");
                        break;
                    case "5":
                    case "E":
                        return false;
                    default: 
                        Console.WriteLine("Select a valid option from the menu!");
                        break;
                }
            }
            while (true);
        }
    }
}
