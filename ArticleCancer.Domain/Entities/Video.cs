using ArticleCancer.Domain.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArticleCancer.Domain.Entities
{
    public class Video : EntityBase
    {
        public Video()
        {
            VideoBlogs = new HashSet<VideoBlog>();
        }
        public Video(string fileName, string fileType, string createdBy)
        {
            FileName = fileName;
            FileType = fileType;
            CreatedBy = createdBy;
        }

        public Guid VideoID { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }

        public ICollection<VideoBlog> VideoBlogs { get; set; }

    }
}
