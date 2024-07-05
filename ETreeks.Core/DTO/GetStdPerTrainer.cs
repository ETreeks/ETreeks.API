using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.DTO
{

    public class TrainerWithStudents
    {
        public int TrainerId { get; set; }
        public string TrainerUsername { get; set; }
        public List<StudentDetail> Students { get; set; }
    }
    public class StudentDetail
    {
        public string StudentUsername { get; set; }
        public string StudentEmail { get; set; }
        public string CourseName { get; set; }
        public string Completed { get; set; }
        public string ReservationDate { get; set; }
    }

  


}
