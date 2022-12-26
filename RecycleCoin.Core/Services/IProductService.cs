using FluentValidation.Results;
using RecycleCoin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core.Services
{
    public interface IProductService
    {
        IEnumerable<Product?> GetProductByCategory(int id);

        Task<IEnumerable<Product>> GetProducts();

        Task<ValidationResult?> AddProduct(Product product);

        void UpdateProduct(long id);

        void DeleteProduct(long id);
    }
}
