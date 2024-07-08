using ETreeks.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IRepository
{
	public interface IAboutRepository
	{
		Task<int> CreateAbout(About about);
		Task<int> UpdateAbout(About about);
		Task<int> DeleteAbout(int id);
		Task<List<About>> GetAllAbout();
		Task<About> GetAboutById(int id);
	}
}
