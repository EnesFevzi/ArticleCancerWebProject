using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Application.DTOs.ApplicationUsers
{
    public class ApplicationUserUpdateDto
    {
        public Guid ApplicationUserID { get; set; }

        [NotMapped]
        public string FirstName { get; set; }
        [NotMapped]
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime LastLoginTime { get; set; }
        public DateTime? LastLogoutTime { get; set; }
        public double? LoginExitDifference { get; set; }
    }
}
