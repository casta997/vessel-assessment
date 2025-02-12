using Application.entities;
using Application.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Application.entities
{
    public class Vessel: IVessel
    {
        public int Id { get; }
        public string ImoNumber { get; set; }

        public Vessel(int id, string imoNumber)
        {
            Id = id;
            ImoNumber = imoNumber;
        }

        public override string ToString()
        {
            return $"Id: {Id} - ImoNumber: {ImoNumber}";
        }
    }
}
