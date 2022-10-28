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
        private readonly ILogger _logger;

        public ProductService(IUnitOfWork unitOfWork, ILogger<ProductService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task? AddProduct(Product product)
        {
            _unitOfWork.Products.Add(product);
            await _unitOfWork.CommitAsync();
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
