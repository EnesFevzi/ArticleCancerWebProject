using ArticleCancer.Infrastructure.Services.Abstract;
using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Infrastructure.Services.Concrete
{
	public class SendMailService : ISendMailService
	{
		public Task<bool> SendMail()
		{
			throw new NotImplementedException();
		}

		public Task<bool> SendPasswordChange(string email, string scheme, string host)
		{
			throw new NotImplementedException();
		}
	}
}
