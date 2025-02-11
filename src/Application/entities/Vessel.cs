using Application.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.entities
{
    internal class Vessel: IVessel
    {
        public int Id { get; }
        public string ImoNumber { get; set; }

        public Vessel(string imoNumber) 
        {
            this.ImoNumber = imoNumber;
        }

    }
}
