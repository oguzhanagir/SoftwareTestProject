using FluentValidation;
using RecycleCoin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Validation.FluentValidation
{
    public class BalanceValidator : AbstractValidator<Balance>
    {
        public BalanceValidator()
        {
            RuleFor(x => x.Value).NotNull().NotEmpty().WithMessage("Bakiye Değeri Boş Olamaz");
        }
    }
}
