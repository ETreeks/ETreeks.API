using ETreeks.Core.Data;
using ETreeks.Core.IRepository;
using ETreeks.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Service
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task<int> CreateTestimonial(Testimonial testimonial)
        {
            return await _testimonialRepository.CreateTestimonial(testimonial);
        }

        public async Task<int> UpdateTestimonial(Testimonial testimonial)
        {
            return await _testimonialRepository.UpdateTestimonial(testimonial);
        }

        public async Task DeleteTestimonial(int testimonialId)
        {
            await _testimonialRepository.DeleteTestimonial(testimonialId);
        }

        public async Task<List<Testimonial>> GetAllTestimonials()
        {
            return await _testimonialRepository.GetAllTestimonials();
        }

        public async Task<Testimonial> GetTestimonialById(int testimonialId)
        {
            return await _testimonialRepository.GetTestimonialById(testimonialId);
        }
    }
}
