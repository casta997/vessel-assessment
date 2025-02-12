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

        public void addVessel(string imoVessel) 
        {
            var countVessels = Vessels.Count + 1;
            var vessel = new Vessel(countVessels, imoVessel);
            Vessels.Add(vessel);
            Console.WriteLine("Vessel added!");
            foreach (var item in Vessels)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public Vessel vessel(int id)
        {
            Vessel v = Vessels.Find(v => v.Id == id);
            return v;
        }

        public bool checkImoNumber(string imoNumber)
        {
            if (string.IsNullOrEmpty(imoNumber)) return false;
            return true;
        }

    }
}
