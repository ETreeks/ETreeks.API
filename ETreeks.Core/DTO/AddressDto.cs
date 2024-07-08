using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.DTO
{
	public class AddresssDto
	{
		public int Id { get; set; }
		public decimal Longitude { get; set; }
		public decimal Latitude { get; set; }
		public string City { get; set; }
		public string Country { get; set; }
	}
}
