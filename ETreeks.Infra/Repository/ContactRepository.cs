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
using System.Xml.Linq;

namespace ETreeks.Infra.Repository
{
    public class ContactRepository : IContactRepository

    {
        private readonly IDbContext _dbContext;

        public ContactRepository (IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateContact(Contactu contactu)
        {
            var param = new DynamicParameters();
            param.Add("Name", contactu.Name, DbType.String, direction: ParameterDirection.Input);
            param.Add("Message", contactu.Message, DbType.String, direction: ParameterDirection.Input);
            param.Add("Subject", contactu.Subject, DbType.String, direction: ParameterDirection.Input);
            param.Add("Email1", contactu.Email1, DbType.String , direction: ParameterDirection.Input);
            param.Add("Email2", contactu.Email2, DbType.String, direction: ParameterDirection.Input);
            //param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            
            var result = await _dbContext.Connection.ExecuteAsync("CONTACTUS_PKG.CREATE_CONTACT", param, commandType: CommandType.StoredProcedure);
            //int contactId = param.Get<int>("C_id");
            //return contactId;
        }

        public async Task DeleteContact(int id)
        {
            var param = new DynamicParameters();
            param.Add("Contact_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("ContactUS_Pkg.DELETE_CONTACT", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Contactu>> GetAllContact()
        {
            var result = await _dbContext.Connection.QueryAsync<Contactu>("ContactUS_Pkg.GET_ALL_CONTACTS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Contactu> GetContactById(int id)
        {
            var param = new DynamicParameters();
            param.Add("Contact_Id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Contactu>("ContactUS_Pkg.GET_CONTACT_BY_ID", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task UpdateContact(Contactu contactu)
        {
            var param = new DynamicParameters();
            param.Add("Contact_Id", contactu.Id , DbType.Int32 , direction: ParameterDirection.Input);
            param.Add("new_Name", contactu.Name, DbType.String, direction: ParameterDirection.Input);
            param.Add("new_Message", contactu.Message, DbType.String, direction: ParameterDirection.Input);
            param.Add("new_Subject", contactu.Subject, DbType.String, direction: ParameterDirection.Input);
            param.Add("new_Email1", contactu.Email1, DbType.String, direction: ParameterDirection.Input);
            param.Add("new_Email2", contactu.Email2, DbType.String, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.ExecuteAsync("ContactUS_Pkg.UPDATE_CONTACT", param, commandType: CommandType.StoredProcedure);
        }
    }
}
