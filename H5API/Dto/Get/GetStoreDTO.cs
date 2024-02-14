namespace H5API.Dto.Get
{
    public class GetStoreDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<GetCategoryDTO> Categories { get; set; }
    }
}
