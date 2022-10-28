using RecycleCoin.Core.Models;
using RecycleCoin.Core.Repositories;
using RecycleCoin.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Concrete
{
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task? AddCategory(Category category)
        { 
                _unitOfWork.Category.Add(category);
                await _unitOfWork.CommitAsync();
        }

        public void DeleteCategory(long id)
        {
            var category = _unitOfWork.Category.Find(x => x.Id == id);
            if (category != null)
            {
                _unitOfWork.Category.Remove(category);
                _unitOfWork.Save();
            }
        }

        public async Task<IEnumerable<Category>> GetCategories()
        {
            return await _unitOfWork.Category.GetAllAsync();
        }
    }
}
