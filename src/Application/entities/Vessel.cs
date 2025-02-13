using Application.services;

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
