using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class Vessel
    {
        //Creation of the model Vessel, with the properies Id and ImoNumber.
        public int Id { get; set; }
        public string ImoNumber { get; set; }

        public Vessel(int id, string imoNumber)
        {
            Id = id;
            ImoNumber = imoNumber;
        }
    }
}
