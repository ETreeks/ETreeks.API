using Dapper;
using ETreeks.Core.Data;
using ETreeks.Core.ICommon;
using ETreeks.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbContext _dbContext;

        public PaymentRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> IsValidPayment(string firstName, string lastName, decimal cardNumber, decimal cvv, DateTime expiryDate)
        {
            var param = new DynamicParameters();
            param.Add("firstName", firstName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("lastName", lastName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("cardNumber", cardNumber, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("cvv", cvv, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("expiryDate", expiryDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("isValid", dbType: DbType.Boolean, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("Payment_Package.IsValidPayment", param, commandType: CommandType.StoredProcedure);

            return param.Get<bool>("isValid");
        }

        public async Task<decimal?> GetUserBalance(decimal cardNumber, decimal cvv)
        {
            var param = new DynamicParameters();
            param.Add("cardNumber", cardNumber, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("cvv", cvv, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<decimal?>("Payment_Package.GetUserBalance", param, commandType: CommandType.StoredProcedure);

            return result;
        }

        public async Task ProcessPayment(string firstName, string lastName, decimal cardNumber, decimal cvv, DateTime expiryDate, decimal amount)
        {
            var param = new DynamicParameters();
            param.Add("firstName", firstName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("lastName", lastName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("cardNumber", cardNumber, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("cvv", cvv, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("expiryDate", expiryDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            param.Add("amount", amount, dbType: DbType.Decimal, direction: ParameterDirection.Input);

            await _dbContext.Connection.ExecuteAsync("Payment_Package.ProcessPayment", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<Paymant> CheckPayment(string firstName, string lastName, decimal cardNumber, decimal cvv, DateTime expiryDate)
        {
            var param = new DynamicParameters();
            param.Add("fName", firstName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("lName", lastName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("cardnum", cardNumber, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("cvv", cvv, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            param.Add("expiryD", expiryDate, dbType: DbType.Date, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryFirstOrDefaultAsync<Paymant>("Payment_Package.CheckPayment", param, commandType: CommandType.StoredProcedure);

            return result;
        }
    }
}
