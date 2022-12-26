using FluentValidation.Results;
using RecycleCoin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Core.Services
{
    public interface IBalanceService
    {
        decimal? Get(int id);
        Task<ValidationResult?> Add(string shaAddress, decimal balanceValue);
        void BalanceTransfer(int sender, int receiver, decimal valueCarbon);
    }
}
