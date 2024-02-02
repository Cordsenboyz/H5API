namespace H5API.Dto.Create
{
    public class CreateStoreDTO
    {
        public string? Name {  get; set; }
        public CreateCategoryDTO Category { get; set; }
    }
}
