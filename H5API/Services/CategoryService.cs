﻿using H5API.Data;
using H5API.Dto.Create;
using H5API.Models;

namespace H5API.Services
{
    public class CategoryService
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> CreateWithRelations(Category category, Guid Id)
        {

            Store updatedStore = await _unitOfWork.Stores.GetWithAllRelations(Id);

            Category categoryInDB = await _unitOfWork.Categories.GetByObject(category);
            if(categoryInDB is not null) 
            { 
                updatedStore.Categories.Add(categoryInDB);
            }
            else
            {
                updatedStore.Categories.Add(category);
            }

            await _unitOfWork.Stores.UpdateAsync(updatedStore);

            return true;
        }
    }
}
