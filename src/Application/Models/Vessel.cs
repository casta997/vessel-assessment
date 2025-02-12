using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
