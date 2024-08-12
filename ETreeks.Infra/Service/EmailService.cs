using ETreeks.API.Helper;
using ETreeks.Core.ICommon;
using ETreeks.Core.IService;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETreeks.Infra.Service
{
	public class EmailService : IEmailService
	{
		private readonly IDbContext _dbContext;

		private readonly EmailSettings emailSettings;
		public EmailService(IOptions<EmailSettings> options)
		{
			this.emailSettings = options.Value;
		}
		public async Task SendEmailAsync(MailRequest mailRequest)
		{
			var email = new MimeMessage();
			email.Sender = MailboxAddress.Parse(emailSettings.Email);
			email.To.Add(MailboxAddress.Parse(mailRequest.TOEmail));
			email.Subject= mailRequest.Subject;
			var builder = new BodyBuilder();
			builder.HtmlBody = mailRequest.Body;
			email.Body = builder.ToMessageBody();
			using var smtp = new SmtpClient();
			try
			{
				smtp.Connect(emailSettings.Host, emailSettings.Port, SecureSocketOptions.StartTls);
				smtp.Authenticate(emailSettings.Email, emailSettings.Password);
				await smtp.SendAsync(email);
			}
			catch (Exception ex)
			{
				// Handle exceptions, log error, etc.
				throw new InvalidOperationException("Error sending email", ex);
			}
			finally
			{
				smtp.Disconnect(true);
			}
		}
	}
}
