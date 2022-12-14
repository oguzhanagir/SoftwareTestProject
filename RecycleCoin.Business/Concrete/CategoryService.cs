using FluentValidation;
using FluentValidation.Results;
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
        private readonly IValidator<Category> _validator;

        public CategoryService(IUnitOfWork unitOfWork, IValidator<Category> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ValidationResult?> AddCategory(Category category)
        {
            var validation = await _validator.ValidateAsync(category);
            if (validation.IsValid)
            {
                _unitOfWork.Category.Add(category);
                await _unitOfWork.CommitAsync();
            }
        
            return validation;

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
