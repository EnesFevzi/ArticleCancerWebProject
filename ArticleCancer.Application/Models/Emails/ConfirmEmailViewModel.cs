using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.Models.Emails
{
	public class ConfirmEmailViewModel
	{
		public string Email { get; set; }
		public int ConfirmationCode { get; set; }
	}
}
