using FluentValidation;
using FluentValidation.Results;
using Microsoft.Extensions.Logging;
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
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
    
        private readonly IValidator<Product> _validator;
        public ProductService(IUnitOfWork unitOfWork, IValidator<Product> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public async Task<ValidationResult?> AddProduct(Product product)
        {
            var validation = await _validator.ValidateAsync(product);

            if (validation.IsValid)
            {
                _unitOfWork.Products.Add(product);
                await _unitOfWork.CommitAsync();
            }

            return validation;

        }

        public void DeleteProduct(long id)
        {
            var product = _unitOfWork.Products.Find(x => x.Id == id);
            if (product != null)
            {
                _unitOfWork.Products.Remove(product);
                _unitOfWork.Save();
            }
        }

        public Product? GetProduct(long id)
        {
            var products = _unitOfWork.Products.Get(x => x.Id == id);

            return products;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _unitOfWork.Products.GetAllAsync();
        }

        public void UpdateProduct(long id)
        {
            var product = _unitOfWork.Products.Find(x => x.Id == id);
            if (product != null)
            {
                _unitOfWork.Products.Update(product);
                _unitOfWork.Save();
            }
        }
    }
}
