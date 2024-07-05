using Dapper;
using ETreeks.Core.Data;
using ETreeks.Core.DTO;
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
    public class GUsersRepository : IGUsersRepository
    {
        private readonly IDbContext _dbContext;

        public GUsersRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //public async Task<Guser> GetUserById(int id)
        //{
        //    //var param = new DynamicParameters();
        //    //param.Add("User_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
        //    //var result = await _dbContext.Connection.QueryAsync<Guser>("GUsers_Package.GetUserById", param, commandType: CommandType.StoredProcedure);

        //    var result = await _dbContext.Connection.QueryAsync<Address, Guser, Guser>("GUsers_Package.GetStudentById",
        //        (address, guser) => {
        //        guser.Address = address;
        //        return guser;
        //    },
        //   param: new { User_ID = id },
        //   splitOn: "id",
        //   commandType: CommandType.StoredProcedure);

        //    return result.FirstOrDefault();
        //}

        public async Task<StudentInfo> GetStudentById(int id)
        {
            //var param = new DynamicParameters();
            //param.Add("User_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            //var result = await _dbContext.Connection.QueryAsync<Guser>("GUsers_Package.GetUserById", param, commandType: CommandType.StoredProcedure);

            var result = await _dbContext.Connection.QueryAsync<AddressDto, StudentInfo, StudentInfo>("GUsers_Package.GetStudentById",
        (address, guser) =>
        {
            guser.Address = address;
            return guser;
        },
            param: new { User_ID = id },
            splitOn: "id",
            commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public async Task<Guser> GetTrainerById(int id)
        {

            var result = await _dbContext.Connection.QueryAsync<Address, Guser, Guser>("GUsers_Package.GetTrainerById",
                (address, guser) =>
                {
                    guser.Address = address;
                    return guser;
                },
           param: new { User_ID = id },
           splitOn: "id",
           commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
    }
}
