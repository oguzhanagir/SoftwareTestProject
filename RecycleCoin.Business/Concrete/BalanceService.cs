using FluentValidation;
using FluentValidation.Results;
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
    public class BalanceService: IBalanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private int rcConverCarbon { get; set; } = 100000000;

        private readonly IValidator<Balance> _validator;
        public BalanceService(IUnitOfWork unitOfWork, IValidator<Balance> validator)
        {
            _unitOfWork = unitOfWork;
            _validator = validator;
        }

        public decimal? Get(int id )
        {
            var balance = _unitOfWork.Balances.Find(x => x.User!.Id == id);
            var balanceValue = balance?.Value;
            return balanceValue!;
        }

        public async Task<ValidationResult?> Add(string shaAddress,decimal balanceValue)
        {
            var user = _unitOfWork.Users.Find(x => x.ShaAddress == System.Text.Encoding.UTF8.GetBytes(shaAddress));
            var balance = _unitOfWork.Balances.Find(x => x.User!.Id == user!.Id);

            var convertValue = balanceValue / rcConverCarbon;

            balance!.Value = balance.Value + convertValue;
            balance!.User = user;

            var validation = await _validator.ValidateAsync(balance!);

            if (validation.IsValid)
            {
                _unitOfWork.Balances.Add(balance!);
                await _unitOfWork.CommitAsync();
            }

            return validation;

        }

        public void BalanceTransfer(int sender, int receiver, decimal valueCarbon)
        {
            var balanceSender = _unitOfWork.Balances.Find(x => x.User!.Id == sender);
            var balanceReceiver = _unitOfWork.Balances.Find(x => x.User!.Id == receiver);


            //Sender
            var senderUser = _unitOfWork.Users.Find(x => x.Id == sender);
            balanceSender!.User = senderUser;
            balanceSender!.Value = balanceSender.Value - valueCarbon;


            //Receiver
            var receiverUser = _unitOfWork.Users.Find(x => x.Id == receiver);
            balanceReceiver!.User = receiverUser;
            balanceReceiver!.Value = balanceReceiver.Value + valueCarbon;



            _unitOfWork.Balances.Update(balanceSender);
            _unitOfWork.Balances.Update(balanceReceiver);


        }
    }
}
