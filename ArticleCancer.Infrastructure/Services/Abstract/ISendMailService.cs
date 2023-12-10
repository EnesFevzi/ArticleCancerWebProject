using ArticleCancer.Application.DTOs.Mails;
using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Services.Abstract
{
	public interface ISendMailService
	{
		Task<bool> SendContactMail(MailRequest mailRequest);
		Task<bool> SendMail();
		Task<bool> SendPasswordChange(string email, string scheme, string host);
	}
}
