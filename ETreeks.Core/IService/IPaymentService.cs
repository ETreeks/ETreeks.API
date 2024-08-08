using ETreeks.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IService
{
    public interface IPaymentService
    {
        Task<bool> IsValidPayment(string firstName, string lastName, decimal cardNumber, decimal cvv, DateTime expiryDate);
        Task<decimal?> GetUserBalance(decimal cardNumber, decimal cvv);
        Task ProcessPayment(string firstName, string lastName, decimal cardNumber, decimal cvv, DateTime expiryDate, decimal amount);
        Task<Paymant> CheckPayment(string firstName, string lastName, decimal cardNumber, decimal cvv, DateTime expiryDate);
    }
}
