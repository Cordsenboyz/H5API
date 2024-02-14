using H5API.Models;

namespace H5API.Dto.Create
{
    public class CreateOrderDTO
    {
        public DateTime? OrderDate { get; set; }
        public float? Price { get; set; }
        public List<Goods>? Goods { get; set; }
    }
}
