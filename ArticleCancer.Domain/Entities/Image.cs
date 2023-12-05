using ArticleCancer.Application.Interfaces.Entities;
using ArticleCancer.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Domain.Entities
{
    public class Image : EntityBase
    {
        public Image()
        {
            Users = new HashSet<AppUser>();
            Articles= new HashSet<Article>();
            News = new HashSet<New>();
        }
        public Image(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }

        public Guid ImageID { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }

        public ICollection<Article> Articles { get; set; }
        public ICollection<AppUser> Users { get; set; }
        public ICollection<New> News { get; set; }


    }
}
