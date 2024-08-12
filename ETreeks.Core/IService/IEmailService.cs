using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETreeks.API.Helper;
namespace ETreeks.Core.IService
{
	public interface IEmailService
	{
		Task SendEmailAsync(MailRequest mailRequest);
	}
}
