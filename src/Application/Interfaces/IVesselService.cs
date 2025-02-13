using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    //Creation of the IVesselService interface.
    public interface IVesselService
    {
        public void CreateVessel();
        public void ReadVessel();
        public void UpdateVessel();
        public void DeleteVessel();
        public bool SelectActionOnVessel();
    }
}
