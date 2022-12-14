using RecycleCoin.Core.Models;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<Category>> GetCategories();

        Task<ValidationResult?> AddCategory(Category category);

        void DeleteCategory(long id);

        
    }
}
