using ArticleCancer.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ArticleCancer.Persistence.Context
{
    public class AppDbContext:IdentityDbContext<AppUser, AppRole, Guid>
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleVisitor> ArticleVisitors { get; set; }
        public DbSet<Visitor> Visitors { get; set; }
        public DbSet<CancerAbout> CancerAbouts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactInformation> ContactInformations { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<New> News { get; set; }
        public DbSet<NewVisitor> NewVisitors { get; set; }
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<VideoBlog> VideoBlogs { get; set; }
        public DbSet<Video> Videos { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<AnnouncementVisitor> AnnouncementVisitors { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
