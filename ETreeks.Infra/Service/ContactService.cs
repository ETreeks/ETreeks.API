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
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task CreateContact(Contactu contactu)
        {
            await _contactRepository.CreateContact(contactu);
        }
  

        public async Task DeleteContact(int id)
        {
            await _contactRepository.DeleteContact(id);
        }

        public async Task<List<Contactu>> GetAllContact()
        {
            return await _contactRepository.GetAllContact();
        }

        public async Task<Contactu> GetContactById(int id)
        {
          return  await _contactRepository.GetContactById(id);
        }

        public async Task UpdateContact(Contactu contactu)
        {
            await _contactRepository.UpdateContact(contactu);
        }
    }
}
