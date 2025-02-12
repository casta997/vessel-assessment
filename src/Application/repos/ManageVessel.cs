using Application.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.repos
{
    internal class ManageVessel
    {
        public List<Vessel> Vessels { get; }

        public ManageVessel()
        {
            Vessels = new List<Vessel>();
        }

        public void AddVessel(string imoVessel) 
        {
            var countVessels = Vessels.Count + 1;
            var vessel = new Vessel(countVessels, imoVessel);
            Vessels.Add(vessel);
            Console.WriteLine($"Vessel {imoVessel} added!");
        }

        public Vessel VesselByImoNumber(string imoCode)
        {
            return Vessels.Find(v => v.ImoNumber == imoCode);
        }

        public bool CheckImoNumber(string imoNumber)
        {
            if (string.IsNullOrEmpty(imoNumber)) return false;
            return true;
        }

        public void ProgrammAddingVessel()
        {
            var emptyImoNumber = true;
            while (emptyImoNumber)
            {
                Console.Write("Insert IMO code:");
                var imoCode = Console.ReadLine();
                if (!CheckImoNumber(imoCode))
                {
                    Console.WriteLine("IMO Number can not be empty!");
                } else
                {
                    AddVessel(imoCode);
                    Console.Clear();
                    Console.WriteLine($"Vessel {imoCode} is created successfully! \n");
                    emptyImoNumber = false;
                }
            }

        }

        public void ProgrammGetVessels()
        {
            Console.WriteLine("----------- List of Vessels -----------");
            foreach (var item in Vessels)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
            Console.Clear();
            /*
            Console.Write("Insert id of the interested vessel: ");
            var idVesselInput = int.Parse(Console.ReadLine());
            var vessel = Vessel(idVesselInput);
            Console.WriteLine(
                $@"
Information of the selected vessel:
    {vessel}
"
                );
            */
        }

        public void ProgrammUpdateVessel()
        {
            Console.WriteLine("Insert IMO Number of Vessel to modify:");
            var imoCode = Console.ReadLine();
            Console.Clear();

            if (!Vessels.Exists(v => v.ImoNumber == imoCode))
            {
                Console.WriteLine("Vessel not found!!");
            } else
            {
                Console.WriteLine($"Insert new IMO Number for vessel {imoCode}");
                var newImoCode = Console.ReadLine();
                Console.Clear();

                var vesselFound = VesselByImoNumber(imoCode);
                vesselFound.ImoNumber = newImoCode;
                Console.WriteLine($"Vessel with IMO Number ({imoCode}) is changed!!\n");
                Console.WriteLine("Press any key to continue...");
                Console.ReadLine();
            }
        }

    }
}
