using ETreeks.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IService
{
    public interface ITestimonialService
    {
        Task<int> CreateTestimonial(Testimonial testimonial);
        Task<int> UpdateTestimonial(Testimonial testimonial);
        Task DeleteTestimonial(int testimonialId);
        Task<List<Testimonial>> GetAllTestimonials();
        Task<Testimonial> GetTestimonialById(int testimonialId);
    }
}
