//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ETreeks.Core.DTO
//{
//	public class ProfileTrainerDTO
//	{
//		public int Id { get; set; }
//		public string Username { get; set; }
//		public string Password { get; set; }
//		public string Fname { get; set; }
//		public string Lname { get; set; }
//		public string Email { get; set; }
//		public string Imagename { get; set; }
//		public string Specialization { get; set; }
//		public string Gender { get; set; }
//		public long Phone { get; set; }
//		public string Bio_Trainer { get; set; }
//		public AddressDto Address { get; set; }
//	}

//	public class Adress
//	{
//		public double Longitude { get; set; }
//		public double Latitude { get; set; }
//		public string City { get; set; }
//		public string Country { get; set; }
//	}
//}


namespace ETreeks.Core.DTO
{
    public class ProfileTrainerDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Email { get; set; }
        public string Imagename { get; set; }
        public string Specialization { get; set; }
        public string gender { get; set; }
        public long Phone { get; set; }
        public string Bio_Trainer { get; set; }
        public AddressDto2 Address { get; set; }
    }

    public class AddressDto2
    {
        public int AddressId { get; set; } // Note the name change to match the splitOn parameter
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }


}
