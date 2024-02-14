using H5API.Data;
using H5API.Models;

namespace H5API.Services
{
    public class GoodsService
    {
        private readonly UnitOfWork _unitOfWork;

        public GoodsService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateWithRelations(Goods goods, Guid Id)
        {
            Category? category = await _unitOfWork.Categories.GetWithRelationsAsync(Id);
            if(category is null) return false;

            category.Goods.Add(goods);

            return true;
        }
    }
}
