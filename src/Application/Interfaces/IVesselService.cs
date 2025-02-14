using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    //Vessel interface
    public interface IVesselService
    {
        //Methods that will be implemented in the VesselService
        public void CreateVessel();
        public void CreateSomeVessel();
        public void ReadVessel();
        public void UpdateVessel();
        public void DeleteVessel();
        public bool SelectActionOnVessel();
    }
}