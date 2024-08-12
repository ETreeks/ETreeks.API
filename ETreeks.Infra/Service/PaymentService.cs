using ETreeks.Core.Data;
using ETreeks.Core.IRepository;
using ETreeks.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Service
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<bool> IsValidPayment(string firstName, string lastName, decimal cardNumber, decimal cvv, DateTime expiryDate)
        {
            return await _paymentRepository.IsValidPayment(firstName, lastName, cardNumber, cvv, expiryDate);
        }

        public async Task<decimal?> GetUserBalance(decimal cardNumber, decimal cvv)
        {
            return await _paymentRepository.GetUserBalance(cardNumber, cvv);
        }

        public async Task ProcessPayment(string firstName, string lastName, decimal cardNumber, decimal cvv, DateTime expiryDate, decimal amount)
        {
            await _paymentRepository.ProcessPayment(firstName, lastName, cardNumber, cvv, expiryDate, amount);
        }

        public async Task<Paymant> CheckPayment(string firstName, string lastName, decimal cardNumber, decimal cvv, DateTime expiryDate)
        {
            return await _paymentRepository.CheckPayment(firstName, lastName, cardNumber, cvv, expiryDate);
        }
    }
}
