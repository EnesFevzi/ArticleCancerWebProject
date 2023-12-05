using ArticleCancer.Application.Interfaces.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Domain.Entities
{
    public class AppUser : IdentityUser<Guid>, IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
		public int? ConfirmCode { get; set; }

		public Guid ImageID { get; set; } = Guid.Parse("01673030-C382-45F8-84DC-A095BF6A7532");
        public Image Image { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<New> News { get; set; }
        public ICollection<ToDo> ToDos { get; set; }

    }
}
