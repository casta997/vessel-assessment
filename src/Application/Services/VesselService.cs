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
            Console.WriteLine("Enter a new vessel");
            Console.WriteLine("Imo number: ");
            string newVesselImoNumber = Console.ReadLine();
            
            Vessel newVesselInList = new()
            {
                Id = counter + 1,
                ImoNumber = newVesselImoNumber
            };
            vessels.Add(newVesselInList);
            Console.WriteLine($"The vessel with imo number {newVesselImoNumber} was saved successfully!" );
        }

        //Method to stamp all the vessels inside the list vessels
        public void ReadVessel()
        {
            if (vessels != null)
            {
                vessels.ForEach(i => Console.WriteLine("{0}\n", i));
            }
            else
            {
                Console.WriteLine("The vessels list is empty");
            }
        }

        public void UpdateVessel() 
        {

        }

        public void DeleteVessel()
        {

        }

        public void SelectActionOnVessel()
        {

        }
    }
}
