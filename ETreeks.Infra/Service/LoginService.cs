using ETreeks.Core.Data;
using ETreeks.Core.IRepository;
using ETreeks.Core.IService;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
      
        public string Guser(Guser guser)
        {
            var result = _loginRepository.Guser(guser);


            if (result == null) { return null; }


            else if (result.Role_Id == 2 && result.Registration_Status_Trainer == "Pending" )
            {
                return "Your registration is pending. Please wait for approval.";
            }

            else
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes
                    ("I hate the programming  I hate programming I hate the programming .... " +
                    "it work ! ...I love a programming"));
                var signCred = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var claims = new List<Claim>
                {
                    new Claim("RoleId" , result.Role_Id.ToString()),
                    new Claim("UserId", result.Id.ToString())
                };
                var tokenOptions = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: signCred);

                var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
                return token;
            }
        }
    }
}
