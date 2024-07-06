using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.DTO
{
    public class UpdateProfileAdminDto
    {
        public int UserId { get; set; }
        public string NewUsername { get; set; }
        public string NewPassword { get; set; }
        public string NewFname { get; set; }
        public string NewLname { get; set; }
        public string NewEmail { get; set; }
        public string NewImageName { get; set; }
        public string NewGender { get; set; }
        public decimal NewPhone { get; set; }
    }
}
