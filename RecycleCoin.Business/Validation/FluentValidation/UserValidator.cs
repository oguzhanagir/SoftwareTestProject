﻿using FluentValidation;
using RecycleCoin.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.Business.Validation.FluentValidation
{
    public class UserValidator: AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(customer => customer.FirstName).NotNull().NotEmpty().WithMessage("Ad Alanı Boş Olamaz")
                .Length(1, 50);
            RuleFor(customer => customer.LastName).NotNull().NotEmpty().WithMessage("Soyad Alanı Boş Olamaz")
                .Length(1, 50);
            //RuleFor(customer => customer.Password).NotNull().NotEmpty().WithMessage("Şifre Alanı Boş Olamaz")
              //.Length(8, 50);
            RuleFor(customer => customer.Mail).NotNull().NotEmpty().WithMessage("Mail Alanı Boş Olamaz")
              .Length(10, 50);
        }
    }
}
