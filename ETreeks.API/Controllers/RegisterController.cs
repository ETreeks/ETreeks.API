using ETreeks.Core.Data;
using ETreeks.Core.IService;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETreeks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRegisterService  _registerService;

        public RegisterController(IRegisterService registerService)
        {
            _registerService = registerService;
        }

        [HttpPost]
        [Route("RegisterStd")]
        public async Task<int> RegisterStudent([FromBody] Guser guser)
        {
            return await _registerService.RegisterStudent(guser);
        }

        [HttpPost]
        [Route("RegisterTrainer")]
        public async Task<int> RegisterTrainer([FromBody] Guser guser)
        {
            return await _registerService.RegisterTrainer(guser);
        }

        //[HttpPost]
        //[Route("UploadImage")]
        //public string UploadImage()
        //{
        //    var file = Request.Form.Files[0];
        //    var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
           
        //    var fullPath = Path.Combine("C:\\Users\\Lenovo\\Desktop\\ETreeks.API\\ETreeks.API\\ETreeks.API\\Images\\", fileName);
        //    using (var stream = new FileStream(fullPath, FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //    }

        //    return fileName;
        //}
        [HttpPost]
        [Route("UploadGImage")]
        public Guser UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;

            var fullPath = Path.Combine("C:\\Users\\Lenovo\\Desktop\\ETreeks_Angular10\\ETreeks\\src\\assets\\Images", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);

            Guser item = new Guser();
                //item.Imagename = file.FileName;
                item.Imagename = fileName;
                return item;
            }
        }


        //[HttpPost]
        //[Route("UploadPDF")]
        //public string UploadPDF()
        //{
        //    var file = Request.Form.Files[0];
        //    var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;

        //    var fullPath = Path.Combine("C:\\Users\\Lenovo\\Desktop\\ETreeks.API\\ETreeks.API\\ETreeks.API\\PDF\\", fileName);
        //    using (var stream = new FileStream(fullPath, FileMode.Create))
        //    {
        //        file.CopyTo(stream);
        //    }

        //    return fileName;
        //}

    }
}
