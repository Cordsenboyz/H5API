using H5API.Repositories.Base;

namespace H5API.Models
{
    public class Category : BaseEntity<Guid>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Goods> Goods { get; set; }
        public Store Store {  get; set; }
    }
}
