using H5API.Repositories.Base;

namespace H5API.Models
{
    public class Goods : BaseEntity<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
