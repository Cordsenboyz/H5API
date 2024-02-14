using H5API.Repositories.Base;

namespace H5API.Models
{
    public class Order : BaseEntity<Guid>
    {
        public User? User { get; set; }
        public DateTime? OrderDate { get; set; }
        public float? Price {  get; set; }
        public List<Goods>? Goods { get; set; }
    }
}
