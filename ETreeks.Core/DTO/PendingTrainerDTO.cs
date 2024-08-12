using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.DTO
{
	public class PendingTrainerDTO
	{
		public decimal Id { get; set; }
		public string Username { get; set; }
		public string Fname { get; set; }
		public string Lname { get; set; }
		public string Email { get; set; }
		public string Specialization { get; set; }
		public decimal Phone { get; set; }
		public string BioTrainer { get; set; }
		public string Registration_Status_Trainer { get; set; }
		public string Imagename { get; set; }
		public string Certificate { get; set; }
	}
}
