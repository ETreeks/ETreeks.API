using ETreeks.Core.Data;
using ETreeks.Core.DTO;
using ETreeks.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        //[HttpPost]
        //public async Task<IActionResult> CreateTestimonial([FromBody] Testimonial testimonial)
        //{
        //    var result = await _testimonialService.CreateTestimonial(testimonial);
        //    return Ok(result);
        //}
        [HttpPost]
        public async Task<IActionResult> CreateTestimonial([FromBody] TestimonialDTO testimonialDto)
        {
            var testimonial = new Testimonial
            {
                Testimonialstext = testimonialDto.Testimonialstext,
                Gusers_Id = testimonialDto.Gusers_Id
            };

            var result = await _testimonialService.CreateTestimonial(testimonial);
            return Ok(result);
        }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateTestimonial(int id, [FromBody] Testimonial testimonial)
        //{
        //    testimonial.Id = id;
        //    var result = await _testimonialService.UpdateTestimonial(testimonial);
        //    return Ok(result);
        //}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTestimonial(int id, [FromBody] TestimonialDTO testimonialDto)
        {
            var testimonial = new Testimonial
            {
                Id = id,
                Testimonialstext = testimonialDto.Testimonialstext,
                Gusers_Id = testimonialDto.Gusers_Id
            };

            var result = await _testimonialService.UpdateTestimonial(testimonial);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task DeleteTestimonial(int id)
        {
             await _testimonialService.DeleteTestimonial(id);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Testimonial>>> GetAllTestimonials()
        {
            var testimonials = await _testimonialService.GetAllTestimonials();
            return Ok(testimonials);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Testimonial>> GetTestimonialById(int id)
        {
            var testimonial = await _testimonialService.GetTestimonialById(id);
            return Ok(testimonial);
        }
    }
}
