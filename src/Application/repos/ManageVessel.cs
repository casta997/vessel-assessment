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
            Console.WriteLine($"Vessel {imoVessel} added!");
        }

        public Vessel VesselByImoNumber(string imoCode)
        {
            return Vessels.Find(v => v.ImoNumber == imoCode);
        }

        public bool checkVesselExist(string imoCode)
        {
            return Vessels.Exists(v => v.ImoNumber == imoCode);
        }

        public bool CheckValueImoNumber(string imoNumber)
        {
            if (string.IsNullOrEmpty(imoNumber)) return false;
            return true;
        }

        public void MsgAfterConcludeOperations()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        public void ProgrammAddingVessel()
        {
            Console.Write("Insert IMO code:");
            var imoCode = Console.ReadLine();
            imoCode = imoCode.Trim();

            if (!CheckValueImoNumber(imoCode))
            {
                Console.Clear();
                Console.WriteLine("IMO Number can not be empty!");
                MsgAfterConcludeOperations();
            }
            else if (checkVesselExist(imoCode))
            {
                Console.Clear();
                Console.WriteLine($"Vessel {imoCode} is already added!");
                MsgAfterConcludeOperations();
            }
            else
            {
                AddVessel(imoCode);
                Console.Clear();
                Console.WriteLine($"Vessel {imoCode} is created successfully! \n");
                MsgAfterConcludeOperations();
            }

        }

        public void ProgrammGetVessels()
        {
            Console.WriteLine("----------- List of Vessels -----------");
            foreach (var item in Vessels)
            {
                Console.WriteLine(item);
            }

            MsgAfterConcludeOperations();
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
                MsgAfterConcludeOperations();
            } else
            {
                Console.WriteLine($"Insert new IMO Number for vessel {imoCode}");
                var newImoCode = Console.ReadLine();
                Console.Clear();

                if (!CheckValueImoNumber(newImoCode))
                {
                    Console.Clear();
                    Console.WriteLine("IMO Number can not be empty!");
                    MsgAfterConcludeOperations();
                }
                else if (checkVesselExist(newImoCode))
                {
                    Console.Clear();
                    Console.WriteLine("Vessel is already added!");
                    MsgAfterConcludeOperations();
                }
                else
                {
                    var vesselFound = VesselByImoNumber(imoCode);
                    vesselFound.ImoNumber = newImoCode;
                    Console.WriteLine($"Vessel with IMO Number ({imoCode}) is changed!!\n");
                    MsgAfterConcludeOperations();
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
                MsgAfterConcludeOperations();
            }
            else
            {
                var vesselFound = VesselByImoNumber(imoCode);
                Vessels.Remove(vesselFound);
                Console.WriteLine($"Vessel with IMO Number ({imoCode}) is deleted!!\n");
                MsgAfterConcludeOperations();
            }
        }
    }
}
