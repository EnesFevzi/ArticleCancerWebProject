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

    }
}
