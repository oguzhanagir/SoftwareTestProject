using FluentValidation;
using RecycleCoin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Validation.FluentValidation
{
    public class SaleValidator:AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(customer => customer.PurchaseDate).NotNull().NotEmpty().WithMessage("Satış Tarihi Boş Olamaz");
        }
    }
}
