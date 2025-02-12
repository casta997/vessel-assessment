using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Application.Models
{
    /*
     *   Creation of the model Vessel, with the following fields: _ id (int)
     *                                                            _ imoNumber (string)
    */
    public class Vessel
    {
        public int Id { get; set; }
        public string ImoNumber { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, Imo number: {ImoNumber}";
        }
    }
}
