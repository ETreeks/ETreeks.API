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
    public class RegisterRepository :IRegisterRepository
    {
        private readonly IDbContext _dbContext;

        public RegisterRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> RegisterStudent(Guser guser)
        {
            var p = new DynamicParameters();
            p.Add("User_Name", guser.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("G_Password", guser.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("First_Name", guser.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Last_Name", guser.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = _dbContext.Connection.ExecuteAsync("Register_Package.RegisterStudent", p, commandType: CommandType.StoredProcedure);
            //int RSID = p.Get<int>("C_id");
            int RSID = p.Get<int?>("C_id") ?? default(int);

            return RSID;
    
        }

        public async Task<int> RegisterTrainer(Guser guser)
        {
            var p = new DynamicParameters();
            p.Add("User_Name", guser.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("G_Password", guser.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("First_Name", guser.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Last_Name", guser.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("G_certificate", guser.Certificate, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("G_specialization", guser.Specialization, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("C_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            var result = _dbContext.Connection.ExecuteAsync("Register_Package.RegisterTrainer", p, commandType: CommandType.StoredProcedure);
            int RTID = p.Get<int>("C_id");
            return RTID;
        }
    }
}
