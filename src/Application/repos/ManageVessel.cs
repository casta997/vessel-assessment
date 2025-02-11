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
        public List<Vessel> Vessels;

        public ManageVessel()
        {
            Vessels = new List<Vessel>();
        }

        public void addVessel(Vessel v) 
        {
            var countVessels = Vessels.Count + 1;
            var vessel = new Vessel(countVessels, "");
            Vessels.Add(v);
            Console.WriteLine("Vessel added!");
            Console.WriteLine(Vessels.ToString());
        }

        public Vessel vessel(int id)
        {
            Vessels.Find(v => v.Id == id);
            return Vessels[id];
        }

        
        /*public List<Vessel> getVessels(Vessel v) 
        {
            return Vessels; 
        }
        */

    }
}
