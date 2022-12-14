using FluentValidation.Results;
using RecycleCoin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core.Services
{
    public interface ISaleService
    {
        Sale? GetSale(long id);

        Task<IEnumerable<Sale>> GetSales();

        Task<ValidationResult?> AddSale(Sale sale);

        void DeleteSale(long id);

    }
}
