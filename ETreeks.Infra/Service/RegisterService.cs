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
    public class RegisterService : IRegisterService
    {
        private readonly IRegisterRepository _registerRepository;

        public RegisterService(IRegisterRepository registerRepository)
        {
            _registerRepository = registerRepository;
        }

        public async Task<int> RegisterStudent(Guser guser)
        {
           
           return await _registerRepository.RegisterStudent(guser);
            
        }

        public async Task<int> RegisterTrainer(Guser guser)
        {
           return await _registerRepository.RegisterTrainer(guser);
        }
    }
}
