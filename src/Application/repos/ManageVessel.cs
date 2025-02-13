using Application.entities;
using Application.services;

namespace Application.repos
{
    internal class ManageVessel: IManageVessel
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
            Console.Clear();
        }

        public Vessel VesselByImoNumber(string imoCode)
        {
            return Vessels.Find(v => v.ImoNumber == imoCode);
        }

        public bool checkVesselExist(string imoCode)
        {
            return Vessels.Exists(v => v.ImoNumber == imoCode);
        }

        public bool CheckValueWithoutChars(string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public void BreakConcludeOperation(string errorMessage)
        {
            Console.WriteLine($"{errorMessage}\nPress any key to continue...");
            Console.ReadKey();
            Console.Clear();
        }

        public void ProgrammAddingVessel()
        {
            Console.Write("Insert IMO code:");
            var imoCode = Console.ReadLine();
            imoCode = imoCode.Trim();

            if (CheckValueWithoutChars(imoCode))
            {
                Console.Clear();
                Console.WriteLine("IMO Number can not be empty!");
                BreakConcludeOperation("");
            }
            else
            {
                AddVessel(imoCode);
                ProgrammGetVessels();
                BreakConcludeOperation("");
            }

        }

        public void ProgrammGetVessels()
        {
            Console.WriteLine("----------- List of Vessels -----------");
            foreach (var item in Vessels)
            {
                Console.WriteLine(item);
            }
        }

        public void ProgrammUpdateVessel()
        {
            Console.WriteLine("----------- List of Vessels -----------");
            foreach (var item in Vessels)
            {
                Console.WriteLine($"IMO Number: {item.ImoNumber}");
            }
            Console.WriteLine("\n\nInsert IMO Number of Vessel to modify:");
            var imoCode = Console.ReadLine();
            Console.Clear();

            if (!Vessels.Exists(v => v.ImoNumber == imoCode))
            {
                Console.WriteLine("Vessel not found!!");
                BreakConcludeOperation("");
            } else
            {
                Console.WriteLine($"Insert new IMO Number for vessel {imoCode}");
                var newImoCode = Console.ReadLine();
                Console.Clear();

                if (CheckValueWithoutChars(newImoCode))
                {
                    Console.Clear();
                    Console.WriteLine("IMO Number can not be empty!");
                    BreakConcludeOperation("");
                }
                else if (checkVesselExist(newImoCode))
                {
                    Console.Clear();
                    Console.WriteLine("Vessel is already added!");
                    BreakConcludeOperation("");
                }
                else
                {
                    var vesselFound = VesselByImoNumber(imoCode);
                    vesselFound.ImoNumber = newImoCode;
                    Console.WriteLine($"Vessel with IMO Number ({imoCode}) is changed!!\n");
                    BreakConcludeOperation("");
                }
            }
        }

        public void ProgrammDeleteVessel()
        {
            Console.WriteLine("Insert IMO Number of Vessel to delete:");
            var imoCode = Console.ReadLine();
            Console.Clear();

            if (!checkVesselExist(imoCode))
            {
                Console.WriteLine("Vessel not found!!");
                BreakConcludeOperation("");
            }
            else
            {
                var vesselFound = VesselByImoNumber(imoCode);
                Vessels.Remove(vesselFound);
                Console.WriteLine($"Vessel with IMO Number ({imoCode}) is deleted!!\n");
                BreakConcludeOperation("");
            }
        }
    }
}
