using Application.Interfaces;
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
        public void ReadVessel()
        {

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
