using ArticleCancer.Application.Interfaces.Entities;

namespace ArticleCancer.Domain.Entities
{
    public class ArticleVisitor : IEntityBase
    {
        public ArticleVisitor()
        {
        }

        public ArticleVisitor(Guid articleId, int visitorId)
        {
            ArticleID = articleId;
            VisitorID = visitorId;
        }


        public Guid ArticleID { get; set; }
        public Article Article { get; set; }
        public int VisitorID { get; set; }
        public Visitor Visitor { get; set; }
    }
}
