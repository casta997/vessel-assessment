using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    //Vessel entity 
    public class Vessel
    {
        //Vessel properties
        public int Id { get; set; }
        public string ImoNumber { get; set; }

        //Vessel constructor
        public Vessel(int id, string imoNumber)
        {
            Id = id;
            ImoNumber = imoNumber;
        }

        //Vessel custom string 
        public override string ToString()
        {
            return $"{Id}\t{ImoNumber}";
        }
    }
}