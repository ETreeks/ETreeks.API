using System;
using System.Collections.Generic;

namespace ETreeks.Core.Data
{
    public partial class Category
    {
        public Category()
        {
            Courses = new HashSet<Course>();
        }

        public decimal Id { get; set; }
        public string? Categoryname { get; set; }
        public string? Imagename { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
