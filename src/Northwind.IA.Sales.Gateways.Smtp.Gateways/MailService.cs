using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Northwind.AB.Sales.Backend.BusinessObjects.Interfaces.Common;
using Northwind.IA.Sales.Gateways.Smtp.Gateways.Options;
using System.Net;
using System.Net.Mail;

namespace Northwind.IA.Sales.Gateways.Smtp.Gateways;
internal class MailService(IOptions<SmtpOptions> smtpOptions,
    ILogger<MailService> logger) : IMailService
{
    public async ValueTask SendMailToAdministrator(string subject, string body)
    {
		try
		{
			MailMessage Message = new System.Net.Mail.MailMessage(smtpOptions.Value.SenderEmail,
				smtpOptions.Value.AdministratorEmail);

            Message.Body = body;
			Message.Subject = subject;

			SmtpClient smtpClient = new SmtpClient(
				smtpOptions.Value.SmtpHost,
				smtpOptions.Value.SmtpHostPort)
			{
				Credentials = new NetworkCredential(smtpOptions.Value.SmtpUserName,
				smtpOptions.Value.SmtpPassword),
				EnableSsl = true
			};

			await smtpClient.SendMailAsync(Message);

        }
		catch (Exception ex)
		{
			logger.LogError(ex.Message, ex.Message);
		}
    }
}
