using FluentValidation;
using RecycleCoin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Validation.FluentValidation
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(customer => customer.Name).NotNull().NotEmpty().WithMessage("Ürün Adı Boş Olamaz")
                .Length(3, 50);
            RuleFor(customer => customer.Quantity).NotNull().NotEmpty().WithMessage("Ürün Adeti Boş Olamaz");

            RuleFor(customer => customer.Point).NotNull().NotEmpty().WithMessage("Ürün Puanı Boş Olamaz");
        }

    }
}
