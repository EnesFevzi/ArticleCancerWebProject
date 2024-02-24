using ArticleCancer.Application.AutoMapper.Users;
using ArticleCancer.Application.FluentValidations.Articles;
using ArticleCancer.Infrastructure.Filter.ArticleVisitors;
using ArticleCancer.Infrastructure.Filter.NewVisitors;
using ArticleCancer.Infrastructure.Filter.VideoBlogVisitors;
using ArticleCancer.Infrastructure.Helpers.Images;
using ArticleCancer.Infrastructure.Helpers.Videos;
using ArticleCancer.Infrastructure.Services.Abstract;
using ArticleCancer.Infrastructure.Services.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NewCancer.Infrastructure.Services.Abstract;
using System.Globalization;
using System.Reflection;

namespace ArticleCancer.Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IAboutService, AboutService>();
            services.AddScoped<IAnnouncementService, AnnouncementService>();
            services.AddScoped<IVideoHelper, VideoHelper>();
            services.AddScoped<IArticleService, ArticleService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IDashboardService, DashboardService>();
            services.AddScoped<INewService, NewService>();
            services.AddScoped<IToDoService, ToDoService>();
            services.AddScoped<IVideoBlogService, VideoBlogService>();
            services.AddScoped<ISendMailService, SendMailService>();
            services.AddScoped<IApplicationUserService, ApplicationUserService>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ArticleVisitorFilter>();
            services.AddScoped<VideoBlogVisitorFilter>();
            services.AddScoped<NewVisitorFilter>();


            services.AddAutoMapper(typeof(UserProfile));
			services.AddControllersWithViews()
                .AddFluentValidation(opt =>
                {
                    opt.RegisterValidatorsFromAssemblyContaining<ArticleValidator>();
                    opt.DisableDataAnnotationsValidation = true;
                    opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
                });

            return services;


        }
    }
}
