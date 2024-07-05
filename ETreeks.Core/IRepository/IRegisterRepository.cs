using ETreeks.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Core.IRepository
{
    public interface IRegisterRepository
    {
        //Guser RegisterStudent(Guser guser);
        Task<int> RegisterStudent(Guser guser);
        Task<int> RegisterTrainer(Guser guser);
    }
}
