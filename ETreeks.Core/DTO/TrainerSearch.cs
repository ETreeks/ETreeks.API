using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.DTO
{
    public class TrainerSearch
    {
        public string? FullName { get; set; }

        public string? courseName { get; set; }
        public string? categoryname { get; set; }

        public DateTime? reservationdate { get; set; }
    }
}
