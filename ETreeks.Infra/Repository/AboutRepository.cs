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

	public class AboutRepository : IAboutRepository
	{
		private readonly IDbContext _dbContext;

		public AboutRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<int> CreateAbout(About about)
		{
			var param = new DynamicParameters();
			param.Add("Title1", about.Title1, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("Title2", about.Title2, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("Title3", about.Title3, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("Title4", about.Title4, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("Description", about.Description, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("ImageName1", about.Imagename1, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("ImageName2", about.Imagename2, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("ImageName3", about.Imagename3, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("ImageName4", about.Imagename4, dbType: DbType.String, direction: ParameterDirection.Input);

			var result = await _dbContext.Connection.ExecuteAsync("ABOUT_PACKAGE.CREATE_ABOUT", param, commandType: CommandType.StoredProcedure);
			return result;
		}

		public async Task<int> UpdateAbout(About about)
		{
			var param = new DynamicParameters();
			param.Add("ID", about.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
			param.Add("new_Title1", about.Title1, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_Title2", about.Title2, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_Title3", about.Title3, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_Title4", about.Title4, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_Description", about.Description, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_ImageName1", about.Imagename1, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_ImageName2", about.Imagename2, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_ImageName3", about.Imagename3, dbType: DbType.String, direction: ParameterDirection.Input);
			param.Add("new_ImageName4", about.Imagename4, dbType: DbType.String, direction: ParameterDirection.Input);

			var result = await _dbContext.Connection.ExecuteAsync("ABOUT_PACKAGE.UPDATE_ABOUT", param, commandType: CommandType.StoredProcedure);
			return result;
		}

		public async Task<int> DeleteAbout(int id)
		{
			var param = new DynamicParameters();
			param.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

			var result = await _dbContext.Connection.ExecuteAsync("ABOUT_PACKAGE.DELETE_ABOUT", param, commandType: CommandType.StoredProcedure);
			return result;
		}

		public async Task<List<About>> GetAllAbout()
		{
			var result = await _dbContext.Connection.QueryAsync<About>("ABOUT_PACKAGE.GET_ALL_ABOUT", commandType: CommandType.StoredProcedure);
			return result.ToList();
		}

		public async Task<About> GetAboutById(int id)
		{
			var param = new DynamicParameters();
			param.Add("ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

			var result = await _dbContext.Connection.QueryAsync<About>("ABOUT_PACKAGE.GET_ABOUT_BY_ID", param, commandType: CommandType.StoredProcedure);
			return result.FirstOrDefault();
		}
	}
}
