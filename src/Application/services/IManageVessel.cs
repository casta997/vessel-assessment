using Application.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.services
{
    internal interface IManageVessel
    {
        void ProgrammDeleteVessel();
        void ProgrammUpdateVessel();
        void ProgrammGetVessels();
        void ProgrammAddingVessel();
    }
}
