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
    public class SaleService : ISaleService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger; 

        public SaleService(IUnitOfWork unitOfWork, ILogger<SaleService> logger)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task? AddSale(Sale sale)
        {
            _unitOfWork.Sales.Add(sale);
            await _unitOfWork.CommitAsync();
        }

        public void DeleteSale(long id)
        {
            var sale = _unitOfWork.Sales.Find(x => x.Id == id);
            if (sale != null)
            {
                _unitOfWork.Sales.Remove(sale);
                _unitOfWork.Save();
            }
        }

        public Sale? GetSale(long id)
        {
            var sale = _unitOfWork.Sales.Get(x => x.Id == id);

            return sale;

        }

        public async Task<IEnumerable<Sale>> GetSales()
        {
            return await _unitOfWork.Sales.GetAllAsync();
        }
    }
}
