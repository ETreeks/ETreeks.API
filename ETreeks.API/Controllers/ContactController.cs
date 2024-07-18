using ETreeks.Core.Data;
using ETreeks.Core.IService;
using ETreeks.Infra.Service;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        [HttpGet]
        public async Task<List<Contactu>> GetAllContact()
        {
            return await _contactService.GetAllContact();
        }

        [HttpGet("GetContactById/{id}")]
        public async Task<Contactu> GetContactById(int id)
        {
            return await _contactService.GetContactById(id);
        }

        [HttpPost]
        public async Task CreateContact([FromBody] Contactu contactu)
        {
             await _contactService.CreateContact(contactu);
        } 

        [HttpPut]
        public async Task UpdateContact(Contactu contactu)
        {
            await _contactService.UpdateContact(contactu);
        }

        [HttpDelete("{id}")] 
        public async Task DeleteContact(int id)
        {
            await _contactService.DeleteContact(id);
        }
    }
}
