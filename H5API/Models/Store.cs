using H5API.Repositories.Base;

namespace H5API.Models
{
    public class Store : BaseEntity<Guid>
    {
        public string? Name { get; set; }
        public List<Category> Categories { get; set; }
    }
}
