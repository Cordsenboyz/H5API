namespace H5API.Dto.Create
{
    public class CreateGoodsDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
