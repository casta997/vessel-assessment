using Application.entities;
using Application.services;
using System.Reflection.Metadata;

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
            var maxId = 0;
            foreach (var item in Vessels)
            {
                maxId = (item.Id > maxId) ? item.Id : maxId;
            }
            Vessels.Add(new Vessel(++maxId, imoVessel));
            Console.Clear();
        }

        public Vessel VesselById(int value) => Vessels.Find(v => v.Id == value);

        public bool CheckVesselExistById(int value)
        {
            return Vessels.Exists(v => v.Id == value);
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
                Console.WriteLine($"\nVessel with IMO Number {imoCode} is added correctly!!");
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
            ProgrammGetVessels();
            Console.WriteLine("\n\nInsert Id of the Vessel to update:");
            string inputIdVessel = Console.ReadLine();
            Console.Clear();

            if (int.TryParse(inputIdVessel, out int idVessel) && CheckVesselExistById(idVessel))
            {
                Console.WriteLine($"Insert new IMO Number for vessel with id: {idVessel}");
                var newImoCode = Console.ReadLine();
                Console.Clear();

                var vesselFound = VesselById(idVessel);
                vesselFound.ImoNumber = newImoCode;
                ProgrammGetVessels();
                Console.WriteLine($"\nIMO number of Vessel with id {idVessel} is updated correctly!!");
                BreakConcludeOperation("");
            } else
            {
                BreakConcludeOperation("Vessel not found!!");
            }
        }

        public void ProgrammDeleteVessel()
        {
            ProgrammGetVessels();
            Console.WriteLine("\n\nInsert Id of the Vessel to delete:");
            string inputIdVessel = Console.ReadLine();
            Console.Clear();

            if (int.TryParse(inputIdVessel, out int idVessel) && CheckVesselExistById(idVessel))
            {
                var vesselFound = VesselById(idVessel);
                Vessels.Remove(vesselFound);

                ProgrammGetVessels();
                Console.WriteLine($"\nVessel with id {idVessel} is deleted!!\n");
                BreakConcludeOperation("");
            }
            else
            {
                BreakConcludeOperation("Vessel not found!!");
            }
        }
    }
}
