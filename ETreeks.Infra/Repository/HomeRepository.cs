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
    public class HomeRepository : IHomeRepository
    {
        private readonly IDbContext _dbContext;

        public HomeRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> CreateHome(Home home)
        {
            var param = new DynamicParameters();
            param.Add("H_Location", home.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("H_Description", home.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("H_ImageName", home.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("H_Phone", home.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("H_Email", home.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("H_Title1", home.Title1, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("Home_Package.CreateHome", param, commandType: CommandType.StoredProcedure);

            int CHID = param.Get<int>("C_id");
            return CHID;
        }

        public async Task<int> DeleteHome(int id)
        {
            var param = new DynamicParameters();
            param.Add("Home_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);
            var result = await _dbContext.Connection.ExecuteAsync("Home_Package.DeleteHome", param, commandType: CommandType.StoredProcedure);
            int CHID = param.Get<int>("C_id");
            return CHID;
        }

        public async Task<List<Home>> DisplayAllHomes()
        {
            var result = await _dbContext.Connection.QueryAsync<Home>("Home_Package.DisplayAllHomes", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Home> GetHomeById(int id)
        {
            var param = new DynamicParameters();
            param.Add("Home_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Home>("Home_Package.GetHomeById", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<int> UpdateHome(Home home)
        {
            var param = new DynamicParameters();
            param.Add("Home_ID", home.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("H_Location", home.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("H_Description", home.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("H_ImageName", home.Imagename, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("H_Phone", home.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("H_Email", home.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("H_Title1", home.Title1, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = await _dbContext.Connection.ExecuteAsync("Home_Package.UpdateHome", param, commandType: CommandType.StoredProcedure);
            int UHID = param.Get<int>("C_id");
            return UHID;
        }
    }
}
