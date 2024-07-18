using ETreeks.Core.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IService
{
    public interface IContactService
    {
        Task CreateContact(Contactu contactu);

        Task UpdateContact(Contactu contactu);

        Task DeleteContact(int id);

        Task<List<Contactu>> GetAllContact();


        Task<Contactu> GetContactById(int id);
    }
}
